using BepInEx;

namespace StaticSpeakers
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        internal void Awake()
        {
            HarmonyPatches.ApplyHarmonyPatches();
        }
    }
}
