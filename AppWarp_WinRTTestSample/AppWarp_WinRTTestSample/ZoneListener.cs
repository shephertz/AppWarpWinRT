using com.shephertz.app42.gaming.multiplayer.client.command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace AppWarp_WinRTTestSample
{
   public class ZoneListener:com.shephertz.app42.gaming.multiplayer.client.listener.ZoneRequestListener
    {
        TextBlock tblmessage;
        public ZoneListener(TextBlock result)
        {
            tblmessage = result;
        }

        public void onDeleteRoomDone(com.shephertz.app42.gaming.multiplayer.client.events.RoomEvent eventObj)
        {
            if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
            {
                WriteOnUI("onDeleteRoomDone " + eventObj.getData().getId());
            }
            else
            {
                WriteOnUI("onDeleteRoomDone Failed ");
            }
        }

        public void onGetAllRoomsDone(com.shephertz.app42.gaming.multiplayer.client.events.AllRoomsEvent eventObj)
        {
            if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
            {
                string[] roomids = eventObj.getRoomIds();
                if (roomids != null)
                {
                    string roomidlist = "";
                    for (int i = 0; i < roomids.Length; i++)
                    {
                        roomidlist = roomidlist + "\n" + roomids[i];
                    }
                    WriteOnUI("Get All Rooms Done room ids:\n" + roomidlist);
                }
                else 
                {
                    WriteOnUI("No rooms available.");
                }
            }
            else
            {
                WriteOnUI("Get All Rooms Done Failed ");
            }
        }

        public void onCreateRoomDone(com.shephertz.app42.gaming.multiplayer.client.events.RoomEvent eventObj)
        {
            if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
            {
                WriteOnUI("Room Created " + eventObj.getData().getId());
            }
            else
            {
                WriteOnUI("Room Creation Failed " + eventObj.getResult());
            }
        }

        public void onGetOnlineUsersDone(com.shephertz.app42.gaming.multiplayer.client.events.AllUsersEvent eventObj)
        {
            if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
            {
                string[] usernames=eventObj.getUserNames();
                string users="";
                for(int i=0;i<usernames.Length;i++)
                {
                   users=users+"\n"+usernames[i];
                }
                WriteOnUI("GetOnlineUsers Done users:\n" + users);
            }
            else
            {
                WriteOnUI("GetOnlineUsers Failed ");
            }
        }

        public void onGetLiveUserInfoDone(com.shephertz.app42.gaming.multiplayer.client.events.LiveUserInfoEvent eventObj)
        {
            if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
            {
                WriteOnUI("GetLiveUserInfo Done room Id: " + eventObj.getLocationId());
            }
            else
            {
                WriteOnUI("GetLiveUserInfo Failed ");
            }
        }

        public void onSetCustomUserDataDone(com.shephertz.app42.gaming.multiplayer.client.events.LiveUserInfoEvent eventObj)
        {
            if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
            {
                WriteOnUI("GetLiveUserInfo Done room Id: " + eventObj.getLocationId());
            }
            else
            {
                WriteOnUI("GetLiveUserInfo Failed ");
            }
        }

        public void onGetMatchedRoomsDone(com.shephertz.app42.gaming.multiplayer.client.events.MatchedRoomsEvent matchedRoomsEvent)
        {
            if (matchedRoomsEvent.getResult() == WarpResponseResultCode.SUCCESS)
            {
                WriteOnUI("onGetMatchedRoomsDone Done room Id: " + matchedRoomsEvent.getRoomsData());
            }
            else
            {
                WriteOnUI("onGetMatchedRoomsDone Failed ");
            }
        }

        private void WriteOnUI(String message)
        {
            UIDispatcher.Execute(delegate()
            {
                if (tblmessage.Text.Length > 200)
                {
                    tblmessage.Text = "";
                }
                tblmessage.Text = tblmessage.Text + "\n" + message;
            });
        }

    }
}
