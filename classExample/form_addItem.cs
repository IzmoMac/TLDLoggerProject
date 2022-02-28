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
            Console.WriteLine(sender);
        }

        private void textBox_productName_Leave(object sender, EventArgs e)
        {

        }
    }
}
