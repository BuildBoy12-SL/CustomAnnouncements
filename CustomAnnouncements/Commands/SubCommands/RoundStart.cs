// -----------------------------------------------------------------------
// <copyright file="RoundStart.cs" company="Build">
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
    /// A command to play the <see cref="Configs.RoundStart"/> announcement.
    /// </summary>
    public class RoundStart : ICommand
    {
        /// <inheritdoc/>
        public string Command => "roundstart";

        /// <inheritdoc />
        public string[] Aliases { get; } = { "rs" };

        /// <inheritdoc />
        public string Description => "Views or plays the RoundStart announcement.";

        /// <inheritdoc />
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("ca.rs"))
            {
                response = "Insufficient permission. Required: ca.rs";
                return false;
            }

            if (Plugin.Instance.Config.RoundStart.IsNullOrEmpty())
            {
                response = "The RoundStart announcement is not set in the config.";
                return true;
            }

            if (arguments.Count == 1)
                return Methods.ViewOrPlay(Plugin.Instance.Config.RoundStart, "rs", arguments.At(0), out response);

            response = "Syntax: ca rs <v/p>";
            return false;
        }
    }
}