using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;


[Serializable()]
[XmlRoot("DATA")]
public class Countries
{
    [XmlElement("ROW")]
    public List<Country> countries { get; set; }

    public Countries()
    {
        countries = new List<Country>();
    }
}