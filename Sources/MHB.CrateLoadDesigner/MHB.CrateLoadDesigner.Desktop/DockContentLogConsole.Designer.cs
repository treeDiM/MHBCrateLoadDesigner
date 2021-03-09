
namespace MHB.CrateLoadDesigner.Desktop
{
    partial class DockContentLogConsole
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuDock = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DockableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoHideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.contextMenuDock.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuDock
            // 
            this.contextMenuDock.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DockableToolStripMenuItem,
            this.AutoHideToolStripMenuItem,
            this.HideToolStripMenuItem});
            this.contextMenuDock.Name = "contextMenuDock";
            this.contextMenuDock.Size = new System.Drawing.Size(127, 70);
            // 
            // DockableToolStripMenuItem
            // 
            this.DockableToolStripMenuItem.Name = "DockableToolStripMenuItem";
            this.DockableToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.DockableToolStripMenuItem.Text = "Dock";
            // 
            // AutoHideToolStripMenuItem
            // 
            this.AutoHideToolStripMenuItem.Name = "AutoHideToolStripMenuItem";
            this.AutoHideToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.AutoHideToolStripMenuItem.Text = "Auto hide";
            // 
            // HideToolStripMenuItem
            // 
            this.HideToolStripMenuItem.Name = "HideToolStripMenuItem";
            this.HideToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.HideToolStripMenuItem.Text = "Hide";
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxLog.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(584, 41);
            this.richTextBoxLog.TabIndex = 1;
            this.richTextBoxLog.Text = "";
            // 
            // DockContentLogConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 41);
            this.Controls.Add(this.richTextBoxLog);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom;
            this.HideOnClose = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DockContentLogConsole";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockBottom;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TabText = "Log console";
            this.Text = "Log console";
            this.contextMenuDock.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuDock;
        private System.Windows.Forms.ToolStripMenuItem DockableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AutoHideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HideToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
    }
}