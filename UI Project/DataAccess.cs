using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

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

namespace UI_Project
{
    class DataAccess
    {
        public ArrayList RetreiveAllProducts()
        {
            ArrayList ProductsList = new ArrayList();
            using (var reader = new StreamReader(@"C:\Users\kolindo\OneDrive\Desktop\Product.txt"))
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                List<string> listC = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split('\t');


                    listA.Add(values[0]);
                    listB.Add(values[1]);
                    listC.Add(values[2]);



                    int ProductID = Convert.ToInt32(values[0]);
                    string ProductName = values[1];
                    string ProductPrice = values[2];

                    ProductsList.Add(new Details() { ID = ProductID, Name = ProductName, Price = ProductPrice });

                }


                return ProductsList;
            }
        }



    }
}

