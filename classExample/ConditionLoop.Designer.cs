namespace classExample
{
    partial class ConditionLoop
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_ConditionValue = new System.Windows.Forms.TextBox();
            this.label_ConditionQuestion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(243, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 54);
            this.button1.TabIndex = 0;
            this.button1.Text = "Enter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_ConditionValue
            // 
            this.textBox_ConditionValue.Location = new System.Drawing.Point(243, 183);
            this.textBox_ConditionValue.Name = "textBox_ConditionValue";
            this.textBox_ConditionValue.Size = new System.Drawing.Size(150, 26);
            this.textBox_ConditionValue.TabIndex = 1;
            // 
            // label_ConditionQuestion
            // 
            this.label_ConditionQuestion.AutoSize = true;
            this.label_ConditionQuestion.Location = new System.Drawing.Point(239, 146);
            this.label_ConditionQuestion.Name = "label_ConditionQuestion";
            this.label_ConditionQuestion.Size = new System.Drawing.Size(217, 20);
            this.label_ConditionQuestion.TabIndex = 2;
            this.label_ConditionQuestion.Text = "Enter Condition value for item";
            // 
            // ConditionLoop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_ConditionQuestion);
            this.Controls.Add(this.textBox_ConditionValue);
            this.Controls.Add(this.button1);
            this.Name = "ConditionLoop";
            this.Text = "ConditionLoop";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_ConditionValue;
        private System.Windows.Forms.Label label_ConditionQuestion;
    }
}