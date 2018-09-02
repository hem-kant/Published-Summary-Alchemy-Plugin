// ***********************************************************************
// Assembly         : PublishedSummary
// Author           : admin
// Created          : 08-25-2018
//
// Last Modified By : admin
// Last Modified On : 08-25-2018
// ***********************************************************************
// <copyright file="ItemPublishedHistory.cs" company="Content Bloom">
//     Copyright © Content Bloom 2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

namespace PublishedSummary.Models
{
    /// <summary>
    /// Class ItemPublishedHistory.
    /// </summary>
    public class ItemPublishedHistory
    {
        /// <summary>
        /// Gets or sets the item publication target.
        /// </summary>
        /// <value>The item publication target.</value>
        public string ItemPublicationTarget { get; set; }
        /// <summary>
        /// Gets or sets the item published at.
        /// </summary>
        /// <value>The item published at.</value>
        public DateTime ItemPublishedAt { get; set; }
        /// <summary>
        /// Gets or sets the user list.
        /// </summary>
        /// <value>The user list.</value>
        public string UserList { get; set; }
        
    }
}
