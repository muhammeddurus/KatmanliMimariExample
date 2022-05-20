using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KatmanliBLL;
using KatmanliBLL.Repository;
using KatmanliDAL;

namespace KatmanliWinUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        CategoryRepository cr = new CategoryRepository();
        OrderDetailRepository orDetail = new OrderDetailRepository();
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource= cr.GetAll();
            try
            {
                orDetail.Insert(new Order_Detail
                {
                    OrderID = 10324,
                    ProductID = 2,
                    Quantity = 10,
                    UnitPrice = 1,
                    Discount = 0
                });
            }
            catch (Exception ex)
            {

                MessageBox.Show("Test"+ex.Message);
            }
          
        }
    }
}
