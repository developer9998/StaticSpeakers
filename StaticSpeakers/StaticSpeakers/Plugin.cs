using System;
using BepInEx;
using HarmonyLib;

namespace StaticSpeakers
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        internal Harmony staticSpeakerHarmony;

        internal void Awake()
        {
            staticSpeakerHarmony = new Harmony(PluginInfo.GUID);
            staticSpeakerHarmony.PatchAll();

            Console.WriteLine("StaticSpeakers patched");
        }

        [HarmonyPatch(typeof(SynchedMusicController), "Start")]
        internal class SpeakerPatch
        {
            internal static void Postfix(SynchedMusicController __instance)
            {
                if (__instance.audioSource != null)
                {
                    __instance.audioSource.minDistance = __instance.audioSource.maxDistance - 0.05f;
                    __instance.audioSource.dopplerLevel = 0;
                    __instance.audioSource.spatialBlend = 0;
                    __instance.audioSource.volume *= 0.1f;
                }

                if (__instance.audioSourceArray.Length >= 1)
                {
                    foreach (var audioSource in __instance.audioSourceArray)
                    {
                        if (audioSource != __instance.audioSource)
                        {
                            audioSource.minDistance = audioSource.maxDistance - 0.05f;
                            audioSource.dopplerLevel = 0;
                            audioSource.spatialBlend = 0;
                            audioSource.volume *= 0.1f;
                        }
                    }
                }
            }
        }
    }
}
