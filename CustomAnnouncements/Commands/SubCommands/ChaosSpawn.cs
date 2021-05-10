// -----------------------------------------------------------------------
// <copyright file="ChaosSpawn.cs" company="Build">
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
    /// A command to play the <see cref="Configs.ChaosSpawn"/> announcement.
    /// </summary>
    public class ChaosSpawn : ICommand
    {
        /// <inheritdoc />
        public string Command => "chaosspawn";

        /// <inheritdoc />
        public string[] Aliases { get; } = { "chs" };

        /// <inheritdoc />
        public string Description => "Views or plays the ChaosSpawn announcement.";

        /// <inheritdoc />
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("ca.chs"))
            {
                response = "Insufficient permission. Required: ca.chs";
                return false;
            }

            if (Plugin.Instance.Config.ChaosSpawn.IsNullOrEmpty())
            {
                response = "The ChaosSpawn announcement is not set in the config.";
                return true;
            }

            if (arguments.Count == 1)
                return Methods.ViewOrPlay(Plugin.Instance.Config.ChaosSpawn, "chs", arguments.At(0), out response);

            response = "Syntax: ca chs <v/p>";
            return false;
        }
    }
}