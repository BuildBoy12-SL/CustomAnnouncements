using EXILED;
using EXILED.Extensions;
using System;
using System.Linq;

namespace CustomAnnouncements
{
	public class EventHandlers
	{
		public Plugin plugin;
		public EventHandlers(Plugin plugin) => this.plugin = plugin;

		//Responses for permissions
		public string success = "Announcement made successfully.";
		public string denied = "Permission ca_main required.";

		//Used to return usages for commands if used incorrectly
		public string chsUsage = "<br>" + "USAGE: chs (view/play)";
		public string reUsage = "<br>" + "USAGE: (view/play)";
		public string rsUsage = "<br>" + "USAGE: (view/play)";
		public string deUsage = "<br>" + "USAGE: (view/play)";
		public string seUsage = "<br>" + "USAGE: (view/play)";
		public string mtfUsage = "<br>" + "USAGE: (view/play)";
		public string mtfaUsage = "<br>" + "USAGE: mtfa (scps left) (mtf number) (mtf letter)";
		public string scpaUsage = "<br>" + "USAGE: scpa (scp number) (death type)";

		//Round start, self explanatory
		public void OnRoundStart()
		{
			if (plugin.rsMessage != "")
				plugin.Methods.DoAnnouncement(plugin.rsMessage, plugin.rsNoise);
			else
				Log.Debug("Round start message not set, skipping.");
		}

		//Round end, self explanatory
		public void OnRoundEnd()
		{
			if (plugin.reMessage != "")
				plugin.Methods.DoAnnouncement(plugin.reMessage, plugin.reNoise);
			else
				Log.Debug("Round end message not set, skipping.");
		}

		//Check if a UserID is in the dictionary for player join announcements
		public void OnPlayerJoin(PlayerJoinEvent ev)
		{
			try
			{
				if (string.IsNullOrEmpty(ev.Player.characterClassManager.UserId) || ev.Player.characterClassManager.IsHost)
					return;

				if (plugin.playerAnnouncements.Count() == 0)
					return;

				string player = plugin.playerAnnouncements[ev.Player.characterClassManager.UserId];
				if (player == null)
					return;

				plugin.Methods.DoAnnouncement(player, plugin.playerNoise);
			}
			catch(Exception e)
			{
				Log.Debug($"Here's probably a useless exception (Probably caused by checking for a player and them not being in the list) {e}");
			}		
		}

		//Both escape cases
		public void CheckEscape(ref CheckEscapeEvent ev)
		{
			if (ev.Player.characterClassManager.CurClass == RoleType.ClassD && plugin.deMessage != "")
				plugin.Methods.DoAnnouncement(plugin.deMessage, plugin.deNoise);
			else if (ev.Player.characterClassManager.CurClass == RoleType.Scientist && plugin.seMessage != "")
				plugin.Methods.DoAnnouncement(plugin.seMessage, plugin.seNoise);
			else
				Log.Debug("No announcements set for escapes, skipping.");
		}

		//Chaos Announcement
		public void OnRespawn(ref TeamRespawnEvent ev)
		{
			if (ev.IsChaos && plugin.chsMessage != "")
				plugin.Methods.DoAnnouncement(plugin.chsMessage, plugin.chsNoise);
			else
				Log.Debug("No announcements set for chaos respawns, skipping.");
		}

		//Replace MTF spawn announcement with custom if enabled.
		public void AnnounceNtfEntrance(AnnounceNtfEntranceEvent ev)
		{
			if (plugin.mtfMessage == "")
			{
				Log.Debug("No announcements set for mtf respawns, skipping.");
				return;
			}
			ev.Allow = false;
			var mtfMsg = plugin.mtfMessage.Replace("%NtfLetter%", ev.NtfLetter.ToString()).Replace("%NtfNumber%", ev.NtfNumber.ToString()).Replace("%ScpsLeft%", ev.ScpsLeft.ToString());
			plugin.Methods.DoAnnouncement(mtfMsg, plugin.mtfNoise);
		}

