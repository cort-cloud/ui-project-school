using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;
namespace UI_Project
{
    public partial class Form1 : Form
    {
        Details ProductDetails = new Details();

        static List<Int16> listA = new List<Int16>();
        static List<string> listB = new List<string>();
        static List<string> listC = new List<string>();
        public Form1()
        {
            InitializeComponent();



           


           
               


           



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (var streamReader = new StreamReader(@"C:\Users\kolindo\OneDrive\Desktop\Product.txt"))
            {
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();
                    var values = line.Split('\t');
                    var rowIndex = dataGridView1.Rows.Add();
                    for (int i = 0; i < values.Length; i++)
                    {
                        dataGridView1.Rows[rowIndex].Cells[i].Value = values[i];
                    }
                }
            }
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:

                    break;
                case MouseButtons.Left:

                    break;
            }
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            Button ProductButton = sender as Button;







            switch (MouseButtons)
            {
                case MouseButtons.Right:



                    {
                        dataGridView1.AllowUserToAddRows = false;
                        bool Found = false;
                        if (dataGridView1.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (Convert.ToString(row.Cells[0].Value) == "1" && Convert.ToString(row.Cells[1].Value) == "Coffee")
                                {
                                    row.Cells[3].Value = Convert.ToString(Convert.ToInt16(row.Cells[3].Value) - 1);

                                    row.Cells[dataGridView1.Columns["Total"].Index].Value = ((Convert.ToDouble(row.Cells[dataGridView1.Columns["Price"].Index].Value) * Convert.ToDouble(row.Cells[dataGridView1.Columns["Quantity"].Index].Value)));


                                    Found = true;
                                }






                            }
                            if (!Found)
                            {


                                dataGridView1.Rows.Add("1", "Coffee", "1.50", "1", 150 * 1);





                            }
                        }
                        else
                        {

                            dataGridView1.Rows.Add("1", "Coffee", "1.50", "1", 150 * 1);

                        }

                    }
                    break;

                case MouseButtons.Left:
                    {
                        bool Found = false;
                        if (dataGridView1.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (Convert.ToString(row.Cells[0].Value) == "1" && Convert.ToString(row.Cells[1].Value) == "Coffee")
                                {
                                    row.Cells[3].Value = Convert.ToString(1 + Convert.ToInt16(row.Cells[3].Value));

                                    row.Cells[dataGridView1.Columns["Total"].Index].Value = ((Convert.ToDouble(row.Cells[dataGridView1.Columns["Price"].Index].Value) * Convert.ToDouble(row.Cells[dataGridView1.Columns["Quantity"].Index].Value)));

                                    Found = true;
                                }






                            }
                            if (!Found)
                            {


                                dataGridView1.Rows.Add("1", "Coffee", "1.50", "1", 150 * 1);





                            }
                        }
                        else
                        {

                            dataGridView1.Rows.Add("1", "Coffee", "1.50", "1", 1.50 * 1);

                        }


                    }
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }


        private void button4_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void button5_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void button6_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

            flowLayoutPanel1.Controls.Clear();

            Button btn = (Button)sender;



            DataAccess _DataAccess = new DataAccess();

            ArrayList AllProducts = _DataAccess.RetreiveAllProducts();

            foreach (Details Product in AllProducts)
            {
                Button ProductButton = new Button();
                ProductButton.Text = Product.Name;
                ProductButton.Size = new System.Drawing.Size(75, 35);
                ProductButton.ForeColor = Color.Black;
                ProductButton.BackColor = Color.LightBlue;



                ProductButton.Tag = Product.ID;

                flowLayoutPanel1.Controls.Add(ProductButton);


                ProductButton.MouseDown += ProductButton_MouseDown;

                //ProductButton.MouseClick += ProductButton_MouseClick;
            }



        }
        void ProductButton_MouseClick(object sender, MouseEventArgs e)
        {
            //for loweing one quantity. do this.. <---------------------
            switch (e.Button)
            {
                case MouseButtons.Right:
                    MessageBox.Show("Right Click");
                    break;
                case MouseButtons.Left:
                    MessageBox.Show("Left Click");
                    break;
            }
        }







        void ProductButton_MouseDown(object sender, MouseEventArgs e)
        {

            Button ProductButton = sender as Button;

            DataAccess _DataAccess = new DataAccess();

            ProductButton.Tag = ProductDetails.ID;



            using (var reader = new StreamReader(@"C:\Users\kolindo\OneDrive\Desktop\Product.txt"))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split('\t');







                    listA.Add(Convert.ToInt16(values[0]));
                    listB.Add(values[1]);
                    listC.Add(values[2]);


                    ProductDetails.ID = Convert.ToInt16(values[0]);
                    ProductDetails.Name = values[1];
                    ProductDetails.Price = values[2];






                    switch (MouseButtons)
                    {
                        case MouseButtons.Right:



                            {
                                dataGridView1.AllowUserToAddRows = false;
                                bool Found = false;
                                if (dataGridView1.Rows.Count > 0)
                                {
                                    foreach (DataGridViewRow row in dataGridView1.Rows)
                                    {
                                        if (Convert.ToString(row.Cells[1].Value) == ProductDetails.Name)
                                        {
                                            row.Cells[3].Value = Convert.ToString(Convert.ToInt16(row.Cells[3].Value) - 1);

                                            row.Cells[dataGridView1.Columns["Total"].Index].Value = ((Convert.ToDouble(row.Cells[dataGridView1.Columns["Price"].Index].Value) * Convert.ToDouble(row.Cells[dataGridView1.Columns["Quantity"].Index].Value)));


                                            Found = true;
                                        }






                                    }
                                    if (!Found)
                                    {


                                        dataGridView1.Rows.Add(ProductDetails.ID, ProductDetails.Name, ProductDetails.Price, "1", Convert.ToDecimal(ProductDetails.Price) * 1);





                                    }
                                }
                                else
                                {

                                    dataGridView1.Rows.Add(ProductDetails.ID, ProductDetails.Name, ProductDetails.Price, "1", Convert.ToDecimal(ProductDetails.Price) * 1);

                                }

                            }
                            break;

                        case MouseButtons.Left:
                            {
                                bool Found = false;
                                if (dataGridView1.Rows.Count > 0)
                                {
                                    foreach (DataGridViewRow row in dataGridView1.Rows)
                                    {
                                        if (Convert.ToString(row.Cells[1].Value) == ProductDetails.Name)
                                        {
                                            row.Cells[3].Value = Convert.ToString(1 + Convert.ToInt16(row.Cells[3].Value));

                                            row.Cells[dataGridView1.Columns["Total"].Index].Value = ((Convert.ToDouble(row.Cells[dataGridView1.Columns["Price"].Index].Value) * Convert.ToDouble(row.Cells[dataGridView1.Columns["Quantity"].Index].Value)));

                                            Found = true;
                                        }






                                    }
                                    if (!Found)
                                    {


                                        dataGridView1.Rows.Add(ProductDetails.ID, ProductDetails.Name, ProductDetails.Price, "1", Convert.ToDecimal(ProductDetails.Price) * 1);





                                    }
                                }
                                else
                                {

                                    dataGridView1.Rows.Add(ProductDetails.ID, ProductDetails.Name, ProductDetails.Price, "1", Convert.ToDecimal(ProductDetails.Price) * 1);

                                }


                            }
                            break;
                    }
                   
                }
            }
        }
                
      
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

