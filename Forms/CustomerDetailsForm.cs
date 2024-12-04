using Northwind_Management_System.Context;
using Northwind_Management_System.DAL;
using Northwind_Management_System.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Northwind_Management_System.Forms
{
    public partial class CustomerDetailsForm : Form
    {
        public Customer Customer { get; private set; }

        private TextBox txtContactName;
        private TextBox txtPhone;
        private TextBox txtAddress;
        private Button btnSave;
        private Button btnCancel;

        public CustomerDetailsForm()
        {
            InitializeComponent();
            Customer = new Customer();

            txtContactName = new TextBox { Location = new System.Drawing.Point(150, 50), Width = 200 };
            txtPhone = new TextBox { Location = new System.Drawing.Point(150, 100), Width = 200 }; // Adjusted position
            txtAddress = new TextBox { Location = new System.Drawing.Point(150, 150), Width = 200 }; // Adjusted position
            btnSave = new Button { Text = "Save", Location = new System.Drawing.Point(150, 200), Size = new System.Drawing.Size(75, 30) };
            btnCancel = new Button { Text = "Cancel", Location = new System.Drawing.Point(250, 200), Size = new System.Drawing.Size(75, 30) };

            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;

            Controls.Add(new Label { Text = "Customer Name", Location = new System.Drawing.Point(50, 50) });
            Controls.Add(new Label { Text = "Phone", Location = new System.Drawing.Point(50, 100) });
            Controls.Add(new Label { Text = "Address", Location = new System.Drawing.Point(50, 150) });
            Controls.Add(txtContactName);
            Controls.Add(txtPhone);
            Controls.Add(txtAddress);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);

            Text = "Customer Details";
            Size = new System.Drawing.Size(400, 300);
        }

        public CustomerDetailsForm(Customer customer) : this()
        {
            Customer = customer;
            txtContactName.Text = customer.ContactName;
            txtPhone.Text = customer.Phone;
            txtAddress.Text = customer.Address;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Customer.ContactName = txtContactName.Text;
            Customer.Phone = txtPhone.Text;
            Customer.Address = txtAddress.Text;
            DialogResult = DialogResult.OK; 
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; 
            Close();
        }
    }
}
