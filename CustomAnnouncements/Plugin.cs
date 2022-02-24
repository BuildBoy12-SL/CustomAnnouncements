// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomAnnouncements
{
    using System;
    using CustomAnnouncements.Handlers;
    using Exiled.API.Features;
    using MapEvents = Exiled.Events.Handlers.Map;
    using PlayerEvents = Exiled.Events.Handlers.Player;
    using ServerEvents = Exiled.Events.Handlers.Server;

    /// <summary>
    /// The main plugin class.
    /// </summary>
    public class Plugin : Plugin<Config>
    {
        private MapHandlers mapHandlers;
        private PlayerHandlers playerHandlers;
        private ServerHandlers serverHandlers;

        /// <summary>
        /// Gets a static instance of the <see cref="Plugin"/> class.
        /// </summary>
        public static Plugin Instance { get; private set; }

        /// <inheritdoc />
        public override Version RequiredExiledVersion { get; } = new Version(5, 0, 0);

        /// <inheritdoc />
        public override void OnEnabled()
        {
            Instance = this;

            mapHandlers = new MapHandlers(this);
            playerHandlers = new PlayerHandlers(this);
            serverHandlers = new ServerHandlers(this);

            PlayerEvents.Escaping += playerHandlers.OnEscaping;
            PlayerEvents.Verified += playerHandlers.OnVerified;
            ServerEvents.RespawningTeam += serverHandlers.OnRespawningTeam;
            ServerEvents.RoundEnded += serverHandlers.OnRoundEnded;
            ServerEvents.RoundStarted += serverHandlers.OnRoundStarted;
            base.OnEnabled();
        }

        /// <inheritdoc />
        public override void OnDisabled()
        {
            MapEvents.AnnouncingNtfEntrance -= mapHandlers.OnAnnouncingNtfEntrance;
            PlayerEvents.Escaping -= playerHandlers.OnEscaping;
            PlayerEvents.Verified -= playerHandlers.OnVerified;
            ServerEvents.RespawningTeam -= serverHandlers.OnRespawningTeam;
            ServerEvents.RoundEnded -= serverHandlers.OnRoundEnded;
            ServerEvents.RoundStarted -= serverHandlers.OnRoundStarted;

            mapHandlers = null;
            playerHandlers = null;
            serverHandlers = null;

            Instance = null;
            base.OnDisabled();
        }
    }
}