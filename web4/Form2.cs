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
using System.Text.Json;

namespace web4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Universe universe = new Universe();

            universe.stars = new List<Star>();
            universe.stars.Add(new Star() { sID = 1, sname = "Альтаир", numberbybrightness = 12, age = 16.8, brightness = 0.77, constellation = 1, spectralclass = 10 });
            universe.stars.Add(new Star() { sID = 2, sname = "Сириус", numberbybrightness = 1, age = 8.6, brightness = -1.5, constellation = 3, spectralclass = 30 });
            universe.stars.Add(new Star() { sID = 3, sname = "Вега", numberbybrightness = 5, age = 25.3, brightness = -1.5, constellation = 2, spectralclass = 30 });

            universe.constellations = new List<Constellation>();
            universe.constellations.Add(new Constellation() { sID = 1, sname = "Орел", latinname = "Aquila", area = 652, numberofstarsbrighterthan6m = 70 });
            universe.constellations.Add(new Constellation() { sID = 2, sname = "Лира", latinname = "Lyra", area = 286, numberofstarsbrighterthan6m = 45 });
            universe.constellations.Add(new Constellation() { sID = 3, sname = "Большой Пес", latinname = "Canis Major", area = 380, numberofstarsbrighterthan6m = 80 });

            universe.spectralclasses = new List<SpectralClass>();
            universe.spectralclasses.Add(new SpectralClass() { ID = 10, name = "F", colour = "желтый", temperature = 8000 });
            universe.spectralclasses.Add(new SpectralClass() { ID = 30, name = "A", colour = "белый", temperature = 10000 });

            XmlSerializer serial = new XmlSerializer(typeof(Universe));
            
            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\universe.xml", FileMode.Create, FileAccess.Write))
            {
                serial.Serialize(fs, universe);
                MessageBox.Show("Created");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Universe universe;
            
            XmlSerializer serial = new XmlSerializer(typeof(Universe));
            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\universe.xml", FileMode.Open, FileAccess.Read))
            {
                universe = serial.Deserialize(fs) as Universe;
            }
            dataGridView1.DataSource = universe.stars;
            dataGridView2.DataSource = universe.constellations;
            dataGridView3.DataSource = universe.spectralclasses;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Universe universe = new Universe();

            universe.stars = new List<Star>();
            universe.stars.Add(new Star() { sID = 1, sname = "Альтаир", numberbybrightness = 12, age = 16.8, brightness = 0.77, constellation = 1, spectralclass = 10 });
            universe.stars.Add(new Star() { sID = 2, sname = "Сириус", numberbybrightness = 1, age = 8.6, brightness = -1.5, constellation = 3, spectralclass = 30 });
            universe.stars.Add(new Star() { sID = 3, sname = "Вега", numberbybrightness = 5, age = 25.3, brightness = -1.5, constellation = 2, spectralclass = 30 });

            universe.constellations = new List<Constellation>();
            universe.constellations.Add(new Constellation() { sID = 1, sname = "Орел", latinname = "Aquila", area = 652, numberofstarsbrighterthan6m = 70 });
            universe.constellations.Add(new Constellation() { sID = 2, sname = "Лира", latinname = "Lyra", area = 286, numberofstarsbrighterthan6m = 45 });
            universe.constellations.Add(new Constellation() { sID = 3, sname = "Большой Пес", latinname = "Canis Major", area = 380, numberofstarsbrighterthan6m = 80 });

            universe.spectralclasses = new List<SpectralClass>();
            universe.spectralclasses.Add(new SpectralClass() { ID = 10, name = "F", colour = "желтый", temperature = 8000 });
            universe.spectralclasses.Add(new SpectralClass() { ID = 30, name = "A", colour = "белый", temperature = 10000 });
            
            string fileName = "universe.json";
            string jsonString = JsonSerializer.Serialize(universe);
            File.WriteAllText(fileName, jsonString);
            MessageBox.Show("Created");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string fileName = "universe.json";
            string jsonString = File.ReadAllText(fileName);
            Universe universe = JsonSerializer.Deserialize<Universe>(jsonString);

            dataGridView1.DataSource = universe.stars;
            dataGridView2.DataSource = universe.constellations;
            dataGridView3.DataSource = universe.spectralclasses;
        }
    } 
}
