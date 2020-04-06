using EXILED;
using System.Collections.Generic;

namespace CustomAnnouncements
{
	public class Plugin : EXILED.Plugin
	{
		public EventHandlers EventHandlers;
		public Methods Methods;

		//All config options
		internal bool Enabled;

		internal string chsMessage;
		internal bool chsNoise;

		internal string mtfMessage;
		internal bool mtfNoise;

		internal string reMessage;
		internal bool reNoise;

		internal string rsMessage;
		internal bool rsNoise;

		internal string deMessage;
		internal bool deNoise;

		internal string seMessage;
		internal bool seNoise;

		internal Dictionary<string, string> playerAnnouncements;
		internal bool playerNoise;

		public override void OnEnable()
		{
			ReloadPlugin();
			if (!Enabled)
				return;

			EventHandlers = new EventHandlers(this);
			Methods = new Methods(this);

			Events.TeamRespawnEvent += EventHandlers.OnRespawn;
			Events.PlayerJoinEvent += EventHandlers.OnPlayerJoin;
			Events.RoundEndEvent += EventHandlers.OnRoundEnd;
			Events.RoundStartEvent += EventHandlers.OnRoundStart;
			Events.RemoteAdminCommandEvent += EventHandlers.OnCommand;
			Events.CheckEscapeEvent += EventHandlers.CheckEscape;
			Events.AnnounceNtfEntranceEvent += EventHandlers.AnnounceNtfEntrance;
			Log.Info($"Custom Announcements loaded successfully.");
		}

		public override void OnDisable()
		{
			Events.TeamRespawnEvent -= EventHandlers.OnRespawn;
			Events.RoundEndEvent -= EventHandlers.OnRoundEnd;
			Events.RoundStartEvent -= EventHandlers.OnRoundStart;
			Events.RemoteAdminCommandEvent -= EventHandlers.OnCommand;
			Events.CheckEscapeEvent -= EventHandlers.CheckEscape;
			Events.AnnounceNtfEntranceEvent -= EventHandlers.AnnounceNtfEntrance;

			EventHandlers = null;
			Methods = null;
		}

		public override void OnReload()
		{
			
		}

		public override string getName { get; } = "Custom Announcements";

		public void ReloadPlugin()
		{
			Enabled = Config.GetBool("ca_enable", true);

			chsMessage = Config.GetString("ca_chaos_spawn", "");
			chsNoise = Config.GetBool("ca_chaos_noise", false);

			mtfMessage = Config.GetString("ca_mtf_spawn", "");
			mtfNoise = Config.GetBool("ca_mtf_noise", false);

			reMessage = Config.GetString("ca_roundend", "");
			reNoise = Config.GetBool("ca_roundend_noise", false);

			rsMessage = Config.GetString("ca_roundstart", "");
			rsNoise = Config.GetBool("ca_roundstart_noise", false);

			deMessage = Config.GetString("ca_dclass_escape", "");
			deNoise = Config.GetBool("ca_dclass_escape_noise", false);

			seMessage = Config.GetString("ca_science_escape", "");
			seNoise = Config.GetBool("ca_science_escape_noise", false);

			playerAnnouncements = Methods.GetDictonaryValue(Config.GetString("ca_join", ""));
			playerNoise = Config.GetBool("ca_join_noise", false);
		}
	}
}