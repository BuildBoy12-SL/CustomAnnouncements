namespace CustomAnnouncements.Handlers
{
    using Exiled.Events.EventArgs;
    using System;
    using static CustomAnnouncements;

    public class MapHandlers
    {
        public void OnAnnouncingScpTermination(AnnouncingScpTerminationEventArgs ev)
        {
            if (Instance.Config.ScpTerminated.IsNullOrEmpty())
                return;

            ev.IsAllowed = false;
            string unitName = !Respawning.NamingRules.UnitNamingRules.TryGetNamingRule(
                Respawning.SpawnableTeamType.NineTailedFox,
                out var unitNamingRule)
                ? "Unknown"
                : "containmentunit " + unitNamingRule.GetCassieUnitName(ev.Killer.ReferenceHub.characterClassManager.CurUnitName);

            var overrideMessage = Instance.Config.ScpTerminated.Message.ReplaceAfterToken('$', new[]
            {
                new Tuple<string, object>("TerminationCause", ev.TerminationCause),
                new Tuple<string, object>("TerminatorRole", ev.Role),
                new Tuple<string, object>("NtfUnit", unitName)
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