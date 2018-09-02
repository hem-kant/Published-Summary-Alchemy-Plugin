// ***********************************************************************
// Assembly         : PublishedSummary
// Author           : admin
// Created          : 08-20-2018
//
// Last Modified By : admin
// Last Modified On : 08-22-2018
// ***********************************************************************
// <copyright file="Publications.cs" company="Content Bloom">
//     Copyright © Content Bloom 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PublishedSummary.Models.Model
{
    /// <summary>
    /// Class Publications.
    /// </summary>
    [XmlRoot(ElementName = "Item", Namespace = "http://www.tridion.com/ContentManager/5.0")]
    public class Publications
    {
        /// <summary>
        /// Gets or sets the name of the publication type.
        /// </summary>
        /// <value>The name of the publication type.</value>
        [XmlAttribute(AttributeName = "PublicationTypeName")]
        public string PublicationTypeName { get; set; }
        /// <summary>
        /// Gets or sets the type of the publication.
        /// </summary>
        /// <value>The type of the publication.</value>
        [XmlAttribute(AttributeName = "PublicationType")]
        public string PublicationType { get; set; }
        /// <summary>
        /// Gets or sets the modified.
        /// </summary>
        /// <value>The modified.</value>
        [XmlAttribute(AttributeName = "Modified")]
        public string Modified { get; set; }
        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>The icon.</value>
        [XmlAttribute(AttributeName = "Icon")]
        public string Icon { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [XmlAttribute(AttributeName = "Title")]
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [XmlAttribute(AttributeName = "ID")]
        public string ID { get; set; }
    }
    /// <summary>
    /// Class ListPublications.
    /// </summary>
    [XmlRoot(ElementName = "ListPublications", Namespace = "http://www.tridion.com/ContentManager/5.0")]
    public class ListPublications
    {
        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        /// <value>The item.</value>
        [XmlElement(ElementName = "Item", Namespace = "http://www.tridion.com/ContentManager/5.0")]
        public List<Publications> Item { get; set; }
        /// <summary>
        /// Gets or sets the ext.
        /// </summary>
        /// <value>The ext.</value>
        [XmlAttribute(AttributeName = "ext", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ext { get; set; }
        /// <summary>
        /// Gets or sets the TCM.
        /// </summary>
        /// <value>The TCM.</value>
        [XmlAttribute(AttributeName = "tcm", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Tcm { get; set; }
        /// <summary>
        /// Gets or sets the managed.
        /// </summary>
        /// <value>The managed.</value>
        [XmlAttribute(AttributeName = "Managed")]
        public string Managed { get; set; }
    }
}
