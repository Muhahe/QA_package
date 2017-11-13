using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WHSQA.HelperClasses
{
    class XmlFileReader
    {
        private XmlDocument XmlDoc = new XmlDocument();
        private String ErrorNodeText;
        private XmlNode ErrorNode;
        

        public XmlFileReader(String filePath) {

            XmlDoc.Load(filePath);
            this.ErrorNode = XmlDoc.DocumentElement.SelectSingleNode("//NodeError");
            if (this.ErrorNode != null) { 
            this.ErrorNodeText = this.ErrorNode.Attributes["Message"].Value;
            }
            Console.WriteLine(this.ErrorNodeText);
        }

        public String GetErrorNodeText() {
            return this.ErrorNodeText;
        }
    }
}
