namespace MyAndAssignment
{
    partial class frmConnectedMode
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
            btnExecute = new Button();
            lstEmpsNames = new ListBox();
            btnExecSP = new Button();
            btnScalar = new Button();
            txtEmpId = new TextBox();
            numericUpDownEmpLvl = new NumericUpDown();
            btnUpdateEmpLvl = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownEmpLvl).BeginInit();
            SuspendLayout();
            // 
            // btnExecute
            // 
            btnExecute.Location = new Point(694, 339);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(94, 29);
            btnExecute.TabIndex = 0;
            btnExecute.Text = "Execute";
            btnExecute.UseVisualStyleBackColor = true;
            btnExecute.Click += btnExecute_Click;
            // 
            // lstEmpsNames
            // 
            lstEmpsNames.FormattingEnabled = true;
            lstEmpsNames.Location = new Point(638, 12);
            lstEmpsNames.Name = "lstEmpsNames";
            lstEmpsNames.Size = new Size(150, 304);
            lstEmpsNames.TabIndex = 1;
            // 
            // btnExecSP
            // 
            btnExecSP.Location = new Point(694, 374);
            btnExecSP.Name = "btnExecSP";
            btnExecSP.Size = new Size(94, 29);
            btnExecSP.TabIndex = 2;
            btnExecSP.Text = "Execute SP";
            btnExecSP.UseVisualStyleBackColor = true;
            btnExecSP.Click += btnExecSP_Click;
            // 
            // btnScalar
            // 
            btnScalar.Location = new Point(694, 409);
            btnScalar.Name = "btnScalar";
            btnScalar.Size = new Size(94, 29);
            btnScalar.TabIndex = 3;
            btnScalar.Text = "Scalar";
            btnScalar.UseVisualStyleBackColor = true;
            btnScalar.Click += btnScalar_Click;
            // 
            // txtEmpId
            // 
            txtEmpId.Location = new Point(12, 12);
            txtEmpId.Name = "txtEmpId";
            txtEmpId.Size = new Size(125, 27);
            txtEmpId.TabIndex = 4;
            // 
            // numericUpDownEmpLvl
            // 
            numericUpDownEmpLvl.Location = new Point(12, 61);
            numericUpDownEmpLvl.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            numericUpDownEmpLvl.Name = "numericUpDownEmpLvl";
            numericUpDownEmpLvl.Size = new Size(150, 27);
            numericUpDownEmpLvl.TabIndex = 6;
            // 
            // btnUpdateEmpLvl
            // 
            btnUpdateEmpLvl.Location = new Point(12, 113);
            btnUpdateEmpLvl.Name = "btnUpdateEmpLvl";
            btnUpdateEmpLvl.Size = new Size(94, 29);
            btnUpdateEmpLvl.TabIndex = 7;
            btnUpdateEmpLvl.Text = "Update LVL";
            btnUpdateEmpLvl.UseVisualStyleBackColor = true;
            btnUpdateEmpLvl.Click += btnUpdateEmpLvl_Click;
            // 
            // frmConnectedMode
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnUpdateEmpLvl);
            Controls.Add(numericUpDownEmpLvl);
            Controls.Add(txtEmpId);
            Controls.Add(btnScalar);
            Controls.Add(btnExecSP);
            Controls.Add(lstEmpsNames);
            Controls.Add(btnExecute);
            Name = "frmConnectedMode";
            Text = "frmConnectedMode";
            Load += frmConnectedMode_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownEmpLvl).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnExecute;
        private ListBox lstEmpsNames;
        private Button btnExecSP;
        private Button btnScalar;
        private TextBox txtEmpId;
        private NumericUpDown numericUpDownEmpLvl;
        private Button btnUpdateEmpLvl;
    }
}