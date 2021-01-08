namespace CustomAnnouncements.Handlers
{
    using Exiled.Events.EventArgs;
    using MEC;
    using System;

    public class MapHandlers
    {
        public MapHandlers(CustomAnnouncements customAnnouncements) => _customAnnouncements = customAnnouncements;
        private readonly CustomAnnouncements _customAnnouncements;

        public void OnAnnouncingNtfEntrance(AnnouncingNtfEntranceEventArgs ev)
        {
            if (_customAnnouncements.Config.MtfSpawn.IsNullOrEmpty())
                return;

            ev.IsAllowed = false;
            var overrideMessage = _customAnnouncements.Config.MtfSpawn.Message.ReplaceAfterToken('$', new[]
            {
                new Tuple<string, object>("UnitName", "nato_" + ev.UnitName),
                new Tuple<string, object>("UnitNumber", ev.UnitNumber)
            });

            Timing.RunCoroutine(Methods.PlayAnnouncement(_customAnnouncements.Config.MtfSpawn, overrideMessage));
        }
    }
}