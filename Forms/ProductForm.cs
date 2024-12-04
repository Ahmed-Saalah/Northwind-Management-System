using Northwind_Management_System.Context;
using Northwind_Management_System.DAL;
using Northwind_Management_System.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Northwind_Management_System.Forms
{
    public partial class ProductForm : Form
    {
        private DataGridView dgvProducts;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private ProductRepository productRepository;

        public ProductForm()
        {
            Text = "Product Management";
            Size = new System.Drawing.Size(700, 500);

            productRepository = new ProductRepository(new NorthwindContext());

            dgvProducts = new DataGridView
            {
                Location = new System.Drawing.Point(50, 50),
                Size = new System.Drawing.Size(600, 300),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            LoadProducts();

            var btnDetails = new Button
            {
                Text = "Details",
                Location = new System.Drawing.Point(50, 400),
                Size = new System.Drawing.Size(100, 30)
            };
            btnDetails.Click += (s, e) =>
            {
                if (dgvProducts.SelectedRows.Count > 0)
                {
                    var id = (int)dgvProducts.SelectedRows[0].Cells[0].Value;
                    var product = productRepository.GetById(id);

                    if (product != null)
                    {
                        using (var detailsForm = new ProductDetailsViewForm(product))
                        {
                            detailsForm.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a product to view details.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            btnAdd = new Button
            {
                Text = "Add",
                Location = new System.Drawing.Point(200, 400),
                Size = new System.Drawing.Size(100, 30)
            };
            btnAdd.Click += (s, e) =>
            {
                var categories = productRepository.GetCategories().ToList();
                var suppliers = productRepository.GetSuppliers().ToList();

                using (var detailsForm = new ProductDetailsForm(suppliers, categories))
                {
                    if (detailsForm.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            productRepository.Add(detailsForm.Product);
                            LoadProducts();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error while adding product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            };

            btnUpdate = new Button
            {
                Text = "Update",
                Location = new System.Drawing.Point(350, 400),
                Size = new System.Drawing.Size(100, 30)
            };
            btnUpdate.Click += (s, e) =>
            {
                if (dgvProducts.SelectedRows.Count > 0)
                {
                    var id = (int)dgvProducts.SelectedRows[0].Cells[0].Value;
                    var product = productRepository.GetById(id);

                    if (product != null)
                    {
                        var categories = productRepository.GetCategories().ToList();
                        var suppliers = productRepository.GetSuppliers().ToList();

                        using (var detailsForm = new ProductDetailsForm(suppliers, categories, product))
                        {
                            if (detailsForm.ShowDialog() == DialogResult.OK)
                            {
                                try
                                {
                                    productRepository.Update(detailsForm.Product);
                                    LoadProducts();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error while updating product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a product to update.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };


            btnDelete = new Button
            {
                Text = "Delete",
                Location = new System.Drawing.Point(500, 400),
                Size = new System.Drawing.Size(100, 30)
            };
            btnDelete.Click += (s, e) =>
            {
                if (dgvProducts.SelectedRows.Count > 0)
                {
                    var id = (int)dgvProducts.SelectedRows[0].Cells[0].Value;

                    try
                    {
                        productRepository.Delete(id);
                        LoadProducts();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while deleting product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a product to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            Controls.Add(dgvProducts);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDetails);
            Controls.Add(btnDelete);
        }

        private void LoadProducts()
        {
            try
            {
                dgvProducts.DataSource = productRepository.GetProductsWithCategory().Select(p => new
                {
                    p.ProductId,
                    p.ProductName,
                    p.UnitPrice,
                    p.UnitsInStock,
                    p.QuantityPerUnit,
                    CategoryName = p.Category?.CategoryName ?? "N/A",  // Handle null categories
                    SupplierName = p.Supplier?.CompanyName ?? "N/A"   // Handle null suppliers
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
