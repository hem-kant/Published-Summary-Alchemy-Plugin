using Alchemy4Tridion.Plugins.GUI.Configuration;

namespace PublishedSummary.GUI
{
    public class PluginContextMenuExtension : Alchemy4Tridion.Plugins.GUI.Configuration.ContextMenuExtension
    {
        public PluginContextMenuExtension()
        {
            AssignId = "";
            InsertBefore = Constants.ContextMenuIds.MainContextMenu.Refresh;

            AddItem("pub_summary_cm", "Published Summary", "PublishedSummary");

            Dependencies.Add<PluginResourceGroup>();

            Apply.ToView(Constants.Views.DashboardView);
        }
    }
}
