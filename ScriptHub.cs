using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace synapsex
{
    public partial class ScriptHub : Form
    {
        private int currentPage = 1;
        public ScriptHub()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ScriptHub_Load(object sender, EventArgs e)
        {
            this.TopMost = Properties.Settings.Default.TopMost;
        }

        private async void searchButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchTextBox.Text))
            {
                MessageBox.Show("Please enter a search query.");
                return;
            }

            currentPage = 1;
            ScriptPanel.Controls.Clear();
            await Task.Delay(200);
            await SearchScripts(searchTextBox.Text, currentPage);
        }

        private async void nextButton_Click(object sender, EventArgs e)
        {
            currentPage++;
            pageLabel.Text = $"Page {currentPage}";
            ScriptPanel.Controls.Clear();
            await Task.Delay(200);
            await SearchScripts(searchTextBox.Text, currentPage);
        }

        private async void backButton_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                pageLabel.Text = $"Page {currentPage}";
                ScriptPanel.Controls.Clear();
                await Task.Delay(200);
                await SearchScripts(searchTextBox.Text, currentPage);
            }
        }

        private async Task SearchScripts(string query, int page)
        {

            using (HttpClient client = new HttpClient())
            {
                string url = $"https://scriptblox.com/api/script/search?q={Uri.EscapeDataString(query)}&max=10&mode=free&page={page}";
                try
                {
                    var response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string json = await response.Content.ReadAsStringAsync();
                    var results = JsonConvert.DeserializeObject<dynamic>(json);

                    if (results?.result?.scripts != null)
                    {
                        this.SuspendLayout();
                        foreach (var script in results.result.scripts)
                        {
                            string title = script.title;
                            string code = script.script;
                            string image = script.game.imageUrl;

                            if (!string.IsNullOrWhiteSpace(image) && !image.Contains("rbxcdn"))
                            {
                                image = $"https://scriptblox.com{script.game.imageUrl}";
                            }

                            AddScriptPanel(title, code, image);
                        }
                        this.ResumeLayout();
                    }
                    else
                    {
                        MessageBox.Show("No results found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching scripts: {ex.Message}");
                }
            }
        }
        private void AddScriptPanel(string title, string code, string imageUrl)
        {
            Panel siticonePanel = new Panel
            {
                Width = 700,
                Height = 100,
                Margin = new Padding(5),
                BackColor = Color.FromArgb(35,35,35)
            };

            PictureBox value = new PictureBox
            {
                Width = 150,
                Height = 99,
                ImageLocation = imageUrl,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Margin = new Padding(5)
            };

            Label value2 = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 11.25f),
                ForeColor = Color.White,
                Text = title,
                Location = new Point(160, 10)
            };

            Button siticoneButton = new Button
            {
                Text = "Copy",
                ForeColor = Color.White,
                BackColor = Color.FromArgb(50,50,50),
                Location = new Point(160, 35),
                Width = 200,
                Height = 30,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
            };
            siticoneButton.Click += (s, e) => Clipboard.SetText(code);

            siticonePanel.Controls.Add(value);
            siticonePanel.Controls.Add(value2);
            siticonePanel.Controls.Add(siticoneButton);

            ScriptPanel.AutoScroll = true;
            ScriptPanel.Controls.Add(siticonePanel);
        }

    }
}
