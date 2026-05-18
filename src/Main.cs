using DiscordRPC;
using Microsoft.Win32;
using Newtonsoft.Json;
using synapsesex;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace synapsex
{
    public partial class Main : Form
    {
        DiscordRpcClient client = new DiscordRpcClient("1495633741408637009");

        private Size originalSize;
        private Point originalLocation;
        private bool isMaximized = false;

        bool IsInjected()
        {
            if (NamedPipes.NamedPipeExist(NamedPipes.luapipename))
            {
                return true;
   
            }
            else
            {
                return false;
            }
        }

        private async void StartChecking()
        {
            while (true)
            {
                //if (Properties.Settings.Default.autoinj)
                //{
                //    AxonFunctions.Inject();
                //}
                if (IsInjected())
                {
                    if (InjectedWindow.Visible == false)
                    {
                        InjectedWindow.Visible = true;
                    }
                }
                else
                {
                    if (InjectedWindow.Visible == true)
                    {
                        InjectedWindow.Visible = false;
                    }
                }
                await Task.Delay(500);
            }
        }
        public Main()
        {
            InitializeComponent();
            LoadScripts();
            ScriptsListBox.SelectedIndexChanged += ScriptsListBox_SelectedIndexChanged;
            this.TopMost = Properties.Settings.Default.TopMost;
        }

        public void UpdateMinimapState(bool isChecked)
        {
            if (webBrowser1.Document != null)
            {
                webBrowser1.Document.InvokeScript("SwitchMinimap", new object[] { isChecked });
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void ScriptsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ScriptsListBox.SelectedItem != null)
            {
                string selectedFile = Path.Combine(Application.StartupPath, "Scripts", ScriptsListBox.SelectedItem.ToString());
                if (File.Exists(selectedFile))
                {
                    string fileContent = File.ReadAllText(selectedFile);
                    webBrowser1.Document.InvokeScript("SetText", new object[] { fileContent });
                }
            }
        }

        private void LoadScripts()
        {
            string scriptsFolder = Path.Combine(Application.StartupPath, "Scripts");
            if (!Directory.Exists(scriptsFolder))
            {
                Directory.CreateDirectory(scriptsFolder);
            }
            string[] scripts = Directory.GetFiles(scriptsFolder);
            ScriptsListBox.Items.Clear();
            foreach (var script in scripts)
            {
                ScriptsListBox.Items.Add(Path.GetFileName(script));
            }
        }
        string GetMemoryUsage()
        {
            long memoryBytes = GC.GetTotalMemory(false);
            double memoryMB = memoryBytes / 1024.0 / 1024.0;
            return $"{memoryMB:F2}MB";
        }

        private async void Main_Load(object sender, EventArgs e)
        {
            label3.Text = $"Synapse X - 1.0.2";
            StartChecking();
            client.Initialize();
            client.SetPresence(new RichPresence()
            {
                Details = "Synapse X",
                State = $"Exploiting with Synapse | Usage : {GetMemoryUsage()}",
                Timestamps = Timestamps.Now,

                Buttons = new DiscordRPC.Button[]
                {
                    new DiscordRPC.Button() { Label = "Join Discord", Url = "https://scamnapse.xyz/discord" },
                    new DiscordRPC.Button() { Label = "Download", Url = "https://scamnapse.xyz/SXREDownload" }
                },
                Assets = new Assets()
                {
                    LargeImageText = "synapsebig"
                }
            });
            await Task.Delay(200);
            WebClient wc = new WebClient();
            wc.Proxy = null;
            try
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
                string friendlyName = AppDomain.CurrentDomain.FriendlyName;
                if (registryKey.GetValue(friendlyName) == null)
                {
                    registryKey.SetValue(friendlyName, 11001, RegistryValueKind.DWord);
                }
            }
            catch (Exception)
            {
            }
            webBrowser1.Url = new Uri(string.Format("file:///{0}/Monaco/Monaco.html", Directory.GetCurrentDirectory()));
            await Task.Delay(200);
            webBrowser1.Document.InvokeScript("SetTheme", new string[] { "Dark" });
            addBase();
            addMath();
            addGlobalNS();
            addGlobalV();
            addGlobalF();
            webBrowser1.Document.InvokeScript("SetText", new object[] { "print(\"hello world\")" });
        }

        private string defPath = Application.StartupPath + "//Monaco//";

        private void addIntel(string label, string kind, string detail, string insertText)
        {
            webBrowser1.Document.InvokeScript("AddIntellisense", new object[] { label, kind, detail, insertText });
        }

        private void addGlobalF()
        {
            string[] array = File.ReadAllLines(this.defPath + "//globalf.txt");
            foreach (string text in array)
            {
                if (text.Contains(':'))
                {
                    this.addIntel(text, "Function", text, text.Substring(1));
                }
                else
                {
                    this.addIntel(text, "Function", text, text);
                }
            }
        }

        private void addGlobalV()
        {
            foreach (string text in File.ReadLines(this.defPath + "//globalv.txt"))
            {
                this.addIntel(text, "Variable", text, text);
            }
        }

        private void addGlobalNS()
        {
            foreach (string text in File.ReadLines(this.defPath + "//globalns.txt"))
            {
                this.addIntel(text, "Class", text, text);
            }
        }

        private void addMath()
        {
            foreach (string text in File.ReadLines(this.defPath + "//classfunc.txt"))
            {
                this.addIntel(text, "Method", text, text);
            }
        }

        private void addBase()
        {
            foreach (string text in File.ReadLines(this.defPath + "//base.txt"))
            {
                this.addIntel(text, "Keyword", text, text);
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void ExecuteBtn_Click(object sender, EventArgs e)
        {
            if (!IsInjected())
            {
                MessageBox.Show("Synapse is not attached!", "Synapse X");
                return;
            }

            HtmlDocument document = webBrowser1.Document;
            string scriptName = "GetText";
            object[] args = new string[0];
            object obj = document.InvokeScript(scriptName, args);

            string script = obj.ToString();
            if (IsInjected())
            {
                NamedPipes.LuaPipe(script);
            }
        }


        private void minimiseBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.InvokeScript("SetText", new object[] { "" });
        }

        private async void OptionsBtn_Click(object sender, EventArgs e)
        {
            OptionsBtn.Text = "Loading...";
            await Task.Delay(300);
            OptionsBtn.Text = "Options";
            OptionsForm optionsForm = new OptionsForm(this);
            optionsForm.Show();
            optionsForm.TopMost = true;
        }

        private void AttachBtn_Click(object sender, EventArgs e)
        {
            // Api.Inject();
            if (!NamedPipes.NamedPipeExist(NamedPipes.luapipename))
            {
                AxonFunctions.Inject();
                MessageBox.Show("Injected!", "Synapse X");
            }
            else
            {
                MessageBox.Show("Already injected!", "Synapse X");
            }
        }

        private void ScriptsListBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void ExecuteFileBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All Files (*.*)|*.*";
                openFileDialog.Title = "Select a script file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedScriptPath = openFileDialog.FileName;
                    string script = File.ReadAllText(selectedScriptPath);

                    if (IsInjected())
                    {
                        NamedPipes.LuaPipe(script);
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void SaveFileBtn_Click(object sender, EventArgs e)
        {
            HtmlDocument document = webBrowser1.Document;
            string scriptName = "GetText";
            object[] args = new string[0];
            object obj = document.InvokeScript(scriptName, args);
            string script = obj.ToString();

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                saveFileDialog.Title = "Save a Script";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, script);
                }
            }
        }

        private void OpenFileBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                openFileDialog.Title = "Open a Script File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string script = File.ReadAllText(openFileDialog.FileName);
                    webBrowser1.Document.InvokeScript("SetText", new object[] { script });
                }
            }
        }

        private async void ScriptHubBtn_Click(object sender, EventArgs e)
        {
            ScriptHubBtn.Text = "Loading...";
            await Task.Delay(200);
            ScriptHubBtn.Text = "Script Hub";
            ScriptHub scripthub = new ScriptHub();
            scripthub.Show();
        }

        private void maximiseBtn_Click(object sender, EventArgs e)
        {
            if (!isMaximized)
            {
                originalSize = this.Size;
                originalLocation = this.Location;
                Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
                this.Location = workingArea.Location;
                this.Size = workingArea.Size;

                isMaximized = true;
            }
            else
            {
                this.Location = originalLocation;
                this.Size = originalSize;
                isMaximized = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by @segcent/@valdoratorzzzz & @scamnapse.v2", "Credits");
        }
    }
}
