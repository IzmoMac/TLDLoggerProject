namespace classExample
{
    partial class form_navigation
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
            this.btn_addItem = new System.Windows.Forms.Button();
            this.btn_viewInventory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_addItem
            // 
            this.btn_addItem.Location = new System.Drawing.Point(446, 179);
            this.btn_addItem.Name = "btn_addItem";
            this.btn_addItem.Size = new System.Drawing.Size(200, 100);
            this.btn_addItem.TabIndex = 0;
            this.btn_addItem.Text = "Add new item";
            this.btn_addItem.UseVisualStyleBackColor = true;
            this.btn_addItem.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_viewInventory
            // 
            this.btn_viewInventory.Location = new System.Drawing.Point(121, 179);
            this.btn_viewInventory.Name = "btn_viewInventory";
            this.btn_viewInventory.Size = new System.Drawing.Size(200, 100);
            this.btn_viewInventory.TabIndex = 1;
            this.btn_viewInventory.Text = "View inventory";
            this.btn_viewInventory.UseVisualStyleBackColor = true;
            this.btn_viewInventory.Click += new System.EventHandler(this.button2_Click);
            // 
            // form_navigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_viewInventory);
            this.Controls.Add(this.btn_addItem);
            this.Name = "form_navigation";
            this.Text = "TLDInventoryApp";
            this.Load += new System.EventHandler(this.form_navigation_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_addItem;
        private System.Windows.Forms.Button btn_viewInventory;
    }
}