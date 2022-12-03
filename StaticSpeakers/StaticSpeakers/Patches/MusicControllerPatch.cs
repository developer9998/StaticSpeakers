using HarmonyLib;

namespace StaticSpeakers.Patches
{
    [HarmonyPatch(typeof(SynchedMusicController), "Start")]
    internal class MusicControllerPatch
    {
        internal static void Postfix(SynchedMusicController __instance)
        {
            if (__instance.audioSource != null)
            {
                __instance.audioSource.minDistance = __instance.audioSource.maxDistance - 0.05f;
                __instance.audioSource.dopplerLevel = 0;
                __instance.audioSource.spatialBlend = 0;
                __instance.audioSource.volume *= 0.2f;
            }
            if (__instance.audioSourceArray.Length >= 1)
            {
                foreach(var audioSource in __instance.audioSourceArray)
                {
                    if (audioSource != __instance.audioSource)
                    {
                        audioSource.minDistance = audioSource.maxDistance - 0.05f;
                        audioSource.dopplerLevel = 0;
                        audioSource.spatialBlend = 0;
                        audioSource.volume *= 0.2f;
                    }
                }
            }
        }
    }
}
