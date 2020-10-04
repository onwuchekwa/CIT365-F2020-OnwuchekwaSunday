using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MegaDesk_Onwuchekwa
{
    public partial class AddQuote : Form
    {
        //Declare variables
        int deskWidth = 0;
        int deskDepth = 0;
        int deskDrawer = 0;
        int rushDays = 0;
        Desk.DesktopMaterial deskMaterial;
        string _customerName = string.Empty;
        

        public AddQuote()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This binds data to the material combobox from an enumerator
        /// </summary>
        public void BindMaterial()
        {
            List<Desk.DesktopMaterial> desktopMaterials = Enum.GetValues(typeof(Desk.DesktopMaterial)).Cast<Desk.DesktopMaterial>().ToList();
            surfaceMaterial.DataSource = desktopMaterials;
        }

        /// <summary>
        /// This method binds data to the shipping method combobox
        /// </summary>
        public void BindRushDays()
        {
            Dictionary<string, string> rushDaysSource = new Dictionary<string, string>();
            rushDaysSource.Add("0", "Normal - 14 Days");
            rushDaysSource.Add("3", "3 Days");
            rushDaysSource.Add("5", "5 Days");
            rushDaysSource.Add("7", "7 Days");

            rushOrder.DataSource = new BindingSource(rushDaysSource, null);
            rushOrder.DisplayMember = "Value";
            rushOrder.ValueMember = "Key";
        }

        private void AddQuote_Load(object sender, EventArgs e)
        {
            quoteDate.Text = DateTime.Now.ToString("dd MMMM yyyy");
            BindMaterial();
            BindRushDays();
        }
        
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            // Close the current form
            MainMenu mainMenu = (MainMenu)Tag;
            mainMenu.Show();
            this.Close();
        }
        
        private void customerName_Validating(object sender, CancelEventArgs e)
        {
            // Change the field color is empty or not
            if(customerName.Text == string.Empty)
            {
                customerName.Text = string.Empty;
                customerName.BackColor = Color.Red;
                customerName.ForeColor = Color.White;
                MessageBox.Show("Customer Name cannot be blank");
                customerName.Focus();
                return;
            } 
            else
            {
                customerName.BackColor = SystemColors.Window;
                customerName.ForeColor = Color.Black;
            }
        }

        private void width_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Accept only digits
            if (Char.IsControl(e.KeyChar) == false && Char.IsDigit(e.KeyChar) == false)
            {
                MessageBox.Show("Only Numbers (Digits) are required");
                e.Handled = true;
            }
        }

        private void depth_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Accept only digits
            if (Char.IsControl(e.KeyChar) == false && Char.IsDigit(e.KeyChar) == false)
            {
                MessageBox.Show("Please enter a number");
                e.Handled = true;
            }
        }

        private void width_Validating(object sender, CancelEventArgs e)
        { 
            // check if width has data or not and change the color accordingly
            if(width.Text != string.Empty)
            {
                int intWidth = int.Parse(width.Text);

                // check if width value is within range and change the color accordingly
                if ((intWidth < Desk.MINWIDTH) || (intWidth > Desk.MAXWIDTH))
                {
                    width.Text = string.Empty;
                    width.BackColor = Color.Red;
                    width.ForeColor = Color.White;
                    MessageBox.Show("The width must be between " + Desk.MINWIDTH + " and " + Desk.MAXWIDTH);
                    width.Focus();
                    return;
                }
                else
                {
                    width.BackColor = SystemColors.Window;
                    width.ForeColor = Color.Black;
                }
            }
            else
            {
                width.Text = string.Empty;
                width.BackColor = Color.Red;
                width.ForeColor = Color.White;
                MessageBox.Show("Width cannot be blank");
                width.Focus();
                return;
            }
        }

        private void depth_Validating(object sender, CancelEventArgs e)
        {
            // check if depth has data or not and change the color accordingly
            if (depth.Text != string.Empty)
            {
                int intDepth = int.Parse(depth.Text);

                // check if depth value is within range and change the color accordingly
                if ((intDepth < Desk.MINDEPTH) || (intDepth > Desk.MAXDEPTH))
                {
                    depth.Text = string.Empty;
                    depth.BackColor = Color.Red;
                    depth.ForeColor = Color.White;
                    MessageBox.Show("The depth must be between " + Desk.MINDEPTH + " and " + Desk.MAXDEPTH);
                    depth.Focus();
                    return;
                }
                else
                {
                    depth.BackColor = SystemColors.Window;
                    depth.ForeColor = Color.Black;
                }
            }
            else
            {
                depth.Text = string.Empty;
                depth.BackColor = Color.Red;
                depth.ForeColor = Color.White;
                MessageBox.Show("Width cannot be blank");
                depth.Focus();
                return;
            }
        }

        private void drawerCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Accepts only digit
            if (Char.IsControl(e.KeyChar) == false && Char.IsDigit(e.KeyChar) == false)
            {
                MessageBox.Show("Only Numbers (Digits) are required");
                e.Handled = true;
            }
        }

        private void drawerCount_Validating(object sender, CancelEventArgs e)
        {
            // check if drawer count has data or not and change the color accordingly
            if (drawerCount.Text != string.Empty)
            {
                int intDrawerCount = int.Parse(drawerCount.Text);

                // check if drawer count value is within range and change the color accordingly
                if ((intDrawerCount < Desk.MINDRAWER) || (intDrawerCount > Desk.MAXDRAWER))
                {
                    drawerCount.Text = string.Empty;
                    drawerCount.BackColor = Color.Red;
                    drawerCount.ForeColor = Color.White;
                    MessageBox.Show("The depth must be between " + Desk.MINDRAWER + " and " + Desk.MAXDRAWER);
                    drawerCount.Focus();
                    return;
                }
                else
                {
                    drawerCount.BackColor = SystemColors.Window;
                    drawerCount.ForeColor = Color.Black;
                }
            }
            else
            {
                drawerCount.Text = string.Empty;
                drawerCount.BackColor = Color.Red;
                drawerCount.ForeColor = Color.White;
                MessageBox.Show("Width cannot be blank");
                drawerCount.Focus();
                return;
            }
        }

        private void btnAddNewQuote_Click(object sender, EventArgs e)
        {
            // Parse and assign value
            deskWidth = int.Parse(width.Text);
            deskDepth = int.Parse(depth.Text);
            deskDrawer = int.Parse(drawerCount.Text);
            deskMaterial = (Desk.DesktopMaterial)surfaceMaterial.SelectedValue;
            rushDays = int.Parse(((KeyValuePair<string, string>)rushOrder.SelectedItem).Key);

            // Call DeskQuote Class with parameters
            DeskQuote deskQuote = new DeskQuote(_customerName, rushDays, DateTime.Now, deskWidth, deskDepth, deskDrawer, deskMaterial);

            // Assign value to get quote controls
            lblArea.Text = deskQuote.calcArea().ToString();
            excessSize.Text = deskQuote.calcSizeOverage().ToString();
            sizeCost.Text = deskQuote.calcSizeCost().ToString() + ".00";
            drawerCost.Text = deskQuote.calcDrawer().ToString() + ".00";
            materialCost.Text = deskQuote.calcMaterial().ToString() + ".00";
            shipCost.Text = deskQuote.calcShippingCost().ToString() + ".00";
            totalCost.Text = deskQuote.calcQuote().ToString() + ".00";
        }
    }
}
