namespace classExample
{
    partial class form_addItem
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
            this.textBox_productName = new System.Windows.Forms.TextBox();
            this.textBox_condition = new System.Windows.Forms.TextBox();
            this.textBox_dayStored = new System.Windows.Forms.TextBox();
            this.textBox_regionName = new System.Windows.Forms.TextBox();
            this.textBox_place = new System.Windows.Forms.TextBox();
            this.label_productName = new System.Windows.Forms.Label();
            this.label_condition = new System.Windows.Forms.Label();
            this.label_dayStored = new System.Windows.Forms.Label();
            this.label_region = new System.Windows.Forms.Label();
            this.label_place = new System.Windows.Forms.Label();
            this.textBox_quantity = new System.Windows.Forms.TextBox();
            this.checkBox_multipleConditionValues = new System.Windows.Forms.CheckBox();
            this.label_quantity = new System.Windows.Forms.Label();
            this.button_submitItem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_productName
            // 
            this.textBox_productName.Location = new System.Drawing.Point(27, 65);
            this.textBox_productName.Name = "textBox_productName";
            this.textBox_productName.Size = new System.Drawing.Size(135, 26);
            this.textBox_productName.TabIndex = 0;
            this.textBox_productName.TextChanged += new System.EventHandler(this.textBox_productName_TextChanged);
            this.textBox_productName.Leave += new System.EventHandler(this.textBox_productName_Leave);
            // 
            // textBox_condition
            // 
            this.textBox_condition.Location = new System.Drawing.Point(168, 65);
            this.textBox_condition.Name = "textBox_condition";
            this.textBox_condition.Size = new System.Drawing.Size(100, 26);
            this.textBox_condition.TabIndex = 1;
            // 
            // textBox_dayStored
            // 
            this.textBox_dayStored.Location = new System.Drawing.Point(274, 65);
            this.textBox_dayStored.Name = "textBox_dayStored";
            this.textBox_dayStored.Size = new System.Drawing.Size(100, 26);
            this.textBox_dayStored.TabIndex = 2;
            // 
            // textBox_regionName
            // 
            this.textBox_regionName.Location = new System.Drawing.Point(380, 65);
            this.textBox_regionName.Name = "textBox_regionName";
            this.textBox_regionName.Size = new System.Drawing.Size(100, 26);
            this.textBox_regionName.TabIndex = 3;
            // 
            // textBox_place
            // 
            this.textBox_place.Location = new System.Drawing.Point(27, 235);
            this.textBox_place.Multiline = true;
            this.textBox_place.Name = "textBox_place";
            this.textBox_place.Size = new System.Drawing.Size(296, 64);
            this.textBox_place.TabIndex = 4;
            // 
            // label_productName
            // 
            this.label_productName.AutoSize = true;
            this.label_productName.Location = new System.Drawing.Point(27, 39);
            this.label_productName.Name = "label_productName";
            this.label_productName.Size = new System.Drawing.Size(110, 20);
            this.label_productName.TabIndex = 5;
            this.label_productName.Text = "Product Name";
            // 
            // label_condition
            // 
            this.label_condition.AutoSize = true;
            this.label_condition.Location = new System.Drawing.Point(168, 39);
            this.label_condition.Name = "label_condition";
            this.label_condition.Size = new System.Drawing.Size(94, 20);
            this.label_condition.TabIndex = 6;
            this.label_condition.Text = "Condition %";
            // 
            // label_dayStored
            // 
            this.label_dayStored.AutoSize = true;
            this.label_dayStored.Location = new System.Drawing.Point(274, 39);
            this.label_dayStored.Name = "label_dayStored";
            this.label_dayStored.Size = new System.Drawing.Size(89, 20);
            this.label_dayStored.TabIndex = 7;
            this.label_dayStored.Text = "Day Stored";
            // 
            // label_region
            // 
            this.label_region.AutoSize = true;
            this.label_region.Location = new System.Drawing.Point(380, 39);
            this.label_region.Name = "label_region";
            this.label_region.Size = new System.Drawing.Size(60, 20);
            this.label_region.TabIndex = 8;
            this.label_region.Text = "Region";
            // 
            // label_place
            // 
            this.label_place.AutoSize = true;
            this.label_place.Location = new System.Drawing.Point(27, 208);
            this.label_place.Name = "label_place";
            this.label_place.Size = new System.Drawing.Size(264, 20);
            this.label_place.TabIndex = 9;
            this.label_place.Text = "Place (Detailted description allowed)";
            // 
            // textBox_quantity
            // 
            this.textBox_quantity.Location = new System.Drawing.Point(27, 166);
            this.textBox_quantity.Name = "textBox_quantity";
            this.textBox_quantity.Size = new System.Drawing.Size(100, 26);
            this.textBox_quantity.TabIndex = 10;
            // 
            // checkBox_multipleConditionValues
            // 
            this.checkBox_multipleConditionValues.AutoSize = true;
            this.checkBox_multipleConditionValues.Location = new System.Drawing.Point(133, 166);
            this.checkBox_multipleConditionValues.Name = "checkBox_multipleConditionValues";
            this.checkBox_multipleConditionValues.Size = new System.Drawing.Size(285, 24);
            this.checkBox_multipleConditionValues.TabIndex = 11;
            this.checkBox_multipleConditionValues.Text = "Do all the item have same condition";
            this.checkBox_multipleConditionValues.UseVisualStyleBackColor = true;
            // 
            // label_quantity
            // 
            this.label_quantity.AutoSize = true;
            this.label_quantity.Location = new System.Drawing.Point(27, 143);
            this.label_quantity.Name = "label_quantity";
            this.label_quantity.Size = new System.Drawing.Size(68, 20);
            this.label_quantity.TabIndex = 12;
            this.label_quantity.Text = "Quantity";
            // 
            // button_submitItem
            // 
            this.button_submitItem.Location = new System.Drawing.Point(27, 356);
            this.button_submitItem.Name = "button_submitItem";
            this.button_submitItem.Size = new System.Drawing.Size(216, 72);
            this.button_submitItem.TabIndex = 13;
            this.button_submitItem.Text = "Add Item";
            this.button_submitItem.UseVisualStyleBackColor = true;
            // 
            // form_addItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_submitItem);
            this.Controls.Add(this.label_quantity);
            this.Controls.Add(this.checkBox_multipleConditionValues);
            this.Controls.Add(this.textBox_quantity);
            this.Controls.Add(this.label_place);
            this.Controls.Add(this.label_region);
            this.Controls.Add(this.label_dayStored);
            this.Controls.Add(this.label_condition);
            this.Controls.Add(this.label_productName);
            this.Controls.Add(this.textBox_place);
            this.Controls.Add(this.textBox_regionName);
            this.Controls.Add(this.textBox_dayStored);
            this.Controls.Add(this.textBox_condition);
            this.Controls.Add(this.textBox_productName);
            this.Name = "form_addItem";
            this.Text = "TLDInventoryApp/AddItem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_productName;
        private System.Windows.Forms.TextBox textBox_condition;
        private System.Windows.Forms.TextBox textBox_dayStored;
        private System.Windows.Forms.TextBox textBox_regionName;
        private System.Windows.Forms.TextBox textBox_place;
        private System.Windows.Forms.Label label_productName;
        private System.Windows.Forms.Label label_condition;
        private System.Windows.Forms.Label label_dayStored;
        private System.Windows.Forms.Label label_region;
        private System.Windows.Forms.Label label_place;
        private System.Windows.Forms.TextBox textBox_quantity;
        private System.Windows.Forms.CheckBox checkBox_multipleConditionValues;
        private System.Windows.Forms.Label label_quantity;
        private System.Windows.Forms.Button button_submitItem;
    }
}