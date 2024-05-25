using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        float GetSelectedCrustPrice()
        {
            if (rBThin.Checked)
            {
                return Convert.ToSingle(rBThin.Tag);
            }
            else
                return Convert.ToSingle(rBThick.Tag);
        }

        float CalculateToppingPrice()
        {
            float ToppingsTotalPrice = 0;

            if (chkCheese.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkCheese.Tag);
            }

            if (chkMushroom.Checked)
            {
                ToppingsTotalPrice +=  Convert.ToSingle(chkMushroom.Tag);
            }

            if (chkOlives.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkOlives.Tag);
            }

            if (chkOnion.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkOnion.Tag);
            }

            if (chkPeppers.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkPeppers.Tag);
            }

            if (chkTomatoes.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkTomatoes.Tag);
            }

            return ToppingsTotalPrice;
        }

        float GetSelectedSizePrice()
        {
            if(rBSmall.Checked)
            {
                return Convert.ToSingle(rBSmall.Tag);
            }
            else if(rBMedium.Checked)
            {
                return Convert.ToSingle(rBMedium.Tag);
            }
            else
                return Convert.ToSingle(rBLarge.Tag);
        }

        float CalculateTotalPrice()
        {
            return GetSelectedSizePrice() + CalculateToppingPrice() + GetSelectedCrustPrice();
        }

        void UpdateTotalPrice()
        {
            lblTotalPrice.Text = "$" + CalculateTotalPrice().ToString();
        }

        void UpdateSize()
        {
            UpdateTotalPrice();

            if(rBSmall.Checked)
            {
                lblSize.Text = "Small";
                return;
            }
            if (rBMedium.Checked)
            {
                lblSize.Text = "Medium";
                return;
            }
            if (rBLarge.Checked)
            {
                lblSize.Text = "Large";
                return;
            }
        }

        void UpdateCrust()
        {
            UpdateTotalPrice();

            if (rBThin.Checked)
            {
                lblCrust.Text = "Thin";
                return;
            }
            if (rBThick.Checked)
            {
                lblCrust.Text = "Thick";
                return;
            }
        }

        void UpdateToppings()
        {
            UpdateTotalPrice();
            string stToppings = "";

            if (chkCheese.Checked)
            {
                stToppings = "Extra Cheese";
            }
            if (chkMushroom.Checked)
            {
                stToppings += ", Mushroom";
            }
            if (chkOnion.Checked)
            {
                stToppings += ", Onion";
            }
            if (chkOlives.Checked)
            {
                stToppings += ", Olives";
            }
            if (chkPeppers.Checked)
            {
                stToppings += ", Peppers";
            }
            if (chkTomatoes.Checked)
            {
                stToppings += ", Tomatoes";
            }
            if (stToppings.StartsWith(","))
            {
                stToppings = stToppings.Substring(1, stToppings.Length - 1).Trim();
            }
            if (stToppings == "")
            {
                stToppings = "No Toppings";
            }

            lblToppings.Text = stToppings;
        }

        void UpdateWhereToEat()
        {
            if (rBIn.Checked)
            {
                lblWhere.Text = "Eat In";
            }
            if (rBOut.Checked)
            {
                lblWhere.Text = "Take Out";
            }
        }

        void ResetForm()
        {
            panel1.Enabled = true;
            panel2.Enabled = true;
            panel3.Enabled = true;
            panel4.Enabled = true;
            btnOrder.Enabled = true;

            rBMedium.Checked = true;

            rBThin.Checked = true;

            rBIn.Checked = true;

            chkCheese.Checked = false;
            chkMushroom.Checked = false;
            chkOlives.Checked = false;
            chkOnion.Checked = false;
            chkTomatoes.Checked = false;
            chkPeppers.Checked = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateTotalPrice();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Confirm Order", "Confirm", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Order Placed Successfully", "Success",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                panel1.Enabled = false;
                panel2.Enabled = false;
                panel3.Enabled = false;
                panel4.Enabled = false;
                btnOrder.Enabled = false;

            }
            
        }


        private void rBSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rBMedium_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rBLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rBThin_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rBThick_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void chkCheese_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkMushroom_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void rBIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void rBOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
