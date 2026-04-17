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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            MainMS = new stigzler.Winforms.Base.UIElements.MenuStrip();
            viewToolStripMenuItem = new ToolStripMenuItem();
            darkModeToolStripMenuItem = new ToolStripMenuItem();
            VersionLB = new stigzler.Winforms.Base.ToolStripElements.Label();
            MainSC = new SplitContainer();
            ListboxPN = new stigzler.Winforms.Base.UIElements.Panel();
            MainLB = new stigzler.Winforms.Base.UIElements.ListBox();
            flowLayoutPanel1 = new stigzler.Winforms.Base.UIElements.FlowLayoutPanel();
            LoadDatsBT = new stigzler.Winforms.Base.UIElements.Button();
            PriorityUpBT = new stigzler.Winforms.Base.UIElements.Button();
            PriorityDownBT = new stigzler.Winforms.Base.UIElements.Button();
            RhsSC = new SplitContainer();
            PgPN = new stigzler.Winforms.Base.UIElements.Panel();
            MainPG = new stigzler.Winforms.Base.UIElements.PropertyGrid();
            label1 = new Label();
            groupBox2 = new stigzler.Winforms.Base.UIElements.GroupBox();
            StripTagsChB = new stigzler.Winforms.Base.UIElements.CheckBox();
            MainTT = new stigzler.Winforms.Base.UIElements.ToolTip(components);
            AlsoTagDescChB = new stigzler.Winforms.Base.UIElements.CheckBox();
            OpenFileAfterCreatedChB = new stigzler.Winforms.Base.UIElements.CheckBox();
            label7 = new stigzler.Winforms.Base.UIElements.Label();
            MethodCB = new stigzler.Winforms.Base.UIElements.ComboBox();
            TagPositionCB = new stigzler.Winforms.Base.UIElements.ComboBox();
            label6 = new stigzler.Winforms.Base.UIElements.Label();
            WarningLB = new Label();
            groupBox1 = new stigzler.Winforms.Base.UIElements.GroupBox();
            label5 = new stigzler.Winforms.Base.UIElements.Label();
            MergeDatCategoryTB = new stigzler.Winforms.Base.UIElements.TextBox();
            label4 = new stigzler.Winforms.Base.UIElements.Label();
            MergeDatAuthorTB = new stigzler.Winforms.Base.UIElements.TextBox();
            label3 = new stigzler.Winforms.Base.UIElements.Label();
            label2 = new stigzler.Winforms.Base.UIElements.Label();
            MergeDatDescTB = new stigzler.Winforms.Base.UIElements.TextBox();
            MergeDatNameTB = new stigzler.Winforms.Base.UIElements.TextBox();
            flowLayoutPanel2 = new stigzler.Winforms.Base.UIElements.FlowLayoutPanel();
            MergeBT = new stigzler.Winforms.Base.UIElements.Button();
            MainMS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MainSC).BeginInit();
            MainSC.Panel1.SuspendLayout();
            MainSC.Panel2.SuspendLayout();
            MainSC.SuspendLayout();
            ListboxPN.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)RhsSC).BeginInit();
            RhsSC.Panel1.SuspendLayout();
            RhsSC.Panel2.SuspendLayout();
            RhsSC.SuspendLayout();
            PgPN.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // MainMS
            // 
            MainMS.BackColor = Color.FromArgb(25, 25, 25);
            MainMS.ForeColor = Color.FromArgb(220, 220, 220);
            MainMS.Items.AddRange(new ToolStripItem[] { viewToolStripMenuItem, VersionLB });
            MainMS.Location = new Point(4, 4);
            MainMS.Name = "MainMS";
            MainMS.ShowItemToolTips = true;
            MainMS.Size = new Size(676, 25);
            MainMS.TabIndex = 0;
            MainMS.Text = "menuStrip1";
            MainMS.ToolTip = null;
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
            // VersionLB
            // 
            VersionLB.Alignment = ToolStripItemAlignment.Right;
            VersionLB.Name = "VersionLB";
            VersionLB.Size = new Size(43, 18);
            VersionLB.Text = "V0.0.0";
            VersionLB.ToolTipImage = null;
            VersionLB.ToolTipText = null;
            VersionLB.ToolTipTitle = null;
            // 
            // MainSC
            // 
            MainSC.Dock = DockStyle.Fill;
            MainSC.Location = new Point(4, 29);
            MainSC.Name = "MainSC";
            // 
            // MainSC.Panel1
            // 
            MainSC.Panel1.BackColor = Color.FromArgb(35, 35, 35);
            MainSC.Panel1.Controls.Add(ListboxPN);
            MainSC.Panel1.Controls.Add(flowLayoutPanel1);
            MainSC.Panel1.ForeColor = Color.FromArgb(220, 220, 220);
            // 
            // MainSC.Panel2
            // 
            MainSC.Panel2.BackColor = Color.FromArgb(35, 35, 35);
            MainSC.Panel2.Controls.Add(RhsSC);
            MainSC.Panel2.ForeColor = Color.FromArgb(220, 220, 220);
            MainSC.Size = new Size(676, 849);
            MainSC.SplitterDistance = 222;
            MainSC.TabIndex = 3;
            // 
            // ListboxPN
            // 
            ListboxPN.BackColor = Color.FromArgb(35, 35, 35);
            ListboxPN.BackgroundShadeFactor = 1D;
            ListboxPN.BorderStyle = BorderStyle.FixedSingle;
            ListboxPN.Controls.Add(MainLB);
            ListboxPN.Dock = DockStyle.Fill;
            ListboxPN.ForeColor = Color.FromArgb(220, 220, 220);
            ListboxPN.Location = new Point(0, 0);
            ListboxPN.Margin = new Padding(2, 3, 2, 3);
            ListboxPN.Name = "ListboxPN";
            ListboxPN.Padding = new Padding(3);
            ListboxPN.Size = new Size(222, 814);
            ListboxPN.TabIndex = 3;
            // 
            // MainLB
            // 
            MainLB.AllowReorder = false;
            MainLB.BackColor = Color.FromArgb(35, 35, 35);
            MainLB.BorderStyle = BorderStyle.None;
            MainLB.Dock = DockStyle.Fill;
            MainLB.ForeColor = Color.FromArgb(220, 220, 220);
            MainLB.FormattingEnabled = true;
            MainLB.Location = new Point(3, 3);
            MainLB.Name = "MainLB";
            MainLB.Size = new Size(214, 806);
            MainLB.TabIndex = 2;
            MainLB.SelectedIndexChanged += MainLB_SelectedIndexChanged;
            MainLB.SelectedValueChanged += MainLB_SelectedValueChanged;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.BackColor = Color.FromArgb(35, 35, 35);
            flowLayoutPanel1.BackgroundShadeFactor = 1D;
            flowLayoutPanel1.Controls.Add(LoadDatsBT);
            flowLayoutPanel1.Controls.Add(PriorityUpBT);
            flowLayoutPanel1.Controls.Add(PriorityDownBT);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.ForeColor = Color.FromArgb(220, 220, 220);
            flowLayoutPanel1.Location = new Point(0, 814);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(222, 35);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // LoadDatsBT
            // 
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
            LoadDatsBT.Location = new Point(140, 3);
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
            // PriorityUpBT
            // 
            PriorityUpBT.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PriorityUpBT.BackColor = Color.FromArgb(55, 55, 55);
            PriorityUpBT.DefocusOnClick = true;
            PriorityUpBT.DisabledBackColor = Color.FromArgb(30, 30, 30);
            PriorityUpBT.DisabledBorderColor = Color.FromArgb(60, 60, 60);
            PriorityUpBT.DisabledForeColor = Color.FromArgb(125, 125, 125);
            PriorityUpBT.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
            PriorityUpBT.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 102, 215);
            PriorityUpBT.FlatStyle = FlatStyle.Flat;
            PriorityUpBT.ForeColor = Color.FromArgb(240, 240, 240);
            PriorityUpBT.Image = Properties.Resources.arrow_090;
            PriorityUpBT.Location = new Point(105, 3);
            PriorityUpBT.Name = "PriorityUpBT";
            PriorityUpBT.Size = new Size(29, 29);
            PriorityUpBT.TabIndex = 1;
            PriorityUpBT.ToolTip = null;
            PriorityUpBT.ToolTipImage = null;
            PriorityUpBT.ToolTipText = "Used in the Merge operation. Higher priority = preferred Game entry in final dat.";
            PriorityUpBT.ToolTipTitle = "Move Prioriry Up";
            PriorityUpBT.UseVisualStyleBackColor = false;
            PriorityUpBT.Click += PriorityUpBT_Click;
            // 
            // PriorityDownBT
            // 
            PriorityDownBT.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PriorityDownBT.BackColor = Color.FromArgb(55, 55, 55);
            PriorityDownBT.DefocusOnClick = true;
            PriorityDownBT.DisabledBackColor = Color.FromArgb(30, 30, 30);
            PriorityDownBT.DisabledBorderColor = Color.FromArgb(60, 60, 60);
            PriorityDownBT.DisabledForeColor = Color.FromArgb(125, 125, 125);
            PriorityDownBT.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
            PriorityDownBT.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 102, 215);
            PriorityDownBT.FlatStyle = FlatStyle.Flat;
            PriorityDownBT.ForeColor = Color.FromArgb(240, 240, 240);
            PriorityDownBT.Image = Properties.Resources.arrow_270;
            PriorityDownBT.Location = new Point(70, 3);
            PriorityDownBT.Name = "PriorityDownBT";
            PriorityDownBT.Size = new Size(29, 29);
            PriorityDownBT.TabIndex = 2;
            PriorityDownBT.ToolTip = null;
            PriorityDownBT.ToolTipImage = null;
            PriorityDownBT.ToolTipText = "Used in the Merge operation. Lower priority = lesser preferred Game entry in final dat.";
            PriorityDownBT.ToolTipTitle = "Move Prioriry Down";
            PriorityDownBT.UseVisualStyleBackColor = false;
            PriorityDownBT.Click += PriorityDownBT_Click;
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
            RhsSC.Panel1.Controls.Add(PgPN);
            RhsSC.Panel1.Controls.Add(label1);
            RhsSC.Panel1.ForeColor = Color.FromArgb(220, 220, 220);
            // 
            // RhsSC.Panel2
            // 
            RhsSC.Panel2.BackColor = Color.FromArgb(35, 35, 35);
            RhsSC.Panel2.Controls.Add(groupBox2);
            RhsSC.Panel2.Controls.Add(WarningLB);
            RhsSC.Panel2.Controls.Add(groupBox1);
            RhsSC.Panel2.Controls.Add(flowLayoutPanel2);
            RhsSC.Panel2.ForeColor = Color.FromArgb(220, 220, 220);
            RhsSC.Panel2.Padding = new Padding(6);
            RhsSC.Size = new Size(450, 849);
            RhsSC.SplitterDistance = 274;
            RhsSC.TabIndex = 0;
            // 
            // PgPN
            // 
            PgPN.BackColor = Color.FromArgb(35, 35, 35);
            PgPN.BackgroundShadeFactor = 1D;
            PgPN.Controls.Add(MainPG);
            PgPN.Dock = DockStyle.Fill;
            PgPN.ForeColor = Color.FromArgb(220, 220, 220);
            PgPN.Location = new Point(0, 29);
            PgPN.Margin = new Padding(2);
            PgPN.Name = "PgPN";
            PgPN.Padding = new Padding(3);
            PgPN.Size = new Size(450, 245);
            PgPN.TabIndex = 2;
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
            MainPG.Location = new Point(3, 3);
            MainPG.Margin = new Padding(5);
            MainPG.Name = "MainPG";
            MainPG.Size = new Size(444, 239);
            MainPG.TabIndex = 0;
            MainPG.ToolbarVisible = false;
            MainPG.ViewBackColor = Color.FromArgb(30, 30, 30);
            MainPG.ViewForeColor = Color.FromArgb(220, 220, 220);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(6);
            label1.Size = new Size(83, 29);
            label1.TabIndex = 1;
            label1.Text = "Dat Details";
            // 
            // groupBox2
            // 
            groupBox2.BorderColor = Color.FromArgb(100, 100, 100);
            groupBox2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            groupBox2.BorderThickness = 1;
            groupBox2.Controls.Add(StripTagsChB);
            groupBox2.Controls.Add(AlsoTagDescChB);
            groupBox2.Controls.Add(OpenFileAfterCreatedChB);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(MethodCB);
            groupBox2.Controls.Add(TagPositionCB);
            groupBox2.Controls.Add(label6);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.ForeColor = Color.FromArgb(220, 220, 220);
            groupBox2.Location = new Point(6, 173);
            groupBox2.Margin = new Padding(2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2);
            groupBox2.Size = new Size(438, 175);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Merge Settings";
            groupBox2.TitleColor = Color.FromArgb(220, 220, 220);
            // 
            // StripTagsChB
            // 
            StripTagsChB.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            StripTagsChB.Location = new Point(117, 141);
            StripTagsChB.Name = "StripTagsChB";
            StripTagsChB.OverrideTheme = false;
            StripTagsChB.Size = new Size(307, 24);
            StripTagsChB.TabIndex = 9;
            StripTagsChB.Text = "Strip Tags for matching";
            StripTagsChB.ToolTip = MainTT;
            StripTagsChB.ToolTipHorizontalAlignment = HorizontalAlignment.Right;
            StripTagsChB.ToolTipImage = null;
            StripTagsChB.ToolTipText = null;
            StripTagsChB.ToolTipTitle = null;
            StripTagsChB.UseVisualStyleBackColor = true;
            // 
            // MainTT
            // 
            MainTT.ActiveControl = null;
            MainTT.AutoPopDelay = 5000;
            MainTT.AutoTitleLength = 30;
            MainTT.BackColor = SystemColors.Control;
            MainTT.BorderColor = SystemColors.ActiveBorder;
            MainTT.DefaultImageSize = new Size(16, 16);
            MainTT.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MainTT.ForeColor = SystemColors.ControlText;
            MainTT.GrowWidthForHeader = true;
            MainTT.Image = (Image)resources.GetObject("MainTT.Image");
            MainTT.InitialDelay = 1500;
            MainTT.MaxHeight = 0;
            MainTT.Offset = new Point(0, 0);
            MainTT.OwnerDraw = true;
            MainTT.PanelPadding = 4;
            MainTT.ReshowDelay = 100;
            MainTT.ResizeImage = true;
            MainTT.ShowFor = 5000;
            MainTT.TitleBackground = SystemColors.ControlLight;
            MainTT.TitleForeground = SystemColors.InfoText;
            MainTT.ToolTipText = "Information here..";
            MainTT.ToolTipTitle = "Info";
            MainTT.Width = 128;
            // 
            // AlsoTagDescChB
            // 
            AlsoTagDescChB.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            AlsoTagDescChB.Location = new Point(117, 81);
            AlsoTagDescChB.Name = "AlsoTagDescChB";
            AlsoTagDescChB.OverrideTheme = false;
            AlsoTagDescChB.Size = new Size(307, 24);
            AlsoTagDescChB.TabIndex = 8;
            AlsoTagDescChB.Tag = "If a tagging Method is selected whether to also tag the description element";
            AlsoTagDescChB.Text = "Also Tag Description";
            AlsoTagDescChB.ToolTip = MainTT;
            AlsoTagDescChB.ToolTipHorizontalAlignment = HorizontalAlignment.Right;
            AlsoTagDescChB.ToolTipImage = null;
            AlsoTagDescChB.ToolTipText = null;
            AlsoTagDescChB.ToolTipTitle = null;
            AlsoTagDescChB.UseVisualStyleBackColor = true;
            AlsoTagDescChB.CheckedChanged += AlsoTagDescChB_CheckedChanged;
            // 
            // OpenFileAfterCreatedChB
            // 
            OpenFileAfterCreatedChB.Location = new Point(117, 111);
            OpenFileAfterCreatedChB.Name = "OpenFileAfterCreatedChB";
            OpenFileAfterCreatedChB.OverrideTheme = false;
            OpenFileAfterCreatedChB.Size = new Size(305, 24);
            OpenFileAfterCreatedChB.TabIndex = 5;
            OpenFileAfterCreatedChB.Text = "Open file after created";
            OpenFileAfterCreatedChB.ToolTip = MainTT;
            OpenFileAfterCreatedChB.ToolTipHorizontalAlignment = HorizontalAlignment.Right;
            OpenFileAfterCreatedChB.ToolTipImage = null;
            OpenFileAfterCreatedChB.ToolTipText = null;
            OpenFileAfterCreatedChB.ToolTipTitle = null;
            OpenFileAfterCreatedChB.UseVisualStyleBackColor = true;
            OpenFileAfterCreatedChB.CheckedChanged += OpenFileAfterCreatedChB_CheckedChanged;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.FontStyle = FontStyle.Regular;
            label7.ForeColor = Color.FromArgb(220, 220, 220);
            label7.Location = new Point(6, 49);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.ScaleFont = 100;
            label7.Size = new Size(100, 29);
            label7.TabIndex = 3;
            label7.Text = "Tag Position:";
            label7.TextAlign = ContentAlignment.MiddleRight;
            label7.ToolTip = MainTT;
            label7.ToolTipHorizontalAlignment = HorizontalAlignment.Right;
            label7.ToolTipImage = null;
            label7.ToolTipText = null;
            label7.ToolTipTitle = null;
            // 
            // MethodCB
            // 
            MethodCB.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            MethodCB.ArrowColor = Color.FromArgb(230, 230, 230);
            MethodCB.BackColor = Color.FromArgb(30, 30, 30);
            MethodCB.BorderColor = Color.FromArgb(100, 100, 100);
            MethodCB.ButtonColor = Color.FromArgb(60, 60, 60);
            MethodCB.DropDownStyle = ComboBoxStyle.DropDownList;
            MethodCB.FlatStyle = FlatStyle.Flat;
            MethodCB.ForeColor = Color.FromArgb(220, 220, 220);
            MethodCB.FormattingEnabled = true;
            MethodCB.ImageSize = new Size(0, 0);
            MethodCB.Location = new Point(117, 22);
            MethodCB.Margin = new Padding(2);
            MethodCB.Name = "MethodCB";
            MethodCB.SelectedColor = SystemColors.Highlight;
            MethodCB.Size = new Size(307, 25);
            MethodCB.TabIndex = 1;
            MethodCB.TextEmphasisColor = Color.White;
            MethodCB.TextEmphasisFont = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            // 
            // TagPositionCB
            // 
            TagPositionCB.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TagPositionCB.ArrowColor = Color.FromArgb(230, 230, 230);
            TagPositionCB.BackColor = Color.FromArgb(30, 30, 30);
            TagPositionCB.BorderColor = Color.FromArgb(100, 100, 100);
            TagPositionCB.ButtonColor = Color.FromArgb(60, 60, 60);
            TagPositionCB.DropDownStyle = ComboBoxStyle.DropDownList;
            TagPositionCB.FlatStyle = FlatStyle.Flat;
            TagPositionCB.ForeColor = Color.FromArgb(220, 220, 220);
            TagPositionCB.FormattingEnabled = true;
            TagPositionCB.ImageSize = new Size(0, 0);
            TagPositionCB.Location = new Point(117, 51);
            TagPositionCB.Margin = new Padding(2);
            TagPositionCB.Name = "TagPositionCB";
            TagPositionCB.SelectedColor = SystemColors.Highlight;
            TagPositionCB.Size = new Size(307, 25);
            TagPositionCB.TabIndex = 4;
            TagPositionCB.TextEmphasisColor = Color.White;
            TagPositionCB.TextEmphasisFont = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.FontStyle = FontStyle.Regular;
            label6.ForeColor = Color.FromArgb(220, 220, 220);
            label6.Location = new Point(6, 20);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.ScaleFont = 100;
            label6.Size = new Size(100, 29);
            label6.TabIndex = 0;
            label6.Text = "Method:";
            label6.TextAlign = ContentAlignment.MiddleRight;
            label6.ToolTip = MainTT;
            label6.ToolTipHorizontalAlignment = HorizontalAlignment.Right;
            label6.ToolTipImage = null;
            label6.ToolTipText = null;
            label6.ToolTipTitle = null;
            // 
            // WarningLB
            // 
            WarningLB.Dock = DockStyle.Bottom;
            WarningLB.Image = Properties.Resources.exclamation__frame;
            WarningLB.ImageAlign = ContentAlignment.MiddleRight;
            WarningLB.Location = new Point(6, 503);
            WarningLB.Margin = new Padding(2, 0, 2, 0);
            WarningLB.Name = "WarningLB";
            WarningLB.Padding = new Padding(2, 2, 2, 6);
            WarningLB.Size = new Size(438, 27);
            WarningLB.TabIndex = 2;
            WarningLB.Text = "Cannot proceed - all Dats must have a unique tag      ";
            WarningLB.TextAlign = ContentAlignment.MiddleRight;
            WarningLB.Visible = false;
            // 
            // groupBox1
            // 
            groupBox1.BorderColor = Color.FromArgb(100, 100, 100);
            groupBox1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            groupBox1.BorderThickness = 1;
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(MergeDatCategoryTB);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(MergeDatAuthorTB);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(MergeDatDescTB);
            groupBox1.Controls.Add(MergeDatNameTB);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.ForeColor = Color.FromArgb(220, 220, 220);
            groupBox1.Location = new Point(6, 6);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(438, 167);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Merged Dat Header Details";
            groupBox1.TitleColor = Color.FromArgb(220, 220, 220);
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.FontStyle = FontStyle.Regular;
            label5.ForeColor = Color.FromArgb(220, 220, 220);
            label5.Location = new Point(11, 124);
            label5.Name = "label5";
            label5.ScaleFont = 100;
            label5.Size = new Size(100, 23);
            label5.TabIndex = 7;
            label5.Text = "Category:";
            label5.TextAlign = ContentAlignment.MiddleRight;
            label5.ToolTip = MainTT;
            label5.ToolTipHorizontalAlignment = HorizontalAlignment.Right;
            label5.ToolTipImage = null;
            label5.ToolTipText = null;
            label5.ToolTipTitle = null;
            // 
            // MergeDatCategoryTB
            // 
            MergeDatCategoryTB.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            MergeDatCategoryTB.BackColor = Color.FromArgb(30, 30, 30);
            MergeDatCategoryTB.BorderStyle = BorderStyle.FixedSingle;
            MergeDatCategoryTB.Cue = null;
            MergeDatCategoryTB.Font = new Font("Segoe UI", 12F);
            MergeDatCategoryTB.FontStyle = FontStyle.Regular;
            MergeDatCategoryTB.ForeColor = Color.FromArgb(220, 220, 220);
            MergeDatCategoryTB.Location = new Point(117, 123);
            MergeDatCategoryTB.Name = "MergeDatCategoryTB";
            MergeDatCategoryTB.ScaleFont = 100;
            MergeDatCategoryTB.Size = new Size(307, 29);
            MergeDatCategoryTB.TabIndex = 6;
            MergeDatCategoryTB.TextChanged += MergeDatCategoryTB_TextChanged;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 12F);
            label4.FontStyle = FontStyle.Regular;
            label4.ForeColor = Color.FromArgb(220, 220, 220);
            label4.Location = new Point(13, 89);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.ScaleFont = 100;
            label4.Size = new Size(100, 29);
            label4.TabIndex = 5;
            label4.Text = "Author:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            label4.ToolTip = MainTT;
            label4.ToolTipHorizontalAlignment = HorizontalAlignment.Right;
            label4.ToolTipImage = null;
            label4.ToolTipText = null;
            label4.ToolTipTitle = null;
            // 
            // MergeDatAuthorTB
            // 
            MergeDatAuthorTB.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            MergeDatAuthorTB.BackColor = Color.FromArgb(30, 30, 30);
            MergeDatAuthorTB.BorderStyle = BorderStyle.FixedSingle;
            MergeDatAuthorTB.Cue = null;
            MergeDatAuthorTB.Font = new Font("Segoe UI", 12F);
            MergeDatAuthorTB.FontStyle = FontStyle.Regular;
            MergeDatAuthorTB.ForeColor = Color.FromArgb(220, 220, 220);
            MergeDatAuthorTB.Location = new Point(117, 89);
            MergeDatAuthorTB.Margin = new Padding(2);
            MergeDatAuthorTB.Name = "MergeDatAuthorTB";
            MergeDatAuthorTB.ScaleFont = 100;
            MergeDatAuthorTB.Size = new Size(307, 29);
            MergeDatAuthorTB.TabIndex = 4;
            MergeDatAuthorTB.TextChanged += MergeDatAuthorTB_TextChanged;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 12F);
            label3.FontStyle = FontStyle.Regular;
            label3.ForeColor = Color.FromArgb(220, 220, 220);
            label3.Location = new Point(13, 56);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.ScaleFont = 100;
            label3.Size = new Size(100, 29);
            label3.TabIndex = 3;
            label3.Text = "Description:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            label3.ToolTip = MainTT;
            label3.ToolTipHorizontalAlignment = HorizontalAlignment.Right;
            label3.ToolTipImage = null;
            label3.ToolTipText = null;
            label3.ToolTipTitle = null;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 12F);
            label2.FontStyle = FontStyle.Regular;
            label2.ForeColor = Color.FromArgb(220, 220, 220);
            label2.Location = new Point(13, 23);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.ScaleFont = 100;
            label2.Size = new Size(100, 29);
            label2.TabIndex = 2;
            label2.Text = "Name:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            label2.ToolTip = MainTT;
            label2.ToolTipHorizontalAlignment = HorizontalAlignment.Right;
            label2.ToolTipImage = null;
            label2.ToolTipText = null;
            label2.ToolTipTitle = null;
            // 
            // MergeDatDescTB
            // 
            MergeDatDescTB.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            MergeDatDescTB.BackColor = Color.FromArgb(30, 30, 30);
            MergeDatDescTB.BorderStyle = BorderStyle.FixedSingle;
            MergeDatDescTB.Cue = null;
            MergeDatDescTB.Font = new Font("Segoe UI", 12F);
            MergeDatDescTB.FontStyle = FontStyle.Regular;
            MergeDatDescTB.ForeColor = Color.FromArgb(220, 220, 220);
            MergeDatDescTB.Location = new Point(117, 56);
            MergeDatDescTB.Margin = new Padding(2);
            MergeDatDescTB.Name = "MergeDatDescTB";
            MergeDatDescTB.ScaleFont = 100;
            MergeDatDescTB.Size = new Size(307, 29);
            MergeDatDescTB.TabIndex = 1;
            MergeDatDescTB.TextChanged += MergeDatDescTB_TextChanged;
            // 
            // MergeDatNameTB
            // 
            MergeDatNameTB.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            MergeDatNameTB.BackColor = Color.FromArgb(30, 30, 30);
            MergeDatNameTB.BorderStyle = BorderStyle.FixedSingle;
            MergeDatNameTB.Cue = null;
            MergeDatNameTB.Font = new Font("Segoe UI", 12F);
            MergeDatNameTB.FontStyle = FontStyle.Regular;
            MergeDatNameTB.ForeColor = Color.FromArgb(220, 220, 220);
            MergeDatNameTB.Location = new Point(117, 23);
            MergeDatNameTB.Margin = new Padding(2);
            MergeDatNameTB.Name = "MergeDatNameTB";
            MergeDatNameTB.ScaleFont = 100;
            MergeDatNameTB.Size = new Size(307, 29);
            MergeDatNameTB.TabIndex = 0;
            MergeDatNameTB.TextChanged += MergeDatNameTB_TextChanged;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.BackColor = Color.FromArgb(35, 35, 35);
            flowLayoutPanel2.BackgroundShadeFactor = 1D;
            flowLayoutPanel2.Controls.Add(MergeBT);
            flowLayoutPanel2.Dock = DockStyle.Bottom;
            flowLayoutPanel2.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel2.ForeColor = Color.FromArgb(220, 220, 220);
            flowLayoutPanel2.Location = new Point(6, 530);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(438, 35);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // MergeBT
            // 
            MergeBT.AutoSize = true;
            MergeBT.BackColor = Color.FromArgb(55, 55, 55);
            MergeBT.DefocusOnClick = true;
            MergeBT.DisabledBackColor = Color.FromArgb(30, 30, 30);
            MergeBT.DisabledBorderColor = Color.FromArgb(60, 60, 60);
            MergeBT.DisabledForeColor = Color.FromArgb(125, 125, 125);
            MergeBT.Dock = DockStyle.Bottom;
            MergeBT.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
            MergeBT.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 102, 215);
            MergeBT.FlatStyle = FlatStyle.Flat;
            MergeBT.ForeColor = Color.FromArgb(240, 240, 240);
            MergeBT.Location = new Point(346, 3);
            MergeBT.Name = "MergeBT";
            MergeBT.Size = new Size(89, 29);
            MergeBT.TabIndex = 1;
            MergeBT.Text = "Merge Dats";
            MergeBT.ToolTip = null;
            MergeBT.ToolTipImage = null;
            MergeBT.ToolTipText = null;
            MergeBT.ToolTipTitle = null;
            MergeBT.UseVisualStyleBackColor = false;
            MergeBT.Click += MergeBT_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 882);
            Controls.Add(MainSC);
            Controls.Add(MainMS);
            DarkMode = true;
            DoubleBuffered = true;
            ForeColor = Color.FromArgb(220, 220, 220);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = MainMS;
            MinimumSize = new Size(700, 650);
            Name = "Main";
            Padding = new Padding(4);
            RememberFormState = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MergeDatRom";
            ToolTip = MainTT;
            FormClosing += Main_FormClosing;
            Load += Main_Load;
            MainMS.ResumeLayout(false);
            MainMS.PerformLayout();
            MainSC.Panel1.ResumeLayout(false);
            MainSC.Panel1.PerformLayout();
            MainSC.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MainSC).EndInit();
            MainSC.ResumeLayout(false);
            ListboxPN.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            RhsSC.Panel1.ResumeLayout(false);
            RhsSC.Panel1.PerformLayout();
            RhsSC.Panel2.ResumeLayout(false);
            RhsSC.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)RhsSC).EndInit();
            RhsSC.ResumeLayout(false);
            PgPN.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private stigzler.Winforms.Base.UIElements.MenuStrip MainMS;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem darkModeToolStripMenuItem;
        private stigzler.Winforms.Base.UIElements.ListBox MainLB;
        private SplitContainer MainSC;
        private SplitContainer RhsSC;
        private stigzler.Winforms.Base.UIElements.PropertyGrid MainPG;
        private stigzler.Winforms.Base.UIElements.FlowLayoutPanel flowLayoutPanel1;
        private stigzler.Winforms.Base.UIElements.Button LoadDatsBT;
        private stigzler.Winforms.Base.UIElements.FlowLayoutPanel flowLayoutPanel2;
        private stigzler.Winforms.Base.UIElements.Button MergeBT;
        private stigzler.Winforms.Base.UIElements.Button PriorityUpBT;
        private stigzler.Winforms.Base.UIElements.Button PriorityDownBT;
        private stigzler.Winforms.Base.UIElements.ToolTip MainTT;
        private stigzler.Winforms.Base.UIElements.Panel ListboxPN;
        private Label label1;
        private stigzler.Winforms.Base.UIElements.Panel PgPN;
        private stigzler.Winforms.Base.UIElements.GroupBox groupBox1;
        private stigzler.Winforms.Base.UIElements.TextBox MergeDatDescTB;
        private stigzler.Winforms.Base.UIElements.TextBox MergeDatNameTB;
        private stigzler.Winforms.Base.UIElements.Label label4;
        private stigzler.Winforms.Base.UIElements.TextBox MergeDatAuthorTB;
        private stigzler.Winforms.Base.UIElements.Label label3;
        private stigzler.Winforms.Base.UIElements.Label label2;
        private Label WarningLB;
        private stigzler.Winforms.Base.UIElements.GroupBox groupBox2;
        private stigzler.Winforms.Base.UIElements.ComboBox MethodCB;
        private stigzler.Winforms.Base.UIElements.Label label6;
        private stigzler.Winforms.Base.UIElements.ComboBox TagPositionCB;
        private stigzler.Winforms.Base.UIElements.Label label7;
        private stigzler.Winforms.Base.UIElements.TextBox MergeDatCategoryTB;
        private stigzler.Winforms.Base.UIElements.Label label5;
        private stigzler.Winforms.Base.UIElements.CheckBox AlsoTagDescChB;
        private stigzler.Winforms.Base.UIElements.CheckBox OpenFileAfterCreatedChB;
        private stigzler.Winforms.Base.ToolStripElements.Label VersionLB;
        private stigzler.Winforms.Base.UIElements.CheckBox StripTagsChB;
    }
}
