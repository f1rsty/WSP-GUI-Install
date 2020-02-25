using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSPInstaller
{
    public partial class Form1 : Form
    {
        string outDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + "WSP";
        string javaVersion;
        string shortcutText;
        string teamNotes = "TeamNotesFormEditorLibrary.msi";
        string linkURL;
        string cmdInstall = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + "WSP" + "\\" + "install.bat";

        public Form1()
        {
            InitializeComponent();
        }


        private void installButton_Click(object sender, EventArgs e)
        {
            if(fntButton.Checked)
            {
                javaVersion = "jre-7u45-windows-i586.exe";
                shortcutText = "Mclaren Flint";
                linkURL = "https://mrmc-wsp.mclaren.org/WSP/Login.aspx";
                this.Opacity = 0;
                beginInstall(javaVersion);
                Dispose();
            }

            if (lapButton.Checked)
            {
                javaVersion = "jre-6u31-windows-i586-s.exe";
                shortcutText = "Mclaren Lapeer";
                linkURL = "https://lrmc-wsp.mclaren.org/WSP/Login.aspx";
                this.Opacity = 0;
                beginInstall(javaVersion);
                Dispose();
            }

            if (bayButton.Checked)
            {
                javaVersion = "jre-7u45-windows-i586.exe";
                shortcutText = "Mclaren BAY";
                linkURL = "https://bay-wsp.mclaren.org/WSP/Login.aspx";
                this.Opacity = 0;
                beginInstall(javaVersion);
                Dispose();
            }

            if (cmiButton.Checked)
            {
                javaVersion = "jre-7u45-windows-i586.exe";
                shortcutText = "Mclaren Central";
                linkURL = "https://cmi-wsp.mclaren.org/WSP/Login.aspx";
                this.Opacity = 0;
                beginInstall(javaVersion);
                Dispose();
            }

            if (macButton.Checked)
            {
                javaVersion = "jre-7u45-windows-i586.exe";
                shortcutText = "Mclaren Macomb";
                linkURL = "https://mcrmc-wsp.mclaren.org/WSP/Login.aspx";
                this.Opacity = 0;
                beginInstall(javaVersion);
                Dispose();
            }

            if (oakButton.Checked)
            {
                javaVersion = "jre-7u45-windows-i586.exe";
                shortcutText = "Mclaren Oakland";
                linkURL = "https://poh-wsp.mclaren.org/WSP/Login.aspx";
                this.Opacity = 0;
                beginInstall(javaVersion);
                Dispose();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void beginInstall(string javaVersion)
        {
            Helper.Extract("WSPInstaller", outDirectory, "Resources", javaVersion);
            LogWriter.WriteLog($"Extracted Java Version {javaVersion}");
            Helper.Extract("WSPInstaller", outDirectory, "Resources", teamNotes);
            LogWriter.WriteLog($"Extracted {teamNotes}");
            Helper.Extract("WSPInstaller", outDirectory, "Resources", "install.bat");
            LogWriter.WriteLog("Updating Internet Explorer registry for all users");
            Explorer.ExplorerRegistrySettings();
            LogWriter.WriteLog("Finished Updating Internet Explorer registry for all users");
            Task net35install = Task.Factory.StartNew(Net35Install);
            net35install.Wait();
            Helper.FakeReboot();
            LogWriter.WriteLog("Starting Team Notes GUID uninstallation");
            Task TeamNotes = Task.Factory.StartNew(TeamNotesUninstall);
            TeamNotes.Wait();
            LogWriter.WriteLog("Finished Team Notes GUID uninstallation");
            LogWriter.WriteLog("Starting Java GUID uninstallation");
            Task output = Task.Factory.StartNew(JavaUninstall);
            output.Wait();
            LogWriter.WriteLog("Finished Java GUID uninstallation");
            LogWriter.WriteLog("Starting Team Notes installation");
            Helper.teamNotesInstall();
            LogWriter.WriteLog("Finished Team Notes installation");
            Java.JavaFolderCleanUp();
            Java.JavaRegistryCleanUp();
            Helper.removePACS();
            LogWriter.WriteLog("Starting new Java installation");
            Task ji = Task.Factory.StartNew(JavaInstall);
            ji.Wait();
            Java.SetJavaRegistrySettings(javaVersion);
            Helper.CreateShortcut(linkURL, shortcutText);
            MessageBox.Show("WSP Successfully Installed, Please restart your computer");
            
        }

        private void JavaUninstall()
        {
            Java.JavaUninstall();
        }

        private void JavaInstall()
        {
            Java.javaInstall(javaVersion);
        }

        private void Net35Install()
        {
            Helper.executeCommand(cmdInstall);
        }

        private void TeamNotesUninstall()
        {
            Helper.teamNotesUninstall();
        }
    }
}