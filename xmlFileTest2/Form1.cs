using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace xmlFileTest2
{
    public partial class Form1 : Form
    {
        Decimal[] array1 = new Decimal[4] { 0.1m, 93.2m, 3876.1839m, 12.3892m };
        Decimal[] array2 = new Decimal[4] { 0.1m, 93.2m, 3876.1839m, 12.3892m };
        Decimal[] array3 = new Decimal[4] { 0.1m, 93.2m, 3876.1839m, 12.3892m };
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //creates an empty sort of 'frame' for the data
            String xmlBase =
                @"<?xml version=""1.0""?> 
                <root>
                    <array1>
                    </array1>
                    <array2>
                    </array2>
                    <array3>
                    </array3>
                </root>";
            //parses the string frame into an xml file
            XDocument savedPiece = XDocument.Parse(xmlBase);

            //each foreach loop fills in the node with data from an array
            foreach (Decimal element in array1)
            {
                savedPiece.Element("root").Element("array1").Add(new XElement("queue", element));
            }
            foreach (Decimal element in array2)
            {
                savedPiece.Element("root").Element("array2").Add(new XElement("queue", element));
            }
            foreach (Decimal element in array3)
            {
                savedPiece.Element("root").Element("array3").Add(new XElement("queue", element));
            }
            //saves it to computer with name
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\savedpiece.xml";
            savedPiece.Save(path);

        }
    }
}
