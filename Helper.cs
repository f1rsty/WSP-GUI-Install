using System;
using System.Reflection;
using System.IO;
using IWshRuntimeLibrary;
using System.Diagnostics;

namespace WSPInstaller
{
    class Helper
    {

        public static void Extract(string nameSpace, string outDirectory, string internalFilePath, string resourceName)
        {
            Assembly assembly = Assembly.GetCallingAssembly();

            if (!Directory.Exists(outDirectory))
            {
                Directory.CreateDirectory(outDirectory);
            }
            else
            {
                LogWriter.WriteLog($"{outDirectory} already exists, skipping creation");
            }

            using (Stream s = assembly.GetManifestResourceStream(nameSpace + '.' + (internalFilePath == "" ? "" : internalFilePath + ".") + resourceName))
            {
                using (BinaryReader r = new BinaryReader(s))
                {
                    using (FileStream fs = new FileStream(outDirectory + "\\" + resourceName, FileMode.OpenOrCreate))
                    {
                        using (BinaryWriter w = new BinaryWriter(fs))
                        {
                            w.Write(r.ReadBytes((int)s.Length));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Creates a shortcut for the url and icon name for the shortcutText
        /// </summary>
        /// <param name="url"></param>
        /// <param name="shortcutText"></param>
        public static void CreateShortcut(string url, string shortcutText)
        {
            try
            {
                WshShell shell = new WshShell();
                string shortcutAddress = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory) + "\\" + shortcutText + ".lnk";
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
                shortcut.Arguments = url;
                shortcut.TargetPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\Internet Explorer\iexplore.exe";
                shortcut.Save();
                LogWriter.WriteLog($"Created shortcut for {url} and naming it {shortcutText}");
            }
            catch
            {
                LogWriter.WriteLog($"ERROR: Creating shortcut for {url} and naming it {shortcutText} has failed");
            }
            
        }

        /// <summary>
        /// Delete PACS folders
        /// </summary>
        public static void removePACS()
        {
            string amicasprogramfiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\AMICAS";
            string amicasappdatalocal = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\AppData\LocalLow\AMICAS";
            string amicasappdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AMICAS";

            if(Directory.Exists(amicasprogramfiles))
            {
                try
                {
                    Directory.Delete(amicasprogramfiles, true);
                }
                catch (System.Exception)
                {
                    LogWriter.WriteLog($"Failed to delete {amicasprogramfiles}");
                }
            }
            else
            {
                LogWriter.WriteLog($"INFO: {amicasprogramfiles} was not found on the system");
            }

            if (Directory.Exists(amicasappdatalocal))
            {
                try
                {
                    Directory.Delete(amicasappdatalocal, true);
                }
                catch (System.Exception)
                {
                    LogWriter.WriteLog($"Failed to delete {amicasappdatalocal}");
                }
            }
            else
            {
                LogWriter.WriteLog($"INFO: {amicasappdatalocal} was not found on the system");
            }

            if (Directory.Exists(amicasappdata))
            {
                try
                {
                    Directory.Delete(amicasprogramfiles, true);
                }
                catch (System.Exception)
                {
                    LogWriter.WriteLog($"Failed to delete {amicasappdata}");
                }
            }
            else
            {
                LogWriter.WriteLog($"INFO: {amicasappdata} was not found on the system");
            }
        }

        public static void executeCommand(string command)
        {
            Process proc = null;
            proc = new Process();
            proc.StartInfo.FileName = command;
            proc.StartInfo.CreateNoWindow = false;
            //proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.Start();
            proc.WaitForExit();
            int ExitCode = proc.ExitCode;
            proc.Close();
        }

        public static void teamNotesInstall()
        {
            Process proc = new Process();
            string teamNotePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + "WSP" + "\\" + "TeamNotesFormEditorLibrary.msi";
            try
            {
                proc.StartInfo.FileName = teamNotePath;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.UseShellExecute = true;
                proc.StartInfo.Arguments = " /qb";
                proc.Start();
                proc.WaitForExit();
            }
            catch (SystemException e)
            {
                LogWriter.WriteLog($"Unable to install Team Notes {e}");
            }
            
        }

        public static void teamNotesUninstall()
        {
            String[] GUIDS = new string[] {
                "{A91B29D0-F359-46AA-9BD5-CF2B2757407F}",
                "{F0657771-5762-49BD-9677-AF3631E8F68E}",
                "{F0657771-5762-49BD-9677-AF3631E8F68E}",
                "{CFD5C74E-36A7-4A08-BECA-2C57B1E5D050}",
                "{AC327FBE-0554-4C44-84CC-3F2815AC1783}"
            };

            foreach (string p in GUIDS)
            {
                Process proc = new Process();
                try
                {
                    proc.StartInfo.FileName = "msiexec.exe";
                    proc.StartInfo.CreateNoWindow = true;
                    proc.StartInfo.UseShellExecute = true;
                    string command = "/X" + p + " /qn";
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

        public static void FakeReboot()
        {
            var process = Process.GetProcessesByName("explorer")[0];
            process.Kill();
        }

    }
}
