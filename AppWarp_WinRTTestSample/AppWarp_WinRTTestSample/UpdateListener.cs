using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace AppWarp_WinRTTestSample
{
    public class UpdateListener : com.shephertz.app42.gaming.multiplayer.client.listener.UpdateRequestListener
    {
        TextBlock tblmessage;
        public UpdateListener(TextBlock result)
        {
            tblmessage = result;
        }
        public void onSendUpdateDone(byte result)
        {
            UIDispatcher.Execute(delegate() { tblmessage.Text = tblmessage.Text+"\non Send Update Done: " + result; });
        }

        public void onSendPrivateUpdateDone(byte result)
        {
            UIDispatcher.Execute(delegate() { tblmessage.Text = tblmessage.Text + "\non Send Private Update Done: " + result; });
        }
    }
}
