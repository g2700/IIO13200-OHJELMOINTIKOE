using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;


public class BL
{
    public static void SerialisoiXml(string tiedosto, Countries ctr)
    {
        XmlSerializer xs = new XmlSerializer(ctr.GetType());
        TextWriter tw = new StreamWriter(tiedosto);
        try
        {
            xs.Serialize(tw, ctr);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            tw.Close();
        }
    }

    public static void DeSerialisoiXml(string filePath, ref Countries ctr)
    {
        XmlSerializer deserializer = new XmlSerializer(typeof(Countries));
        try
        {
            FileStream xmlFile = new FileStream(filePath, FileMode.Open);
            ctr = (Countries)deserializer.Deserialize(xmlFile);
            xmlFile.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }

    }

}