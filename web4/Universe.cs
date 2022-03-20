using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web4
{
    public class Universe
    {
     //  [System.Xml.Serialization.XmlElement("star")]
       public List <Star> stars { get; set; }
       //[System.Xml.Serialization.XmlElement("constellation")]
       public List <Constellation> constellations { get; set; }
       //[System.Xml.Serialization.XmlElement("spectralslass")]
       public List<SpectralClass> spectralclasses { get; set; }
    }
}
