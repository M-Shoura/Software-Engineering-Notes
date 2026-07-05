namespace UI
{
    partial class frmDetaiedView
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
            txtEmpName = new TextBox();
            lblEmpId = new Label();
            lblStatus = new Label();
            btnDelete = new Button();
            btnSave = new Button();
            SuspendLayout();
            // 
            // txtEmpName
            // 
            txtEmpName.Location = new Point(55, 99);
            txtEmpName.Name = "txtEmpName";
            txtEmpName.Size = new Size(125, 27);
            txtEmpName.TabIndex = 0;
            // 
            // lblEmpId
            // 
            lblEmpId.AutoSize = true;
            lblEmpId.Location = new Point(55, 54);
            lblEmpId.Name = "lblEmpId";
            lblEmpId.Size = new Size(50, 20);
            lblEmpId.TabIndex = 2;
            lblEmpId.Text = "label1";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(55, 150);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(50, 20);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "label1";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(55, 211);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(190, 211);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // frmDetaiedView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(lblStatus);
            Controls.Add(lblEmpId);
            Controls.Add(txtEmpName);
            Name = "frmDetaiedView";
            Text = "frmDetaiedView";
            Load += frmDetaiedView_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEmpName;
        private Label lblEmpId;
        private Label lblStatus;
        private Button btnDelete;
        private Button btnSave;
    }
}