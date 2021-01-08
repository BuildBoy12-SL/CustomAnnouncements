namespace CustomAnnouncements
{
    using Exiled.API.Features;
    using MEC;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Methods
    {
        public static IEnumerator<float> PlayAnnouncement(IAnnouncement announcement, string overrideMessage = null)
        {
            if (announcement.IsNullOrEmpty())
                yield break;

            if (!string.IsNullOrEmpty(overrideMessage))
                announcement.Message = overrideMessage;

            string message = GetVariableMessage(announcement.Message);
            if (announcement.IsGlitchy)
                Cassie.DelayedGlitchyMessage(message, announcement.Delay,
                    announcement.GlitchChance * 0.01f, announcement.JamChance * 0.01f);
            else
                Cassie.DelayedMessage(message, announcement.Delay, isNoisy: announcement.IsNoisy);
        }

        private static string GetVariableMessage(string str)
        {
            var scpCount = Player.Get(Team.SCP).Count();
            return str.ReplaceAfterToken('$',
                new[]
                {
                    new Tuple<string, object>("ScpsLeft", scpCount),
                    new Tuple<string, object>("MtfLeft", Player.Get(Team.MTF).Count()),
                    new Tuple<string, object>("SciLeft", Player.Get(Team.RSC).Count()),
                    new Tuple<string, object>("CdpLeft", Player.Get(Team.CDP).Count()),
                    new Tuple<string, object>("ChiLeft", Player.Get(Team.CHI).Count()),
                    new Tuple<string, object>("HumansLeft",
                        Player.List.Count(player =>
                            player.Team != Team.RIP && player.Team != Team.SCP && player.Team != Team.TUT)),
                    new Tuple<string, object>("TotalPlayers", Player.List.Count()),
                    new Tuple<string, object>("ScpSubjects",
                        scpCount == 1 ? "ScpSubject" : "ScpSubjects"),
                    new Tuple<string, object>("NtfScpSubjects",
                        $"{(scpCount == 0 ? "NoScpsLeft" : $"AwaitingRecontainment {scpCount} {(scpCount == 1 ? "scpsubject" : "scpsubjects")}")}"),
                });
        }

        public static bool ViewOrPlay(IAnnouncement announcement, string command, string argument, out string response)
        {
            switch (argument)
            {
                case "p":
                case "play":
                    response = "Playing announcement.";
                    Timing.RunCoroutine(PlayAnnouncement(announcement));
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
    }
}