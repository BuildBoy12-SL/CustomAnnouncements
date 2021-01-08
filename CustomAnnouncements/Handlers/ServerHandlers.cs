namespace CustomAnnouncements.Handlers
{
    using Exiled.API.Enums;
    using Exiled.Events.EventArgs;
    using MEC;

    public class ServerHandlers
    {
        public ServerHandlers(CustomAnnouncements customAnnouncements) => _customAnnouncements = customAnnouncements;
        private readonly CustomAnnouncements _customAnnouncements;

        public void OnRespawningTeam(RespawningTeamEventArgs ev)
        {
            if (ev.NextKnownTeam == Respawning.SpawnableTeamType.ChaosInsurgency && ev.Players.Count > 0)
                Timing.RunCoroutine(Methods.PlayAnnouncement(_customAnnouncements.Config.ChaosSpawn));
        }

        public void OnRoundEnd(EndingRoundEventArgs ev)
        {
            if (!ev.IsRoundEnded)
                return;

            string str = ev.LeadingTeam switch
            {
                LeadingTeam.Anomalies => _customAnnouncements.Config.RoundEnd.ScpMessage,
                LeadingTeam.FacilityForces => _customAnnouncements.Config.RoundEnd.MtfMessage,
                LeadingTeam.ChaosInsurgency => _customAnnouncements.Config.RoundEnd.ChiMessage,
                LeadingTeam.Draw => _customAnnouncements.Config.RoundEnd.DrawMessage,
                _ => null
            };

            Timing.RunCoroutine(Methods.PlayAnnouncement(_customAnnouncements.Config.RoundEnd, str));
        }

        public void OnRoundStart()
        {
            Timing.RunCoroutine(Methods.PlayAnnouncement(_customAnnouncements.Config.RoundStart));
        }
    }
}