using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace web4
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Constellation> constellations = new List<Constellation>();
            XmlSerializer serial = new XmlSerializer(typeof(List<Constellation>));
            constellations.Add(new Constellation() { sID = 1, sname = "Орел", latinname = "Aquila", area = 652, numberofstarsbrighterthan6m = 70 });
            constellations.Add(new Constellation() { sID = 2, sname = "Лира", latinname = "Lyra", area = 286, numberofstarsbrighterthan6m = 45 });
            constellations.Add(new Constellation() { sID = 3, sname = "Большой Пес", latinname = "Canis Major", area = 380, numberofstarsbrighterthan6m = 80 });
            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\constellations.xml", FileMode.Create, FileAccess.Write))
            {
                serial.Serialize(fs, constellations);
                MessageBox.Show("Created");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Constellation> constellations = new List<Constellation>();
            XmlSerializer serial = new XmlSerializer(typeof(List<Constellation>));
            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\constellations.xml", FileMode.Open, FileAccess.Read))
            {
                constellations = serial.Deserialize(fs) as List<Constellation>;
            }
            dataGridView1.DataSource = constellations;
        }
    }
}
