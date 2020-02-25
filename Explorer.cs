using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace WSPInstaller
{
    class Explorer
    {

        public static void ExplorerRegistrySettings()
        {
            string CompatibilityViewKey = @"Software\Microsoft\Internet Explorer\BrowserEmulation\ClearableListData";
            string PopupKey = @"Software\Microsoft\Internet Explorer\New Windows\Allow";
            string DomainKey = @"Software\Microsoft\Windows\CurrentVersion\Internet Settings\ZoneMap\Domains\";
            string MclarenDomainKey = @"Software\Microsoft\Windows\CurrentVersion\Internet Settings\ZoneMap\Domains\mclaren.org";
            string DomainKeyName = "mclaren.org";
            string PopupKeyValue = "*.mclaren.org";
            string star = "*";
            string UserFilter = "UserFilter";

            var UserFilterData = new byte[] { 0x41, 0x1f, 0x00, 0x00, 0x53, 0x08, 0xad, 0xba, 0x01, 0x00, 0x00, 0x00, 0x34, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x0c, 0x00, 0x00, 0x00, 0x96, 0xa6, 0xd4, 0x45, 0x01, 0xa9, 0xd5, 0x01, 0x01, 0x00, 0x00, 0x00, 0x0b, 0x00, 0x6d, 0x00, 0x63, 0x00, 0x6c, 0x00, 0x61, 0x00, 0x72, 0x00, 0x65, 0x00, 0x6e, 0x00, 0x2e, 0x00, 0x6f, 0x00, 0x72, 0x00, 0x67, 0x00 };
            var PopupKeyValueData = new byte[] { 0x00, 0x00 };
            RegistryKey rk = Registry.Users;

            foreach (string s in ObtainUsers(rk))
            {
                string userKey = $"HKEY_USERS\\{s}\\";
                string trimmedKey = $"{s}\\";
                string DomainMap = trimmedKey + DomainKey + DomainKeyName;
                Console.Write(DomainMap);
                Registry.SetValue(userKey + CompatibilityViewKey, UserFilter, UserFilterData, RegistryValueKind.Binary);
                Registry.SetValue(userKey + PopupKey, PopupKeyValue, PopupKeyValueData, RegistryValueKind.Binary);
                rk.CreateSubKey(DomainMap);
                Registry.SetValue(userKey + MclarenDomainKey, star, 2, RegistryValueKind.DWord);
            }
        }

        private static List<string> ObtainUsers(RegistryKey rkey)
        {
            // Retrieve all the subkeys for the specified key.
            String[] names = rkey.GetSubKeyNames();
            var keys = new List<string>();

            // Print the contents of the array to the console.
            foreach (String s in names)
            {
                if (s.EndsWith("_Classes") || s.StartsWith("S-1-5-18") || s.StartsWith("S-1-5-19") || s.StartsWith("S-1-5-20") || s.StartsWith(".DEFAULT"))
                {
                    continue;
                }
                else
                {
                    keys.Add(s);
                }
            }

            return keys;
        }
    }
}
