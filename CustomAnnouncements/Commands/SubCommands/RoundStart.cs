namespace CustomAnnouncements.Commands.SubCommands
{
    using CommandSystem;
    using Exiled.Permissions.Extensions;
    using MEC;
    using System;
    using static CustomAnnouncements;

    public class RoundStart : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender as CommandSender).CheckPermission("ca.rs"))
            {
                response = "Insufficient permission. Required: ca.rs";
                return false;
            }

            if (Instance.Config.RoundStart.IsNullOrEmpty())
            {
                response = "The RoundStart announcement is not set in the config.";
                return true;
            }

            if (arguments.Count != 1)
            {
                response = "Syntax: ca rs <v/p>";
                return false;
            }

            switch (arguments.At(0))
            {
                case "p":
                case "play":
                    response = "Playing RoundStart announcement.";
                    Timing.RunCoroutine(Methods.PlayAnnouncement(Instance.Config.RoundStart));
                    return true;
                case "v":
                case "view":
                    response = Instance.Config.RoundStart.Message;
                    return true;
                default:
                    response = "Syntax: ca rs (v/p)";
                    return false;
            }
        }

        public string Command => "roundstart";
        public string[] Aliases => new[] {"rs"};
        public string Description => "Views or plays the RoundStart announcement.";
    }
}