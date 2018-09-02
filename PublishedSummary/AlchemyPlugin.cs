using Alchemy4Tridion.Plugins;

namespace PublishedSummary
{
    /// <summary>
    /// Required entry class that represents your plugin. There should only be one IAlchemyPlugin in your project.
    /// </summary>
	public class AlchemyPlugin : Alchemy4Tridion.Plugins.AlchemyPluginBase
    {
        /// <summary>
        /// Optional override of Configure method if you want to add your own plugin utilities
        /// or to set custom options on existing ones.
        /// </summary>
        /// <param name="services">The strongly typed services.</param>
        public override void Configure(IPluginServiceLocator services)
        {
            services.SettingsEncryptor.EncryptionKey = "MyCustomKey";
        }
    }
}