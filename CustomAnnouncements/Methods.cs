namespace CustomAnnouncements
{
    using Exiled.API.Features;

    public class Methods
    {
        public void PlayAnnouncement(IAnnouncement announcement, string overrideMessage = null)
        {
            if (!string.IsNullOrEmpty(overrideMessage))
                announcement.Message = overrideMessage;
            
            if (announcement.IsGlitchy)
                NineTailedFoxAnnouncer.singleton.ServerOnlyAddGlitchyPhrase(announcement.Message,
                    announcement.GlitchChance * 0.01f, announcement.JamChance * 0.01f);
            else
                Cassie.Message(announcement.Message, isNoisy: announcement.IsNoisy);
        }
    }
}