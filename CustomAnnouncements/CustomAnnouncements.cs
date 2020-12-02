namespace CustomAnnouncements
{
    using Exiled.API.Features;
    using Handlers;
    using System;
    using MapEvents = Exiled.Events.Handlers.Map;
    using PlayerEvents = Exiled.Events.Handlers.Player;
    using ServerEvents = Exiled.Events.Handlers.Server;

    public class CustomAnnouncements : Plugin<Config>
    {
        internal static CustomAnnouncements Instance;
        private MapHandlers _mapHandlers;
        private PlayerHandlers _playerHandlers;
        private ServerHandlers _serverHandlers;

        public override void OnEnabled()
        {
            Instance = this;
            _mapHandlers = new MapHandlers();
            _playerHandlers = new PlayerHandlers();
            _serverHandlers = new ServerHandlers();
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
            _mapHandlers = null;
            _playerHandlers = null;
            _serverHandlers = null;
            Instance = null;
            base.OnDisabled();
        }

        public override string Author => "Build";
        public override Version Version => new Version(1, 1, 2);
    }
}