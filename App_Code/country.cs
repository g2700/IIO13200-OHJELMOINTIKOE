using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;


[Serializable()]
public class Country
{
    [XmlElement("Code")]
    public string Code { get; set; }
    [XmlElement("Name")]
    public string Name { get; set; }
    [XmlElement("Continent")]
    public string Continent { get; set; }
    [XmlElement("Region")]
    public string Region { get; set; }
    [XmlElement("SurfaceArea")]
    public double SurfaceArea { get; set; }
    [XmlElement("IndepYear")]
    public string IndepYear { get; set; }
    [XmlElement("Population")]
    public int Population { get; set; }
    [XmlElement("LifeExpectancy")]
    public string LifeExpectancy { get; set; }
    [XmlElement("GNP")]
    public string GNP { get; set; }
    [XmlElement("GNPOld")]
    public string GNPOld { get; set; }
    [XmlElement("LocalName")]
    public string LocalName { get; set; }
    [XmlElement("GovernmentForm")]
    public string GovernmentForm { get; set; }
    [XmlElement("HeadOfState")]
    public string HeadOfState { get; set; }
    [XmlElement("Capital")]
    public string Capital { get; set; }
    [XmlElement("Code2")]
    public string Code2 { get; set; }

    public Country()
    {

    }
}