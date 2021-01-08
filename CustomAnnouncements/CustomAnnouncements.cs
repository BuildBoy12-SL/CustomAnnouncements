namespace CustomAnnouncements
{
    using Configs;
    using Exiled.API.Features;
    using Handlers;
    using System;
    using MapEvents = Exiled.Events.Handlers.Map;
    using PlayerEvents = Exiled.Events.Handlers.Player;
    using ServerEvents = Exiled.Events.Handlers.Server;

    public class CustomAnnouncements : Plugin<Config>
    {
        internal static CustomAnnouncements Singleton;
        private MapHandlers _mapHandlers;
        private PlayerHandlers _playerHandlers;
        private ServerHandlers _serverHandlers;

        public override void OnEnabled()
        {
            Singleton = this;
            _mapHandlers = new MapHandlers(this);
            _playerHandlers = new PlayerHandlers(this);
            _serverHandlers = new ServerHandlers(this);
            MapEvents.AnnouncingNtfEntrance += _mapHandlers.OnAnnouncingNtfEntrance;
            PlayerEvents.Escaping += _playerHandlers.OnEscaping;
            PlayerEvents.Joined += _playerHandlers.OnPlayerJoin;
            ServerEvents.RespawningTeam += _serverHandlers.OnRespawningTeam;
            ServerEvents.EndingRound += _serverHandlers.OnRoundEnd;
            ServerEvents.RoundStarted += _serverHandlers.OnRoundStart;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            MapEvents.AnnouncingNtfEntrance -= _mapHandlers.OnAnnouncingNtfEntrance;
            PlayerEvents.Escaping -= _playerHandlers.OnEscaping;
            PlayerEvents.Joined -= _playerHandlers.OnPlayerJoin;
            ServerEvents.RespawningTeam -= _serverHandlers.OnRespawningTeam;
            ServerEvents.EndingRound -= _serverHandlers.OnRoundEnd;
            ServerEvents.RoundStarted -= _serverHandlers.OnRoundStart;
            _mapHandlers = null;
            _playerHandlers = null;
            _serverHandlers = null;
            Singleton = null;
            base.OnDisabled();
        }

        public override string Author => "Build";
        public override Version Version => new Version(1, 1, 3);
    }
}