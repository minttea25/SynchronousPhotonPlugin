using System.Collections.Generic;
using Photon.Hive.Plugin;

namespace SynchronousPlugin.KWY
{
    class SynchronousPluginFactory : IPluginFactory
    {
        public IGamePlugin Create(IPluginHost gameHost, string pluginName, Dictionary<string, string> config, out string errorMsg)
        {
            SynchronousPlugin plugin = new SynchronousPlugin(); // default

            switch (pluginName)
            {
                case "Default":
                    // name not allowed, throw error
                    break;
                case "SynchronousPlugin":
                    plugin = new SynchronousPlugin();
                    break;
                default:
                    break;
            }

            if (plugin.SetupInstance(gameHost, config, out errorMsg))
            {
                return plugin;
            }
            return null;
        }
    }
}
