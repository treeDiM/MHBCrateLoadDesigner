
namespace MHB.CrateLoadDesigner.Desktop
{
    partial class DockContentContainer
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainerHoriz = new System.Windows.Forms.SplitContainer();
            this.lbContainerName = new System.Windows.Forms.Label();
            this.pbContainer = new System.Windows.Forms.PictureBox();
            this.lbContainers = new MHB.CrateLoadDesigner.Desktop.ListBoxContainers();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).BeginInit();
            this.splitContainerHoriz.Panel1.SuspendLayout();
            this.splitContainerHoriz.Panel2.SuspendLayout();
            this.splitContainerHoriz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbContainers);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainerHoriz);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 193;
            this.splitContainer1.TabIndex = 0;
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
            this.splitContainerHoriz.Panel1.Controls.Add(this.lbContainerName);
            // 
            // splitContainerHoriz.Panel2
            // 
            this.splitContainerHoriz.Panel2.Controls.Add(this.pbContainer);
            this.splitContainerHoriz.Size = new System.Drawing.Size(603, 450);
            this.splitContainerHoriz.SplitterDistance = 96;
            this.splitContainerHoriz.TabIndex = 0;
            // 
            // lbContainerName
            // 
            this.lbContainerName.AutoSize = true;
            this.lbContainerName.Location = new System.Drawing.Point(14, 13);
            this.lbContainerName.Name = "lbContainerName";
            this.lbContainerName.Size = new System.Drawing.Size(80, 13);
            this.lbContainerName.TabIndex = 0;
            this.lbContainerName.Text = "ContainerName";
            // 
            // pbContainer
            // 
            this.pbContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbContainer.Location = new System.Drawing.Point(0, 0);
            this.pbContainer.Name = "pbContainer";
            this.pbContainer.Size = new System.Drawing.Size(603, 350);
            this.pbContainer.TabIndex = 0;
            this.pbContainer.TabStop = false;
            this.pbContainer.SizeChanged += new System.EventHandler(this.OnPbContainerResized);
            // 
            // lbContainers
            // 
            this.lbContainers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbContainers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbContainers.FormattingEnabled = true;
            this.lbContainers.IntegralHeight = false;
            this.lbContainers.ItemHeight = 150;
            this.lbContainers.Location = new System.Drawing.Point(0, 0);
            this.lbContainers.Name = "lbContainers";
            this.lbContainers.Size = new System.Drawing.Size(193, 450);
            this.lbContainers.TabIndex = 0;
            this.lbContainers.SelectedIndexChanged += new System.EventHandler(this.OnSelectedContainerChanged);
            // 
            // DockContentContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "DockContentContainer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Containers";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainerHoriz.Panel1.ResumeLayout(false);
            this.splitContainerHoriz.Panel1.PerformLayout();
            this.splitContainerHoriz.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).EndInit();
            this.splitContainerHoriz.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbContainer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainerHoriz;
        private MHB.CrateLoadDesigner.Desktop.ListBoxContainers lbContainers;
        private System.Windows.Forms.PictureBox pbContainer;
        private System.Windows.Forms.Label lbContainerName;
    }
}