using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace web4
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<SpectralClass> spectralclass = new List<SpectralClass>();
            XmlSerializer serial = new XmlSerializer(typeof(List<SpectralClass>));
            spectralclass.Add(new SpectralClass() { ID = 10, name = "F", colour="желтый", temperature=8000 });
            spectralclass.Add(new SpectralClass() { ID = 30, name = "A", colour="белый", temperature=10000 });
            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\spectralclass.xml", FileMode.Create, FileAccess.Write))
            {
                serial.Serialize(fs, spectralclass);
                MessageBox.Show("Created");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<SpectralClass> spectralclass = new List<SpectralClass>();
            XmlSerializer serial = new XmlSerializer(typeof(List<SpectralClass>));
            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\spectralclass.xml", FileMode.Open, FileAccess.Read))
            {
                spectralclass = serial.Deserialize(fs) as List<SpectralClass>;
            }
            dataGridView1.DataSource = spectralclass;
        }
    }
}
