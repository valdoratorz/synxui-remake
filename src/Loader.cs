using DiscordRPC;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace synapsex
{
    public partial class Load : Form
    {
        private string localVersion = "1.0.2";
        private const string VersionUrl = "https://raw.githubusercontent.com/scamnapse/SXREDLLs/refs/heads/main/version";
        private const string UpdateCheckerUrl = "https://github.com/scamnapse/SXREDLLs/raw/main/UpdateChecker.exe";
        private const string UpdateCheckerExe = "UpdateChecker.exe";

        public Load()
        {
            InitializeComponent();
        }

        private async void Load_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            progressBar1.Value = 0;
            progressBar1.Visible = true;
            await ValidateKey();
        }

        private async Task ValidateKey()
        {
            await Task.Delay(200);
            progressBar1.Value = 32;
            label1.Text = "Checking for updates...";
            string remoteVersion = await GetRemoteVersion();

            if (IsLocalVersionOlder(remoteVersion))
            {
                label1.Text = "New update available!";
                var result = MessageBox.Show($"{remoteVersion} is available! Wanna update?", "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    label1.Text = "Locating UpdateChecker...";
                    progressBar1.Value = 50;

                    try
                    {
                        string updaterPath = await EnsureUpdateChecker();
                        label1.Text = "Launching update...";
                        await Task.Delay(500);
                        Process.Start(updaterPath);
                        Environment.Exit(0);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to launch updater: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }
                else
                {
                    label1.Text = "Cancelled";
                    progressBar1.Value = 100;
                    await Task.Delay(300);
                    ProceedWithApplication();
                    return;
                }
            }

            await Task.Delay(1000);
            progressBar1.Value = 57;
            label1.Text = "Checking Whitelist...";
            await Task.Delay(300);

            progressBar1.Value = 100;
            await Task.Delay(300);

            Main mainAppForm = new Main();
            mainAppForm.Show();
            this.Hide();
        }

        private string FindUpdateChecker()
        {
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            string parentDir = Directory.GetParent(currentDir)?.FullName;

            string inCurrent = Path.Combine(currentDir, UpdateCheckerExe);
            if (File.Exists(inCurrent)) return inCurrent;

            if (parentDir != null)
            {
                string inParent = Path.Combine(parentDir, UpdateCheckerExe);
                if (File.Exists(inParent)) return inParent;
            }

            return null;
        }

        private async Task<string> EnsureUpdateChecker()
        {
            string found = FindUpdateChecker();
            if (found != null) return found;

            label1.Text = "Downloading UpdateChecker...";
            string dest = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, UpdateCheckerExe);

            using (HttpClient client = new HttpClient())
            {
                byte[] data = await client.GetByteArrayAsync(UpdateCheckerUrl);
                File.WriteAllBytes(dest, data);
            }

            return dest;
        }

        private async Task<string> GetRemoteVersion()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string version = await client.GetStringAsync(VersionUrl);
                    return version.Trim();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching version: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return localVersion;
                }
            }
        }

        private bool IsLocalVersionOlder(string remoteVersion)
        {
            try
            {
                Version localVer = new Version(CleanVersion(localVersion));
                Version remoteVer = new Version(CleanVersion(remoteVersion));
                return localVer.CompareTo(remoteVer) < 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Version comparison failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private string CleanVersion(string version)
        {
            version = new string(version.Where(c => char.IsDigit(c) || c == '.').ToArray());
            var parts = version.Split('.');
            if (parts.Length < 4)
                version = string.Join(".", parts.Concat(new string[] { "0", "0" }).Take(4));
            return version;
        }

        private void ProceedWithApplication()
        {
            Main mainAppForm = new Main();
            mainAppForm.Show();
            this.Hide();
        }

        private void exitBtn_Click(object sender, EventArgs e) => Environment.Exit(0);
        private void label1_Click(object sender, EventArgs e) { }
    }
}