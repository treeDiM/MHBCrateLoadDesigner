
namespace MHB.CrateLoadDesigner.Desktop
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.toolStripMIFile = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMIExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMIOutputs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMITableOfContents = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMIWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMIInputs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMIFrameCrates = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMIGlassCrates = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMIContainers = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.inputFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.outputFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockPanel
            // 
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.DockBackColor = System.Drawing.SystemColors.Control;
            this.dockPanel.Location = new System.Drawing.Point(0, 24);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.Size = new System.Drawing.Size(800, 426);
            this.dockPanel.TabIndex = 0;
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMIFile,
            this.toolStripMIOutputs,
            this.helpToolStripMenuItem,
            this.toolStripMIWindow});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(800, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStripMain";
            // 
            // toolStripMIFile
            // 
            this.toolStripMIFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator2,
            this.closeToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMIExit});
            this.toolStripMIFile.Name = "toolStripMIFile";
            this.toolStripMIFile.Size = new System.Drawing.Size(37, 20);
            this.toolStripMIFile.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.newToolStripMenuItem.Text = "New...";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.OnFileNew);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OnFileOpen);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.OnFileSave);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(104, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseAllForms);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(104, 6);
            // 
            // toolStripMIExit
            // 
            this.toolStripMIExit.Name = "toolStripMIExit";
            this.toolStripMIExit.Size = new System.Drawing.Size(107, 22);
            this.toolStripMIExit.Text = "Exit";
            this.toolStripMIExit.Click += new System.EventHandler(this.OnExit);
            // 
            // toolStripMIOutputs
            // 
            this.toolStripMIOutputs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMITableOfContents});
            this.toolStripMIOutputs.Name = "toolStripMIOutputs";
            this.toolStripMIOutputs.Size = new System.Drawing.Size(62, 20);
            this.toolStripMIOutputs.Text = "Outputs";
            // 
            // toolStripMITableOfContents
            // 
            this.toolStripMITableOfContents.Name = "toolStripMITableOfContents";
            this.toolStripMITableOfContents.Size = new System.Drawing.Size(164, 22);
            this.toolStripMITableOfContents.Text = "Table of contents";
            this.toolStripMITableOfContents.Click += new System.EventHandler(this.OnGenerateTableOfContents);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.OnAbout);
            // 
            // toolStripMIWindow
            // 
            this.toolStripMIWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMIInputs,
            this.toolStripMIFrameCrates,
            this.toolStripMIGlassCrates,
            this.toolStripMIContainers});
            this.toolStripMIWindow.Name = "toolStripMIWindow";
            this.toolStripMIWindow.Size = new System.Drawing.Size(63, 20);
            this.toolStripMIWindow.Text = "Window";
            // 
            // toolStripMIInputs
            // 
            this.toolStripMIInputs.Name = "toolStripMIInputs";
            this.toolStripMIInputs.Size = new System.Drawing.Size(180, 22);
            this.toolStripMIInputs.Text = "Inputs";
            this.toolStripMIInputs.Click += new System.EventHandler(this.ShowFormInputs);
            // 
            // toolStripMIFrameCrates
            // 
            this.toolStripMIFrameCrates.Name = "toolStripMIFrameCrates";
            this.toolStripMIFrameCrates.Size = new System.Drawing.Size(180, 22);
            this.toolStripMIFrameCrates.Text = "Frame crates";
            this.toolStripMIFrameCrates.Click += new System.EventHandler(this.ShowFormFrameCrates);
            // 
            // toolStripMIGlassCrates
            // 
            this.toolStripMIGlassCrates.Name = "toolStripMIGlassCrates";
            this.toolStripMIGlassCrates.Size = new System.Drawing.Size(180, 22);
            this.toolStripMIGlassCrates.Text = "Glass crates";
            this.toolStripMIGlassCrates.Click += new System.EventHandler(this.ShowFormGlassCrates);
            // 
            // toolStripMIContainers
            // 
            this.toolStripMIContainers.Name = "toolStripMIContainers";
            this.toolStripMIContainers.Size = new System.Drawing.Size(180, 22);
            this.toolStripMIContainers.Text = "Containers";
            this.toolStripMIContainers.Click += new System.EventHandler(this.ShowFormContainers);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // inputFileDialog
            // 
            this.inputFileDialog.FileName = "inputFileDialog";
            // 
            // outputFileDialog
            // 
            this.outputFileDialog.Filter = "Microsoft Excel (*.xlsx)|*.xlsx";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormMain";
            this.Text = "MHB Crate load designer";
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem toolStripMIFile;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem toolStripMIOutputs;
        private System.Windows.Forms.OpenFileDialog inputFileDialog;
        private System.Windows.Forms.SaveFileDialog outputFileDialog;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMIExit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMIWindow;
        private System.Windows.Forms.ToolStripMenuItem toolStripMIInputs;
        private System.Windows.Forms.ToolStripMenuItem toolStripMIFrameCrates;
        private System.Windows.Forms.ToolStripMenuItem toolStripMIContainers;
        private System.Windows.Forms.ToolStripMenuItem toolStripMITableOfContents;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMIGlassCrates;
    }
}

