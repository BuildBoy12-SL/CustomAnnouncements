// -----------------------------------------------------------------------
// <copyright file="FakeMtf.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomAnnouncements.Commands.SubCommands
{
    using System;
    using CommandSystem;
    using Exiled.API.Features;
    using Exiled.Permissions.Extensions;

    /// <summary>
    /// A command to play a faked MTF spawn.
    /// </summary>
    public class FakeMtf : ICommand
    {
        /// <inheritdoc />
        public string Command => "fakemtf";

        /// <inheritdoc />
        public string[] Aliases { get; } = { "mtfa", "fmtf" };

        /// <inheritdoc />
        public string Description => "Fakes a Mtf spawn announcement.";

        /// <inheritdoc />
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("ca.fmtf"))
            {
                response = "Insufficient permission. Required: ca.es";
                return false;
            }

            response = "Syntax: ca mtfa (mtf letter) (mtf number) (scps left)";
            if (arguments.Count < 3)
                return false;

            if (!char.TryParse(arguments.At(0), out char unitDesignation) ||
                !int.TryParse(arguments.At(1), out int unitNumber) ||
                !int.TryParse(arguments.At(2), out int scpsRemaining))
                return false;

            Cassie.Message($"MtfUnit epsilon 11 designated nato_{unitDesignation} {unitNumber} " +
                           $"HasEntered AllRemaining {(scpsRemaining == 0 ? "NoScpsLeft" : $"AwaitingRecontainment {scpsRemaining} {(scpsRemaining == 1 ? "scpsubject" : "scpsubjects")}")}");
            response = "Playing announcement.";
            return true;
        }
    }
}