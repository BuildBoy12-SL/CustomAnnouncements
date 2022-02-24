// -----------------------------------------------------------------------
// <copyright file="RoundEnd.cs" company="Build">
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
    /// A command to play the <see cref="Configs.RoundEnd"/> announcement.
    /// </summary>
    public class RoundEnd : ICommand
    {
        /// <inheritdoc />
        public string Command => "roundend";

        /// <inheritdoc />
        public string[] Aliases { get; } = { "re" };

        /// <inheritdoc />
        public string Description => "Views or plays the RoundEnd announcement.";

        /// <inheritdoc />
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("ca.re"))
            {
                response = "Insufficient permission. Required: ca.re";
                return false;
            }

            if (Plugin.Instance.Config.RoundEnd.IsNullOrEmpty())
            {
                response = "The RoundEnd announcement is not set in the config.";
                return true;
            }

            if (arguments.Count == 1)
                return Methods.ViewOrPlay(Plugin.Instance.Config.RoundEnd, "re", arguments.At(0), out response);

            response = "Syntax: ca re <v/p>";
            return false;
        }
    }
}