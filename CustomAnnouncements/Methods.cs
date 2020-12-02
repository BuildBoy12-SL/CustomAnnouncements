namespace CustomAnnouncements
{
    using Exiled.API.Features;
    using MEC;
    using System.Collections.Generic;

    public class Methods
    {
        public static IEnumerator<float> PlayAnnouncement(IAnnouncement announcement, string overrideMessage = null)
        {
            if (!string.IsNullOrEmpty(overrideMessage))
                announcement.Message = overrideMessage;

            if (announcement.Delay > 0f)
                yield return Timing.WaitForSeconds(announcement.Delay);

            if (announcement.IsGlitchy)
                NineTailedFoxAnnouncer.singleton.ServerOnlyAddGlitchyPhrase(announcement.Message,
                    announcement.GlitchChance * 0.01f, announcement.JamChance * 0.01f);
            else
                Cassie.Message(announcement.Message, isNoisy: announcement.IsNoisy);
        }
    }
}