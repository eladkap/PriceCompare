using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Xml;

namespace XmlAccess
{
    public class XmlValidator
    {
        private static bool IsFileWithXmlExtension(string xmlFilePath)
        {
            return Path.GetExtension(xmlFilePath).Equals(".xml");
        }

        private static bool IsXmlFileValid(string xmlFilePath)
        {
            try
            {
                XDocument.Load(xmlFilePath);
                return true;
            }
            catch (XmlException e)
            {
                return false;
            } 
        }

        public static bool IsValidXmlFile(string xmlFilePath)
        {
            return IsFileWithXmlExtension(xmlFilePath) && IsXmlFileValid(xmlFilePath);
        }
    }
}
