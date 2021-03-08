
namespace MHB.CrateLoadDesigner.Desktop
{
    partial class FormAddNewGlass
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
            this.lbBrand = new System.Windows.Forms.Label();
            this.bnOk = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.uCtrlDimensions = new treeDiM.Basics.UCtrlDualDouble();
            this.lbNumber = new System.Windows.Forms.Label();
            this.tbBrand = new System.Windows.Forms.TextBox();
            this.nudNumber = new System.Windows.Forms.NumericUpDown();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // lbBrand
            // 
            this.lbBrand.AutoSize = true;
            this.lbBrand.Location = new System.Drawing.Point(12, 8);
            this.lbBrand.Name = "lbBrand";
            this.lbBrand.Size = new System.Drawing.Size(35, 13);
            this.lbBrand.TabIndex = 0;
            this.lbBrand.Text = "Brand";
            // 
            // bnOk
            // 
            this.bnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOk.Location = new System.Drawing.Point(547, 3);
            this.bnOk.Name = "bnOk";
            this.bnOk.Size = new System.Drawing.Size(75, 23);
            this.bnOk.TabIndex = 2;
            this.bnOk.Text = "OK";
            this.bnOk.UseVisualStyleBackColor = true;
            // 
            // bnCancel
            // 
            this.bnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Location = new System.Drawing.Point(547, 30);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 23);
            this.bnCancel.TabIndex = 3;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 89);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(634, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(66, 17);
            this.statusLabel.Text = "statusLabel";
            // 
            // uCtrlDimensions
            // 
            this.uCtrlDimensions.Location = new System.Drawing.Point(12, 59);
            this.uCtrlDimensions.MinValue = 0D;
            this.uCtrlDimensions.Name = "uCtrlDimensions";
            this.uCtrlDimensions.Size = new System.Drawing.Size(321, 20);
            this.uCtrlDimensions.TabIndex = 5;
            this.uCtrlDimensions.Text = "Dimensions";
            this.uCtrlDimensions.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlDimensions.ValueX = 0D;
            this.uCtrlDimensions.ValueY = 0D;
            this.uCtrlDimensions.ValueChanged += new treeDiM.Basics.UCtrlDualDouble.ValueChangedDelegate(this.UpdateStatus);
            // 
            // lbNumber
            // 
            this.lbNumber.AutoSize = true;
            this.lbNumber.Location = new System.Drawing.Point(12, 35);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Size = new System.Drawing.Size(44, 13);
            this.lbNumber.TabIndex = 6;
            this.lbNumber.Text = "Number";
            // 
            // tbBrand
            // 
            this.tbBrand.Location = new System.Drawing.Point(174, 6);
            this.tbBrand.Name = "tbBrand";
            this.tbBrand.Size = new System.Drawing.Size(159, 20);
            this.tbBrand.TabIndex = 7;
            this.tbBrand.TextChanged += new System.EventHandler(this.UpdateStatus);
            // 
            // nudNumber
            // 
            this.nudNumber.Location = new System.Drawing.Point(174, 33);
            this.nudNumber.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumber.Name = "nudNumber";
            this.nudNumber.Size = new System.Drawing.Size(58, 20);
            this.nudNumber.TabIndex = 8;
            this.nudNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumber.ValueChanged += new System.EventHandler(this.UpdateStatus);
            // 
            // FormAddNewGlass
            // 
            this.AcceptButton = this.bnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.ClientSize = new System.Drawing.Size(634, 111);
            this.Controls.Add(this.nudNumber);
            this.Controls.Add(this.tbBrand);
            this.Controls.Add(this.lbNumber);
            this.Controls.Add(this.uCtrlDimensions);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOk);
            this.Controls.Add(this.lbBrand);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(650, 150);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(650, 150);
            this.Name = "FormAddNewGlass";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Add new Glass item...";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbBrand;
        private System.Windows.Forms.Button bnOk;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private treeDiM.Basics.UCtrlDualDouble uCtrlDimensions;
        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.TextBox tbBrand;
        private System.Windows.Forms.NumericUpDown nudNumber;
    }
}