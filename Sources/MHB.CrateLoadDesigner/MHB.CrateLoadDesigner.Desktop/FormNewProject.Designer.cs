
namespace MHB.CrateLoadDesigner.Desktop
{
    partial class FormNewProject
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbInputFilePath = new System.Windows.Forms.TextBox();
            this.bnOK = new System.Windows.Forms.Button();
            this.bnExplore = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.inputFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitHoriz = new System.Windows.Forms.SplitContainer();
            this.cbGlassType = new System.Windows.Forms.ComboBox();
            this.lbGlassType = new System.Windows.Forms.Label();
            this.tbProjectNumber = new System.Windows.Forms.TextBox();
            this.lbProjectNr = new System.Windows.Forms.Label();
            this.tbProjectName = new System.Windows.Forms.TextBox();
            this.lbProjectName = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageFrames = new System.Windows.Forms.TabPage();
            this.gridFrames = new SourceGrid.Grid();
            this.tabPageGlass = new System.Windows.Forms.TabPage();
            this.gridGlass = new SourceGrid.Grid();
            this.tabPageCratesFrame = new System.Windows.Forms.TabPage();
            this.gridCratesFrame = new SourceGrid.Grid();
            this.tabPageCrateGlass = new System.Windows.Forms.TabPage();
            this.gridCratesGlass = new SourceGrid.Grid();
            this.tabPageContainers = new System.Windows.Forms.TabPage();
            this.gridContainers = new SourceGrid.Grid();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitHoriz)).BeginInit();
            this.splitHoriz.Panel1.SuspendLayout();
            this.splitHoriz.Panel2.SuspendLayout();
            this.splitHoriz.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageFrames.SuspendLayout();
            this.tabPageGlass.SuspendLayout();
            this.tabPageCratesFrame.SuspendLayout();
            this.tabPageCrateGlass.SuspendLayout();
            this.tabPageContainers.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input file";
            // 
            // tbInputFilePath
            // 
            this.tbInputFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInputFilePath.Location = new System.Drawing.Point(98, 5);
            this.tbInputFilePath.Name = "tbInputFilePath";
            this.tbInputFilePath.Size = new System.Drawing.Size(579, 20);
            this.tbInputFilePath.TabIndex = 1;
            this.tbInputFilePath.TextChanged += new System.EventHandler(this.OnInputFilePathChanged);
            // 
            // bnOK
            // 
            this.bnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOK.Location = new System.Drawing.Point(722, 3);
            this.bnOK.Name = "bnOK";
            this.bnOK.Size = new System.Drawing.Size(75, 23);
            this.bnOK.TabIndex = 2;
            this.bnOK.Text = "OK";
            this.bnOK.UseVisualStyleBackColor = true;
            // 
            // bnExplore
            // 
            this.bnExplore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnExplore.Location = new System.Drawing.Point(683, 3);
            this.bnExplore.Name = "bnExplore";
            this.bnExplore.Size = new System.Drawing.Size(33, 23);
            this.bnExplore.TabIndex = 3;
            this.bnExplore.Text = "...";
            this.bnExplore.UseVisualStyleBackColor = true;
            this.bnExplore.Click += new System.EventHandler(this.OnExploreInputFolder);
            // 
            // bnCancel
            // 
            this.bnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Location = new System.Drawing.Point(722, 32);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 23);
            this.bnCancel.TabIndex = 4;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // inputFileDialog
            // 
            this.inputFileDialog.Filter = "Excel file (*.xlsx;*.xlsm)|*.xlsx;*.xlsm|All files (*.*)|*.*";
            this.inputFileDialog.FilterIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 428);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(800, 22);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // splitHoriz
            // 
            this.splitHoriz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitHoriz.Location = new System.Drawing.Point(0, 0);
            this.splitHoriz.Name = "splitHoriz";
            this.splitHoriz.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitHoriz.Panel1
            // 
            this.splitHoriz.Panel1.Controls.Add(this.cbGlassType);
            this.splitHoriz.Panel1.Controls.Add(this.lbGlassType);
            this.splitHoriz.Panel1.Controls.Add(this.tbProjectNumber);
            this.splitHoriz.Panel1.Controls.Add(this.lbProjectNr);
            this.splitHoriz.Panel1.Controls.Add(this.tbProjectName);
            this.splitHoriz.Panel1.Controls.Add(this.lbProjectName);
            this.splitHoriz.Panel1.Controls.Add(this.tbInputFilePath);
            this.splitHoriz.Panel1.Controls.Add(this.label1);
            this.splitHoriz.Panel1.Controls.Add(this.bnExplore);
            this.splitHoriz.Panel1.Controls.Add(this.bnCancel);
            this.splitHoriz.Panel1.Controls.Add(this.bnOK);
            // 
            // splitHoriz.Panel2
            // 
            this.splitHoriz.Panel2.Controls.Add(this.tabControl1);
            this.splitHoriz.Size = new System.Drawing.Size(800, 428);
            this.splitHoriz.SplitterDistance = 73;
            this.splitHoriz.TabIndex = 6;
            // 
            // cbGlassType
            // 
            this.cbGlassType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGlassType.FormattingEnabled = true;
            this.cbGlassType.Items.AddRange(new object[] {
            "Double Glass - Tempered",
            "Double Glass - Laminated",
            "Triple Glass - Tempered",
            "Triple Glass - Laminated"});
            this.cbGlassType.Location = new System.Drawing.Point(494, 34);
            this.cbGlassType.Name = "cbGlassType";
            this.cbGlassType.Size = new System.Drawing.Size(183, 21);
            this.cbGlassType.TabIndex = 10;
            this.cbGlassType.SelectedIndexChanged += new System.EventHandler(this.OnGlassTypeChanged);
            // 
            // lbGlassType
            // 
            this.lbGlassType.AutoSize = true;
            this.lbGlassType.Location = new System.Drawing.Point(431, 37);
            this.lbGlassType.Name = "lbGlassType";
            this.lbGlassType.Size = new System.Drawing.Size(56, 13);
            this.lbGlassType.TabIndex = 9;
            this.lbGlassType.Text = "Glass type";
            // 
            // tbProjectNumber
            // 
            this.tbProjectNumber.Location = new System.Drawing.Point(322, 34);
            this.tbProjectNumber.Name = "tbProjectNumber";
            this.tbProjectNumber.Size = new System.Drawing.Size(46, 20);
            this.tbProjectNumber.TabIndex = 8;
            this.tbProjectNumber.TextChanged += new System.EventHandler(this.OnProjectNameChanged);
            // 
            // lbProjectNr
            // 
            this.lbProjectNr.AutoSize = true;
            this.lbProjectNr.Location = new System.Drawing.Point(259, 37);
            this.lbProjectNr.Name = "lbProjectNr";
            this.lbProjectNr.Size = new System.Drawing.Size(57, 13);
            this.lbProjectNr.TabIndex = 7;
            this.lbProjectNr.Text = "Project Nr.";
            // 
            // tbProjectName
            // 
            this.tbProjectName.Location = new System.Drawing.Point(97, 34);
            this.tbProjectName.Name = "tbProjectName";
            this.tbProjectName.Size = new System.Drawing.Size(156, 20);
            this.tbProjectName.TabIndex = 6;
            this.tbProjectName.TextChanged += new System.EventHandler(this.OnProjectNameChanged);
            // 
            // lbProjectName
            // 
            this.lbProjectName.AutoSize = true;
            this.lbProjectName.Location = new System.Drawing.Point(12, 37);
            this.lbProjectName.Name = "lbProjectName";
            this.lbProjectName.Size = new System.Drawing.Size(69, 13);
            this.lbProjectName.TabIndex = 5;
            this.lbProjectName.Text = "Project name";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageFrames);
            this.tabControl1.Controls.Add(this.tabPageGlass);
            this.tabControl1.Controls.Add(this.tabPageCratesFrame);
            this.tabControl1.Controls.Add(this.tabPageCrateGlass);
            this.tabControl1.Controls.Add(this.tabPageContainers);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 351);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageFrames
            // 
            this.tabPageFrames.Controls.Add(this.gridFrames);
            this.tabPageFrames.Location = new System.Drawing.Point(4, 22);
            this.tabPageFrames.Name = "tabPageFrames";
            this.tabPageFrames.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFrames.Size = new System.Drawing.Size(792, 325);
            this.tabPageFrames.TabIndex = 0;
            this.tabPageFrames.Text = "Frames";
            this.tabPageFrames.UseVisualStyleBackColor = true;
            // 
            // gridFrames
            // 
            this.gridFrames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFrames.EnableSort = false;
            this.gridFrames.Location = new System.Drawing.Point(3, 3);
            this.gridFrames.Name = "gridFrames";
            this.gridFrames.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridFrames.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridFrames.Size = new System.Drawing.Size(786, 319);
            this.gridFrames.TabIndex = 0;
            this.gridFrames.TabStop = true;
            this.gridFrames.ToolTipText = "";
            // 
            // tabPageGlass
            // 
            this.tabPageGlass.Controls.Add(this.gridGlass);
            this.tabPageGlass.Location = new System.Drawing.Point(4, 22);
            this.tabPageGlass.Name = "tabPageGlass";
            this.tabPageGlass.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGlass.Size = new System.Drawing.Size(792, 325);
            this.tabPageGlass.TabIndex = 1;
            this.tabPageGlass.Text = "Glass";
            this.tabPageGlass.UseVisualStyleBackColor = true;
            // 
            // gridGlass
            // 
            this.gridGlass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridGlass.EnableSort = false;
            this.gridGlass.Location = new System.Drawing.Point(3, 3);
            this.gridGlass.Name = "gridGlass";
            this.gridGlass.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridGlass.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridGlass.Size = new System.Drawing.Size(786, 319);
            this.gridGlass.TabIndex = 0;
            this.gridGlass.TabStop = true;
            this.gridGlass.ToolTipText = "";
            // 
            // tabPageCratesFrame
            // 
            this.tabPageCratesFrame.Controls.Add(this.gridCratesFrame);
            this.tabPageCratesFrame.Location = new System.Drawing.Point(4, 22);
            this.tabPageCratesFrame.Name = "tabPageCratesFrame";
            this.tabPageCratesFrame.Size = new System.Drawing.Size(792, 325);
            this.tabPageCratesFrame.TabIndex = 2;
            this.tabPageCratesFrame.Text = "Crates (Frames)";
            this.tabPageCratesFrame.UseVisualStyleBackColor = true;
            // 
            // gridCratesFrame
            // 
            this.gridCratesFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCratesFrame.EnableSort = false;
            this.gridCratesFrame.Location = new System.Drawing.Point(0, 0);
            this.gridCratesFrame.Name = "gridCratesFrame";
            this.gridCratesFrame.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridCratesFrame.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridCratesFrame.Size = new System.Drawing.Size(792, 325);
            this.gridCratesFrame.TabIndex = 0;
            this.gridCratesFrame.TabStop = true;
            this.gridCratesFrame.ToolTipText = "";
            // 
            // tabPageCrateGlass
            // 
            this.tabPageCrateGlass.Controls.Add(this.gridCratesGlass);
            this.tabPageCrateGlass.Location = new System.Drawing.Point(4, 22);
            this.tabPageCrateGlass.Name = "tabPageCrateGlass";
            this.tabPageCrateGlass.Size = new System.Drawing.Size(792, 325);
            this.tabPageCrateGlass.TabIndex = 3;
            this.tabPageCrateGlass.Text = "Crates (Glass)";
            this.tabPageCrateGlass.UseVisualStyleBackColor = true;
            // 
            // gridCratesGlass
            // 
            this.gridCratesGlass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCratesGlass.EnableSort = false;
            this.gridCratesGlass.Location = new System.Drawing.Point(0, 0);
            this.gridCratesGlass.Name = "gridCratesGlass";
            this.gridCratesGlass.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridCratesGlass.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridCratesGlass.Size = new System.Drawing.Size(792, 325);
            this.gridCratesGlass.TabIndex = 0;
            this.gridCratesGlass.TabStop = true;
            this.gridCratesGlass.ToolTipText = "";
            // 
            // tabPageContainers
            // 
            this.tabPageContainers.Controls.Add(this.gridContainers);
            this.tabPageContainers.Location = new System.Drawing.Point(4, 22);
            this.tabPageContainers.Name = "tabPageContainers";
            this.tabPageContainers.Size = new System.Drawing.Size(792, 325);
            this.tabPageContainers.TabIndex = 4;
            this.tabPageContainers.Text = "Containers";
            this.tabPageContainers.UseVisualStyleBackColor = true;
            // 
            // gridContainers
            // 
            this.gridContainers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridContainers.EnableSort = false;
            this.gridContainers.Location = new System.Drawing.Point(0, 0);
            this.gridContainers.Name = "gridContainers";
            this.gridContainers.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridContainers.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridContainers.Size = new System.Drawing.Size(792, 325);
            this.gridContainers.TabIndex = 0;
            this.gridContainers.TabStop = true;
            this.gridContainers.ToolTipText = "";
            // 
            // FormNewProject
            // 
            this.AcceptButton = this.bnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitHoriz);
            this.Controls.Add(this.statusStrip);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewProject";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "New project...";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitHoriz.Panel1.ResumeLayout(false);
            this.splitHoriz.Panel1.PerformLayout();
            this.splitHoriz.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitHoriz)).EndInit();
            this.splitHoriz.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageFrames.ResumeLayout(false);
            this.tabPageGlass.ResumeLayout(false);
            this.tabPageCratesFrame.ResumeLayout(false);
            this.tabPageCrateGlass.ResumeLayout(false);
            this.tabPageContainers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbInputFilePath;
        private System.Windows.Forms.Button bnOK;
        private System.Windows.Forms.Button bnExplore;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.OpenFileDialog inputFileDialog;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.SplitContainer splitHoriz;
        private System.Windows.Forms.TextBox tbProjectName;
        private System.Windows.Forms.Label lbProjectName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageFrames;
        private SourceGrid.Grid gridFrames;
        private System.Windows.Forms.TabPage tabPageGlass;
        private SourceGrid.Grid gridGlass;
        private System.Windows.Forms.TabPage tabPageCratesFrame;
        private SourceGrid.Grid gridCratesFrame;
        private System.Windows.Forms.TabPage tabPageCrateGlass;
        private SourceGrid.Grid gridCratesGlass;
        private System.Windows.Forms.TabPage tabPageContainers;
        private SourceGrid.Grid gridContainers;
        private System.Windows.Forms.TextBox tbProjectNumber;
        private System.Windows.Forms.Label lbProjectNr;
        private System.Windows.Forms.ComboBox cbGlassType;
        private System.Windows.Forms.Label lbGlassType;
    }
}