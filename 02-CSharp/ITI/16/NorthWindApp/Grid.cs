using Microsoft.EntityFrameworkCore;
using NorthWindApp.Context;
using NorthWindApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NorthWindApp
{
    public partial class Grid : Form
    {
        NorthwindContext Context = new();
        BindingSource bindingSource;
        public Grid()
        {
            InitializeComponent();
        }
        private void Grid_Load(object sender, EventArgs e)
        {
            this.FormClosed += (sender, e) => Context?.Dispose();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Binding with Windows forms : 

            // // V1.0 : one way binding , valid for update only but insert and delete not valid
            // var products = (from p in Context.Products
            //                 where p.UnitsInStock > 0
            //                 select p).ToList();        // differed execution , so we must make it immediate exec to make binding (WRONG way)
            // 
            // // this will allow "Update" only , but when adding or deleting we are adding and deleting from the "List called products" 
            // // so this is not tracked
            // 
            // bindingSource = new BindingSource(products, "");
            // gridView.DataSource = bindingSource;

            // // V2.0 : Wrong !
            // bindingSource = new BindingSource(Context.Products, "");      // to make it work use .ToList() , (same problem of V1.0 above)
            // gridView.DataSource = bindingSource;                      

            // V3.0 : Right way , this is the two way binding 

            // 1. Load All products from DB to local copy
            Context.Products.Load();    // getAll prds and stored in the load 

            // 2. Bind control to local copy
            gridView.DataSource = Context.Products.Local.ToBindingList();

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView.EndEdit();
            Context.SaveChanges();

            // Note : the EFCore ".SaveChanges" is Transactional By default , means that if we have 3 statements and the last one failed then
            //        all of them will fail , BUT ADO is not Transactional by default , but can be achieved by making a transaction object 
        }
    }
}
