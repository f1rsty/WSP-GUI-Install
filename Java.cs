using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace WSPInstaller
{
    class Java
    {

        public static void javaInstall(string javaVersion)
        {

            string args = null;

            Process proc = new Process();

            if (javaVersion == "jre-7u45-windows-i586.exe")
            {
                args = "/s INSTALL_SILENT=1 STATIC=0 AUTOUPDATECHECK=0 AUTO_UPDATE=0 WEB_JAVA=0 WEB_JAVA_SECURITY_LEVEL=M WEB_ANALYTICS=0 EULA=0 REBOOT=0";
            }
                
            else
            {
                args = "/s INSTALL_SILENT=1 AUTO_UPDATE=0 REBOOT=0";
            }
                

            try
            {
                proc.StartInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + "WSP" + "\\" + javaVersion;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.UseShellExecute = true;
                proc.StartInfo.Arguments = args;
                proc.Start();
                proc.WaitForExit();
                LogWriter.WriteLog($"Successfully installed Java Version {javaVersion}");
            }
            catch (System.Exception)
            {
                LogWriter.WriteLog($"ERROR: Unable to install Java Version {javaVersion}");
                proc.Dispose();
            }

        }

        public static void SetJavaRegistrySettings(string javaVersion)
        {
            String JavaPlugin = null;


            if (javaVersion == "jre-7u45-windows-i586.exe")
            {
                JavaPlugin = "HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\JavaSoft\\Java Plug-in\\10.45.2";
                LogWriter.WriteLog($"Java Plugin Registry Path set to {JavaPlugin}");
            }
            else
            {
                JavaPlugin = "HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\JavaSoft\\Java Plug-in\\1.6.0_31";
                LogWriter.WriteLog($"Java Plugin Registry Path set to {JavaPlugin}");
            }

            const string javaUpdate = "HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\JavaSoft\\Java Update\\Policy";
            const string javaAddon1 = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Ext\Settings\{761497BB-D6F0-462C-B6EB-D4DAF1D92D43}";
            const string javaAddon2 = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Ext\Settings\{DBC80044-A445-435B-BC74-9C25C1C588A9}";
            const string UseNewJavaPlugin = "UseNewJavaPlugin";
            const string UseJava2IExplorer = "UseJava2IExplorer";
            const string EnableJavaUpdate = "EnableJavaUpdate";
            const string NotifyDownload = "NotifyDownload";
            const string Flags = "Flags";
            const string NewInstallPromptCount = "NewInstallPromptCount";

            try
            {

                Registry.SetValue(javaAddon1, Flags, 0, RegistryValueKind.DWord);
                Registry.SetValue(javaAddon1, NewInstallPromptCount, 0, RegistryValueKind.DWord);
                Registry.SetValue(javaAddon2, Flags, 0, RegistryValueKind.DWord);
                Registry.SetValue(javaAddon2, NewInstallPromptCount, 0, RegistryValueKind.DWord);
                Registry.SetValue(JavaPlugin, UseNewJavaPlugin, 0, RegistryValueKind.DWord);
                Registry.SetValue(JavaPlugin, UseJava2IExplorer, 0, RegistryValueKind.DWord);
                Registry.SetValue(javaUpdate, EnableJavaUpdate, 0, RegistryValueKind.DWord);
                Registry.SetValue(javaUpdate, NotifyDownload, 0, RegistryValueKind.DWord);
                LogWriter.WriteLog("Successfully set Java Registry keys");
            }
            catch (SystemException e)
            {
                LogWriter.WriteLog($"Access violation {e}");
            }

        }

        public static void JavaUninstall()
        {
            String[] GUIDS = new string[] {
                "{26A24AE4-039D-4CA4-87B4-2F86418073F0}",
                "{26A24AE4-039D-4CA4-87B4-2F83218073F0}",
                "{26A24AE4-039D-4CA4-87B4-2F86418072F0}",
                "{26A24AE4-039D-4CA4-87B4-2F83218072F0}",
                "{26A24AE4-039D-4CA4-87B4-2F86418071F0}",
                "{26A24AE4-039D-4CA4-87B4-2F83218071F0}",
                "{26A24AE4-039D-4CA4-87B4-2F86418066F0}",
                "{26A24AE4-039D-4CA4-87B4-2F83218066F0}",
                "{26A24AE4-039D-4CA4-87B4-2F86418031F0}",
                "{26A24AE4-039D-4CA4-87B4-2F83218031F0}",
                "{26A24AE4-039D-4CA4-87B4-2F86418025F0}",
                "{26A24AE4-039D-4CA4-87B4-2F83218025F0}",
                "{26A24AE4-039D-4CA4-87B4-2F06417080FF}",
                "{26A24AE4-039D-4CA4-87B4-2F03217080FF}",
                "{26A24AE4-039D-4CA4-87B4-2F06417079FF}",
                "{26A24AE4-039D-4CA4-87B4-2F03217079FF}",
                "{26A24AE4-039D-4CA4-87B4-2F06417076FF}",
                "{26A24AE4-039D-4CA4-87B4-2F03217076FF}",
                "{26A24AE4-039D-4CA4-87B4-2F06417075FF}",
                "{26A24AE4-039D-4CA4-87B4-2F03217075FF}",
                "{26A24AE4-039D-4CA4-87B4-2F06417072FF}",
                "{26A24AE4-039D-4CA4-87B4-2F03217072FF}",
                "{26A24AE4-039D-4CA4-87B4-2F06417071FF}",
                "{26A24AE4-039D-4CA4-87B4-2F03217071FF}",
                "{26A24AE4-039D-4CA4-87B4-2F06417067FF}",
                "{26A24AE4-039D-4CA4-87B4-2F03217067FF}",
                "{26A24AE4-039D-4CA4-87B4-2F06417060FF}",
                "{26A24AE4-039D-4CA4-87B4-2F03217060FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86417055FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83217055FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83217051FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83217051FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86417045FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83217045FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86417040FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83217040FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86417025FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83217025FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86417021FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83217021FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86417017FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83217017FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86417016FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83217016FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86417015FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83217015FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86417014FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83217014FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86417013FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83217013FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86417012FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83217012FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86417011FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83217011FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86417010FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83217010FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86417009FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83217009FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86417008FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83217008FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86417007FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83217007FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86417006FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83217006FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86417005FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83217005FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86417004FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83217004FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86417003FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83217003FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86417002FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83217002FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86417001FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83217001FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86416043FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83216043FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86416042FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83216042FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86416041FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83216041FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86416040FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83216040FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86416039FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83216039FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86416038FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83216038FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86416037FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83216037FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86416036FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83216036FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86416035FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83216035FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86416034FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83216034FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86416033FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83216033FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86416032FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83216032FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86416031FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83216031FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86416030FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83216030FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86416029FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83216029FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86416028FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83216028FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86416027FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83216027FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86416026FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83216026FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86416025FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83216025FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86416024FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83216024FF}",
                "{26A24AE4-039D-4CA4-87B4-2F86416023FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83216023FF}",
                "{26A24AE4-039D-4CA4-87B4-2F83216022FF}",
                "{3248F0A8-6813-11D6-A77B-00B0D0160220}",
                "{26A24AE4-039D-4CA4-87B4-2F83216021FF}",
                "{3248F0A8-6813-11D6-A77B-00B0D0160210}",
                "{26A24AE4-039D-4CA4-87B4-2F83216020FF}",
                "{3248F0A8-6813-11D6-A77B-00B0D0160200}",
                "{26A24AE4-039D-4CA4-87B4-2F83216019FF}",
                "{3248F0A8-6813-11D6-A77B-00B0D0160190}",
                "{26A24AE4-039D-4CA4-87B4-2F83216018FF}",
                "{3248F0A8-6813-11D6-A77B-00B0D0160180}",
                "{26A24AE4-039D-4CA4-87B4-2F83216017FF}",
                "{3248F0A8-6813-11D6-A77B-00B0D0160170}",
                "{26A24AE4-039D-4CA4-87B4-2F83216016FF}",
                "{3248F0A8-6813-11D6-A77B-00B0D0160160}",
                "{26A24AE4-039D-4CA4-87B4-2F83216015FF}",
                "{3248F0A8-6813-11D6-A77B-00B0D0160150}",
                "{26A24AE4-039D-4CA4-87B4-2F83216014FF}",
                "{3248F0A8-6813-11D6-A77B-00B0D0160140}",
                "{26A24AE4-039D-4CA4-87B4-2F83216013FF}",
                "{3248F0A8-6813-11D6-A77B-00B0D0160130}",
                "{26A24AE4-039D-4CA4-87B4-2F83216012FF}",
                "{3248F0A8-6813-11D6-A77B-00B0D0160120}",
                "{26A24AE4-039D-4CA4-87B4-2F83216011FF}",
                "{3248F0A8-6813-11D6-A77B-00B0D0160110}",
                "{26A24AE4-039D-4CA4-87B4-2F83216010FF}",
                "{3248F0A8-6813-11D6-A77B-00B0D0160100}",
                "{26A24AE4-039D-4CA4-87B4-2F83216009FF}",
                "{3248F0A8-6813-11D6-A77B-00B0D0160090}",
                "{26A24AE4-039D-4CA4-87B4-2F83216008FF}",
                "{3248F0A8-6813-11D6-A77B-00B0D0160080}",
                "{26A24AE4-039D-4CA4-87B4-2F83216007FF}",
                "{3248F0A8-6813-11D6-A77B-00B0D0160070}",
                "{26A24AE4-039D-4CA4-87B4-2F83216006FF}",
                "{3248F0A8-6813-11D6-A77B-00B0D0160060}",
                "{26A24AE4-039D-4CA4-87B4-2F83216005FF}",
                "{3248F0A8-6813-11D6-A77B-00B0D0160050}",
                "{26A24AE4-039D-4CA4-87B4-2F83216004FF}",
                "{3248F0A8-6813-11D6-A77B-00B0D0160040}",
                "{26A24AE4-039D-4CA4-87B4-2F83216003FF}",
                "{3248F0A8-6813-11D6-A77B-00B0D0160030}",
                "{26A24AE4-039D-4CA4-87B4-2F83216002FF}",
                "{3248F0A8-6813-11D6-A77B-00B0D0160020}",
                "{26A24AE4-039D-4CA4-87B4-2F83216001FF}",
                "{3248F0A8-6813-11D6-A77B-00B0D0160010}",
                "{26A24AE4-039D-4CA4-87B4-2F83216000FF}",
                "{3248F0A8-6813-11D6-A77B-00B0D0160000}",
                "{3248F0A8-6813-11D6-A77B-00B0D0150230}",
                "{3248F0A8-6813-11D6-A77B-00B0D0150220}",
                "{3248F0A8-6813-11D6-A77B-00B0D0150210}",
                "{3248F0A8-6813-11D6-A77B-00B0D0150200}",
                "{3248F0A8-6813-11D6-A77B-00B0D0150190}",
                "{3248F0A8-6813-11D6-A77B-00B0D0150180}",
                "{3248F0A8-6813-11D6-A77B-00B0D0150170}",
                "{3248F0A8-6813-11D6-A77B-00B0D0150160}",
                "{3248F0A8-6813-11D6-A77B-00B0D0150150}",
                "{3248F0A8-6813-11D6-A77B-00B0D0150140}",
                "{3248F0A8-6813-11D6-A77B-00B0D0150130}",
                "{3248F0A8-6813-11D6-A77B-00B0D0150120}",
                "{3248F0A8-6813-11D6-A77B-00B0D0150110}",
                "{3248F0A8-6813-11D6-A77B-00B0D0150100}",
                "{3248F0A8-6813-11D6-A77B-00B0D0150090}",
                "{3248F0A8-6813-11D6-A77B-00B0D0150080}",
                "{3248F0A8-6813-11D6-A77B-00B0D0150070}",
                "{3248F0A8-6813-11D6-A77B-00B0D0150060}",
                "{3248F0A8-6813-11D6-A77B-00B0D0150050}",
                "{3248F0A8-6813-11D6-A77B-00B0D0150040}",
                "{3248F0A8-6813-11D6-A77B-00B0D0150030}",
                "{3248F0A8-6813-11D6-A77B-00B0D0150020}",
                "{3248F0A8-6813-11D6-A77B-00B0D0150010}",
                "{3248F0A8-6813-11D6-A77B-00B0D0150000}",
                "{7148F0A8-6813-11D6-A77B-00B0D0142190}",
                "{7148F0A8-6813-11D6-A77B-00B0D0142180}",
                "{7148F0A8-6813-11D6-A77B-00B0D0142170}",
                "{7148F0A8-6813-11D6-A77B-00B0D0142160}",
                "{7148F0A8-6813-11D6-A77B-00B0D0142150}",
                "{7148F0A8-6813-11D6-A77B-00B0D0142140}",
                "{7148F0A8-6813-11D6-A77B-00B0D0142130}",
                "{7148F0A8-6813-11D6-A77B-00B0D0142120}",
                "{7148F0A8-6813-11D6-A77B-00B0D0142110}",
                "{7148F0A8-6813-11D6-A77B-00B0D0142100}",
                "{7148F0A8-6813-11D6-A77B-00B0D0142090}",
                "{7148F0A8-6813-11D6-A77B-00B0D0142080}",
                "{7148F0A8-6813-11D6-A77B-00B0D0142070}",
                "{7148F0A8-6813-11D6-A77B-00B0D0142060}",
                "{7148F0A8-6813-11D6-A77B-00B0D0142050}",
                "{7148F0A8-6813-11D6-A77B-00B0D0142040}",
                "{7148F0A8-6813-11D6-A77B-00B0D0142030}",
                "{7148F0A8-6813-11D6-A77B-00B0D0142020}",
                "{7148F0A8-6813-11D6-A77B-00B0D0142010}",
                "{7148F0A8-6813-11D6-A77B-00B0D0142000}"};

            foreach (string p in GUIDS)
            {
                Process proc = new Process();
                try
                {
                    proc.StartInfo.FileName = "msiexec.exe";
                    proc.StartInfo.CreateNoWindow = true;
                    proc.StartInfo.UseShellExecute = true;
                    string command = "/X" + p + " /quiet";
                    proc.StartInfo.Arguments = command;
                    proc.Start();
                    proc.WaitForExit();
                }
                catch (System.Exception)
                {
                    proc.Dispose();
                }
            }
        }

        public static void JavaFolderCleanUp()
        {
            string appdatalow = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "Low" + @"\Sun";
            try
            {
                Directory.Delete(appdatalow, true);
            }
            catch (SystemException e)
            {
                LogWriter.WriteLog($"Unable to delete directory {e} {appdatalow}");
            }


            foreach (Environment.SpecialFolder p in Enum.GetValues(typeof(Environment.SpecialFolder)))
            {

                string oraclePath = Environment.GetFolderPath(p) + @"\Oracle";
                string sunPath = Environment.GetFolderPath(p) + @"\Sun";
                string javaPath = Environment.GetFolderPath(p) + @"\Java";
                string javaSoftPath = Environment.GetFolderPath(p) + @"\JavaSoft";

                if (Directory.Exists(oraclePath))
                {
                    try
                    {
                        Directory.Delete(oraclePath, true);
                    }
                    catch (SystemException e)
                    {
                        LogWriter.WriteLog($"Unable to delete directory {e}");
                    }
                }
                else
                {
                    LogWriter.WriteLog($"Directory {oraclePath} does not exist");
                }

                if (Directory.Exists(javaSoftPath))
                {
                    try
                    {
                        Directory.Delete(javaSoftPath, true);
                    }
                    catch (SystemException e)
                    {
                        LogWriter.WriteLog($"Unable to delete directory {e}");
                    }
                }
                else
                {
                    LogWriter.WriteLog($"Directory {javaSoftPath} does not exist");
                }

                if (Directory.Exists(javaPath))
                {
                    try
                    {
                        Directory.Delete(javaPath, true);
                    }
                    catch (SystemException e)
                    {
                        LogWriter.WriteLog($"Unable to delete directory {e}");
                    }
                }
                else
                {
                    LogWriter.WriteLog($"Directory {javaPath} does not exist");
                }

                if (Directory.Exists(sunPath))
                {
                    try
                    {
                        Directory.Delete(sunPath, true);
                    }
                    catch (SystemException e)
                    {
                        LogWriter.WriteLog($"Generic system exception thrown {e}");
                    }
                }
                else
                {
                    LogWriter.WriteLog($"Directory {sunPath} does not exist");
                }
            }
        }

        public static void EditDeploymentProperties()
        {
            StreamWriter fileWriter;
            FileStream fileStream = null;
            FileInfo propertiesFileInfo;
            string propertiesFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "Low" + @"\Sun\Java\Deployment\deployment.properties";

            propertiesFileInfo = new FileInfo(propertiesFile);
            if (propertiesFileInfo.Exists)
            {
                fileStream = new FileStream(propertiesFile, FileMode.Append);
            }
            fileWriter = new StreamWriter(fileStream);
            fileWriter.WriteLine("deployment.cache.enabled=false");
            fileWriter.Close();
        }

        public static void JavaRegistryCleanUp()
        {
            RegistryKey rklm = Registry.LocalMachine;
            RegistryKey rk = Registry.Users;

            string JavaSoft64 = @"SOFTWARE\WOW6432Node\JavaSoft";
            string JavaSoft32 = @"SOFTWARE\JavaSoft";
            string JreMetrics64 = @"SOFTWARE\WOW6432Node\JreMetrics";
            string JreMetrics32 = @"SOFTWARE\JreMetrics";
            string JavaSoftAppData = @"Software\AppDataLow\Software\JavaSoft";

            if (Environment.Is64BitOperatingSystem)
            {
                try
                {
                    rklm.DeleteSubKey(JavaSoft64);
                    rklm.DeleteSubKey(JreMetrics64);
                    rklm.DeleteSubKeyTree(JavaSoft64);
                    rklm.DeleteSubKeyTree(JreMetrics64);
                }
                catch (SystemException e)
                {
                    LogWriter.WriteLog($"Unable to delete registry keys {e} {JavaSoft64} {JreMetrics64}");
                }
                    
            }
            else
            {
                try
                {
                    rklm.DeleteSubKey(JavaSoft32);
                    rklm.DeleteSubKey(JreMetrics32);
                    rklm.DeleteSubKeyTree(JavaSoft32);
                    rklm.DeleteSubKeyTree(JreMetrics32);
                }
                catch (SystemException e)
                {
                    LogWriter.WriteLog($"Unable to delete registry keys {e} {JavaSoft32} {JreMetrics32}");
                }
            }

            foreach (string s in ObtainUsers(rk))
            {
                string trimmedKey = $"{s}\\";
                try
                {
                    rk.DeleteSubKeyTree(trimmedKey + JavaSoftAppData);
                    rk.DeleteSubKey(trimmedKey + @"Software\JavaSoft");
                }
                catch (SystemException e)
                {
                    LogWriter.WriteLog($"Unable to delete registry key {e} {rk.Name + trimmedKey + JavaSoftAppData}");
                }
                
            }

        }

        private static List<string> ObtainUsers(RegistryKey rkey)
        {
            // Retrieve all the subkeys for the specified key.
            String[] keys = rkey.GetSubKeyNames();
            var names = new List<string>();

            // Loop through each key, and append only the created user SIDs to the list
            foreach (String s in keys)
            {
                if (s.EndsWith("_Classes") || s.StartsWith("S-1-5-18") || s.StartsWith("S-1-5-19") || s.StartsWith("S-1-5-20") || s.StartsWith(".DEFAULT"))
                {
                    continue;
                }
                else
                {
                    names.Add(s);
                }
            }

            return names;
        }
    }
}
