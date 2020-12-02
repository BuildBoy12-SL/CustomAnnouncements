namespace CustomAnnouncements.Commands.SubCommands
{
    using CommandSystem;
    using Exiled.Permissions.Extensions;
    using MEC;
    using System;
    using static CustomAnnouncements;

    public class ChaosSpawn : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender as CommandSender).CheckPermission("ca.chs"))
            {
                response = "Insufficient permission. Required: ca.chs";
                return false;
            }

            if (Instance.Config.ChaosSpawn.IsNullOrEmpty())
            {
                response = "The ChaosSpawn announcement is not set in the config.";
                return true;
            }

            if (arguments.Count != 1)
            {
                response = "Syntax: ca chs <v/p>";
                return false;
            }

            switch (arguments.At(0))
            {
                case "p":
                case "play":
                    response = "Playing ChaosSpawn announcement.";
                    Timing.RunCoroutine(Methods.PlayAnnouncement(Instance.Config.ChaosSpawn));
                    return true;
                case "v":
                case "view":
                    response = Instance.Config.ChaosSpawn.Message;
                    return true;
                default:
                    response = "Syntax: ca chs (v/p)";
                    return true;
            }
        }

        public string Command => "chaosspawn";
        public string[] Aliases => new[] {"chs"};
        public string Description => "Views or plays the ChaosSpawn announcement.";
    }
}