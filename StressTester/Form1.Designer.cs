namespace StressTester
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbMeasurements = new ListBox();
            lbLog = new ListBox();
            cbStressCPU = new CheckBox();
            cbStressStorage = new CheckBox();
            nmTestLength = new NumericUpDown();
            gbTestParams = new GroupBox();
            lblTestLength = new Label();
            btnStart = new Button();
            gbMeasureParams = new GroupBox();
            numericUpDown1 = new NumericUpDown();
            nmMeasureInterval = new NumericUpDown();
            lblMeasureInterval = new Label();
            cbRecordToFile = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)nmTestLength).BeginInit();
            gbTestParams.SuspendLayout();
            gbMeasureParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmMeasureInterval).BeginInit();
            SuspendLayout();
            // 
            // lbMeasurements
            // 
            lbMeasurements.FormattingEnabled = true;
            lbMeasurements.ItemHeight = 15;
            lbMeasurements.Location = new Point(738, 12);
            lbMeasurements.Name = "lbMeasurements";
            lbMeasurements.Size = new Size(367, 619);
            lbMeasurements.TabIndex = 0;
            // 
            // lbLog
            // 
            lbLog.FormattingEnabled = true;
            lbLog.ItemHeight = 15;
            lbLog.Location = new Point(12, 12);
            lbLog.Name = "lbLog";
            lbLog.Size = new Size(720, 619);
            lbLog.TabIndex = 1;
            // 
            // cbStressCPU
            // 
            cbStressCPU.AutoSize = true;
            cbStressCPU.Location = new Point(28, 37);
            cbStressCPU.Name = "cbStressCPU";
            cbStressCPU.Size = new Size(87, 19);
            cbStressCPU.TabIndex = 2;
            cbStressCPU.Text = "Stress CPU?";
            cbStressCPU.UseVisualStyleBackColor = true;
            // 
            // cbStressStorage
            // 
            cbStressStorage.AutoSize = true;
            cbStressStorage.Location = new Point(28, 62);
            cbStressStorage.Name = "cbStressStorage";
            cbStressStorage.Size = new Size(114, 19);
            cbStressStorage.TabIndex = 3;
            cbStressStorage.Text = "Stress HDD/SSD?";
            cbStressStorage.UseVisualStyleBackColor = true;
            // 
            // nmTestLength
            // 
            nmTestLength.Location = new Point(396, 37);
            nmTestLength.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            nmTestLength.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nmTestLength.Name = "nmTestLength";
            nmTestLength.Size = new Size(120, 23);
            nmTestLength.TabIndex = 5;
            nmTestLength.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // gbTestParams
            // 
            gbTestParams.Controls.Add(lblTestLength);
            gbTestParams.Controls.Add(cbStressCPU);
            gbTestParams.Controls.Add(cbStressStorage);
            gbTestParams.Controls.Add(nmTestLength);
            gbTestParams.Location = new Point(12, 637);
            gbTestParams.Name = "gbTestParams";
            gbTestParams.Size = new Size(720, 158);
            gbTestParams.TabIndex = 6;
            gbTestParams.TabStop = false;
            gbTestParams.Text = "Test Parameters";
            // 
            // lblTestLength
            // 
            lblTestLength.AutoSize = true;
            lblTestLength.Location = new Point(269, 41);
            lblTestLength.Name = "lblTestLength";
            lblTestLength.Size = new Size(121, 15);
            lblTestLength.TabIndex = 6;
            lblTestLength.Text = "Test Length (minutes)";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(537, 861);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 7;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // gbMeasureParams
            // 
            gbMeasureParams.Controls.Add(cbRecordToFile);
            gbMeasureParams.Controls.Add(lblMeasureInterval);
            gbMeasureParams.Controls.Add(nmMeasureInterval);
            gbMeasureParams.Controls.Add(numericUpDown1);
            gbMeasureParams.Location = new Point(738, 637);
            gbMeasureParams.Name = "gbMeasureParams";
            gbMeasureParams.Size = new Size(367, 158);
            gbMeasureParams.TabIndex = 7;
            gbMeasureParams.TabStop = false;
            gbMeasureParams.Text = "Measurement Parameters";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(396, 37);
            numericUpDown1.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 5;
            numericUpDown1.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // nmMeasureInterval
            // 
            nmMeasureInterval.DecimalPlaces = 1;
            nmMeasureInterval.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            nmMeasureInterval.Location = new Point(241, 43);
            nmMeasureInterval.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            nmMeasureInterval.Minimum = new decimal(new int[] { 5, 0, 0, 65536 });
            nmMeasureInterval.Name = "nmMeasureInterval";
            nmMeasureInterval.Size = new Size(120, 23);
            nmMeasureInterval.TabIndex = 7;
            nmMeasureInterval.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblMeasureInterval
            // 
            lblMeasureInterval.AutoSize = true;
            lblMeasureInterval.Location = new Point(6, 45);
            lblMeasureInterval.Name = "lblMeasureInterval";
            lblMeasureInterval.Size = new Size(141, 15);
            lblMeasureInterval.TabIndex = 7;
            lblMeasureInterval.Text = "Update Interval (seconds)";
            // 
            // cbRecordToFile
            // 
            cbRecordToFile.AutoSize = true;
            cbRecordToFile.Location = new Point(6, 108);
            cbRecordToFile.Name = "cbRecordToFile";
            cbRecordToFile.Size = new Size(103, 19);
            cbRecordToFile.TabIndex = 7;
            cbRecordToFile.Text = "Record to File?";
            cbRecordToFile.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1117, 896);
            Controls.Add(gbMeasureParams);
            Controls.Add(btnStart);
            Controls.Add(lbMeasurements);
            Controls.Add(gbTestParams);
            Controls.Add(lbLog);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)nmTestLength).EndInit();
            gbTestParams.ResumeLayout(false);
            gbTestParams.PerformLayout();
            gbMeasureParams.ResumeLayout(false);
            gbMeasureParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmMeasureInterval).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListBox lbMeasurements;
        private ListBox lbLog;
        private CheckBox cbStressCPU;
        private CheckBox cbStressStorage;
        private NumericUpDown nmTestLength;
        private GroupBox gbTestParams;
        private Label lblTestLength;
        private Button btnStart;
        private GroupBox gbMeasureParams;
        private NumericUpDown nmMeasureInterval;
        private NumericUpDown numericUpDown1;
        private CheckBox cbRecordToFile;
        private Label lblMeasureInterval;
    }
}
