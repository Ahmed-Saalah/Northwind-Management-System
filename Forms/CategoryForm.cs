using Northwind_Management_System.Context;
using Northwind_Management_System.DAL;
using Northwind_Management_System.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Northwind_Management_System.Forms
{
    public partial class CategoryForm : Form
    {
        private DataGridView dgvCategories;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnDetails;
        private CategoryRepository categoryRepository;

        public CategoryForm()
        {
            InitializeComponent();
            Text = "Category Management";
            Size = new System.Drawing.Size(700, 500);

            categoryRepository = new CategoryRepository(new NorthwindContext());

            dgvCategories = new DataGridView
            {
                Location = new System.Drawing.Point(50, 50),
                Size = new System.Drawing.Size(600, 300),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            LoadCategories();

            btnDetails = new Button
            {
                Text = "Details",
                Location = new System.Drawing.Point(50, 400),
                Size = new System.Drawing.Size(100, 30)
            };
            btnDetails.Click += (s, e) =>
            {
                if (dgvCategories.SelectedRows.Count > 0)
                {
                    var id = (int)dgvCategories.SelectedRows[0].Cells[0].Value;
                    var category = categoryRepository.GetCategoriesByIdWithProducts(id);

                    if (category != null)
                    {
                        using (var detailsForm = new CategoryDetailsViewForm(category))
                        {
                            detailsForm.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a Category to view details.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                using (var detailsForm = new CategoryDetailsForm())
                {
                    if (detailsForm.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            categoryRepository.Add(detailsForm.Category);
                            LoadCategories();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error while adding category: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (dgvCategories.SelectedRows.Count > 0)
                {
                    var id = (int)dgvCategories.SelectedRows[0].Cells[0].Value;
                    var category = categoryRepository.GetById(id);

                    if (category != null)
                    {
                        using (var detailsForm = new CategoryDetailsForm(category))
                        {
                            if (detailsForm.ShowDialog() == DialogResult.OK)
                            {
                                try
                                {
                                    categoryRepository.Update(detailsForm.Category);
                                    LoadCategories();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error while updating category: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a category to update.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (dgvCategories.SelectedRows.Count > 0)
                {
                    var id = (int)dgvCategories.SelectedRows[0].Cells[0].Value;

                    try
                    {
                        categoryRepository.Delete(id);
                        LoadCategories();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while deleting category: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a category to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            Controls.Add(dgvCategories);
            Controls.Add(btnDetails);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
        }

        private void LoadCategories()
        {
            try
            {
                dgvCategories.DataSource = categoryRepository.GetAll().Select(c => new
                {
                    c.CategoryId,
                    c.CategoryName,
                    c.Description
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading categories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
