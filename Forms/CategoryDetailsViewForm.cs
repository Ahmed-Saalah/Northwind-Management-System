using Northwind_Management_System.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Northwind_Management_System.Forms
{
    public partial class CategoryDetailsViewForm : Form
    {
        public CategoryDetailsViewForm(Category category)
        {
            InitializeComponent();
            Text = "Category Details";
            Size = new System.Drawing.Size(500, 400);

            var lblName = new Label
            {
                Text = "Category Name: " + category.CategoryName,
                Location = new System.Drawing.Point(30, 30),
                AutoSize = true
            };

            var lblDescription = new Label
            {
                Text = "Description: " + (category.Description ?? "N/A"),
                Location = new System.Drawing.Point(30, 70),
                AutoSize = true
            };

            var lblProducts = new Label
            {
                Text = "Products:",
                Location = new System.Drawing.Point(30, 110),
                AutoSize = true
            };

            var lstProducts = new ListBox
            {
                Location = new System.Drawing.Point(30, 140),
                Size = new System.Drawing.Size(400, 200)
            };

            if (category.Products != null && category.Products.Any())
            {
                 lstProducts.Items.AddRange(category.Products.Select(p => 
                    $"{p.ProductName} - {p.UnitPrice:C}")
                    .ToArray());
            }
            else
            {
                lstProducts.Items.Add("No products available.");
            }

            Controls.Add(lblName);
            Controls.Add(lblDescription);
            Controls.Add(lblProducts);
            Controls.Add(lstProducts);
        }
    }
}
