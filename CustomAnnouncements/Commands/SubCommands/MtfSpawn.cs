// -----------------------------------------------------------------------
// <copyright file="MtfSpawn.cs" company="Build">
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
    /// A command to play the <see cref="Configs.MtfSpawn"/> announcement.
    /// </summary>
    public class MtfSpawn : ICommand
    {
        /// <inheritdoc />
        public string Command => "mtfspawn";

        /// <inheritdoc />
        public string[] Aliases { get; } = { "ms" };

        /// <inheritdoc />
        public string Description => "Views or plays the MtfSpawn announcement.";

        /// <inheritdoc />
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("ca.ms"))
            {
                response = "Insufficient permission. Required: ca.ms";
                return false;
            }

            if (Plugin.Instance.Config.MtfSpawn.IsNullOrEmpty())
            {
                response = "The MtfSpawn announcement is not set in the config.";
                return true;
            }

            if (arguments.Count == 1)
                return Methods.ViewOrPlay(Plugin.Instance.Config.MtfSpawn, "ms", arguments.At(0), out response);

            response = "Syntax: ca ms <v/p>";
            return false;
        }
    }
}