
namespace MHB.CrateLoadDesigner.Desktop
{
    partial class DockContentCratesGlass
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
            this.splitContainerVert = new System.Windows.Forms.SplitContainer();
            this.splitContainerHoriz = new System.Windows.Forms.SplitContainer();
            this.splitContainerCrate = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCrateDimInner = new System.Windows.Forms.Label();
            this.lbCrateName = new System.Windows.Forms.Label();
            this.pbCrate = new System.Windows.Forms.PictureBox();
            this.gridCrate = new SourceGrid.Grid();
            this.lbCrates = new MHB.CrateLoadDesigner.Desktop.ListBoxCratesGlass();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).BeginInit();
            this.splitContainerVert.Panel1.SuspendLayout();
            this.splitContainerVert.Panel2.SuspendLayout();
            this.splitContainerVert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).BeginInit();
            this.splitContainerHoriz.Panel1.SuspendLayout();
            this.splitContainerHoriz.Panel2.SuspendLayout();
            this.splitContainerHoriz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCrate)).BeginInit();
            this.splitContainerCrate.Panel1.SuspendLayout();
            this.splitContainerCrate.Panel2.SuspendLayout();
            this.splitContainerCrate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCrate)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerVert
            // 
            this.splitContainerVert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerVert.Location = new System.Drawing.Point(0, 0);
            this.splitContainerVert.Name = "splitContainerVert";
            // 
            // splitContainerVert.Panel1
            // 
            this.splitContainerVert.Panel1.Controls.Add(this.lbCrates);
            // 
            // splitContainerVert.Panel2
            // 
            this.splitContainerVert.Panel2.Controls.Add(this.splitContainerHoriz);
            this.splitContainerVert.Size = new System.Drawing.Size(800, 450);
            this.splitContainerVert.SplitterDistance = 266;
            this.splitContainerVert.TabIndex = 0;
            // 
            // splitContainerHoriz
            // 
            this.splitContainerHoriz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerHoriz.Location = new System.Drawing.Point(0, 0);
            this.splitContainerHoriz.Name = "splitContainerHoriz";
            this.splitContainerHoriz.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerHoriz.Panel1
            // 
            this.splitContainerHoriz.Panel1.Controls.Add(this.splitContainerCrate);
            // 
            // splitContainerHoriz.Panel2
            // 
            this.splitContainerHoriz.Panel2.Controls.Add(this.gridCrate);
            this.splitContainerHoriz.Size = new System.Drawing.Size(530, 450);
            this.splitContainerHoriz.SplitterDistance = 290;
            this.splitContainerHoriz.TabIndex = 0;
            // 
            // splitContainerCrate
            // 
            this.splitContainerCrate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerCrate.Location = new System.Drawing.Point(0, 0);
            this.splitContainerCrate.Name = "splitContainerCrate";
            this.splitContainerCrate.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerCrate.Panel1
            // 
            this.splitContainerCrate.Panel1.Controls.Add(this.label1);
            this.splitContainerCrate.Panel1.Controls.Add(this.lbCrateDimInner);
            this.splitContainerCrate.Panel1.Controls.Add(this.lbCrateName);
            // 
            // splitContainerCrate.Panel2
            // 
            this.splitContainerCrate.Panel2.Controls.Add(this.pbCrate);
            this.splitContainerCrate.Size = new System.Drawing.Size(530, 290);
            this.splitContainerCrate.SplitterDistance = 67;
            this.splitContainerCrate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Outer dimensions";
            // 
            // lbCrateDimInner
            // 
            this.lbCrateDimInner.AutoSize = true;
            this.lbCrateDimInner.Location = new System.Drawing.Point(176, 13);
            this.lbCrateDimInner.Name = "lbCrateDimInner";
            this.lbCrateDimInner.Size = new System.Drawing.Size(86, 13);
            this.lbCrateDimInner.TabIndex = 1;
            this.lbCrateDimInner.Text = "Inner dimensions";
            // 
            // lbCrateName
            // 
            this.lbCrateName.AutoSize = true;
            this.lbCrateName.Location = new System.Drawing.Point(16, 13);
            this.lbCrateName.Name = "lbCrateName";
            this.lbCrateName.Size = new System.Drawing.Size(60, 13);
            this.lbCrateName.TabIndex = 0;
            this.lbCrateName.Text = "CrateName";
            // 
            // pbCrate
            // 
            this.pbCrate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCrate.Location = new System.Drawing.Point(0, 0);
            this.pbCrate.Name = "pbCrate";
            this.pbCrate.Size = new System.Drawing.Size(530, 219);
            this.pbCrate.TabIndex = 0;
            this.pbCrate.TabStop = false;
            this.pbCrate.SizeChanged += new System.EventHandler(this.OnPbCrateResized);
            // 
            // gridCrate
            // 
            this.gridCrate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCrate.EnableSort = true;
            this.gridCrate.Location = new System.Drawing.Point(0, 0);
            this.gridCrate.Name = "gridCrate";
            this.gridCrate.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridCrate.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.gridCrate.Size = new System.Drawing.Size(530, 156);
            this.gridCrate.TabIndex = 0;
            this.gridCrate.TabStop = true;
            this.gridCrate.ToolTipText = "";
            // 
            // lbCrates
            // 
            this.lbCrates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCrates.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbCrates.FormattingEnabled = true;
            this.lbCrates.IntegralHeight = false;
            this.lbCrates.ItemHeight = 150;
            this.lbCrates.Location = new System.Drawing.Point(0, 0);
            this.lbCrates.Name = "lbCrates";
            this.lbCrates.Size = new System.Drawing.Size(266, 450);
            this.lbCrates.TabIndex = 0;
            this.lbCrates.SelectedIndexChanged += new System.EventHandler(this.OnSelectedCrateChanged);
            // 
            // DockContentCratesGlass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainerVert);
            this.Name = "DockContentCratesGlass";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Glass crates";
            this.splitContainerVert.Panel1.ResumeLayout(false);
            this.splitContainerVert.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).EndInit();
            this.splitContainerVert.ResumeLayout(false);
            this.splitContainerHoriz.Panel1.ResumeLayout(false);
            this.splitContainerHoriz.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).EndInit();
            this.splitContainerHoriz.ResumeLayout(false);
            this.splitContainerCrate.Panel1.ResumeLayout(false);
            this.splitContainerCrate.Panel1.PerformLayout();
            this.splitContainerCrate.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCrate)).EndInit();
            this.splitContainerCrate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCrate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerVert;
        private System.Windows.Forms.SplitContainer splitContainerHoriz;
        private ListBoxCratesGlass lbCrates;
        private System.Windows.Forms.SplitContainer splitContainerCrate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCrateDimInner;
        private System.Windows.Forms.Label lbCrateName;
        private System.Windows.Forms.PictureBox pbCrate;
        private SourceGrid.Grid gridCrate;
    }
}