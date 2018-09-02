using Alchemy4Tridion.Plugins.GUI.Configuration;
using Alchemy4Tridion.Plugins.GUI.Configuration.Elements;

namespace PublishedSummary.GUI
{
    public class PublishedSummaryResourceGroup : ResourceGroup
    {
        public PublishedSummaryResourceGroup()
        {
            AddFile("PublishedSummary.js");
            AddFile("PublishedSummary.css");
            AddWebApiProxy();
            AttachToView("PublishedSummary.aspx");
            Dependencies.Add("Tridion.Web.UI.Editors.CME");
        }
    }
}