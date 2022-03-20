using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web4
{
    public class SpectralClass
    {
        [System.Xml.Serialization.XmlAttribute("ID", Namespace = "")]
        public int ID { get; set; }
        [System.Xml.Serialization.XmlElement("name", Namespace = "")]
        public string name { get; set; }
        public string colour { get; set; }
        public int temperature { get; set; }
    }
}
