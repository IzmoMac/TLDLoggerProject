using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace classExample
{
    public partial class ConditionLoop : Form
    {
        private CProduct p = null;
        int orgQuantity;
        int itemNumber = 1;
        public ConditionLoop(CProduct product)
        {
            p = product;
            orgQuantity = p.Quantity;
            InitializeComponent();
            RefreshLabel();
            
        }
        private void RefreshLabel()
        {
            label_ConditionQuestion.Text = $"Enter Condition value for item {itemNumber} / {orgQuantity}";
            label_ConditionQuestion.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            p.SetCondition(textBox_ConditionValue.Text);
            if (p.ConditionValid)
            {
                p.InsertStringAddToList(1);
                p.Quantity--;
                itemNumber++;
            }
            else
            {
                MessageBox.Show($"Give a valid Condition amount between {CtInt.INT_1} and {CtInt.PRCT_MAX}.");
            }
            
            if (p.Quantity.Equals(CtInt.ZERO))
            {
                p.Save();
                Close();
            }
            RefreshLabel();

        }
    }
}
