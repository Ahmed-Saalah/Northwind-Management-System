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
    public partial class ProductDetailsViewForm : Form
    {
        public ProductDetailsViewForm(Product product)
        {
            Text = "Product Details";
            Size = new System.Drawing.Size(400, 400);

            var lblName = new Label
            {
                Text = "Product Name: " + product.ProductName,
                Location = new System.Drawing.Point(30, 30),
                AutoSize = true
            };

            var lblPrice = new Label
            {
                Text = "Unit Price: " + (product.UnitPrice.HasValue ? product.UnitPrice.Value.ToString("C") : "N/A"),
                Location = new System.Drawing.Point(30, 80),
                AutoSize = true
            };

            var lblStock = new Label
            {
                Text = "Units in Stock: " + product.UnitsInStock,
                Location = new System.Drawing.Point(30, 130),
                AutoSize = true
            };

            var lblCategory = new Label
            {
                Text = "Category: " + (product.Category?.CategoryName ?? "N/A"),
                Location = new System.Drawing.Point(30, 180),
                AutoSize = true
            };

            var lblSupplier = new Label
            {
                Text = "Supplier: " + (product.Supplier?.CompanyName ?? "N/A"),
                Location = new System.Drawing.Point(30, 230),
                AutoSize = true
            };

            var lblQuantity = new Label
            {
                Text = "Quantity Per Unit: " + product.QuantityPerUnit,
                Location = new System.Drawing.Point(30, 280),
                AutoSize = true
            };

            // Add controls to the form
            Controls.Add(lblName);
            Controls.Add(lblPrice);
            Controls.Add(lblStock);
            Controls.Add(lblCategory);
            Controls.Add(lblSupplier);
            Controls.Add(lblQuantity);
        }
    }
}
