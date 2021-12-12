// -----------------------------------------------------------------------
// <copyright file="Methods.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomAnnouncements
{
    using System;
    using System.Linq;
    using Exiled.API.Features;

    /// <summary>
    /// A collection of various methods utilized for abstraction.
    /// </summary>
    public class Methods
    {
        /// <summary>
        /// Plays a CASSIE announcement based off of the configuration of a <see cref="IAnnouncement"/>.
        /// </summary>
        /// <param name="announcement">The announcement to play.</param>
        /// <param name="overrideMessage">The message to override the <see cref="IAnnouncement.Message"/>. Ignored if null or empty.</param>
        public static void PlayAnnouncement(IAnnouncement announcement, string overrideMessage = null)
        {
            string message = announcement.Message;
            if (!string.IsNullOrEmpty(overrideMessage))
                message = overrideMessage;

            if (string.IsNullOrEmpty(message))
                return;

            message = GetVariableMessage(message);
            if (announcement.IsGlitchy)
                Cassie.DelayedGlitchyMessage(message, announcement.Delay, announcement.GlitchChance * 0.01f, announcement.JamChance * 0.01f);
            else
                Cassie.DelayedMessage(message, announcement.Delay, isNoisy: announcement.IsNoisy);
        }

        /// <summary>
        /// Used for commands so that a user may view or play an <see cref="IAnnouncement"/> based off of the given arguments.
        /// </summary>
        /// <param name="announcement">The <see cref="IAnnouncement"/> to view or play.</param>
        /// <param name="command">The command that the request originated from.</param>
        /// <param name="argument">The player given request of action.</param>
        /// <param name="response">The message to send back to the player.</param>
        /// <returns>Whether the command executed successfully.</returns>
        public static bool ViewOrPlay(IAnnouncement announcement, string command, string argument, out string response)
        {
            switch (argument)
            {
                case "p":
                case "play":
                    response = "Playing announcement.";
                    PlayAnnouncement(announcement);
                    return true;
                case "v":
                case "view":
                    response = announcement.Message;
                    return true;
                default:
                    response = $"Syntax: ca {command} (v/p)";
                    return false;
            }
        }

        private static string GetVariableMessage(string str)
        {
            var scpCount = Player.Get(Team.SCP).Count();
            return str.ReplaceAfterToken('$', new[]
            {
                new Tuple<string, object>("ScpsLeft", scpCount),
                new Tuple<string, object>("MtfLeft", Player.Get(Team.MTF).Count()),
                new Tuple<string, object>("SciLeft", Player.Get(Team.RSC).Count()),
                new Tuple<string, object>("CdpLeft", Player.Get(Team.CDP).Count()),
                new Tuple<string, object>("ChiLeft", Player.Get(Team.CHI).Count()),
                new Tuple<string, object>("HumansLeft", Player.List.Count(player => player.Team != Team.RIP && player.Team != Team.SCP && player.Team != Team.TUT)),
                new Tuple<string, object>("TotalPlayers", Player.List.Count()),
                new Tuple<string, object>("ScpSubjects", scpCount == 1 ? "ScpSubject" : "ScpSubjects"),
                new Tuple<string, object>("NtfScpSubjects", $"{(scpCount == 0 ? "NoScpsLeft" : $"AwaitingRecontainment {scpCount} {(scpCount == 1 ? "scpsubject" : "scpsubjects")}")}"),
            });
        }
    }
}