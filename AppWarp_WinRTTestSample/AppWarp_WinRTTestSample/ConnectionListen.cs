using com.shephertz.app42.gaming.multiplayer.client;
using com.shephertz.app42.gaming.multiplayer.client.command;
using com.shephertz.app42.gaming.multiplayer.client.events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace AppWarp_WinRTTestSample
{
    public class ConnectionListen : com.shephertz.app42.gaming.multiplayer.client.listener.ConnectionRequestListener
    {
        private MainPage _page;
        TextBlock tblmessage;
        private int _recoverCounts;
        public ConnectionListen(TextBlock result)
        {
            tblmessage = result;
        }

        public void onConnectDone(ConnectEvent eventObj)
        {
            Debug.WriteLine("Connect Done: " + eventObj.getResult());
            String subMessage = "";
            switch (eventObj.getResult())
            {
                case WarpResponseResultCode.AUTH_ERROR:
                    if (eventObj.getReasonCode() == WarpReasonCode.WAITING_FOR_PAUSED_USER)
                    {
                        Debug.WriteLine("Connection state : " + WarpClient.GetInstance().GetConnectionState());
                        subMessage = "Auth Error Waiting for Paused User";

                        //int sessionID = (int)DBManager.getDBData("SessionID");
                        //Debug.WriteLine("Auth Error for paused user " + sessionID);
                        //WarpClient.GetInstance().RecoverConnectionWithSessionId(sessionID, "rahul");
                         
                    }
                    else
                    {
                        Debug.WriteLine("Auth Error session id expired");
                    }
                    break;
                case WarpResponseResultCode.SUCCESS:
                     subMessage = "success";
                     WarpClient.GetInstance().Disconnect();
                    //DBManager.saveData("SessionID", WarpClient.GetInstance().GetSessionId());
                    // _page.showResult("connection success");
                    break;
                case WarpResponseResultCode.CONNECTION_ERROR_RECOVERABLE:
                     subMessage = "connection error recoverable";
                    // _page.showResult("connection recoverable " + eventObj.getResult());
                    // Deployment.Current.Dispatcher.BeginInvoke(delegate() {   RecoverConnection(); });
                    break;
                case WarpResponseResultCode.SUCCESS_RECOVERED:
                    subMessage = "connection success recoverd";
                    break;
                default:

                    break;
            }
            UIDispatcher.Execute(delegate() {
                if (tblmessage.Text.Length > 200)
                {
                    tblmessage.Text = "";
                }
                tblmessage.Text = tblmessage.Text + "\nConnect Done: " + subMessage; 
            });
        }
        /*
        public void RecoverConnection()
        {
            if (_recoverCounts == 0)
            {
                timer = new DispatcherTimer();
                timer.Tick += timer_Tick;
                timer.Interval = new TimeSpan(0, 0, 0, 10);
                timer.Start();
            }

        }
        public void ConnectionRecovered()
        {
            timer.Stop();
            _recoverCounts = 0;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            _recoverCounts++;
            if (_recoverCounts <= 6)
            {
                WarpClient.GetInstance().RecoverConnection();
            }
            else
            {
                (sender as DispatcherTimer).Stop();
                _page.showResult("connection failed");
            }
        }*/
        public void onDisconnectDone(ConnectEvent eventObj)
        {
                Debug.WriteLine("Disconnect Done: " + eventObj.getResult());
                UIDispatcher.Execute(delegate()
                {
                    try
                    {
                    if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
                    {
                        if (tblmessage.Text.Length > 200)
                        {
                            tblmessage.Text = "";
                        }
                        tblmessage.Text = tblmessage.Text + "\ndisconnect done success";
                        //Task.Delay(1000);
                        WarpClient.GetInstance().Connect("kanak");
                    }
                    else
                    {
                        tblmessage.Text = tblmessage.Text + "\ndisconnect done failed";
                    }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.StackTrace);
                    }
                });

        }

        public void onInitUDPDone(byte resultCode)
        {
            UIDispatcher.Execute(delegate()
            {
                if (resultCode == WarpResponseResultCode.SUCCESS)
                {
                    tblmessage.Text =tblmessage.Text+ "\ndisconnect done success";
                }
                else
                {
                    tblmessage.Text = tblmessage.Text+"\ndisconnect done failed";
                }

            });
        }


        public void onLog(string msg)
        {
            throw new NotImplementedException();
        }
    }
}
