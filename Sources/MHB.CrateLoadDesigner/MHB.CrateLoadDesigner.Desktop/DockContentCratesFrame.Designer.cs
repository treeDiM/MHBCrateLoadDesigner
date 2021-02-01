
namespace MHB.CrateLoadDesigner.Desktop
{
    partial class DockContentCratesFrame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockContentCratesFrame));
            this.splitContainerVert = new System.Windows.Forms.SplitContainer();
            this.lbCrates = new MHB.CrateLoadDesigner.Desktop.ListBoxCratesFrame();
            this.splitContainerHoriz1 = new System.Windows.Forms.SplitContainer();
            this.splitContainerCrateSummary = new System.Windows.Forms.SplitContainer();
            this.lbCrateDimsOuterValue = new System.Windows.Forms.Label();
            this.lbCrateDimsInnerValue = new System.Windows.Forms.Label();
            this.lbCrateDimsOuter = new System.Windows.Forms.Label();
            this.lbCrateDimsInner = new System.Windows.Forms.Label();
            this.lbCrateName = new System.Windows.Forms.Label();
            this.gridCrate = new SourceGrid.Grid();
            this.pbCrate = new System.Windows.Forms.PictureBox();
            this.gridLayers = new SourceGrid.Grid();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).BeginInit();
            this.splitContainerVert.Panel1.SuspendLayout();
            this.splitContainerVert.Panel2.SuspendLayout();
            this.splitContainerVert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz1)).BeginInit();
            this.splitContainerHoriz1.Panel1.SuspendLayout();
            this.splitContainerHoriz1.Panel2.SuspendLayout();
            this.splitContainerHoriz1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCrateSummary)).BeginInit();
            this.splitContainerCrateSummary.Panel1.SuspendLayout();
            this.splitContainerCrateSummary.Panel2.SuspendLayout();
            this.splitContainerCrateSummary.SuspendLayout();
            this.gridCrate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCrate)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerVert
            // 
            resources.ApplyResources(this.splitContainerVert, "splitContainerVert");
            this.splitContainerVert.Name = "splitContainerVert";
            // 
            // splitContainerVert.Panel1
            // 
            this.splitContainerVert.Panel1.Controls.Add(this.lbCrates);
            // 
            // splitContainerVert.Panel2
            // 
            this.splitContainerVert.Panel2.Controls.Add(this.splitContainerHoriz1);
            // 
            // lbCrates
            // 
            resources.ApplyResources(this.lbCrates, "lbCrates");
            this.lbCrates.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbCrates.Name = "lbCrates";
            this.lbCrates.SelectedIndexChanged += new System.EventHandler(this.OnSelectedCrateChanged);
            // 
            // splitContainerHoriz1
            // 
            resources.ApplyResources(this.splitContainerHoriz1, "splitContainerHoriz1");
            this.splitContainerHoriz1.Name = "splitContainerHoriz1";
            // 
            // splitContainerHoriz1.Panel1
            // 
            this.splitContainerHoriz1.Panel1.Controls.Add(this.splitContainerCrateSummary);
            // 
            // splitContainerHoriz1.Panel2
            // 
            this.splitContainerHoriz1.Panel2.Controls.Add(this.gridLayers);
            // 
            // splitContainerCrateSummary
            // 
            resources.ApplyResources(this.splitContainerCrateSummary, "splitContainerCrateSummary");
            this.splitContainerCrateSummary.Name = "splitContainerCrateSummary";
            // 
            // splitContainerCrateSummary.Panel1
            // 
            this.splitContainerCrateSummary.Panel1.Controls.Add(this.lbCrateDimsOuterValue);
            this.splitContainerCrateSummary.Panel1.Controls.Add(this.lbCrateDimsInnerValue);
            this.splitContainerCrateSummary.Panel1.Controls.Add(this.lbCrateDimsOuter);
            this.splitContainerCrateSummary.Panel1.Controls.Add(this.lbCrateDimsInner);
            this.splitContainerCrateSummary.Panel1.Controls.Add(this.lbCrateName);
            // 
            // splitContainerCrateSummary.Panel2
            // 
            this.splitContainerCrateSummary.Panel2.Controls.Add(this.gridCrate);
            // 
            // lbCrateDimsOuterValue
            // 
            resources.ApplyResources(this.lbCrateDimsOuterValue, "lbCrateDimsOuterValue");
            this.lbCrateDimsOuterValue.Name = "lbCrateDimsOuterValue";
            // 
            // lbCrateDimsInnerValue
            // 
            resources.ApplyResources(this.lbCrateDimsInnerValue, "lbCrateDimsInnerValue");
            this.lbCrateDimsInnerValue.Name = "lbCrateDimsInnerValue";
            // 
            // lbCrateDimsOuter
            // 
            resources.ApplyResources(this.lbCrateDimsOuter, "lbCrateDimsOuter");
            this.lbCrateDimsOuter.Name = "lbCrateDimsOuter";
            // 
            // lbCrateDimsInner
            // 
            resources.ApplyResources(this.lbCrateDimsInner, "lbCrateDimsInner");
            this.lbCrateDimsInner.Name = "lbCrateDimsInner";
            // 
            // lbCrateName
            // 
            resources.ApplyResources(this.lbCrateName, "lbCrateName");
            this.lbCrateName.Name = "lbCrateName";
            // 
            // gridCrate
            // 
            this.gridCrate.Controls.Add(this.pbCrate);
            resources.ApplyResources(this.gridCrate, "gridCrate");
            this.gridCrate.EnableSort = true;
            this.gridCrate.Name = "gridCrate";
            this.gridCrate.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridCrate.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.gridCrate.TabStop = true;
            this.gridCrate.ToolTipText = "";
            // 
            // pbCrate
            // 
            resources.ApplyResources(this.pbCrate, "pbCrate");
            this.pbCrate.Name = "pbCrate";
            this.pbCrate.TabStop = false;
            this.pbCrate.Resize += new System.EventHandler(this.OnPbCrateResized);
            // 
            // gridLayers
            // 
            resources.ApplyResources(this.gridLayers, "gridLayers");
            this.gridLayers.EnableSort = false;
            this.gridLayers.Name = "gridLayers";
            this.gridLayers.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridLayers.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridLayers.TabStop = true;
            this.gridLayers.ToolTipText = "";
            // 
            // DockContentCratesFrame
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerVert);
            this.Name = "DockContentCratesFrame";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.splitContainerVert.Panel1.ResumeLayout(false);
            this.splitContainerVert.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).EndInit();
            this.splitContainerVert.ResumeLayout(false);
            this.splitContainerHoriz1.Panel1.ResumeLayout(false);
            this.splitContainerHoriz1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz1)).EndInit();
            this.splitContainerHoriz1.ResumeLayout(false);
            this.splitContainerCrateSummary.Panel1.ResumeLayout(false);
            this.splitContainerCrateSummary.Panel1.PerformLayout();
            this.splitContainerCrateSummary.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCrateSummary)).EndInit();
            this.splitContainerCrateSummary.ResumeLayout(false);
            this.gridCrate.ResumeLayout(false);
            this.gridCrate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCrate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerVert;
        private ListBoxCratesFrame lbCrates;
        private System.Windows.Forms.SplitContainer splitContainerHoriz1;
        private System.Windows.Forms.SplitContainer splitContainerCrateSummary;
        private System.Windows.Forms.PictureBox pbCrate;
        private SourceGrid.Grid gridCrate;
        private SourceGrid.Grid gridLayers;
        private System.Windows.Forms.Label lbCrateName;
        private System.Windows.Forms.Label lbCrateDimsInner;
        private System.Windows.Forms.Label lbCrateDimsOuter;
        private System.Windows.Forms.Label lbCrateDimsInnerValue;
        private System.Windows.Forms.Label lbCrateDimsOuterValue;
    }
}