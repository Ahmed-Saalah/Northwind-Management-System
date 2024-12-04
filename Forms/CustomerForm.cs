using Northwind_Management_System.Context;
using Northwind_Management_System.DAL;
using Northwind_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Northwind_Management_System.Forms
{
    public partial class CustomerForm : Form
    {
        private DataGridView dgvCustomer;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private CustomerRepository CustomerRepository;

        public CustomerForm()
        {
            Text = "Customer Management";
            Size = new System.Drawing.Size(800, 600);

            CustomerRepository = new CustomerRepository(new NorthwindContext());

            dgvCustomer = new DataGridView
            {
                Location = new System.Drawing.Point(50, 50),
                Size = new System.Drawing.Size(700, 300),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            LoadCustomers();

            btnAdd = new Button
            {
                Text = "Add",
                Location = new System.Drawing.Point(50, 400),
                Size = new System.Drawing.Size(100, 30)
            };
            btnAdd.Click += (s, e) =>
            { 
                using (var detailsFrom = new CustomerDetailsForm())
                {
                    if (detailsFrom.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            CustomerRepository.Add(detailsFrom.Customer);
                            LoadCustomers();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error while adding customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            };
            

            btnUpdate = new Button
            {
                Text = "Update",
                Location = new System.Drawing.Point(200, 400),
                Size = new System.Drawing.Size(100, 30)
            };
            btnUpdate.Click += (s, e) => 
            {
                if (dgvCustomer.SelectedRows.Count > 0)
                {
                    var id = (int)dgvCustomer.SelectedRows[0].Cells[0].Value;
                    var customer = CustomerRepository.GetById(id);
                    if (customer != null)
                    {
                        using (var detailForm = new CustomerDetailsForm(customer))
                        {
                            if (detailForm.ShowDialog() == DialogResult.OK)
                            {
                                try
                                {
                                    CustomerRepository.Update(detailForm.Customer);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error while updating Customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a customer to update.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            };
            

            btnDelete = new Button
            {
                Text = "Delete",
                Location = new System.Drawing.Point(350, 400),
                Size = new System.Drawing.Size(100, 30)
            };
            btnDelete.Click += (s, e) =>
            {
                if (dgvCustomer.SelectedRows.Count > 0)
                {
                    var id = (int)dgvCustomer.SelectedRows[0].Cells[0].Value;
                    try
                    {
                        CustomerRepository.Delete(id);
                        LoadCustomers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while deleting Customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a Cutomer to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            Controls.Add(dgvCustomer);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
        }

        private void LoadCustomers()
        {
            try
            {
                dgvCustomer.DataSource = CustomerRepository.GetAll().Select(c => new
                {
                    c.CustomerId,
                    c.ContactName,
                    c.Phone,
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading Customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
