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
    public partial class form_addItem : Form
    {
        public form_addItem()
        {
            InitializeComponent();
        }

        private void textBox_productName_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox_productName_Leave(object sender, EventArgs e)
        {

        }

        private void label_productName_Click(object sender, EventArgs e)
        {

        }

        private void form_addItem_Load(object sender, EventArgs e)
        {
            Init();
        }
        private void Init()
        {
            //MessageBox.Show("Moi");
        }

        private void button_submitItem_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            CProduct p = new CProduct()
            {
                ProductName = textBox_productName.Text,
                DayStored = int.Parse(textBox_dayStored.Text), //Muuta samalla tavalla kuin p.SetCondition
                RegionName = textBox_regionName.Text,
                PlaceName = textBox_place.Text,
                Quantity = int.Parse(textBox_quantity.Text) //Muuta samalla tavalla kuin p.SetCondition
            };
            p.SetCondition(textBox_condition.Text);

            if (!ValidateInput(p))
            {
                return;
            }
            if (p.Quantity > CtInt.INT_1)
            {
                //Refer new Form that Ask question and loop 
                //Input box?
                string message = "Does all products have same condition?";
                string caption = "Condition Check";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result.Equals(DialogResult.No))
                {
                    new ConditionLoop(p).ShowDialog();
                    return;
                }
            }
            p.InsertStringAddToList(p.Quantity);
            p.Save();

        }
        private bool ValidateInput(CProduct p)
        {
            StringBuilder sb = new StringBuilder();

            if (p.ConditionTooBig)
            {
                sb.AppendLine("Condition value too big.");
            }
            if (p.ConditionTooSmall)
            {
                sb.AppendLine("Condition value too small.");
            }

            //jatkaa tähän muita chekkejä

            p.Verify();
            if (!p.IsProductKeyValid)
            {
                sb.AppendLine("Given Product name not valid.");
            }
            if (!p.IsRegionKeyValid)
            {
                sb.AppendLine("Given Region do not exist.");
            }
            if (!p.IsPlaceKeyValid)
            {
                sb.AppendLine("Given Place name do not exist.");
            }

            if (sb.Length > CtInt.ZERO)
            {
                MessageBox.Show(sb.ToString());
                return false;
            }
            return true;
        }
        public bool ValidateCondition()
        {
            return true;
        }
    }
}
