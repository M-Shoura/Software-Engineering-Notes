namespace MyAndAssignment
{
    partial class frmDisconnectedModeList
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
            lstEmpNames = new ListBox();
            lblEmpId = new Label();
            txtEmpName = new TextBox();
            numericUpDownJobId = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnNext = new Button();
            btnPrev = new Button();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownJobId).BeginInit();
            SuspendLayout();
            // 
            // lstEmpNames
            // 
            lstEmpNames.FormattingEnabled = true;
            lstEmpNames.Location = new Point(638, 50);
            lstEmpNames.Name = "lstEmpNames";
            lstEmpNames.Size = new Size(150, 344);
            lstEmpNames.TabIndex = 0;
            lstEmpNames.SelectedIndexChanged += lstEmpNames_SelectedIndexChanged;
            // 
            // lblEmpId
            // 
            lblEmpId.AutoSize = true;
            lblEmpId.Location = new Point(156, 27);
            lblEmpId.Name = "lblEmpId";
            lblEmpId.Size = new Size(50, 20);
            lblEmpId.TabIndex = 1;
            lblEmpId.Text = "label1";
            // 
            // txtEmpName
            // 
            txtEmpName.Location = new Point(156, 67);
            txtEmpName.Name = "txtEmpName";
            txtEmpName.Size = new Size(125, 27);
            txtEmpName.TabIndex = 2;
            // 
            // numericUpDownJobId
            // 
            numericUpDownJobId.Location = new Point(156, 125);
            numericUpDownJobId.Name = "numericUpDownJobId";
            numericUpDownJobId.Size = new Size(150, 27);
            numericUpDownJobId.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 27);
            label1.Name = "label1";
            label1.Size = new Size(94, 20);
            label1.TabIndex = 4;
            label1.Text = "Employee ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 74);
            label2.Name = "label2";
            label2.Size = new Size(113, 20);
            label2.TabIndex = 5;
            label2.Text = "Emp Last Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 132);
            label3.Name = "label3";
            label3.Size = new Size(51, 20);
            label3.TabIndex = 6;
            label3.Text = "Job ID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(651, 14);
            label4.Name = "label4";
            label4.Size = new Size(114, 20);
            label4.TabIndex = 7;
            label4.Text = "Emp First Name";
            // 
            // btnNext
            // 
            btnNext.Location = new Point(156, 188);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(94, 29);
            btnNext.TabIndex = 8;
            btnNext.Text = ">";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrev
            // 
            btnPrev.Location = new Point(36, 188);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(94, 29);
            btnPrev.TabIndex = 9;
            btnPrev.Text = "<";
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(286, 412);
            label5.Name = "label5";
            label5.Size = new Size(502, 20);
            label5.TabIndex = 10;
            label5.Text = "Incase we don't have this list , use arrows that change in the binding source";
            // 
            // frmDisconnectedModeList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(btnPrev);
            Controls.Add(btnNext);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numericUpDownJobId);
            Controls.Add(txtEmpName);
            Controls.Add(lblEmpId);
            Controls.Add(lstEmpNames);
            Name = "frmDisconnectedModeList";
            Text = "frmDisconnectedModeList";
            Load += frmDisconnectedModeList_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownJobId).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstEmpNames;
        private Label lblEmpId;
        private TextBox txtEmpName;
        private NumericUpDown numericUpDownJobId;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnNext;
        private Button btnPrev;
        private Label label5;
    }
}