		//All commands
		public void OnCommand(ref RACommandEvent ev)
		{
			try
			{
				if (ev.Command.Contains("REQUEST_DATA PLAYER_LIST SILENT"))
					return;

				string[] args = ev.Command.Split(' ');
				ReferenceHub sender = ev.Sender.SenderId == "SERVER CONSOLE" ? Player.GetPlayer(PlayerManager.localPlayer) : Player.GetPlayer(ev.Sender.SenderId);

				switch (args[0].ToLower())
				{
					case "ca":
						ev.Allow = false;
						if (!sender.CheckPermission("ca.main"))
						{
							ev.Sender.RAMessage(denied);
							return;
						}
						ev.Sender.RAMessage("<br>" +
							"ca: Displays commands and info" + "<br>" + "<br>" +
							"chs (view/play): Plays configured chaos announcement" + "<br>" +
							"re (view/play): Plays configured round end announcement" + "<br>" +
							"rs (view/play): Plays configured round start announcement" + "<br>" +
							"de (view/play): Plays configured DClass escape announcement" + "<br>" +
							"se (view/play): Plays configured Scientist escape announcement" + "<br>" +
							"mtfa (scps left) (mtf number) (mtf letter): Plays mtf annoucement" + "<br>" +
							"scpa (scp number) (death type): Plays scp death announcement;" + "<br>" + 
							"Use tesla, dclass, science, mtf, or chaos for death type");
						break;

					case "chs":
						ev.Allow = false;
						if (!sender.CheckPermission("ca.main"))
						{
							ev.Sender.RAMessage(denied);
							return;
						}
						if (args.Length != 2)
						{
							ev.Sender.RAMessage(chsUsage);
							return;
						}

						if (args[1] == "play" || args[1] == "p")
						{
							if (plugin.chsMessage != "")
							{
								plugin.Methods.DoAnnouncement(plugin.chsMessage, plugin.chsNoise);
								ev.Sender.RAMessage(success);
								return;
							}
							else
							{
								ev.Sender.RAMessage("Chaos Spawn announcement is not set");
							}
						}
						else if (args[1] == "view" || args[1] == "v")
						{
							if (plugin.chsMessage != "")
							{
								ev.Sender.RAMessage(plugin.chsMessage);
								return;
							}
							else
							{
								ev.Sender.RAMessage("Chaos Spawn announcement is not set");
							}
						}
						else
						{
							ev.Sender.RAMessage(chsUsage);
						}
						break;

					case "re":
						ev.Allow = false;
						if (!sender.CheckPermission("ca.main"))
						{
							ev.Sender.RAMessage(denied);
							return;
						}
						if (args.Length != 2)
						{
							ev.Sender.RAMessage(reUsage);
							return;
						}

						if (args[1] == "play" || args[1] == "p")
						{
							if (plugin.reMessage != "")
							{
								plugin.Methods.DoAnnouncement(plugin.reMessage, plugin.reNoise);
								ev.Sender.RAMessage(success);
								return;
							}
							else
							{
								ev.Sender.RAMessage("Round End announcement is not set");
							}
						}
						else if (args[1] == "view" || args[1] == "v")
						{
							if (plugin.reMessage != "")
							{
								ev.Sender.RAMessage(plugin.reMessage);
								return;
							}
							else
							{
								ev.Sender.RAMessage("Round End announcement is not set");
							}
						}
						else
						{
							ev.Sender.RAMessage(reUsage);
						}
						break;

					case "rs":
						ev.Allow = false;
						if (!sender.CheckPermission("ca.main"))
						{
							ev.Sender.RAMessage(denied);
							return;
						}
						if (args.Length != 2)
						{
							ev.Sender.RAMessage(rsUsage);
							return;
						}

						if (args[1] == "play" || args[1] == "p")
						{
							if (plugin.rsMessage != "")
							{
								plugin.Methods.DoAnnouncement(plugin.rsMessage, plugin.rsNoise);
								ev.Sender.RAMessage(success);
								return;
							}
							else
							{
								ev.Sender.RAMessage("Round Start announcement is not set");
							}
						}
						else if (args[1] == "view" || args[1] == "v")
						{
							if (plugin.rsMessage != "")
							{
								ev.Sender.RAMessage(plugin.rsMessage);
								return;
							}
							else
							{
								ev.Sender.RAMessage("Round Start announcement is not set");
							}
						}
						else
						{
							ev.Sender.RAMessage(rsUsage);
						}
						break;

					case "de":
						ev.Allow = false;
						if (!sender.CheckPermission("ca.main"))
						{
							ev.Sender.RAMessage(denied);
							return;
						}
						if (args.Length != 2)
						{
							ev.Sender.RAMessage(deUsage);
							return;
						}

						if (args[1] == "play" || args[1] == "p")
						{
							if (plugin.deMessage != "")
							{
								plugin.Methods.DoAnnouncement(plugin.deMessage, plugin.deNoise);
								ev.Sender.RAMessage(success);
								return;
							}
							else
							{
								ev.Sender.RAMessage("DClass Escape announcement is not set");
							}
						}
						else if (args[1] == "view" || args[1] == "v")
						{
							if (plugin.deMessage != "")
							{
								ev.Sender.RAMessage(plugin.deMessage);
								return;
							}
							else
							{
								ev.Sender.RAMessage("DClass Escape announcement is not set");
							}
						}
						else
						{
							ev.Sender.RAMessage(deUsage);
						}
						break;

					case "se":
						ev.Allow = false;
						if (!sender.CheckPermission("ca.main"))
						{
							ev.Sender.RAMessage(denied);
							return;
						}
						if (args.Length != 2)
						{
							ev.Sender.RAMessage(seUsage);
							return;
						}

						if (args[1] == "play" || args[1] == "p")
						{
							if (plugin.seMessage != "")
							{
								plugin.Methods.DoAnnouncement(plugin.seMessage, plugin.seNoise);
								ev.Sender.RAMessage(success);
								return;
							}
							else
							{
								ev.Sender.RAMessage("Scientist Escape announcement is not set");
							}
						}
						else if (args[1] == "view" || args[1] == "v")
						{
							if (plugin.seMessage != "")
							{
								ev.Sender.RAMessage(plugin.seMessage);
								return;
							}
							else
							{
								ev.Sender.RAMessage("Scientist Escape announcement is not set");
							}
						}
						else
						{
							ev.Sender.RAMessage(seUsage);
						}
						break;

					case "mtfa":
						if (!sender.CheckPermission("ca.main"))
						{
							ev.Sender.RAMessage(denied);
							return;
						}
						ev.Allow = false;
						if (args.Length != 4)
						{
							ev.Sender.RAMessage(mtfaUsage);
							return;
						}

						if (int.TryParse(args[1], out int a))
						{
							int scpsLeft = a;
						}
						else
						{
							ev.Sender.RAMessage(mtfaUsage);
							return;
						}

						if (int.TryParse(args[2], out int b))
						{
							int mtfNumber = b;
						}
						else
						{
							ev.Sender.RAMessage(mtfaUsage);
							return;
						}

						if (char.TryParse(args[3], out char c))
						{
							char mtfLetter = c;
						}
						else
						{
							ev.Sender.RAMessage(mtfaUsage);
							return;
						}

						PlayerManager.localPlayer.GetComponent<MTFRespawn>().RpcPlayCustomAnnouncement("MtfUnit epsilon 11 designated nato_" + c + " " + b + " " + "HasEntered AllRemaining AwaitingRecontainment" + " " + a + " " + "scpsubjects", false, true);
						ev.Sender.RAMessage(success);				
						break;

					case "scpa":					
						ev.Allow = false;
						if (!sender.CheckPermission("ca.main"))
						{
							ev.Sender.RAMessage(denied);
							return;
						}
						if (args.Length != 3)
						{
							ev.Sender.RAMessage(scpaUsage);
							return;
						}

						string deathCause = null;
						string ebic = null;
						int e = 0;
						bool resultNan = int.TryParse(args[1], out e);

						if (e == 0)
						{
							ev.Sender.RAMessage(scpaUsage);
							return;
						}
						else
						{
							ebic = args[1];

							for (int i = 1; i <= ebic.Length; i += 1)
							{
								ebic = ebic.Insert(i, " ");
								i++;
							}
						}

						if (args[2] == "t" || args[2] == "tesla")
						{
							deathCause = "Successfully Terminated by Automatic Security System";
						}
						else if (args[2] == "d" || args[2] == "dclass")
						{
							deathCause = "terminated by ClassD personnel";
						}
						else if (args[2] == "s" || args[2] == "science")
						{
							deathCause = "terminated by science personnel";
						}
						else if (args[2] == "c" || args[2] == "chaos")
						{
							deathCause = "terminated by ChaosInsurgency";
						}
						else if (args[2] == "m" || args[2] == "mtf")
						{
							var chars1 = "abcdefghijklmnopqrstuvwxyz";
							var stringChars1 = new char[1];
							var random1 = new Random();

							for (int i = 0; i < stringChars1.Length; i++)
							{
								stringChars1[i] = chars1[random1.Next(chars1.Length)];
							}

							var randLetter = new String(stringChars1);

							var chars2 = "123456789";
							var stringChars2 = new char[1];
							var random2 = new Random();

							for (int i = 0; i < stringChars2.Length; i++)
							{
								stringChars2[i] = chars2[random2.Next(chars2.Length)];
							}

							var randNumber = new String(stringChars2);

							deathCause = "ContainedSuccessfully  ContainmentUnit nato_" + randLetter + " " + randNumber;
						}

						if (deathCause == null)
						{
							ev.Sender.RAMessage(scpaUsage);
							return;
						}
						PlayerManager.localPlayer.GetComponent<MTFRespawn>().RpcPlayCustomAnnouncement("scp" + " " + ebic + " " + deathCause, false, true);
						ev.Sender.RAMessage(success);
						deathCause = null;						
						break;				
				}
			}
			catch(Exception e)
			{
				Log.Error($"Command error for CustomAnnouncements: {e}");
			}
		}
	}
}