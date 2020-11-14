namespace CustomAnnouncements.SubConfigs
{
    public class EscapeScientist : IAnnouncement
    {
        public string Message { get; set; }
        public bool IsNoisy { get; set; }
        public bool IsGlitchy { get; set; }
        public float GlitchChance { get; set; }
        public float JamChance { get; set; }
    }
}