// ***********************************************************************
// Assembly         : PublishedSummary
// Author           : admin
// Created          : 08-20-2018
//
// Last Modified By : admin
// Last Modified On : 08-28-2018
// ***********************************************************************
// <copyright file="Items.cs" company="Content Bloom">
//     Copyright © Content Bloom 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PublishedSummary.Models
{
    /// <summary>
    /// Class Item.
    /// </summary>
    [XmlRoot(ElementName = "Item", Namespace = "http://www.tridion.com/ContentManager/5.0")]
    public class Item
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [XmlAttribute(AttributeName = "ID")]
        public string ID { get; set; }
        /// <summary>
        /// Gets or sets the schema identifier.
        /// </summary>
        /// <value>The schema identifier.</value>
        [XmlAttribute(AttributeName = "SchemaId")]
        public string SchemaId { get; set; }
        /// <summary>
        /// Gets or sets the owning publication title.
        /// </summary>
        /// <value>The owning publication title.</value>
        [XmlAttribute(AttributeName = "OwningPublicationTitle")]
        public string OwningPublicationTitle { get; set; }
        /// <summary>
        /// Gets or sets the owning publication identifier.
        /// </summary>
        /// <value>The owning publication identifier.</value>
        [XmlAttribute(AttributeName = "OwningPublicationID")]
        public string OwningPublicationID { get; set; }
        /// <summary>
        /// Gets or sets the modified.
        /// </summary>
        /// <value>The modified.</value>
        [XmlAttribute(AttributeName = "Modified")]
        public DateTime Modified { get; set; }
        /// <summary>
        /// Gets or sets the is new.
        /// </summary>
        /// <value>The is new.</value>
        [XmlAttribute(AttributeName = "IsNew")]
        public string IsNew { get; set; }
        /// <summary>
        /// Gets or sets from pub.
        /// </summary>
        /// <value>From pub.</value>
        [XmlAttribute(AttributeName = "FromPub")]
        public string FromPub { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }
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
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        [XmlAttribute(AttributeName = "Size")]
        public string Size { get; set; }
        /// <summary>
        /// Gets or sets the open item.
        /// </summary>
        /// <value>The open item.</value>
        public string openItem { get; set; }
        /// <summary>
        /// Gets or sets the schemaname.
        /// </summary>
        /// <value>The schemaname.</value>
        public string schemaname { get; set; }
        /// <summary>
        /// Gets or sets the month.
        /// </summary>
        /// <value>The month.</value>
        public string month { get; set; }
        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>The year.</value>
        public string year { get; set; }
        /// <summary>
        /// Gets or sets the iscurrent year.
        /// </summary>
        /// <value>The iscurrent year.</value>
        public string iscurrentYear { get; set; }

        /// <summary>
        /// Gets or sets the publication target.
        /// </summary>
        /// <value>The publication target.</value>
        public string PublicationTarget { get; set; }
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        public string User { get; set; }

        /// <summary>
        /// Gets or sets the is published.
        /// </summary>
        /// <value>The is published.</value>
        [XmlAttribute(AttributeName = "IsPublished")]
        public string IsPublished { get; set; }
        /// <summary>
        /// Gets or sets the published at.
        /// </summary>
        /// <value>The published at.</value>
        public DateTime PublishedAt { get; set; }
    }

    /// <summary>
    /// Class ListItems.
    /// </summary>
    [XmlRoot(ElementName = "ListItems", Namespace = "http://www.tridion.com/ContentManager/5.0")]
    public class ListItems
    {
        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        /// <value>The item.</value>
        [XmlElement(ElementName = "Item", Namespace = "http://www.tridion.com/ContentManager/5.0")]
        public List<Item> Item { get; set; }
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
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [XmlAttribute(AttributeName = "ID")]
        public string ID { get; set; }

         
    }

    public class TcmIds
    {
        public List<string> IDs { get; set; }
    }
    /// <summary>
    /// Class data.
    /// </summary>
    public class PublishUnPublishInfoData
    {

        /// <summary>
        /// Gets or sets the i ds.
        /// </summary>
        /// <value>The i ds.</value>
        public List<PublishUnPublishData> IDs { get; set; }
    }
    /// <summary>
    /// Class PublishUnPublishData.
    /// </summary>
    public class PublishUnPublishData
    {
        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        /// <value>The target.</value>
        public string Target { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }
    }
}
