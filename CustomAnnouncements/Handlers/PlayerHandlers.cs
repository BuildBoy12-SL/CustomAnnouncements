// -----------------------------------------------------------------------
// <copyright file="PlayerHandlers.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomAnnouncements.Handlers
{
    using Exiled.Events.EventArgs;

    /// <summary>
    /// Contains methods which subscribe to events in <see cref="Exiled.Events.Handlers.Player"/>.
    /// </summary>
    public class PlayerHandlers
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerHandlers"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public PlayerHandlers(Plugin plugin) => this.plugin = plugin;

        /// <inheritdoc cref="Exiled.Events.Handlers.Player.OnVerified(VerifiedEventArgs)"/>
        public void OnVerified(VerifiedEventArgs ev)
        {
            if (plugin.Config.PlayerJoined.UserIds == null)
                return;

            if (!plugin.Config.PlayerJoined.UserIds.Contains(ev.Player.UserId))
                return;

            Methods.PlayAnnouncement(plugin.Config.PlayerJoined);
        }

        /// <inheritdoc cref="Exiled.Events.Handlers.Player.OnEscaping(EscapingEventArgs)"/>
        public void OnEscaping(EscapingEventArgs ev)
        {
            switch (ev.Player.Role)
            {
                case RoleType.ClassD:
                    if (plugin.Config.EscapeClassD.OnlyPlayFirst && RoundSummary.escaped_ds != 0)
                        return;

                    Methods.PlayAnnouncement(plugin.Config.EscapeClassD);
                    break;
                case RoleType.Scientist:
                    if (plugin.Config.EscapeScientist.OnlyPlayFirst && RoundSummary.escaped_scientists != 0)
                        return;

                    Methods.PlayAnnouncement(plugin.Config.EscapeScientist);
                    break;
            }
        }
    }
}