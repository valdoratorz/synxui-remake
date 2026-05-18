namespace synapsex
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.InjectedWindow = new Guna.UI2.WinForms.Guna2Chip();
            this.maximiseBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.minimiseBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ExecuteBtn = new Guna.UI2.WinForms.Guna2Button();
            this.ScriptsListBox = new System.Windows.Forms.ListBox();
            this.ClearBtn = new Guna.UI2.WinForms.Guna2Button();
            this.ExecuteFileBtn = new Guna.UI2.WinForms.Guna2Button();
            this.SaveFileBtn = new Guna.UI2.WinForms.Guna2Button();
            this.OptionsBtn = new Guna.UI2.WinForms.Guna2Button();
            this.ScriptHubBtn = new Guna.UI2.WinForms.Guna2Button();
            this.AttachBtn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.OpenFileBtn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2DragControl2 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl3 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.InjectedWindow);
            this.panel1.Controls.Add(this.maximiseBtn);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.minimiseBtn);
            this.panel1.Controls.Add(this.exitBtn);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(876, 33);
            this.panel1.TabIndex = 9;
            // 
            // InjectedWindow
            // 
            this.InjectedWindow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.InjectedWindow.BorderRadius = 0;
            this.InjectedWindow.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.InjectedWindow.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.InjectedWindow.ForeColor = System.Drawing.Color.White;
            this.InjectedWindow.Location = new System.Drawing.Point(500, 4);
            this.InjectedWindow.Name = "InjectedWindow";
            this.InjectedWindow.Size = new System.Drawing.Size(75, 26);
            this.InjectedWindow.TabIndex = 20;
            this.InjectedWindow.Text = "Injected";
            this.InjectedWindow.TextOffset = new System.Drawing.Point(-4, -1);
            // 
            // maximiseBtn
            // 
            this.maximiseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maximiseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.maximiseBtn.FlatAppearance.BorderSize = 0;
            this.maximiseBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.maximiseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximiseBtn.Font = new System.Drawing.Font("Nirmala UI", 7F);
            this.maximiseBtn.ForeColor = System.Drawing.Color.White;
            this.maximiseBtn.Location = new System.Drawing.Point(823, 3);
            this.maximiseBtn.Name = "maximiseBtn";
            this.maximiseBtn.Size = new System.Drawing.Size(25, 29);
            this.maximiseBtn.TabIndex = 19;
            this.maximiseBtn.Text = "🗖";
            this.maximiseBtn.UseVisualStyleBackColor = false;
            this.maximiseBtn.Click += new System.EventHandler(this.maximiseBtn_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(373, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 19);
            this.label3.TabIndex = 18;
            this.label3.Text = "LABEL CHANGES";
            // 
            // minimiseBtn
            // 
            this.minimiseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimiseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.minimiseBtn.FlatAppearance.BorderSize = 0;
            this.minimiseBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.minimiseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimiseBtn.Font = new System.Drawing.Font("Nirmala UI", 14F);
            this.minimiseBtn.ForeColor = System.Drawing.Color.White;
            this.minimiseBtn.Location = new System.Drawing.Point(798, 3);
            this.minimiseBtn.Name = "minimiseBtn";
            this.minimiseBtn.Size = new System.Drawing.Size(25, 29);
            this.minimiseBtn.TabIndex = 16;
            this.minimiseBtn.Text = "-";
            this.minimiseBtn.UseVisualStyleBackColor = false;
            this.minimiseBtn.Click += new System.EventHandler(this.minimiseBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.exitBtn.FlatAppearance.BorderSize = 0;
            this.exitBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.Font = new System.Drawing.Font("Nirmala UI", 11F);
            this.exitBtn.ForeColor = System.Drawing.Color.White;
            this.exitBtn.Location = new System.Drawing.Point(848, 3);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(25, 29);
            this.exitBtn.TabIndex = 15;
            this.exitBtn.Text = "×";
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, -6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ExecuteBtn
            // 
            this.ExecuteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExecuteBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ExecuteBtn.BorderRadius = 1;
            this.ExecuteBtn.BorderThickness = 1;
            this.ExecuteBtn.CheckedState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.ExecuteBtn.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.ExecuteBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ExecuteBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ExecuteBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ExecuteBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ExecuteBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ExecuteBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ExecuteBtn.ForeColor = System.Drawing.Color.White;
            this.ExecuteBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ExecuteBtn.Location = new System.Drawing.Point(5, 355);
            this.ExecuteBtn.Name = "ExecuteBtn";
            this.ExecuteBtn.Size = new System.Drawing.Size(90, 27);
            this.ExecuteBtn.TabIndex = 14;
            this.ExecuteBtn.Text = "Execute";
            this.ExecuteBtn.Click += new System.EventHandler(this.ExecuteBtn_Click);
            // 
            // ScriptsListBox
            // 
            this.ScriptsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScriptsListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ScriptsListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ScriptsListBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ScriptsListBox.ForeColor = System.Drawing.Color.White;
            this.ScriptsListBox.FormattingEnabled = true;
            this.ScriptsListBox.ItemHeight = 15;
            this.ScriptsListBox.Location = new System.Drawing.Point(733, 64);
            this.ScriptsListBox.Name = "ScriptsListBox";
            this.ScriptsListBox.Size = new System.Drawing.Size(137, 285);
            this.ScriptsListBox.TabIndex = 17;
            this.ScriptsListBox.SelectedIndexChanged += new System.EventHandler(this.ScriptsListBox_SelectedIndexChanged_1);
            // 
            // ClearBtn
            // 
            this.ClearBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ClearBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClearBtn.BorderRadius = 1;
            this.ClearBtn.BorderThickness = 1;
            this.ClearBtn.CheckedState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.ClearBtn.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.ClearBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ClearBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ClearBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ClearBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ClearBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClearBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ClearBtn.ForeColor = System.Drawing.Color.White;
            this.ClearBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ClearBtn.Location = new System.Drawing.Point(101, 355);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(90, 27);
            this.ClearBtn.TabIndex = 18;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // ExecuteFileBtn
            // 
            this.ExecuteFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExecuteFileBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ExecuteFileBtn.BorderRadius = 1;
            this.ExecuteFileBtn.BorderThickness = 1;
            this.ExecuteFileBtn.CheckedState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.ExecuteFileBtn.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.ExecuteFileBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ExecuteFileBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ExecuteFileBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ExecuteFileBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ExecuteFileBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ExecuteFileBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ExecuteFileBtn.ForeColor = System.Drawing.Color.White;
            this.ExecuteFileBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ExecuteFileBtn.Location = new System.Drawing.Point(293, 355);
            this.ExecuteFileBtn.Name = "ExecuteFileBtn";
            this.ExecuteFileBtn.Size = new System.Drawing.Size(90, 27);
            this.ExecuteFileBtn.TabIndex = 19;
            this.ExecuteFileBtn.Text = "Execute File";
            this.ExecuteFileBtn.Click += new System.EventHandler(this.ExecuteFileBtn_Click);
            // 
            // SaveFileBtn
            // 
            this.SaveFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveFileBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.SaveFileBtn.BorderRadius = 1;
            this.SaveFileBtn.BorderThickness = 1;
            this.SaveFileBtn.CheckedState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.SaveFileBtn.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.SaveFileBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.SaveFileBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.SaveFileBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.SaveFileBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.SaveFileBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.SaveFileBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SaveFileBtn.ForeColor = System.Drawing.Color.White;
            this.SaveFileBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.SaveFileBtn.Location = new System.Drawing.Point(389, 355);
            this.SaveFileBtn.Name = "SaveFileBtn";
            this.SaveFileBtn.Size = new System.Drawing.Size(90, 27);
            this.SaveFileBtn.TabIndex = 20;
            this.SaveFileBtn.Text = "Save File";
            this.SaveFileBtn.Click += new System.EventHandler(this.SaveFileBtn_Click);
            // 
            // OptionsBtn
            // 
            this.OptionsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OptionsBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.OptionsBtn.BorderRadius = 1;
            this.OptionsBtn.BorderThickness = 1;
            this.OptionsBtn.CheckedState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.OptionsBtn.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.OptionsBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.OptionsBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.OptionsBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.OptionsBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.OptionsBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.OptionsBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.OptionsBtn.ForeColor = System.Drawing.Color.White;
            this.OptionsBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.OptionsBtn.Location = new System.Drawing.Point(485, 355);
            this.OptionsBtn.Name = "OptionsBtn";
            this.OptionsBtn.Size = new System.Drawing.Size(90, 27);
            this.OptionsBtn.TabIndex = 21;
            this.OptionsBtn.Text = "Options";
            this.OptionsBtn.Click += new System.EventHandler(this.OptionsBtn_Click);
            // 
            // ScriptHubBtn
            // 
            this.ScriptHubBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ScriptHubBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ScriptHubBtn.BorderRadius = 1;
            this.ScriptHubBtn.BorderThickness = 1;
            this.ScriptHubBtn.CheckedState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.ScriptHubBtn.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.ScriptHubBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ScriptHubBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ScriptHubBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ScriptHubBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ScriptHubBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ScriptHubBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ScriptHubBtn.ForeColor = System.Drawing.Color.White;
            this.ScriptHubBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ScriptHubBtn.Location = new System.Drawing.Point(780, 355);
            this.ScriptHubBtn.Name = "ScriptHubBtn";
            this.ScriptHubBtn.Size = new System.Drawing.Size(90, 27);
            this.ScriptHubBtn.TabIndex = 22;
            this.ScriptHubBtn.Text = "Script Hub";
            this.ScriptHubBtn.Click += new System.EventHandler(this.ScriptHubBtn_Click);
            // 
            // AttachBtn
            // 
            this.AttachBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AttachBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.AttachBtn.BorderRadius = 1;
            this.AttachBtn.BorderThickness = 1;
            this.AttachBtn.CheckedState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.AttachBtn.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.AttachBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.AttachBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.AttachBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AttachBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.AttachBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.AttachBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.AttachBtn.ForeColor = System.Drawing.Color.White;
            this.AttachBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.AttachBtn.Location = new System.Drawing.Point(684, 355);
            this.AttachBtn.Name = "AttachBtn";
            this.AttachBtn.Size = new System.Drawing.Size(90, 27);
            this.AttachBtn.TabIndex = 23;
            this.AttachBtn.Text = "Attach";
            this.AttachBtn.Click += new System.EventHandler(this.AttachBtn_Click);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.panel1;
            this.guna2DragControl1.TransparentWhileDrag = false;
            // 
            // OpenFileBtn
            // 
            this.OpenFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OpenFileBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.OpenFileBtn.BorderRadius = 1;
            this.OpenFileBtn.BorderThickness = 1;
            this.OpenFileBtn.CheckedState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.OpenFileBtn.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.OpenFileBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.OpenFileBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.OpenFileBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.OpenFileBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.OpenFileBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.OpenFileBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.OpenFileBtn.ForeColor = System.Drawing.Color.White;
            this.OpenFileBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.OpenFileBtn.Location = new System.Drawing.Point(197, 355);
            this.OpenFileBtn.Name = "OpenFileBtn";
            this.OpenFileBtn.Size = new System.Drawing.Size(90, 27);
            this.OpenFileBtn.TabIndex = 24;
            this.OpenFileBtn.Text = "Open File";
            this.OpenFileBtn.Click += new System.EventHandler(this.OpenFileBtn_Click);
            // 
            // guna2DragControl2
            // 
            this.guna2DragControl2.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl2.TargetControl = this.pictureBox1;
            this.guna2DragControl2.TransparentWhileDrag = false;
            // 
            // guna2DragControl3
            // 
            this.guna2DragControl3.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl3.TargetControl = this.label3;
            this.guna2DragControl3.TransparentWhileDrag = false;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(5, 39);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(722, 310);
            this.webBrowser1.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(776, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 19);
            this.label1.TabIndex = 19;
            this.label1.Text = "Scripts";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(875, 387);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.OpenFileBtn);
            this.Controls.Add(this.AttachBtn);
            this.Controls.Add(this.ScriptHubBtn);
            this.Controls.Add(this.OptionsBtn);
            this.Controls.Add(this.SaveFileBtn);
            this.Controls.Add(this.ExecuteFileBtn);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.ScriptsListBox);
            this.Controls.Add(this.ExecuteBtn);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Synapse X";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button minimiseBtn;
        private System.Windows.Forms.Button exitBtn;
        private Guna.UI2.WinForms.Guna2Button ExecuteBtn;
        private System.Windows.Forms.ListBox ScriptsListBox;
        private Guna.UI2.WinForms.Guna2Button ClearBtn;
        private Guna.UI2.WinForms.Guna2Button ExecuteFileBtn;
        private Guna.UI2.WinForms.Guna2Button SaveFileBtn;
        private Guna.UI2.WinForms.Guna2Button OptionsBtn;
        private Guna.UI2.WinForms.Guna2Button ScriptHubBtn;
        private Guna.UI2.WinForms.Guna2Button AttachBtn;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2Button OpenFileBtn;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl2;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl3;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button maximiseBtn;
        private Guna.UI2.WinForms.Guna2Chip InjectedWindow;
    }
}