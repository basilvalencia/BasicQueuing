using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueuingForm
{
    public partial class Upnext : Form
    {
        public Upnext()
        {
            InitializeComponent();
        }

        private void Upnext_Load(object sender, EventArgs e)
        {
            try
            {
                if (CashierClass.CashierQueue.Count == 0)
                {
                    throw new ArgumentNullException("No student in the line");
                }
                else
                {
                    lblServing.Text = CashierClass.CashierQueue.Peek();
                    tmrTimer.Start();
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int timer = 1;

        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            if (timer <= 1)
            {
                timer++;
            }
            else
            {
                CashierClass.CashierQueue.Dequeue();
                tmrTimer.Stop();
                this.Close();
            }
        }
    }
}

        

    
    

