using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web4
{
    public class Constellation
    {
        [System.Xml.Serialization.XmlAttribute("ID", Namespace = "")]
        public int sID { get; set; }
        [System.Xml.Serialization.XmlElement("name", Namespace = "")]
        public string sname { get; set; }
        public string latinname { get; set; }
        public int area { get; set; }
        public int numberofstarsbrighterthan6m{get;set;}
    }
}
