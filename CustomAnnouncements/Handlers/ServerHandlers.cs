namespace CustomAnnouncements.Handlers
{
    using Exiled.Events.EventArgs;
    using static CustomAnnouncements;
    
    public class ServerHandlers
    {
        public void OnRespawningTeam(RespawningTeamEventArgs ev)
        {
            if (ev.Players.Count <= 0)
                return;
            
            if (!Instance.Config.ChaosSpawn.IsNullOrEmpty() && ev.NextKnownTeam == Respawning.SpawnableTeamType.ChaosInsurgency)
                Instance.Methods.PlayAnnouncement(Instance.Config.ChaosSpawn);
        }

        public void OnRoundEnd(RoundEndedEventArgs _)
        {
            if (Instance.Config.RoundEnd.IsNullOrEmpty())
                return;
            
            Instance.Methods.PlayAnnouncement(Instance.Config.RoundEnd);
        }

        public void OnRoundStart()
        {
            if (Instance.Config.RoundStart.IsNullOrEmpty())
                return;
            
            Instance.Methods.PlayAnnouncement(Instance.Config.RoundStart);
        }
    }
}