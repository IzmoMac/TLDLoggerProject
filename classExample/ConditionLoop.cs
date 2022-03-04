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
        public ConditionLoop(CProduct product)
        {
            p = product;
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Validate
            //string s = textBox_ConditionValue.Text;
            
            p.SetCondition(textBox_ConditionValue.Text);
            if (p.ConditionValid)
            {
                p.InsertStringAddToList(1);
                p.Quantity--;
            }
            if (p.Quantity.Equals(CtInt.ZERO))
            {
                p.Save();
                Close();
            }
        }
    }
}
