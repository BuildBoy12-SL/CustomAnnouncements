namespace CustomAnnouncements.Handlers
{
    using Exiled.Events.EventArgs;
    using System.Linq;
    using static CustomAnnouncements;
    
    public class PlayerHandlers
    {
        public void OnPlayerJoin(JoinedEventArgs ev)
        {
            if (Instance.Config.PlayerJoined.UserIds == null)
                return;
            
            if (!Instance.Config.PlayerJoined.UserIds.Any())
                return;
            
            if (!Instance.Config.PlayerJoined.UserIds.Contains(ev.Player.UserId) || Instance.Config.PlayerJoined.IsNullOrEmpty())
                return;
            
            Instance.Methods.PlayAnnouncement(Instance.Config.PlayerJoined);
        }

        public void OnEscaping(EscapingEventArgs ev)
        {
            switch (ev.Player.Role)
            {
                case RoleType.ClassD:
                    if (!Instance.Config.EscapeClassD.IsNullOrEmpty())
                        Instance.Methods.PlayAnnouncement(Instance.Config.EscapeClassD);
                    break;
                case RoleType.Scientist:
                    if (!Instance.Config.EscapeScientist.IsNullOrEmpty())
                        Instance.Methods.PlayAnnouncement(Instance.Config.EscapeScientist);
                    break;
            }
        }
    }
}