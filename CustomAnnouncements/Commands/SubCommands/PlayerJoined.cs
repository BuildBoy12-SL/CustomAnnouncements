// -----------------------------------------------------------------------
// <copyright file="PlayerJoined.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomAnnouncements.Commands.SubCommands
{
    using System;
    using CommandSystem;
    using Exiled.Permissions.Extensions;

    /// <summary>
    /// A command to play the <see cref="Configs.PlayerJoined"/> announcement.
    /// </summary>
    public class PlayerJoined : ICommand
    {
        /// <inheritdoc />
        public string Command => "playerjoined";

        /// <inheritdoc />
        public string[] Aliases { get; } = { "pj" };

        /// <inheritdoc />
        public string Description => "Views or plays the PlayerJoined announcement.";

        /// <inheritdoc />
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("ca.pj"))
            {
                response = "Insufficient permission. Required: ca.pj";
                return false;
            }

            if (Plugin.Instance.Config.PlayerJoined.IsNullOrEmpty())
            {
                response = "The PlayerJoined announcement is not set in the config.";
                return true;
            }

            if (arguments.Count == 1)
                return Methods.ViewOrPlay(Plugin.Instance.Config.PlayerJoined, "pj", arguments.At(0), out response);

            response = "Syntax: ca pj <v/p>";
            return false;
        }
    }
}