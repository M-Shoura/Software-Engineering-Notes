namespace UI
{
    partial class frmUpdateJobLvl
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
            lstEmps = new ListBox();
            numericUpDownJobLvl = new NumericUpDown();
            btnUpdate = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownJobLvl).BeginInit();
            SuspendLayout();
            // 
            // lstEmps
            // 
            lstEmps.FormattingEnabled = true;
            lstEmps.Location = new Point(313, 27);
            lstEmps.Name = "lstEmps";
            lstEmps.Size = new Size(150, 364);
            lstEmps.TabIndex = 0;
            lstEmps.SelectedIndexChanged += lstEmps_SelectedIndexChanged;
            // 
            // numericUpDownJobLvl
            // 
            numericUpDownJobLvl.Location = new Point(31, 63);
            numericUpDownJobLvl.Name = "numericUpDownJobLvl";
            numericUpDownJobLvl.Size = new Size(150, 27);
            numericUpDownJobLvl.TabIndex = 1;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(350, 409);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // frmUpdateJobLvl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(485, 450);
            Controls.Add(btnUpdate);
            Controls.Add(numericUpDownJobLvl);
            Controls.Add(lstEmps);
            Name = "frmUpdateJobLvl";
            Text = "frmUpdateJobLvl";
            Load += frmUpdateJobLvl_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownJobLvl).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstEmps;
        private NumericUpDown numericUpDownJobLvl;
        private Button btnUpdate;
    }
}