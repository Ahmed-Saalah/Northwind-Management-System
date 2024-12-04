using System;
using System.Drawing;
using System.Windows.Forms;

namespace Northwind_Management_System.Forms
{
    public partial class MainForm : Form
    {
        private Panel sidebarPanel;
        private Panel headerPanel;
        private Panel contentPanel;
        private Label lblHeader;

        public MainForm()
        {
            Text = "Northwind Management System";
            Size = new Size(1000, 700);
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(800, 600);

            // Define theme colors
            Color primaryColor = Color.FromArgb(52, 152, 219);
            Color secondaryColor = Color.FromArgb(41, 128, 185);
            Color backgroundColor = Color.FromArgb(236, 240, 241);
            Font headerFont = new Font("Arial", 18, FontStyle.Bold);
            Font buttonFont = new Font("Arial", 12, FontStyle.Bold);

            // Header Panel
            headerPanel = new Panel
            {
                BackColor = primaryColor,
                Dock = DockStyle.Top,
                Height = 70
            };

            lblHeader = new Label
            {
                Text = "Northwind Management System",
                ForeColor = Color.White,
                Font = headerFont,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            headerPanel.Controls.Add(lblHeader);

            // Sidebar Panel
            sidebarPanel = new Panel
            {
                BackColor = secondaryColor,
                Dock = DockStyle.Left,
                Width = 200
            };

            // Content Panel
            contentPanel = new Panel
            {
                BackColor = backgroundColor,
                Dock = DockStyle.Fill
            };

            // Sidebar Buttons
            var btnCategories = CreateSidebarButton("Categories", 0);
            btnCategories.Click += (s, e) => LoadContent(new CategoryForm(), btnCategories);

            var btnProducts = CreateSidebarButton("Products", 1);
            btnProducts.Click += (s, e) => LoadContent(new ProductForm(), btnProducts);

            var btnCustomers = CreateSidebarButton("Customers", 2);
            btnCustomers.Click += (s, e) => LoadContent(new CustomerForm(), btnCustomers);

            sidebarPanel.Controls.Add(btnCategories);
            sidebarPanel.Controls.Add(btnProducts);
            sidebarPanel.Controls.Add(btnCustomers);

            // Add Panels to Form
            Controls.Add(headerPanel);
            Controls.Add(sidebarPanel);
            Controls.Add(contentPanel);
        }

        private Button CreateSidebarButton(string text, int positionIndex)
        {
            return new Button
            {
                Text = text,
                Size = new Size(200, 50),
                BackColor = Color.FromArgb(41, 128, 185),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0),
                Location = new Point(0, 70 + positionIndex * 60),
                Cursor = Cursors.Hand
            };
        }

        private void LoadContent(Form form, Button activeButton)
        {
            // First clear the contentPanel to avoid overlap of forms
            foreach (Control control in contentPanel.Controls)
            {
                control.Dispose();  // Dispose the existing form
            }

            // Set form to be in the contentPanel, without docking
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;

            // Manually set the location to center the form
            form.Size = new Size(contentPanel.Width - 40, contentPanel.Height - 90); // Adjust size as needed
            form.Location = new Point((contentPanel.Width - form.Width + 300) / 2, (contentPanel.Height - form.Height) / 2);

            contentPanel.Controls.Add(form);
            form.Show();

            // Highlight the active button
            foreach (var button in sidebarPanel.Controls.OfType<Button>())
            {
                button.BackColor = Color.FromArgb(41, 128, 185); // Default color
            }
            activeButton.BackColor = Color.FromArgb(52, 152, 219); // Highlighted color
        }


    }
}
