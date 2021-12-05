using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ClinicManager.ViewModels
{
    class ConnectionStringHelper
    {
        private IList<XmlElement> connectionStrings = new List<XmlElement>();

        public string ConnectionString => connectionStrings[1].Attributes.GetNamedItem("value").Value;
        public string ClinicDataEntities => connectionStrings[0].Attributes.GetNamedItem("value").Value;

        /* Singleton instance */
        private ConnectionStringHelper _instance;
        private ConnectionStringHelper()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"../../ClinicManager.config");

            XmlElement xRoot = xDoc.DocumentElement;

            foreach (XmlElement elem in xRoot)
            {
                connectionStrings.Add(elem);
            }
        }
        public ConnectionStringHelper ConnectionStringInstance => _instance ?? new ConnectionStringHelper(); 
    }
}
