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
   public class TurnRoomListener:TurnBasedRoomListener
    {
        TextBlock tblmessage;
        public TurnRoomListener(TextBlock result)
        {
            tblmessage = result;
        }

        public void onSendMoveDone(byte result)
        {
            if (result == WarpResponseResultCode.SUCCESS)
            {
                WriteOnUI("onSendMoveDone Success");
            }
            else
            {
                WriteOnUI("onSendMoveDone Failed ");
            }
        }

        public void onStartGameDone(byte result)
        {
            if (result == WarpResponseResultCode.SUCCESS)
            {
                WriteOnUI("onStartGameDone Success");
            }
            else
            {
                WriteOnUI("onStartGameDone Failed ");
            }
        }

        public void onStopGameDone(byte result)
        {
            if (result == WarpResponseResultCode.SUCCESS)
            {
                WriteOnUI("onStopGameDone Success");
            }
            else
            {
                WriteOnUI("onStopGameDone Failed ");
            }
        }

        public void onSetNextTurnDone(byte result)
        {
            if (result == WarpResponseResultCode.SUCCESS)
            {
                WriteOnUI("onSetNextTurnDone Success");
            }
            else
            {
                WriteOnUI("onSetNextTurnDone Failed ");
            }
        }

        public void onGetMoveHistoryDone(byte result, com.shephertz.app42.gaming.multiplayer.client.events.MoveEvent[] moves)
        {
            WriteOnUI("onGetMoveHistoryDone " + result);
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
