
namespace MHB.CrateLoadDesigner.Desktop
{
    partial class DockContentInputs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockContentInputs));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabFrames = new System.Windows.Forms.TabPage();
            this.toolStripFrames = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddFrame = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRemoveFrame = new System.Windows.Forms.ToolStripButton();
            this.gridFrames = new SourceGrid.Grid();
            this.tabGlass = new System.Windows.Forms.TabPage();
            this.toolStripGlass = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddGlass = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRemoveGlass = new System.Windows.Forms.ToolStripButton();
            this.gridGlass = new SourceGrid.Grid();
            this.tabCratesFrame = new System.Windows.Forms.TabPage();
            this.gridCratesFrame = new SourceGrid.Grid();
            this.tabCratesGlass = new System.Windows.Forms.TabPage();
            this.gridCratesGlass = new SourceGrid.Grid();
            this.tabContainers = new System.Windows.Forms.TabPage();
            this.gridContainers = new SourceGrid.Grid();
            this.tabControl.SuspendLayout();
            this.tabFrames.SuspendLayout();
            this.toolStripFrames.SuspendLayout();
            this.tabGlass.SuspendLayout();
            this.toolStripGlass.SuspendLayout();
            this.tabCratesFrame.SuspendLayout();
            this.tabCratesGlass.SuspendLayout();
            this.tabContainers.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabFrames);
            this.tabControl.Controls.Add(this.tabGlass);
            this.tabControl.Controls.Add(this.tabCratesFrame);
            this.tabControl.Controls.Add(this.tabCratesGlass);
            this.tabControl.Controls.Add(this.tabContainers);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 450);
            this.tabControl.TabIndex = 0;
            // 
            // tabFrames
            // 
            this.tabFrames.Controls.Add(this.toolStripFrames);
            this.tabFrames.Controls.Add(this.gridFrames);
            this.tabFrames.Location = new System.Drawing.Point(4, 22);
            this.tabFrames.Name = "tabFrames";
            this.tabFrames.Padding = new System.Windows.Forms.Padding(3);
            this.tabFrames.Size = new System.Drawing.Size(792, 424);
            this.tabFrames.TabIndex = 0;
            this.tabFrames.Text = "Frames";
            this.tabFrames.UseVisualStyleBackColor = true;
            // 
            // toolStripFrames
            // 
            this.toolStripFrames.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddFrame,
            this.toolStripButtonRemoveFrame});
            this.toolStripFrames.Location = new System.Drawing.Point(3, 3);
            this.toolStripFrames.Name = "toolStripFrames";
            this.toolStripFrames.Size = new System.Drawing.Size(786, 25);
            this.toolStripFrames.TabIndex = 1;
            this.toolStripFrames.Text = "Frame tools";
            // 
            // toolStripButtonAddFrame
            // 
            this.toolStripButtonAddFrame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddFrame.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddFrame.Image")));
            this.toolStripButtonAddFrame.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButtonAddFrame.Name = "toolStripButtonAddFrame";
            this.toolStripButtonAddFrame.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAddFrame.Text = "Add...";
            this.toolStripButtonAddFrame.Click += new System.EventHandler(this.OnAddFrame);
            // 
            // toolStripButtonRemoveFrame
            // 
            this.toolStripButtonRemoveFrame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRemoveFrame.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRemoveFrame.Image")));
            this.toolStripButtonRemoveFrame.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButtonRemoveFrame.Name = "toolStripButtonRemoveFrame";
            this.toolStripButtonRemoveFrame.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRemoveFrame.Text = "Remove";
            this.toolStripButtonRemoveFrame.Click += new System.EventHandler(this.OnRemoveFrame);
            // 
            // gridFrames
            // 
            this.gridFrames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridFrames.EnableSort = true;
            this.gridFrames.Location = new System.Drawing.Point(0, 29);
            this.gridFrames.Name = "gridFrames";
            this.gridFrames.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridFrames.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.gridFrames.Size = new System.Drawing.Size(792, 395);
            this.gridFrames.TabIndex = 0;
            this.gridFrames.TabStop = true;
            this.gridFrames.ToolTipText = "";
            // 
            // tabGlass
            // 
            this.tabGlass.Controls.Add(this.toolStripGlass);
            this.tabGlass.Controls.Add(this.gridGlass);
            this.tabGlass.Location = new System.Drawing.Point(4, 22);
            this.tabGlass.Name = "tabGlass";
            this.tabGlass.Padding = new System.Windows.Forms.Padding(3);
            this.tabGlass.Size = new System.Drawing.Size(792, 424);
            this.tabGlass.TabIndex = 1;
            this.tabGlass.Text = "Glass";
            this.tabGlass.UseVisualStyleBackColor = true;
            // 
            // toolStripGlass
            // 
            this.toolStripGlass.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddGlass,
            this.toolStripButtonRemoveGlass});
            this.toolStripGlass.Location = new System.Drawing.Point(3, 3);
            this.toolStripGlass.Name = "toolStripGlass";
            this.toolStripGlass.Size = new System.Drawing.Size(786, 25);
            this.toolStripGlass.TabIndex = 1;
            this.toolStripGlass.Text = "Glass tools";
            this.toolStripGlass.Click += new System.EventHandler(this.OnAddGlass);
            // 
            // toolStripButtonAddGlass
            // 
            this.toolStripButtonAddGlass.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddGlass.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddGlass.Image")));
            this.toolStripButtonAddGlass.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButtonAddGlass.Name = "toolStripButtonAddGlass";
            this.toolStripButtonAddGlass.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAddGlass.Text = "Add...";
            // 
            // toolStripButtonRemoveGlass
            // 
            this.toolStripButtonRemoveGlass.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRemoveGlass.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRemoveGlass.Image")));
            this.toolStripButtonRemoveGlass.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButtonRemoveGlass.Name = "toolStripButtonRemoveGlass";
            this.toolStripButtonRemoveGlass.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRemoveGlass.Text = "Remove";
            this.toolStripButtonRemoveGlass.Click += new System.EventHandler(this.OnRemoveGlass);
            // 
            // gridGlass
            // 
            this.gridGlass.EnableSort = true;
            this.gridGlass.Location = new System.Drawing.Point(0, 33);
            this.gridGlass.Name = "gridGlass";
            this.gridGlass.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridGlass.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.gridGlass.Size = new System.Drawing.Size(792, 391);
            this.gridGlass.TabIndex = 0;
            this.gridGlass.TabStop = true;
            this.gridGlass.ToolTipText = "";
            // 
            // tabCratesFrame
            // 
            this.tabCratesFrame.Controls.Add(this.gridCratesFrame);
            this.tabCratesFrame.Location = new System.Drawing.Point(4, 22);
            this.tabCratesFrame.Name = "tabCratesFrame";
            this.tabCratesFrame.Size = new System.Drawing.Size(792, 424);
            this.tabCratesFrame.TabIndex = 2;
            this.tabCratesFrame.Text = "Crates (Frames)";
            this.tabCratesFrame.UseVisualStyleBackColor = true;
            // 
            // gridCratesFrame
            // 
            this.gridCratesFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCratesFrame.EnableSort = true;
            this.gridCratesFrame.Location = new System.Drawing.Point(0, 0);
            this.gridCratesFrame.Name = "gridCratesFrame";
            this.gridCratesFrame.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridCratesFrame.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.gridCratesFrame.Size = new System.Drawing.Size(792, 424);
            this.gridCratesFrame.TabIndex = 0;
            this.gridCratesFrame.TabStop = true;
            this.gridCratesFrame.ToolTipText = "";
            // 
            // tabCratesGlass
            // 
            this.tabCratesGlass.Controls.Add(this.gridCratesGlass);
            this.tabCratesGlass.Location = new System.Drawing.Point(4, 22);
            this.tabCratesGlass.Name = "tabCratesGlass";
            this.tabCratesGlass.Padding = new System.Windows.Forms.Padding(3);
            this.tabCratesGlass.Size = new System.Drawing.Size(792, 424);
            this.tabCratesGlass.TabIndex = 3;
            this.tabCratesGlass.Text = "Crates (Glass)";
            this.tabCratesGlass.UseVisualStyleBackColor = true;
            // 
            // gridCratesGlass
            // 
            this.gridCratesGlass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCratesGlass.EnableSort = true;
            this.gridCratesGlass.Location = new System.Drawing.Point(3, 3);
            this.gridCratesGlass.Name = "gridCratesGlass";
            this.gridCratesGlass.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridCratesGlass.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.gridCratesGlass.Size = new System.Drawing.Size(786, 418);
            this.gridCratesGlass.TabIndex = 0;
            this.gridCratesGlass.TabStop = true;
            this.gridCratesGlass.ToolTipText = "";
            // 
            // tabContainers
            // 
            this.tabContainers.Controls.Add(this.gridContainers);
            this.tabContainers.Location = new System.Drawing.Point(4, 22);
            this.tabContainers.Name = "tabContainers";
            this.tabContainers.Size = new System.Drawing.Size(792, 424);
            this.tabContainers.TabIndex = 4;
            this.tabContainers.Text = "Containers";
            this.tabContainers.UseVisualStyleBackColor = true;
            // 
            // gridContainers
            // 
            this.gridContainers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridContainers.EnableSort = true;
            this.gridContainers.Location = new System.Drawing.Point(0, 0);
            this.gridContainers.Name = "gridContainers";
            this.gridContainers.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridContainers.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.gridContainers.Size = new System.Drawing.Size(792, 424);
            this.gridContainers.TabIndex = 0;
            this.gridContainers.TabStop = true;
            this.gridContainers.ToolTipText = "";
            // 
            // DockContentInputs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Name = "DockContentInputs";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Inputs";
            this.ToolTipText = "Project inputs";
            this.tabControl.ResumeLayout(false);
            this.tabFrames.ResumeLayout(false);
            this.tabFrames.PerformLayout();
            this.toolStripFrames.ResumeLayout(false);
            this.toolStripFrames.PerformLayout();
            this.tabGlass.ResumeLayout(false);
            this.tabGlass.PerformLayout();
            this.toolStripGlass.ResumeLayout(false);
            this.toolStripGlass.PerformLayout();
            this.tabCratesFrame.ResumeLayout(false);
            this.tabCratesGlass.ResumeLayout(false);
            this.tabContainers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabFrames;
        private System.Windows.Forms.TabPage tabGlass;
        private System.Windows.Forms.TabPage tabCratesFrame;
        private System.Windows.Forms.TabPage tabCratesGlass;
        private SourceGrid.Grid gridFrames;
        private System.Windows.Forms.TabPage tabContainers;
        private System.Windows.Forms.ToolStrip toolStripFrames;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddFrame;
        private System.Windows.Forms.ToolStrip toolStripGlass;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddGlass;
        private SourceGrid.Grid gridGlass;
        private SourceGrid.Grid gridCratesFrame;
        private SourceGrid.Grid gridCratesGlass;
        private SourceGrid.Grid gridContainers;
        private System.Windows.Forms.ToolStripButton toolStripButtonRemoveFrame;
        private System.Windows.Forms.ToolStripButton toolStripButtonRemoveGlass;
    }
}