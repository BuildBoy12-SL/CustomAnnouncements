namespace CustomAnnouncements
{
    using Exiled.API.Features;
    using Handlers;
    using MapEvents = Exiled.Events.Handlers.Map;
    using PlayerEvents = Exiled.Events.Handlers.Player;
    using ServerEvents = Exiled.Events.Handlers.Server;

    public class CustomAnnouncements : Plugin<Config>
    {
        internal static CustomAnnouncements Instance;
        public readonly Methods Methods = new Methods();
        private readonly MapHandlers _mapHandlers = new MapHandlers();
        private readonly PlayerHandlers _playerHandlers = new PlayerHandlers();
        private readonly ServerHandlers _serverHandlers = new ServerHandlers();

        public override void OnEnabled()
        {
            Instance = this;
            MapEvents.AnnouncingNtfEntrance += _mapHandlers.OnAnnouncingNtfEntrance;
            //MapEvents.AnnouncingScpTermination += _mapHandlers.OnAnnouncingScpTermination;
            PlayerEvents.Escaping += _playerHandlers.OnEscaping;
            PlayerEvents.Joined += _playerHandlers.OnPlayerJoin;
            ServerEvents.RespawningTeam += _serverHandlers.OnRespawningTeam;
            ServerEvents.RoundEnded += _serverHandlers.OnRoundEnd;
            ServerEvents.RoundStarted += _serverHandlers.OnRoundStart;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            MapEvents.AnnouncingNtfEntrance -= _mapHandlers.OnAnnouncingNtfEntrance;
            //MapEvents.AnnouncingScpTermination -= _mapHandlers.OnAnnouncingScpTermination;
            PlayerEvents.Escaping -= _playerHandlers.OnEscaping;
            PlayerEvents.Joined -= _playerHandlers.OnPlayerJoin;
            ServerEvents.RespawningTeam -= _serverHandlers.OnRespawningTeam;
            ServerEvents.RoundEnded -= _serverHandlers.OnRoundEnd;
            ServerEvents.RoundStarted -= _serverHandlers.OnRoundStart;
            Instance = null;
            base.OnDisabled();
        }

        public override string Author => "Build";
    }
}