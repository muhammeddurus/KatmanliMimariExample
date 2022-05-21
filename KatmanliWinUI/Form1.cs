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
using KatmanliDTO;

namespace KatmanliWinUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        CategoryRepository cr = new CategoryRepository();
        
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource= cr.GetAll();
           
          
        }

        private void buttonIdyeGore_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox3.Text);
            List<CategoryDto> category = new List<CategoryDto>();
            category.Add(cr.GetById(id));
            dataGridView1.DataSource = category;
            
        }
    }
}
