using Northwind_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Northwind_Management_System.Forms
{
    public partial class ProductDetailsForm : Form
    {
        public Product Product { get; private set; }
        private List<Supplier> Suppliers { get; set; }
        private List<Category> Categories { get; set; }

        public ProductDetailsForm(List<Supplier> suppliers, List<Category> categories, Product product = null)
        {
            Text = product == null ? "Add Product" : "Update Product";
            Size = new System.Drawing.Size(400, 400);

            Suppliers = suppliers;
            Categories = categories;

            Product = product ?? new Product();

            var lblName = new Label
            {
                Text = "Product Name:",
                Location = new System.Drawing.Point(30, 30),
                AutoSize = true
            };
            var txtName = new TextBox
            {
                Location = new System.Drawing.Point(150, 30),
                Size = new System.Drawing.Size(200, 30),
                Text = Product.ProductName ?? ""
            };

            var lblPrice = new Label
            {
                Text = "Unit Price:",
                Location = new System.Drawing.Point(30, 80),
                AutoSize = true
            };
            var txtPrice = new TextBox
            {
                Location = new System.Drawing.Point(150, 80),
                Size = new System.Drawing.Size(200, 30),
                Text = Product.UnitPrice?.ToString() ?? ""
            };

            var lblStock = new Label
            {
                Text = "Units in Stock:",
                Location = new System.Drawing.Point(30, 130),
                AutoSize = true
            };
            var txtStock = new TextBox
            {
                Location = new System.Drawing.Point(150, 130),
                Size = new System.Drawing.Size(200, 30),
                Text = Product.UnitsInStock?.ToString() ?? ""
            };

            var lblSupplier = new Label
            {
                Text = "Supplier:",
                Location = new System.Drawing.Point(30, 180),
                AutoSize = true
            };
            var cmbSupplier = new ComboBox
            {
                Location = new System.Drawing.Point(150, 180),
                Size = new System.Drawing.Size(200, 30),
                DropDownStyle = ComboBoxStyle.DropDownList,
                DataSource = Suppliers,
                DisplayMember = "CompanyName", 
                ValueMember = "SupplierID" 
            };

            if (Product.Supplier != null)
                cmbSupplier.SelectedValue = Product.Supplier.SupplierId;

            var lblCategory = new Label
            {
                Text = "Category:",
                Location = new System.Drawing.Point(30, 230),
                AutoSize = true
            };
            var cmbCategory = new ComboBox
            {
                Location = new System.Drawing.Point(150, 230),
                Size = new System.Drawing.Size(200, 30),
                DropDownStyle = ComboBoxStyle.DropDownList,
                DataSource = Categories,
                DisplayMember = "CategoryName", 
                ValueMember = "CategoryID"  
            };

            if (Product.Category != null)
                cmbCategory.SelectedValue = Product.Category.CategoryId;

            var btnSave = new Button
            {
                Text = "Save",
                Location = new System.Drawing.Point(150, 300),
                Size = new System.Drawing.Size(100, 30)
            };

            btnSave.Click += (s, e) =>
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(txtName.Text))
                        throw new Exception("Product Name is required.");

                    if (!decimal.TryParse(txtPrice.Text, out var price) || price < 0)
                        throw new Exception("Unit Price must be a positive number.");

                    if (!int.TryParse(txtStock.Text, out var stock) || stock < 0)
                        throw new Exception("Units in Stock must be a positive integer.");

                    if (cmbSupplier.SelectedItem == null)
                        throw new Exception("Supplier is required.");

                    if (cmbCategory.SelectedItem == null)
                        throw new Exception("Category is required.");

                    Product.ProductName = txtName.Text;
                    Product.UnitPrice = price;
                    Product.UnitsInStock = (short)stock;
                    Product.Supplier = (Supplier)cmbSupplier.SelectedItem; 
                    Product.Category = (Category)cmbCategory.SelectedItem; 

                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblPrice);
            Controls.Add(txtPrice);
            Controls.Add(lblStock);
            Controls.Add(txtStock);
            Controls.Add(lblSupplier);
            Controls.Add(cmbSupplier);
            Controls.Add(lblCategory);
            Controls.Add(cmbCategory);
            Controls.Add(btnSave);
        }
    }
}
