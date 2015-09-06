using System;
using System.Windows.Forms;

namespace TV.TiskarnaApp
{
    public partial class Order : UserControl
    {
        public Order()
        {
            InitializeComponent();
        }

        private void checkBoxKorektura_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerKorektura.Enabled = checkBoxKorektura.Checked;
        }
    }
}
