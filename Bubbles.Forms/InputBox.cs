using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bubbles.Forms
{
    public partial class InputBox : Form
    {
        public int Qtd { get; set; }
        public double UseArea { get; set; }
        public InputBox(string _title, string _message, string _default_value)
        {
            InitializeComponent();
            this.Text = _title;
            lbl.Text = _message;
            ipt_qtd.Text = _default_value;

        }

        protected void Ipt_QtdChanged(object sender, EventArgs e)
        {
            try
            {
                Qtd = int.Parse(ipt_qtd.Text.ToString());
            }
            catch (Exception) { }
            
        }
        protected void Ipt_UseAreaChanged(object sender, EventArgs e)
        {
            try
            {
                UseArea = Double.Parse(ipt_use_area.Text.ToString());
            }
            catch (Exception) { }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
