using com.shephertz.app42.gaming.multiplayer.client.command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace AppWarp_WinRTTestSample
{
    public class NotificationListener:com.shephertz.app42.gaming.multiplayer.client.listener.NotifyListener
    {
        TextBlock tblmessage;
        public NotificationListener(TextBlock result)
        {
            tblmessage = result;
        }
        public void onRoomCreated(com.shephertz.app42.gaming.multiplayer.client.events.RoomData eventObj)
        {
            UIDispatcher.Execute(delegate()
            {
                tblmessage.Text = tblmessage.Text + "\nonRoomCreated Name " + eventObj.getName() + " Id " + eventObj.getId() + " MaxUsers " + eventObj.getMaxUsers();
            });
        }

        public void onRoomDestroyed(com.shephertz.app42.gaming.multiplayer.client.events.RoomData eventObj)
        {
            UIDispatcher.Execute(delegate()
            {
                tblmessage.Text = tblmessage.Text + "\nonRoomDestroyed Name " + eventObj.getName() + " Id " + eventObj.getId() + " MaxUsers " + eventObj.getMaxUsers();
            });
        }

        public void onUserLeftRoom(com.shephertz.app42.gaming.multiplayer.client.events.RoomData eventObj, string username)
        {
            UIDispatcher.Execute(delegate()
            {
                tblmessage.Text = tblmessage.Text + "\nonUserLeftRoom Name " + eventObj.getName() + " Id " + eventObj.getId() + " MaxUsers " + eventObj.getMaxUsers() + " username " + username;
            });
        }

        public void onUserJoinedRoom(com.shephertz.app42.gaming.multiplayer.client.events.RoomData eventObj, string username)
        {
            UIDispatcher.Execute(delegate()
            {
                tblmessage.Text = tblmessage.Text + "\nonUserJoinedRoom Name " + eventObj.getName() + " Id " + eventObj.getId() + " MaxUsers " + eventObj.getMaxUsers() + " username " + username;
            });
        }

        public void onUserLeftLobby(com.shephertz.app42.gaming.multiplayer.client.events.LobbyData eventObj, string username)
        {
            UIDispatcher.Execute(delegate()
            {
                tblmessage.Text = tblmessage.Text+"\nonUserLeftLobby Name " + eventObj.getName() + " Id " + eventObj.getId() + " MaxUsers " + eventObj.getMaxUsers() + " username " + username;
            });
        }

        public void onUserJoinedLobby(com.shephertz.app42.gaming.multiplayer.client.events.LobbyData eventObj, string username)
        {
            UIDispatcher.Execute(delegate()
            {
                tblmessage.Text = tblmessage.Text + "\nonUserJoinedLobby Name " + eventObj.getName() + " Id " + eventObj.getId() + " MaxUsers " + eventObj.getMaxUsers() + " username " + username;
            });
        }

        public void onChatReceived(com.shephertz.app42.gaming.multiplayer.client.events.ChatEvent eventObj)
        {
            UIDispatcher.Execute(delegate() { tblmessage.Text = tblmessage.Text+"\n"+eventObj.getSender() + " sent " + eventObj.getMessage(); });
        }

        public void onUpdatePeersReceived(com.shephertz.app42.gaming.multiplayer.client.events.UpdateEvent eventObj)
        {
            UIDispatcher.Execute(delegate()
            {
                tblmessage.Text = tblmessage.Text + "\nonUpdatePeersReceived " + Encoding.UTF8.GetString(eventObj.getUpdate(), 0, eventObj.getUpdate().Count()) + " fromudp " + eventObj.getIsUdp();
            });
        }

        public void onUserChangeRoomProperty(com.shephertz.app42.gaming.multiplayer.client.events.RoomData roomData, string sender, Dictionary<string, object> properties, Dictionary<string, string> lockedPropertiesTable)
        {
            UIDispatcher.Execute(delegate()
            {
                tblmessage.Text = tblmessage.Text + "\nonUserChangeRoomProperty : sender" + roomData.getName() + " sender " + sender;
            });
        }

        public void onPrivateChatReceived(string sender, string message)
        {
            UIDispatcher.Execute(delegate() { tblmessage.Text = tblmessage.Text + "\nonPrivateChatReceived :" + sender + " sent " + message; });
        }

        public void onMoveCompleted(com.shephertz.app42.gaming.multiplayer.client.events.MoveEvent moveEvent)
        {
            UIDispatcher.Execute(delegate()
            {
                tblmessage.Text = tblmessage.Text + "\nonMoveCompleted : sender" + moveEvent.getSender() + " Next Turn " + moveEvent.getNextTurn();
            });
        }

        public void onUserPaused(string locid, bool isLobby, string username)
        {
           UIDispatcher.Execute(delegate()
           {
               tblmessage.Text = tblmessage.Text + "\nonUserPaused " + locid + " username: " + username + " isLobby " + isLobby;
           });
        }

        public void onUserResumed(string locid, bool isLobby, string username)
        {
            UIDispatcher.Execute(delegate()
          {
              tblmessage.Text = tblmessage.Text + "\nonUserResumed " + locid + " username: " + username + " isLobby " + isLobby;
          });
        }

        public void onGameStarted(string sender, string roomId, string nextTurn)
        {
           UIDispatcher.Execute(delegate()
           {
               tblmessage.Text = tblmessage.Text + "\nonGameStarted Sender" + sender + " Room Id: " + roomId + " Next Turn " + nextTurn;
           });
        }

        public void onGameStopped(string sender, string roomId)
        {
            UIDispatcher.Execute(delegate()
            {
                tblmessage.Text = tblmessage.Text + "\nonGameStopped sender" + sender + " RoomId: " + roomId;
            });
        }

        public void onPrivateUpdateReceived(string sender, byte[] update, bool fromUdp)
        {
            UIDispatcher.Execute(delegate() { tblmessage.Text =tblmessage.Text+"\n"+Encoding.UTF8.GetString(update, 0, update.Length);});
        }


        public void onNextTurnRequest(string lastTurn)
        {
            UIDispatcher.Execute(delegate() { tblmessage.Text = tblmessage.Text + "\nonNextTurnRequest lastturn" + lastTurn; });
        }
    }
}
