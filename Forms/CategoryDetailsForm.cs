using Northwind_Management_System.Models;
using System;
using System.Windows.Forms;

namespace Northwind_Management_System.Forms
{
    public partial class CategoryDetailsForm : Form
    {
        public Category Category { get; private set; }

        // Controls
        private TextBox txtCategoryName;
        private TextBox txtDescription;
        private Button btnSave;
        private Button btnCancel;

        public CategoryDetailsForm()
        {
            InitializeComponent();
            Category = new Category();

            // Initialize controls
            txtCategoryName = new TextBox { Location = new System.Drawing.Point(150, 50), Width = 200 };
            txtDescription = new TextBox { Location = new System.Drawing.Point(150, 100), Width = 200, Height = 60, Multiline = true };
            btnSave = new Button { Text = "Save", Location = new System.Drawing.Point(150, 180), Size = new System.Drawing.Size(75, 30) };
            btnCancel = new Button { Text = "Cancel", Location = new System.Drawing.Point(250, 180), Size = new System.Drawing.Size(75, 30) };

            // Event handlers
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;

            // Adding controls to the form
            Controls.Add(new Label { Text = "Category Name", Location = new System.Drawing.Point(50, 50) });
            Controls.Add(new Label { Text = "Description", Location = new System.Drawing.Point(50, 100) });
            Controls.Add(txtCategoryName);
            Controls.Add(txtDescription);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);

            // Set form properties
            Text = "Category Details";
            Size = new System.Drawing.Size(400, 300);
        }

        public CategoryDetailsForm(Category category) : this()
        {
            Category = category;
            txtCategoryName.Text = category.CategoryName;
            txtDescription.Text = category.Description;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Category.CategoryName = txtCategoryName.Text;
            Category.Description = txtDescription.Text;

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
