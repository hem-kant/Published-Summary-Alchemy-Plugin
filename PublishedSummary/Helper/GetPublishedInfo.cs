// ***********************************************************************
// Assembly         : PublishedSummary
// Author           : admin
// Created          : 08-20-2018
//
// Last Modified By : admin
// Last Modified On : 08-22-2018
// ***********************************************************************
// <copyright file="GetPublishedInfo.cs" company="Content Bloom">
//     Copyright © Content Bloom 2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using PublishedSummary.Models;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using PublishedSummary.Models.Model;
using Tridion.ContentManager.CoreService.Client;

namespace PublishedSummary.Helper
{
    /// <summary>
    /// Class GetPublishedInfo.
    /// </summary>
    public class GetPublishedInfo
    {
        /// <summary>
        /// Gets the published information list.
        /// </summary>
        /// <param name="publishInfoData">The publish information data.</param>
        /// <returns>ItemPublishedHistory.</returns>
        public List<ItemPublishedHistory> GetPublishedHistory(PublishInfoData[] publishInfoData)
        {
            return publishInfoData.OrderBy(x => x.PublishedAt).Select(publishInfo => new ItemPublishedHistory {ItemPublicationTarget = publishInfo.PublicationTarget.Title, ItemPublishedAt = publishInfo.PublishedAt, UserList = publishInfo.User.Title}).ToList();
        }
        /// <summary>
        /// Returns the final list.
        /// </summary>
        /// <param name="publishInfoData">The publish information data.</param>
        /// <param name="item">The item.</param>
        /// <returns>Item.</returns>
        public List<Item> ReturnFinalList(PublishInfoData[] publishInfoData, Item item)
        {
            var finalList = new List<Item>();
            
            IEnumerable<PublishInfoData> getPublishedInfos = null;
            if (publishInfoData.Any())
                getPublishedInfos = publishInfoData.OrderByDescending(pubAt => pubAt.PublishedAt)
                    .GroupBy(pubTarget => pubTarget.PublicationTarget.Title)
                    .Select(pubTarget => pubTarget.FirstOrDefault());

            if (getPublishedInfos == null) return finalList;
            foreach (var getPublishedInfo in getPublishedInfos)
            {
                var tempItem = new Item();
                if (getPublishedInfo == null) continue;
                FinalPublishedItemList(item, finalList, tempItem, getPublishedInfo);
            }

            return finalList;
        }

        /// <summary>
        /// News the method.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="finalList">The final list.</param>
        /// <param name="tempItem">The temporary item.</param>
        /// <param name="getPublishedInfo">The get published information.</param>
        private static void FinalPublishedItemList(Item item, List<Item> finalList, Item tempItem, PublishInfoData getPublishedInfo)
        {
            tempItem.ID = item.ID;
            tempItem.Title = item.Title;
            tempItem.PublicationTarget = getPublishedInfo.PublicationTarget.Title;
            tempItem.User = getPublishedInfo.User.Title;
            tempItem.openItem = PageURL.GetDomain() + "/WebUI/item.aspx?tcm=" + item.Type + "#id=" + item.ID;
            tempItem.Type = item.Type != "64" ? item.Type != "512" ? item.Type != "32" ? item.Type == "16" ? Enum.GetName(typeof(ItemType), 16) : item.Type :
                Enum.GetName(typeof(ItemType), 32) :
                Enum.GetName(typeof(ItemType), 512) :
                Enum.GetName(typeof(ItemType), 64);
            tempItem.PublishedAt = getPublishedInfo.PublishedAt;
            finalList.Add(tempItem);
        }
        /// <summary>
        /// Filters the is published item.
        /// </summary>
        /// <param name="multipleListItems">The multiple list items.</param>
        /// <returns>IEnumerable&lt;List&lt;Item&gt;&gt;.</returns>
        public IEnumerable<List<Item>> FilterIsPublishedItem(List<ListItems> multipleListItems)
        {
            var publishedItems = from multipleListItem in multipleListItems
                select multipleListItem.Item.Where(x => x.IsPublished == "true").ToList();
            IEnumerable<List<Item>> listItems = publishedItems.ToList();
            return listItems;
        }
        /// <summary>
        /// Publications the specified publication list.
        /// </summary>
        /// <param name="publicationList">The publication list.</param>
        /// <param name="publications">The publications.</param>
        /// <returns>List&lt;Publications&gt;.</returns>
        public List<Publications> Publications(XmlDocument publicationList, XElement publications)
        {
            publicationList.Load(publications.CreateReader());
            var pubList = TransformObjectAndXml.Deserialize<ListPublications>(publicationList);
            return pubList.Item;
        }


        /// <summary>
        /// Summaries the panel.
        /// </summary>
        /// <param name="analytics">The analytics.</param>
        /// <param name="allPublicationTargets">All publication targets.</param>
        /// <param name="PublicationTargets"></param>
        /// <returns>List&lt;ItemSummary&gt;.</returns>
        public List<ItemSummary> SummaryPanelData(IEnumerable<Analytics> analytics, IdentifiableObjectData[] PublicationTargets)
        {
            List<ItemSummary> itemssummary = new List<ItemSummary>();
            foreach (var publicationTarget in PublicationTargets)
            {
                ItemSummary itemsum = new ItemSummary();
                var analyticses = analytics as Analytics[] ?? analytics.ToArray();
                var page = analyticses.Where(x =>
                        (x.ItemType == "Page") && (x.PublicationTarget == publicationTarget.Title))
                    .Select(x => x.Count)
                    .ToList();
                var componentTemplate = analyticses.Where(x =>
                        (x.ItemType == "ComponentTemplate") && (x.PublicationTarget == publicationTarget.Title))
                    .Select(x => x.Count)
                    .ToList();
                var component = analyticses.Where(x =>
                        (x.ItemType == "Component") && (x.PublicationTarget == publicationTarget.Title))
                    .Select(x => x.Count)
                    .ToList();
                var category = analyticses.Where(x =>
                        (x.ItemType == "Category") && (x.PublicationTarget == publicationTarget.Title))
                    .Select(x => x.Count)
                    .ToList();
                itemsum.title = publicationTarget.Title;
                itemsum.page = page.Count > 0
                    ? page[0]
                    : 0;
                itemsum.componentTemplate = componentTemplate.Count > 0
                    ? componentTemplate[0]
                    : 0;
                itemsum.component = component.Count > 0
                    ? component[0]
                    : 0;
                itemsum.category = category.Count > 0
                    ? component[0]
                    : 0;

                itemssummary.Add(itemsum);
            }

            return itemssummary;
        }
    }
}
