using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PublishedSummary.Models.Model
{
    [XmlRoot(ElementName = "Item", Namespace = "http://www.tridion.com/ContentManager/5.0")]
    public class Publications
    {
        [XmlAttribute(AttributeName = "PublicationTypeName")]
        public string PublicationTypeName { get; set; }
        [XmlAttribute(AttributeName = "PublicationType")]
        public string PublicationType { get; set; }
        [XmlAttribute(AttributeName = "Modified")]
        public string Modified { get; set; }
        [XmlAttribute(AttributeName = "Icon")]
        public string Icon { get; set; }
        [XmlAttribute(AttributeName = "Title")]
        public string Title { get; set; }
        [XmlAttribute(AttributeName = "ID")]
        public string ID { get; set; }
    }
    [XmlRoot(ElementName = "ListPublications", Namespace = "http://www.tridion.com/ContentManager/5.0")]
    public class ListPublications
    {
        [XmlElement(ElementName = "Item", Namespace = "http://www.tridion.com/ContentManager/5.0")]
        public List<Publications> Item { get; set; }
        [XmlAttribute(AttributeName = "ext", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ext { get; set; }
        [XmlAttribute(AttributeName = "tcm", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Tcm { get; set; }
        [XmlAttribute(AttributeName = "Managed")]
        public string Managed { get; set; }
    }
}
