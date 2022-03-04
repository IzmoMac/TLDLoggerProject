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
                RegionName = textBox_regionName.Text,
                PlaceName = textBox_place.Text,
            };
            p.SetCondition(textBox_condition.Text);
            p.SetDayStored(textBox_dayStored.Text);
            p.SetQuantity(textBox_quantity.Text);

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
            p.Verify();

            if (!p.IsProductKeyValid)
            {
                sb.AppendLine("Given Product do not exist.");
            }

            if (p.ConditionTooBig)
            {
                sb.AppendLine($"Condition value cannot be bigger than {CtInt.PRCT_MAX}");
            }
            if (p.ConditionTooSmall)
            {
                sb.AppendLine($"Condition value has to be {CtInt.INT_1} or higher");
            }
            if (p.DayStoredTooBig)
            {
                sb.AppendLine($"Day stored cannot be bigger than {CtInt.DAY_MAX}.");
            }
            if (p.DayStoredTooSmall)
            {
                sb.AppendLine($"Day stored have to be {CtInt.DAY_MIN} or higher.");
            }

            if (!p.IsRegionKeyValid)
            {
                sb.AppendLine("Given Region do not exist.");
            }

            if (!p.IsPlaceKeyValid)
            {
                sb.AppendLine("Given Place do not exist.");
            }

            if (p.QuantityTooBig)
            {
                sb.AppendLine($"Quantity cannot be bigger than {CtInt.QTY_MAX}.");
            }
            if (p.QuantityTooSmall)
            {
                sb.AppendLine($"Quantity have to be {CtInt.QTY_MIN} or higher.");
            }
            //jatkaa tähän muita chekkejä
            
            if (sb.Length > CtInt.ZERO)
            {
                MessageBox.Show(sb.ToString());
                return false;
            }
            return true;
        }
    }
}
