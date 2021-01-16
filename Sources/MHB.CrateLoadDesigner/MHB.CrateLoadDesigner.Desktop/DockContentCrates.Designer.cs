
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
            this.lbCrates = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).BeginInit();
            this.splitContainerVert.Panel1.SuspendLayout();
            this.splitContainerVert.SuspendLayout();
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
            // lbCrates
            // 
            resources.ApplyResources(this.lbCrates, "lbCrates");
            this.lbCrates.FormattingEnabled = true;
            this.lbCrates.Name = "lbCrates";
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).EndInit();
            this.splitContainerVert.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerVert;
        private System.Windows.Forms.ListBox lbCrates;
    }
}