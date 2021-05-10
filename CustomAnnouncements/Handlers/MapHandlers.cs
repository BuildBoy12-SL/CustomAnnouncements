// -----------------------------------------------------------------------
// <copyright file="MapHandlers.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomAnnouncements.Handlers
{
    using System;
    using Exiled.Events.EventArgs;

    /// <summary>
    /// Contains methods which subscribe to events in <see cref="Exiled.Events.Handlers.Map"/>.
    /// </summary>
    public class MapHandlers
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="MapHandlers"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public MapHandlers(Plugin plugin) => this.plugin = plugin;

        /// <inheritdoc cref="Exiled.Events.Handlers.Map.OnAnnouncingNtfEntrance(AnnouncingNtfEntranceEventArgs)"/>
        public void OnAnnouncingNtfEntrance(AnnouncingNtfEntranceEventArgs ev)
        {
            if (plugin.Config.MtfSpawn.IsNullOrEmpty())
                return;

            ev.IsAllowed = false;
            var overrideMessage = plugin.Config.MtfSpawn.Message.ReplaceAfterToken('$', new[]
            {
                new Tuple<string, object>("UnitName", "nato_" + ev.UnitName),
                new Tuple<string, object>("UnitNumber", ev.UnitNumber),
            });

            Methods.PlayAnnouncement(plugin.Config.MtfSpawn, overrideMessage);
        }
    }
}