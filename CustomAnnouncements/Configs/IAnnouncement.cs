namespace CustomAnnouncements
{
    public interface IAnnouncement
    {
        string Message { get; set; }
        bool IsNoisy { get; set; } 
        bool IsGlitchy { get; set; }
        float GlitchChance { get; set; }
        float JamChance { get; set; }
    }
}