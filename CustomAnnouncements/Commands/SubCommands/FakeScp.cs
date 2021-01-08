namespace CustomAnnouncements.Commands.SubCommands
{
    using CommandSystem;
    using Exiled.API.Features;
    using Exiled.Permissions.Extensions;
    using System;
    using System.Linq;

    public class FakeScp : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("ca.fscp"))
            {
                response = "Insufficient permission. Required: ca.fscp";
                return false;
            }

            response =
                "Syntax: scpa (scp number) (death type)\nDeath Types: tesla, dclass, scientist, mtf, chaos, decont";

            if (arguments.Count != 2)
                return false;

            string scpNum = arguments.At(0);
            if (!int.TryParse(scpNum, out _))
                return false;

            for (int i = 0; i <= scpNum.Length; i += 2)
            {
                scpNum = scpNum.Insert(i, " ");
            }

            string deathCause = string.Empty;
            switch (arguments.At(1))
            {
                case "t":
                case "tesla":
                    deathCause = "Successfully Terminated by Automatic Security System";
                    break;
                case "d":
                case "dclass":
                    deathCause = "terminated by ClassD personnel";
                    break;
                case "s":
                case "science":
                case "scientist":
                    deathCause = "terminated by science personnel";
                    break;
                case "c":
                case "chaos":
                    deathCause = "terminated by ChaosInsurgency";
                    break;
                case "m":
                case "mtf":
                    Player dummy = Player.List.FirstOrDefault(player => player.Team == Team.MTF);
                    if (dummy == null)
                    {
                        response = "There are currently no alive MTF to mimic the unit of.";
                        return false;
                    }

                    if (!Respawning.NamingRules.UnitNamingRules.TryGetNamingRule(
                        Respawning.SpawnableTeamType.NineTailedFox,
                        out Respawning.NamingRules.UnitNamingRule unitNamingRule))
                        deathCause = "Unknown";
                    else
                        deathCause = "CONTAINEDSUCCESSFULLY CONTAINMENTUNIT " +
                                     unitNamingRule.GetCassieUnitName(dummy.ReferenceHub.characterClassManager
                                         .CurUnitName);
                    break;
                case "decont":
                    deathCause = "Lost in Decontamination Sequence";
                    break;
            }

            if (string.IsNullOrEmpty(deathCause))
                return false;

            Cassie.Message($"scp {scpNum} {deathCause}");
            response = "Playing announcement.";
            return true;
        }

        public string Command => "fakescp";
        public string[] Aliases => new[] {"scpa", "fscp"};
        public string Description => "Fakes a Scp death announcement.";
    }
}