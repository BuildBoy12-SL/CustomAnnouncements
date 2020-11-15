namespace CustomAnnouncements.Handlers
{
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using Respawning;
    using Respawning.NamingRules;
    using System;
    using System.Linq;
    using static CustomAnnouncements;

    public class MapHandlers
    {
        public void OnAnnouncingScpTermination(AnnouncingScpTerminationEventArgs ev)
        {
            if (Instance.Config.ScpTerminated.IsNullOrEmpty())
                return;

            ev.IsAllowed = false;

            string terminationCause;
            var damageType = ev.HitInfo.GetDamageType();
            if (damageType == DamageTypes.Tesla)
            {
                terminationCause = "SUCCESSFULLY TERMINATED BY AUTOMATIC SECURITY SYSTEM";
            }
            else if (damageType == DamageTypes.Nuke)
            {
                terminationCause = "SUCCESSFULLY TERMINATED BY ALPHA WARHEAD";
            }
            else if (damageType == DamageTypes.Decont)
            {
                terminationCause = "LOST IN DECONTAMINATION SEQUENCE";
            }
            else
            {
                if (ev.Killer != null)
                {
                    terminationCause = ev.Killer.Team switch
                    {
                        Team.MTF => !UnitNamingRules.TryGetNamingRule(SpawnableTeamType.NineTailedFox,
                            out var unitNamingRule)
                            ? "UNKNOWN"
                            : $"CONTAINEDSUCCESSFULLY CONTAINMENTUNIT {unitNamingRule}",
                        Team.CHI => "CONTAINEDSUCCESSFULLY BY CHAOSINSURGENCY",
                        Team.RSC => "CONTAINEDSUCCESSFULLY BY SCIENCE PERSONNEL",
                        Team.CDP => "CONTAINEDSUCCESSFULLY BY CLASSD PERSONNEL",
                        _ => "SUCCESSFULLY TERMINATED . CONTAINMENTUNIT UNKNOWN"
                    };
                }
                else
                {
                    terminationCause = "SUCCESSFULLY TERMINATED . TERMINATION CAUSE UNSPECIFIED";
                }
            }

            var scpRole = ev.Role.fullName.Split('-')[1];
            string announcedScpRole = "SCP ";
            for (int i = 0; i < scpRole.Length; i++)
            {
                announcedScpRole += scpRole[i] + " ";
            }

            int scpsRemaining = Player.Get(Team.SCP).Count() - 1;
            var overrideMessage = Instance.Config.ScpTerminated.Message.ReplaceAfterToken('$', new[]
            {
                new Tuple<string, object>("TerminationCause", terminationCause),
                new Tuple<string, object>("KilledScp", announcedScpRole),
                new Tuple<string, object>("RemainingScps", scpsRemaining),
            });
            Instance.Methods.PlayAnnouncement(Instance.Config.ScpTerminated, overrideMessage);
        }

        public void OnAnnouncingNtfEntrance(AnnouncingNtfEntranceEventArgs ev)
        {
            if (Instance.Config.MtfSpawn.IsNullOrEmpty())
                return;

            ev.IsAllowed = false;
            var overrideMessage = Instance.Config.MtfSpawn.Message.ReplaceAfterToken('$', new[]
            {
                new Tuple<string, object>("ScpsLeft", ev.ScpsLeft),
                new Tuple<string, object>("UnitName", ev.UnitName),
                new Tuple<string, object>("UnitNumber", ev.UnitNumber)
            });
            Instance.Methods.PlayAnnouncement(Instance.Config.MtfSpawn, overrideMessage);
        }
    }
}