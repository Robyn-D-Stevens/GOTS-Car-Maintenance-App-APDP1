
namespace FinalVersion
{
    partial class CarMaintainceManager
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPlateNum = new System.Windows.Forms.TextBox();
            this.radYesDam = new System.Windows.Forms.RadioButton();
            this.radNoDam = new System.Windows.Forms.RadioButton();
            this.panDamage = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEstimatedCost = new System.Windows.Forms.TextBox();
            this.txtCarDam = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.panDamage.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter License Plate Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Is Car Damaged?";
            // 
            // txtPlateNum
            // 
            this.txtPlateNum.Location = new System.Drawing.Point(236, 46);
            this.txtPlateNum.Name = "txtPlateNum";
            this.txtPlateNum.Size = new System.Drawing.Size(255, 26);
            this.txtPlateNum.TabIndex = 2;
            this.txtPlateNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPlateNum_KeyPress);
            this.txtPlateNum.Leave += new System.EventHandler(this.txtPlateNum_Leave);
            this.txtPlateNum.Validating += new System.ComponentModel.CancelEventHandler(this.txtPlateNum_Validating);
            this.txtPlateNum.Validated += new System.EventHandler(this.txtPlateNum_Validated);
            // 
            // radYesDam
            // 
            this.radYesDam.AutoSize = true;
            this.radYesDam.Location = new System.Drawing.Point(236, 88);
            this.radYesDam.Name = "radYesDam";
            this.radYesDam.Size = new System.Drawing.Size(49, 20);
            this.radYesDam.TabIndex = 3;
            this.radYesDam.TabStop = true;
            this.radYesDam.Text = "Yes";
            this.radYesDam.UseVisualStyleBackColor = true;
            this.radYesDam.Enter += new System.EventHandler(this.radYesDam_Enter);
            // 
            // radNoDam
            // 
            this.radNoDam.AutoSize = true;
            this.radNoDam.Location = new System.Drawing.Point(447, 88);
            this.radNoDam.Name = "radNoDam";
            this.radNoDam.Size = new System.Drawing.Size(44, 20);
            this.radNoDam.TabIndex = 4;
            this.radNoDam.TabStop = true;
            this.radNoDam.Text = "No";
            this.radNoDam.UseVisualStyleBackColor = true;
            this.radNoDam.CheckedChanged += new System.EventHandler(this.radNoDam_CheckedChanged);
            // 
            // panDamage
            // 
            this.panDamage.BackColor = System.Drawing.Color.DarkOrange;
            this.panDamage.Controls.Add(this.label4);
            this.panDamage.Controls.Add(this.label3);
            this.panDamage.Controls.Add(this.txtEstimatedCost);
            this.panDamage.Controls.Add(this.txtCarDam);
            this.panDamage.Location = new System.Drawing.Point(35, 124);
            this.panDamage.Name = "panDamage";
            this.panDamage.Size = new System.Drawing.Size(456, 118);
            this.panDamage.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(23, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Enter Estimated Repair Cost:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(23, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(290, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "If Yes, Enter type of Damage the Car Has:";
            // 
            // txtEstimatedCost
            // 
            this.txtEstimatedCost.Location = new System.Drawing.Point(26, 76);
            this.txtEstimatedCost.Name = "txtEstimatedCost";
            this.txtEstimatedCost.Size = new System.Drawing.Size(406, 26);
            this.txtEstimatedCost.TabIndex = 1;
            // 
            // txtCarDam
            // 
            this.txtCarDam.Location = new System.Drawing.Point(26, 28);
            this.txtCarDam.Name = "txtCarDam";
            this.txtCarDam.Size = new System.Drawing.Size(406, 26);
            this.txtCarDam.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(35, 273);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(456, 26);
            this.dateTimePicker1.TabIndex = 6;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Enter Date of Inspection:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkOrange;
            this.button1.Location = new System.Drawing.Point(35, 338);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 28);
            this.button1.TabIndex = 8;
            this.button1.Text = "EXIT";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.DarkOrange;
            this.btnSubmit.Location = new System.Drawing.Point(364, 338);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(127, 28);
            this.btnSubmit.TabIndex = 9;
            this.btnSubmit.Text = "Upload Report";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // CarMaintainceManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(529, 378);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.panDamage);
            this.Controls.Add(this.radNoDam);
            this.Controls.Add(this.radYesDam);
            this.Controls.Add(this.txtPlateNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CarMaintainceManager";
            this.Text = "CarMaintainceManager";
            this.Load += new System.EventHandler(this.CarMaintainceManager_Load);
            this.panDamage.ResumeLayout(false);
            this.panDamage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPlateNum;
        private System.Windows.Forms.RadioButton radYesDam;
        private System.Windows.Forms.RadioButton radNoDam;
        private System.Windows.Forms.Panel panDamage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEstimatedCost;
        private System.Windows.Forms.TextBox txtCarDam;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSubmit;
    }
}