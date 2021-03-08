
namespace MHB.CrateLoadDesigner.Desktop
{
    partial class FormAddNewFrame
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
            this.bnOk = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbBrand = new System.Windows.Forms.TextBox();
            this.lbBrand = new System.Windows.Forms.Label();
            this.lbDescription = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lbNumber = new System.Windows.Forms.Label();
            this.nudNumber = new System.Windows.Forms.NumericUpDown();
            this.uCtrlDimensions = new treeDiM.Basics.UCtrlDualDouble();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // bnOk
            // 
            this.bnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOk.Location = new System.Drawing.Point(547, 3);
            this.bnOk.Name = "bnOk";
            this.bnOk.Size = new System.Drawing.Size(75, 23);
            this.bnOk.TabIndex = 0;
            this.bnOk.Text = "OK";
            this.bnOk.UseVisualStyleBackColor = true;
            // 
            // bnCancel
            // 
            this.bnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Location = new System.Drawing.Point(547, 33);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 23);
            this.bnCancel.TabIndex = 1;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 109);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(634, 22);
            this.statusStrip.TabIndex = 2;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(66, 17);
            this.statusLabel.Text = "statusLabel";
            // 
            // tbBrand
            // 
            this.tbBrand.Location = new System.Drawing.Point(114, 6);
            this.tbBrand.Name = "tbBrand";
            this.tbBrand.Size = new System.Drawing.Size(161, 20);
            this.tbBrand.TabIndex = 3;
            this.tbBrand.TextChanged += new System.EventHandler(this.UpdateStatus);
            // 
            // lbBrand
            // 
            this.lbBrand.AutoSize = true;
            this.lbBrand.Location = new System.Drawing.Point(13, 11);
            this.lbBrand.Name = "lbBrand";
            this.lbBrand.Size = new System.Drawing.Size(35, 13);
            this.lbBrand.TabIndex = 4;
            this.lbBrand.Text = "Brand";
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(13, 84);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(60, 13);
            this.lbDescription.TabIndex = 5;
            this.lbDescription.Text = "Description";
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescription.Location = new System.Drawing.Point(114, 84);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(509, 20);
            this.tbDescription.TabIndex = 6;
            // 
            // lbNumber
            // 
            this.lbNumber.AutoSize = true;
            this.lbNumber.Location = new System.Drawing.Point(12, 33);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Size = new System.Drawing.Size(44, 13);
            this.lbNumber.TabIndex = 7;
            this.lbNumber.Text = "Number";
            // 
            // nudNumber
            // 
            this.nudNumber.Location = new System.Drawing.Point(114, 31);
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
            this.nudNumber.Size = new System.Drawing.Size(67, 20);
            this.nudNumber.TabIndex = 8;
            this.nudNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumber.ValueChanged += new System.EventHandler(this.UpdateStatus);
            // 
            // uCtrlDimensions
            // 
            this.uCtrlDimensions.Location = new System.Drawing.Point(12, 57);
            this.uCtrlDimensions.MinValue = -10000D;
            this.uCtrlDimensions.Name = "uCtrlDimensions";
            this.uCtrlDimensions.Size = new System.Drawing.Size(262, 20);
            this.uCtrlDimensions.TabIndex = 9;
            this.uCtrlDimensions.Text = "Dimensions";
            this.uCtrlDimensions.Unit = treeDiM.Basics.UnitsManager.UnitType.UT_LENGTH;
            this.uCtrlDimensions.ValueX = 0D;
            this.uCtrlDimensions.ValueY = 0D;
            this.uCtrlDimensions.ValueChanged += new treeDiM.Basics.UCtrlDualDouble.ValueChangedDelegate(this.UpdateStatus);
            // 
            // FormAddNewFrame
            // 
            this.AcceptButton = this.bnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.ClientSize = new System.Drawing.Size(634, 131);
            this.Controls.Add(this.uCtrlDimensions);
            this.Controls.Add(this.nudNumber);
            this.Controls.Add(this.lbNumber);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.lbBrand);
            this.Controls.Add(this.tbBrand);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOk);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(650, 170);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(650, 170);
            this.Name = "FormAddNewFrame";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Add new frame...";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnOk;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.TextBox tbBrand;
        private System.Windows.Forms.Label lbBrand;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.NumericUpDown nudNumber;
        private treeDiM.Basics.UCtrlDualDouble uCtrlDimensions;
    }
}