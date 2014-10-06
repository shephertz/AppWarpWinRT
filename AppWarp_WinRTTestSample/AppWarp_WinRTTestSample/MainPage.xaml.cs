using com.shephertz.app42.gaming.multiplayer.client;
using Platformer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AppWarp_WinRTTestSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //ServiceAPI sp;
        String CloudApiKey = "", SecretApiKey = "";
        public MainPage()
        {
            UIDispatcher.Initialize();
            this.InitializeComponent();
             //MasterClient.initialize("192.168.1.78", 12349);
             //WarpClient.initialize("0a338a1f-4521-4acf-9", "192.168.1.17");
             WarpClient.initialize(CloudApiKey, SecretApiKey);
             WarpClient.GetInstance().AddConnectionRequestListener(new ConnectionListen(tblResponse));
             WarpClient.GetInstance().AddNotificationListener(new NotificationListener(tblNotification));
             WarpClient.GetInstance().AddZoneRequestListener(new ZoneListener(tblResponse));
             WarpClient.GetInstance().AddRoomRequestListener(new RoomListener(tblResponse));
             WarpClient.GetInstance().AddUpdateRequestListener(new UpdateListener(tblResponse));
             WarpClient.GetInstance().AddLobbyRequestListener(new LobbyListener(tblResponse));
             WarpClient.GetInstance().AddTurnBasedRoomRequestListener(new TurnRoomListener(tblResponse));
             //MasterClient.GetInstance().AddMasterRequestListener(new MasterListener(tblMessage));
        }

        private void btnJoinRoom_Click(object sender, RoutedEventArgs e)
        {
            WarpClient.GetInstance().JoinRoom(tbxRoomId.Text);
        }

        private void btnGetRoomInfo_Click(object sender, RoutedEventArgs e)
        {
            WarpClient.GetInstance().GetLiveRoomInfo(tbxRoomId.Text);
        }

        private void btnSubscribeRoom_Click(object sender, RoutedEventArgs e)
        {
            WarpClient.GetInstance().SubscribeRoom(tbxRoomId.Text);
        }

        private void btnLeaveRoom_Click(object sender, RoutedEventArgs e)
        {
            WarpClient.GetInstance().LeaveRoom(tbxRoomId.Text);
        }

        private void btnUnsubscribeRom_Click(object sender, RoutedEventArgs e)
        {
            WarpClient.GetInstance().UnsubscribeRoom(tbxRoomId.Text);
        }

        private void btnSubLobby_Click(object sender, RoutedEventArgs e)
        {
            WarpClient.GetInstance().SubscribeLobby();
        }

        private void btnLobbyInfo_Click(object sender, RoutedEventArgs e)
        {
            WarpClient.GetInstance().GetLiveLobbyInfo();
        }

        private void btnJoinLobby_Click(object sender, RoutedEventArgs e)
        {
            WarpClient.GetInstance().JoinLobby();
        }

        private void btnLeaveLobby_Click(object sender, RoutedEventArgs e)
        {
            WarpClient.GetInstance().LeaveLobby();
        }

        private void btnGetOnlineUsers_Click(object sender, RoutedEventArgs e)
        {
            WarpClient.GetInstance().GetOnlineUsers();
        }

        private void btnUpdateProperty_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add(tbxPropertyName.Text, tbxPropertyValue.Text);
            List<String> removeList = new List<string>();
            removeList.Add(tbxRemoveProperty.Text);
            WarpClient.GetInstance().UpdateRoomProperties(tbxRoomId1.Text, properties, removeList);
        }

        private void btnLockProperty_Click(object sender, RoutedEventArgs e)
        {
             Dictionary<string, object> properties = new Dictionary<string, object>();
             properties.Add(tbxPropertyName.Text, tbxPropertyValue.Text);
             WarpClient.GetInstance().LockProperties(properties);
        }

        private void btnUnlockProperty_Click(object sender, RoutedEventArgs e)
        {
            List<String> unlockProperties = new List<string>();
            unlockProperties.Add(tbxRemoveProperty.Text);
            WarpClient.GetInstance().UnlockProperties(unlockProperties);
        }

        private void btnSendUpdate_Click(object sender, RoutedEventArgs e)
        {
            WarpClient.GetInstance().SendUpdatePeers(Encoding.UTF8.GetBytes(tbxChatMessage.Text));
        }

        private void btnSendChat_Click(object sender, RoutedEventArgs e)
        {
            WarpClient.GetInstance().SendChat(tbxChatMessage.Text);
        }

        private void btnPrivateUpdate_Click(object sender, RoutedEventArgs e)
        {
            int count = Convert.ToInt32(tbxMessageCount.Text);
            for (int i = 0; i < count; i++)
                WarpClient.GetInstance().sendPrivateUpdate(tbxRemoteUserName.Text,Encoding.UTF8.GetBytes(tbxChatMessage.Text));
        }

        private void btnPrivateChat_Click(object sender, RoutedEventArgs e)
        {
            int count = Convert.ToInt32(tbxMessageCount.Text);
            for (int i = 0; i < count;i++ )
                WarpClient.GetInstance().sendPrivateChat(tbxRemoteUserName.Text, tbxChatMessage.Text);
        }

        private void btnStartGame_Click(object sender, RoutedEventArgs e)
        {
            WarpClient.GetInstance().startGame();
        }

        private void btnStopGame_Click(object sender, RoutedEventArgs e)
        {
            WarpClient.GetInstance().stopGame();
        }

        private void btnCreateRoom_Click(object sender, RoutedEventArgs e)
        {
            WarpClient.GetInstance().CreateRoom(tbxRoomName.Text,tbxRoomName.Text, Convert.ToInt32(tbxUserCount.Text), null);
        }

        private void btnCreateTurnRoom_Click(object sender, RoutedEventArgs e)
        {
            WarpClient.GetInstance().CreateTurnRoom(tbxRoomName.Text, tbxRoomName.Text, Convert.ToInt32(tbxUserCount.Text), null,30);
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            WarpClient.GetInstance().Connect(tbxUsername.Text);
        }

        private void btnDisconnect_Click(object sender, RoutedEventArgs e)
        {
            WarpClient.GetInstance().Disconnect();
        }

        private void btnInitUdp_Click(object sender, RoutedEventArgs e)
        {
            WarpClient.GetInstance().initUDP();
        }

        private void btnSetNextTurn_Click(object sender, RoutedEventArgs e)
        {
            //WarpClient.GetInstance().SetNextTurn(tbxSetNextTurn.Text);
        }

        private void btnGetMoveHistory_Click(object sender, RoutedEventArgs e)
        {
            WarpClient.GetInstance().getMoveHistory();
        }

        private void btnGetAllRooms_Click(object sender, RoutedEventArgs e)
        {
            WarpClient.GetInstance().GetAllRooms();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tblNotification.Text = "Notifications :";
            tblResponse.Text = "Response :";
        }
    }
    /*
    public class callback : App42Callback
    {
        TextBlock tblmessage;
        public callback(TextBlock tbl)
        {
            this.tblmessage = tbl;
        }
        public void OnException(App42Exception exception)
        {
            UIDispatcher.Execute(delegate() { tblmessage.Text = "Exception :" + exception.GetMessage(); });
        }

        public void OnSuccess(object response)
        {
            UIDispatcher.Execute(delegate() { tblmessage.Text = "Success :" + response; });
          
        }
    }*/
}
