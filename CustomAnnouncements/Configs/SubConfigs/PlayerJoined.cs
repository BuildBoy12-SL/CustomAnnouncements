namespace CustomAnnouncements.Configs.SubConfigs
{
    using System.Collections.Generic;
    using System.ComponentModel;

    public class PlayerJoined : IAnnouncement
    {
        public string Message { get; set; }
        public bool IsNoisy { get; set; }
        public bool IsGlitchy { get; set; }
        public float GlitchChance { get; set; }
        public float JamChance { get; set; }
        public float Delay { get; set; }

        [Description("UserIds that will trigger this announcement.")]
        public List<string> UserIds { get; private set; } = new List<string>
        {
            "mysteamid@steam",
            "mydiscordid@discord"
        };
    }
}