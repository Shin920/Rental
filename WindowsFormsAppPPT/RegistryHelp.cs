using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental
{
    public class RegistryHelp
    {
        public static bool WriteRegKey(string KeyString, string KeyName, object KeyValue)
        {
            try
            {
                //서브키를 생성한 후 데이터를 기록한다.
                Registry.CurrentUser.CreateSubKey(KeyString).SetValue(KeyName, KeyValue);
                //조회한 서브키를 닫는다.
                Registry.CurrentUser.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static  object ReadRegKey(string KeyString, string KeyName, object DefaultValue)
        {
            try
            {
                //서브키를 오픈한 후 데이터를 조회한다.
                object ReadRegKey = Registry.CurrentUser.CreateSubKey(KeyString).GetValue(KeyName);
                if (ReadRegKey == null)
                {
                    //서브키가 없다면, 서브키를 생성한 후 데이터를 기록한다.
                    Registry.CurrentUser.CreateSubKey(KeyString).SetValue(KeyName, DefaultValue);
                    ReadRegKey = DefaultValue;
                }
                //조회한 서브키를 닫는다.
                Registry.CurrentUser.Close();
                return ReadRegKey;
            }
            catch
            {
                return DefaultValue;
            }
        }
    }
}
