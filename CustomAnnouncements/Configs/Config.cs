namespace CustomAnnouncements
{
    using Exiled.API.Interfaces;
    using Configs.SubConfigs;
    using System.ComponentModel;

    public class Config : IConfig
    {
        [Description(
            "An announcement being glitchy will cause IsNoisy to not be accounted for. For now, if IsGlitchy is true, IsNoisy will also be true.")]
        public bool IsEnabled { get; set; } = true;

        public ChaosSpawn ChaosSpawn { get; private set; } = new ChaosSpawn();
        public EscapeClassD EscapeClassD { get; private set; } = new EscapeClassD();
        public EscapeScientist EscapeScientist { get; private set; } = new EscapeScientist();
        public MtfSpawn MtfSpawn { get; private set; } = new MtfSpawn();
        public PlayerJoined PlayerJoined { get; private set; } = new PlayerJoined();
        public RoundEnd RoundEnd { get; private set; } = new RoundEnd();

        public RoundStart RoundStart { get; private set; } = new RoundStart();
        // public ScpTerminated ScpTerminated { get; private set; } = new ScpTerminated();
    }
}