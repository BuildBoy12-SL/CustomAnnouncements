namespace CustomAnnouncements.Handlers
{
    using Exiled.Events.EventArgs;
    using MEC;
    using System.Linq;

    public class PlayerHandlers
    {
        public PlayerHandlers(CustomAnnouncements customAnnouncements) => _customAnnouncements = customAnnouncements;
        private readonly CustomAnnouncements _customAnnouncements;

        public void OnPlayerJoin(JoinedEventArgs ev)
        {
            if (_customAnnouncements.Config.PlayerJoined.UserIds == null)
                return;

            if (!_customAnnouncements.Config.PlayerJoined.UserIds.Any() ||
                !_customAnnouncements.Config.PlayerJoined.UserIds.Contains(ev.Player.UserId))
                return;

            Timing.RunCoroutine(Methods.PlayAnnouncement(_customAnnouncements.Config.PlayerJoined));
        }

        public void OnEscaping(EscapingEventArgs ev)
        {
            switch (ev.Player.Role)
            {
                case RoleType.ClassD:
                    if (_customAnnouncements.Config.EscapeClassD.OnlyPlayFirst && RoundSummary.escaped_ds != 0)
                        return;

                    Timing.RunCoroutine(Methods.PlayAnnouncement(_customAnnouncements.Config.EscapeClassD));
                    break;
                case RoleType.Scientist:
                    if (_customAnnouncements.Config.EscapeScientist.OnlyPlayFirst &&
                        RoundSummary.escaped_scientists != 0)
                        return;

                    Timing.RunCoroutine(Methods.PlayAnnouncement(_customAnnouncements.Config.EscapeScientist));
                    break;
            }
        }
    }
}