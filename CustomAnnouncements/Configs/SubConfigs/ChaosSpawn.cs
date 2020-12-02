namespace CustomAnnouncements.Configs.SubConfigs
{
    using System.ComponentModel;

    public class ChaosSpawn : IAnnouncement
    {
        [Description("The message CASSIE will say. Leave empty to disable an announcement.")]
        public string Message { get; set; } = "Unauthorized Personnel Detected . . on Surface . . Chaos Insurgency .";

        [Description("If there should be background static and the starting/stopping noise.")]
        public bool IsNoisy { get; set; } = false;

        [Description("If there should be glitches and jams randomly in the broadcast.")]
        public bool IsGlitchy { get; set; } = true;

        [Description("Chance that a glitch can occur.")]
        public float GlitchChance { get; set; } = 1;

        [Description("Chance that a jam can occur.")]
        public float JamChance { get; set; } = 1;

        [Description("Seconds before the announcement will play after the event fires.")]
        public float Delay { get; set; }
    }
}