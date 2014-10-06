using com.shephertz.app42.gaming.multiplayer.client.command;
using com.shephertz.app42.gaming.multiplayer.client.listener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace AppWarp_WinRTTestSample
{
   public class LobbyListener:LobbyRequestListener
    {
        TextBlock tblmessage;
        public LobbyListener(TextBlock result)
        {
            tblmessage = result;
        }

        public void onJoinLobbyDone(com.shephertz.app42.gaming.multiplayer.client.events.LobbyEvent eventObj)
        {
            if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
            {
                WriteOnUI("onJoinLobbyDone " + eventObj.getInfo().getName());
            }
            else
            {
                WriteOnUI("onJoinLobbyDone Failed ");
            }
        }

        public void onLeaveLobbyDone(com.shephertz.app42.gaming.multiplayer.client.events.LobbyEvent eventObj)
        {
            if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
            {
                WriteOnUI("onLeaveLobbyDone " + eventObj.getInfo().getName());
            }
            else
            {
                WriteOnUI("onLeaveLobbyDone Failed ");
            }
        }

        public void onSubscribeLobbyDone(com.shephertz.app42.gaming.multiplayer.client.events.LobbyEvent eventObj)
        {
            if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
            {
                WriteOnUI("onSubscribeLobbyDone " + eventObj.getInfo().getName());
            }
            else
            {
                WriteOnUI("onSubscribeLobbyDone Failed ");
            }
        }

        public void onUnSubscribeLobbyDone(com.shephertz.app42.gaming.multiplayer.client.events.LobbyEvent eventObj)
        {
            if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
            {
                WriteOnUI("onUnSubscribeLobbyDone " + eventObj.getInfo().getName());
            }
            else
            {
                WriteOnUI("onUnSubscribeLobbyDone Failed ");
            }
        }

        public void onGetLiveLobbyInfoDone(com.shephertz.app42.gaming.multiplayer.client.events.LiveRoomInfoEvent eventObj)
        {
            if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
            {
                WriteOnUI("onGetLiveLobbyInfoDone " + eventObj.getData().getName());
            }
            else
            {
                WriteOnUI("onGetLiveLobbyInfoDone Failed ");
            }
        }

        private void WriteOnUI(String message)
        {
            UIDispatcher.Execute(delegate()
            {
                tblmessage.Text =tblmessage.Text+"\n"+ message;
            });
        }
    }
}
