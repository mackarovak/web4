using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web4
{
    public class Star
    {
        [System.Xml.Serialization.XmlAttribute("ID",Namespace ="")]
        public int sID { get; set; }
        [System.Xml.Serialization.XmlElement("name", Namespace ="")]
        public string sname { get; set; }
        public int constellation { get; set; }
        public int numberbybrightness { get; set; }
        public double age { get; set; }
        public double brightness { get; set; }
        [System.Xml.Serialization.XmlElement("spectralclass", Namespace ="")]
        public int spectralclass { get; set; }

    }
}
