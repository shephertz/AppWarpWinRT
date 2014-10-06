using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Windows.Storage;
using Windows.Storage.Streams;

namespace AppWarp_WinRTTestSample
{
    public class DBManager
    {
        private static DBManager dbManager;
        private static String DB_App42Photos = "App42PhotosList";

        private static object databaseLocker = new object();
        private static StorageFolder sdCard = null, externalDevices = null;
        private static StorageFolder appFolder = null;
        private static StorageFolder serviceFolder = null;
        private static StorageFolder userFolder = null;
        private static bool databaseflag = true;
        private object locker = new object();
        private DBManager()
        {

        }

        public static DBManager getInstance()
        {
            if (dbManager == null)
            {
                dbManager = new DBManager();
            }
            return dbManager;
        }

        public static void saveData(String dbName, Object data)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            if (localSettings.Values.ContainsKey(dbName))
            {
                localSettings.Values[dbName] = data;
            }
            else
            {
                localSettings.Values.Add(dbName, data);
            }
        }

        public static object getDBData(String dbName)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            try
            {
                return localSettings.Values[dbName];
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Boolean isDBAvailable(String dbName)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            return localSettings.Values.ContainsKey(dbName);
        }

        public static void cleanData(String dbName)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values.Remove(dbName);
        }
    }
}
