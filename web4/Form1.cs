using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;

namespace web4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Star> star = new List<Star>();
            XmlSerializer serial = new XmlSerializer(typeof(List<Star>));
            star.Add(new Star() { sID = 1, sname = "Альтаир", numberbybrightness = 12, age = 16.8, brightness = 0.77, constellation = 1, spectralclass = 10 });
            star.Add(new Star() { sID = 2, sname = "Сириус", numberbybrightness = 1, age = 8.6, brightness = -1.5, constellation = 3, spectralclass = 30 });
            star.Add(new Star() { sID = 3, sname = "Вега", numberbybrightness = 5, age = 25.3, brightness = -1.5, constellation = 2, spectralclass = 30 });
            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\star.xml", FileMode.Create, FileAccess.Write))
            {
                serial.Serialize(fs, star);
                MessageBox.Show("Created");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Star> star = new List<Star>();
            XmlSerializer serial = new XmlSerializer(typeof(List<Star>));
            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\star.xml", FileMode.Open, FileAccess.Read))
            {
                star = serial.Deserialize(fs) as List<Star>;
            }
            dataGridView1.DataSource = star;
        }
    }
}
