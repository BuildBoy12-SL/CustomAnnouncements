// -----------------------------------------------------------------------
// <copyright file="ServerHandlers.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomAnnouncements.Handlers
{
    using Exiled.API.Enums;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;

    /// <summary>
    /// Contains methods which subscribe to events in <see cref="Exiled.Events.Handlers.Server"/>.
    /// </summary>
    public class ServerHandlers
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerHandlers"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public ServerHandlers(Plugin plugin) => this.plugin = plugin;

        /// <inheritdoc cref="Exiled.Events.Handlers.Server.OnRespawningTeam(RespawningTeamEventArgs)"/>
        public void OnRespawningTeam(RespawningTeamEventArgs ev)
        {
            if (ev.NextKnownTeam == Respawning.SpawnableTeamType.ChaosInsurgency && ev.Players.Count > 0)
                Methods.PlayAnnouncement(plugin.Config.ChaosSpawn);
        }

        /// <inheritdoc cref="Exiled.Events.Handlers.Server.OnRoundEnded(RoundEndedEventArgs)"/>
        public void OnRoundEnded(RoundEndedEventArgs ev)
        {
            string announcement = ev.LeadingTeam switch
            {
                LeadingTeam.FacilityForces when !string.IsNullOrEmpty(plugin.Config.RoundEnd.MtfMessage) => plugin.Config.RoundEnd.MtfMessage,
                LeadingTeam.ChaosInsurgency when !string.IsNullOrEmpty(plugin.Config.RoundEnd.ChiMessage) => plugin.Config.RoundEnd.ChiMessage,
                LeadingTeam.Anomalies when !string.IsNullOrEmpty(plugin.Config.RoundEnd.ScpMessage) => plugin.Config.RoundEnd.ScpMessage,
                LeadingTeam.Draw when !string.IsNullOrEmpty(plugin.Config.RoundEnd.DrawMessage) => plugin.Config.RoundEnd.DrawMessage,
                _ => string.Empty,
            };

            Log.Warn(announcement);
            Methods.PlayAnnouncement(plugin.Config.RoundEnd, announcement);
        }

        /// <inheritdoc cref="Exiled.Events.Handlers.Server.OnRoundStarted"/>
        public void OnRoundStarted()
        {
            Methods.PlayAnnouncement(plugin.Config.RoundStart);
        }
    }
}