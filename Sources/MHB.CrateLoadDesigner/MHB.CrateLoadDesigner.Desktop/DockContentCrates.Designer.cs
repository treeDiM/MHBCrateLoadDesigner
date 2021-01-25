﻿
namespace MHB.CrateLoadDesigner.Desktop
{
    partial class DockContentCrates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockContentCrates));
            this.splitContainerVert = new System.Windows.Forms.SplitContainer();
            this.splitContainerHoriz1 = new System.Windows.Forms.SplitContainer();
            this.splitContainerVert2 = new System.Windows.Forms.SplitContainer();
            this.pbCrate = new System.Windows.Forms.PictureBox();
            this.gridCrate = new SourceGrid.Grid();
            this.gridLayers = new SourceGrid.Grid();
            this.lbCrates = new MHB.CrateLoadDesigner.Desktop.ListBoxCrates();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).BeginInit();
            this.splitContainerVert.Panel1.SuspendLayout();
            this.splitContainerVert.Panel2.SuspendLayout();
            this.splitContainerVert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz1)).BeginInit();
            this.splitContainerHoriz1.Panel1.SuspendLayout();
            this.splitContainerHoriz1.Panel2.SuspendLayout();
            this.splitContainerHoriz1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert2)).BeginInit();
            this.splitContainerVert2.Panel1.SuspendLayout();
            this.splitContainerVert2.Panel2.SuspendLayout();
            this.splitContainerVert2.SuspendLayout();
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
            // splitContainerHoriz1
            // 
            resources.ApplyResources(this.splitContainerHoriz1, "splitContainerHoriz1");
            this.splitContainerHoriz1.Name = "splitContainerHoriz1";
            // 
            // splitContainerHoriz1.Panel1
            // 
            this.splitContainerHoriz1.Panel1.Controls.Add(this.splitContainerVert2);
            // 
            // splitContainerHoriz1.Panel2
            // 
            this.splitContainerHoriz1.Panel2.Controls.Add(this.gridLayers);
            // 
            // splitContainerVert2
            // 
            resources.ApplyResources(this.splitContainerVert2, "splitContainerVert2");
            this.splitContainerVert2.Name = "splitContainerVert2";
            // 
            // splitContainerVert2.Panel1
            // 
            this.splitContainerVert2.Panel1.Controls.Add(this.pbCrate);
            // 
            // splitContainerVert2.Panel2
            // 
            this.splitContainerVert2.Panel2.Controls.Add(this.gridCrate);
            // 
            // pbCrate
            // 
            resources.ApplyResources(this.pbCrate, "pbCrate");
            this.pbCrate.Name = "pbCrate";
            this.pbCrate.TabStop = false;
            this.pbCrate.Resize += new System.EventHandler(this.OnPbCrateResized);
            // 
            // gridCrate
            // 
            resources.ApplyResources(this.gridCrate, "gridCrate");
            this.gridCrate.EnableSort = true;
            this.gridCrate.Name = "gridCrate";
            this.gridCrate.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridCrate.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.gridCrate.TabStop = true;
            this.gridCrate.ToolTipText = "";
            // 
            // gridLayers
            // 
            resources.ApplyResources(this.gridLayers, "gridLayers");
            this.gridLayers.EnableSort = true;
            this.gridLayers.Name = "gridLayers";
            this.gridLayers.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridLayers.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.gridLayers.TabStop = true;
            this.gridLayers.ToolTipText = "";
            // 
            // lbCrates
            // 
            resources.ApplyResources(this.lbCrates, "lbCrates");
            this.lbCrates.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbCrates.Name = "lbCrates";
            this.lbCrates.SelectedIndexChanged += new System.EventHandler(this.OnSelectedCrateChanged);
            // 
            // DockContentCrates
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerVert);
            this.Name = "DockContentCrates";
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
            this.splitContainerVert2.Panel1.ResumeLayout(false);
            this.splitContainerVert2.Panel1.PerformLayout();
            this.splitContainerVert2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert2)).EndInit();
            this.splitContainerVert2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCrate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerVert;
        private ListBoxCrates lbCrates;
        private System.Windows.Forms.SplitContainer splitContainerHoriz1;
        private System.Windows.Forms.SplitContainer splitContainerVert2;
        private System.Windows.Forms.PictureBox pbCrate;
        private SourceGrid.Grid gridCrate;
        private SourceGrid.Grid gridLayers;
    }
}