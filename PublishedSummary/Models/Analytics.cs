// ***********************************************************************
// Assembly         : PublishedSummary
// Author           : admin
// Created          : 08-25-2018
//
// Last Modified By : admin
// Last Modified On : 08-28-2018
// ***********************************************************************
// <copyright file="Analytics.cs" company="Content Bloom">
//     Copyright © Content Bloom 2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace PublishedSummary.Models
{
    /// <summary>
    /// Class Analytics.
    /// </summary>
    public class Analytics
    {
        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>The count.</value>
        public int Count { get; set; }
        /// <summary>
        /// Gets or sets the publication target.
        /// </summary>
        /// <value>The publication target.</value>
        public string PublicationTarget { get; set; }
        /// <summary>
        /// Gets or sets the type of the item.
        /// </summary>
        /// <value>The type of the item.</value>
        public string ItemType { get; set; }
    }
}
