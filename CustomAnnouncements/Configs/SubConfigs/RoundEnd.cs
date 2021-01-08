namespace CustomAnnouncements.Configs.SubConfigs
{
    using System.ComponentModel;

    public class RoundEnd : IAnnouncement
    {
        [Description("Broadcast to be played if the broadcast for the win condition is not set.")]
        public string Message { get; set; }

        [Description("Broadcast played in a MTF victory.")]
        public string MtfMessage { get; set; }

        [Description("Broadcast played in a CHI victory.")]
        public string ChiMessage { get; set; }

        [Description("Broadcast played in a SCP victory.")]
        public string ScpMessage { get; set; }
        
        [Description("Broadcast played in a Draw.")]
        public string DrawMessage { get; set; }

        public bool IsNoisy { get; set; }
        public bool IsGlitchy { get; set; }
        public float GlitchChance { get; set; }
        public float JamChance { get; set; }
        public float Delay { get; set; }
    }
}