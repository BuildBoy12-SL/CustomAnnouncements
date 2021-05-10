// -----------------------------------------------------------------------
// <copyright file="EscapeScientist.cs" company="Build">
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
    /// A command to play the <see cref="Configs.EscapeScientist"/> announcement.
    /// </summary>
    public class EscapeScientist : ICommand
    {
        /// <inheritdoc />
        public string Command => "escapescientist";

        /// <inheritdoc />
        public string[] Aliases { get; } = { "es" };

        /// <inheritdoc/>
        public string Description => "Views or plays the EscapeScientist announcement.";

        /// <inheritdoc />
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("ca.es"))
            {
                response = "Insufficient permission. Required: ca.es";
                return false;
            }

            if (Plugin.Instance.Config.EscapeScientist.IsNullOrEmpty())
            {
                response = "The EscapeScientist announcement is not set in the config.";
                return true;
            }

            if (arguments.Count == 1)
                return Methods.ViewOrPlay(Plugin.Instance.Config.RoundStart, "es", arguments.At(0), out response);

            response = "Syntax: ca es <v/p>";
            return false;
        }
    }
}