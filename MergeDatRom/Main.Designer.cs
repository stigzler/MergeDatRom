namespace MergeDatRom
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new stigzler.Winforms.Base.UIElements.MenuStrip();
            viewToolStripMenuItem = new ToolStripMenuItem();
            darkModeToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new stigzler.Winforms.Base.UIElements.StatusStrip();
            MainSC = new SplitContainer();
            MainLV = new stigzler.Winforms.Base.UIElements.ListView();
            flowLayoutPanel1 = new stigzler.Winforms.Base.UIElements.FlowLayoutPanel();
            LoadDatsBT = new stigzler.Winforms.Base.UIElements.Button();
            RhsSC = new SplitContainer();
            MainPG = new stigzler.Winforms.Base.UIElements.PropertyGrid();
            label1 = new stigzler.Winforms.Base.UIElements.Label();
            flowLayoutPanel2 = new stigzler.Winforms.Base.UIElements.FlowLayoutPanel();
            button1 = new stigzler.Winforms.Base.UIElements.Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MainSC).BeginInit();
            MainSC.Panel1.SuspendLayout();
            MainSC.Panel2.SuspendLayout();
            MainSC.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)RhsSC).BeginInit();
            RhsSC.Panel1.SuspendLayout();
            RhsSC.Panel2.SuspendLayout();
            RhsSC.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(25, 25, 25);
            menuStrip1.ForeColor = Color.FromArgb(220, 220, 220);
            menuStrip1.Items.AddRange(new ToolStripItem[] { viewToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.ShowItemToolTips = true;
            menuStrip1.Size = new Size(738, 25);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ToolTip = null;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { darkModeToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(47, 21);
            viewToolStripMenuItem.Text = "View";
            // 
            // darkModeToolStripMenuItem
            // 
            darkModeToolStripMenuItem.Checked = true;
            darkModeToolStripMenuItem.CheckOnClick = true;
            darkModeToolStripMenuItem.CheckState = CheckState.Checked;
            darkModeToolStripMenuItem.Name = "darkModeToolStripMenuItem";
            darkModeToolStripMenuItem.Size = new Size(142, 22);
            darkModeToolStripMenuItem.Text = "Dark Mode";
            darkModeToolStripMenuItem.Click += darkModeToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.FromArgb(25, 25, 25);
            statusStrip1.ForeColor = Color.FromArgb(220, 220, 220);
            statusStrip1.Location = new Point(0, 445);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.ShowItemToolTips = true;
            statusStrip1.Size = new Size(738, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            statusStrip1.ToolTip = null;
            // 
            // MainSC
            // 
            MainSC.Dock = DockStyle.Fill;
            MainSC.Location = new Point(0, 25);
            MainSC.Name = "MainSC";
            // 
            // MainSC.Panel1
            // 
            MainSC.Panel1.BackColor = Color.FromArgb(35, 35, 35);
            MainSC.Panel1.Controls.Add(MainLV);
            MainSC.Panel1.Controls.Add(flowLayoutPanel1);
            MainSC.Panel1.ForeColor = Color.FromArgb(220, 220, 220);
            // 
            // MainSC.Panel2
            // 
            MainSC.Panel2.BackColor = Color.FromArgb(35, 35, 35);
            MainSC.Panel2.Controls.Add(RhsSC);
            MainSC.Panel2.ForeColor = Color.FromArgb(220, 220, 220);
            MainSC.Size = new Size(738, 420);
            MainSC.SplitterDistance = 246;
            MainSC.TabIndex = 3;
            // 
            // MainLV
            // 
            MainLV.AllowDrop = true;
            MainLV.AllowReorder = true;
            MainLV.AutoArrange = false;
            MainLV.BackColor = Color.FromArgb(35, 35, 35);
            MainLV.BorderStyle = BorderStyle.FixedSingle;
            MainLV.ColumnResize = ColumnHeaderAutoResizeStyle.ColumnContent;
            MainLV.Dock = DockStyle.Fill;
            MainLV.ForeColor = Color.FromArgb(220, 220, 220);
            MainLV.HeaderBackground = Color.FromArgb(30, 30, 30);
            MainLV.HeaderBorderColor = Color.FromArgb(100, 100, 100);
            MainLV.HeaderForecolor = Color.FromArgb(240, 240, 240);
            MainLV.InsertionMarkerColor = Color.FromArgb(1, 115, 199);
            MainLV.Location = new Point(0, 0);
            MainLV.Name = "MainLV";
            MainLV.OverrideTheme = false;
            MainLV.SingleColumnMode = false;
            MainLV.Size = new Size(246, 385);
            MainLV.TabIndex = 0;
            MainLV.UseCompatibleStateImageBehavior = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.BackColor = Color.FromArgb(35, 35, 35);
            flowLayoutPanel1.BackgroundShadeFactor = 1D;
            flowLayoutPanel1.Controls.Add(LoadDatsBT);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.ForeColor = Color.FromArgb(220, 220, 220);
            flowLayoutPanel1.Location = new Point(0, 385);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(246, 35);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // LoadDatsBT
            // 
            LoadDatsBT.AutoSize = true;
            LoadDatsBT.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            LoadDatsBT.BackColor = Color.FromArgb(55, 55, 55);
            LoadDatsBT.DefocusOnClick = true;
            LoadDatsBT.DisabledBackColor = Color.FromArgb(30, 30, 30);
            LoadDatsBT.DisabledBorderColor = Color.FromArgb(60, 60, 60);
            LoadDatsBT.DisabledForeColor = Color.FromArgb(125, 125, 125);
            LoadDatsBT.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
            LoadDatsBT.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 102, 215);
            LoadDatsBT.FlatStyle = FlatStyle.Flat;
            LoadDatsBT.ForeColor = Color.FromArgb(240, 240, 240);
            LoadDatsBT.Location = new Point(164, 3);
            LoadDatsBT.Name = "LoadDatsBT";
            LoadDatsBT.Size = new Size(79, 29);
            LoadDatsBT.TabIndex = 0;
            LoadDatsBT.Text = "Load Dats";
            LoadDatsBT.ToolTip = null;
            LoadDatsBT.ToolTipImage = null;
            LoadDatsBT.ToolTipText = null;
            LoadDatsBT.ToolTipTitle = null;
            LoadDatsBT.UseVisualStyleBackColor = false;
            LoadDatsBT.Click += LoadDatsBT_Click;
            // 
            // RhsSC
            // 
            RhsSC.Dock = DockStyle.Fill;
            RhsSC.Location = new Point(0, 0);
            RhsSC.Name = "RhsSC";
            RhsSC.Orientation = Orientation.Horizontal;
            // 
            // RhsSC.Panel1
            // 
            RhsSC.Panel1.BackColor = Color.FromArgb(35, 35, 35);
            RhsSC.Panel1.Controls.Add(MainPG);
            RhsSC.Panel1.Controls.Add(label1);
            RhsSC.Panel1.ForeColor = Color.FromArgb(220, 220, 220);
            // 
            // RhsSC.Panel2
            // 
            RhsSC.Panel2.BackColor = Color.FromArgb(35, 35, 35);
            RhsSC.Panel2.Controls.Add(flowLayoutPanel2);
            RhsSC.Panel2.ForeColor = Color.FromArgb(220, 220, 220);
            RhsSC.Size = new Size(488, 420);
            RhsSC.SplitterDistance = 141;
            RhsSC.TabIndex = 0;
            // 
            // MainPG
            // 
            MainPG.BackColor = Color.FromArgb(30, 30, 30);
            MainPG.CategoryForeColor = Color.FromArgb(240, 240, 240);
            MainPG.CategorySplitterColor = Color.FromArgb(0, 102, 215);
            MainPG.DisabledItemForeColor = Color.FromArgb(127, 220, 220, 220);
            MainPG.Dock = DockStyle.Fill;
            MainPG.HelpBackColor = Color.FromArgb(30, 30, 30);
            MainPG.HelpForeColor = Color.FromArgb(192, 192, 192);
            MainPG.HelpVisible = false;
            MainPG.LineColor = Color.FromArgb(50, 50, 50);
            MainPG.Location = new Point(0, 23);
            MainPG.Name = "MainPG";
            MainPG.Size = new Size(488, 118);
            MainPG.TabIndex = 0;
            MainPG.ToolbarVisible = false;
            MainPG.ViewBackColor = Color.FromArgb(30, 30, 30);
            MainPG.ViewForeColor = Color.FromArgb(220, 220, 220);
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 9.75F);
            label1.FontStyle = FontStyle.Regular;
            label1.ForeColor = Color.FromArgb(220, 220, 220);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(4);
            label1.ScaleFont = 100;
            label1.Size = new Size(488, 23);
            label1.TabIndex = 1;
            label1.Text = "Dat Details";
            label1.ToolTip = null;
            label1.ToolTipHorizontalAlignment = HorizontalAlignment.Right;
            label1.ToolTipImage = null;
            label1.ToolTipText = null;
            label1.ToolTipTitle = null;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.BackColor = Color.FromArgb(35, 35, 35);
            flowLayoutPanel2.BackgroundShadeFactor = 1D;
            flowLayoutPanel2.Controls.Add(button1);
            flowLayoutPanel2.Dock = DockStyle.Bottom;
            flowLayoutPanel2.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel2.ForeColor = Color.FromArgb(220, 220, 220);
            flowLayoutPanel2.Location = new Point(0, 240);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(488, 35);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.BackColor = Color.FromArgb(55, 55, 55);
            button1.DefocusOnClick = true;
            button1.DisabledBackColor = Color.FromArgb(30, 30, 30);
            button1.DisabledBorderColor = Color.FromArgb(60, 60, 60);
            button1.DisabledForeColor = Color.FromArgb(125, 125, 125);
            button1.Dock = DockStyle.Bottom;
            button1.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 102, 215);
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.FromArgb(240, 240, 240);
            button1.Location = new Point(396, 3);
            button1.Name = "button1";
            button1.Size = new Size(89, 29);
            button1.TabIndex = 1;
            button1.Text = "Merge Dats";
            button1.ToolTip = null;
            button1.ToolTipImage = null;
            button1.ToolTipText = null;
            button1.ToolTipTitle = null;
            button1.UseVisualStyleBackColor = false;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(738, 467);
            Controls.Add(MainSC);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            DarkMode = true;
            DoubleBuffered = true;
            ForeColor = Color.FromArgb(220, 220, 220);
            MainMenuStrip = menuStrip1;
            Name = "Main";
            Text = "MergeDatRom";
            Load += Main_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            MainSC.Panel1.ResumeLayout(false);
            MainSC.Panel1.PerformLayout();
            MainSC.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MainSC).EndInit();
            MainSC.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            RhsSC.Panel1.ResumeLayout(false);
            RhsSC.Panel2.ResumeLayout(false);
            RhsSC.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)RhsSC).EndInit();
            RhsSC.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private stigzler.Winforms.Base.UIElements.MenuStrip menuStrip1;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem darkModeToolStripMenuItem;
        private stigzler.Winforms.Base.UIElements.StatusStrip statusStrip1;
        private stigzler.Winforms.Base.UIElements.ListBox MainLB;
        private SplitContainer MainSC;
        private SplitContainer RhsSC;
        private stigzler.Winforms.Base.UIElements.PropertyGrid MainPG;
        private stigzler.Winforms.Base.UIElements.ListView MainLV;
        private stigzler.Winforms.Base.UIElements.FlowLayoutPanel flowLayoutPanel1;
        private stigzler.Winforms.Base.UIElements.Button LoadDatsBT;
        private stigzler.Winforms.Base.UIElements.FlowLayoutPanel flowLayoutPanel2;
        private stigzler.Winforms.Base.UIElements.Button button1;
        private stigzler.Winforms.Base.UIElements.Label label1;
    }
}
