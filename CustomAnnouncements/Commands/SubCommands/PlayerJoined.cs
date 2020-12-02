namespace CustomAnnouncements.Commands.SubCommands
{
    using CommandSystem;
    using Exiled.Permissions.Extensions;
    using MEC;
    using System;
    using static CustomAnnouncements;

    public class PlayerJoined : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender as CommandSender).CheckPermission("ca.pj"))
            {
                response = "Insufficient permission. Required: ca.pj";
                return false;
            }

            if (Instance.Config.PlayerJoined.IsNullOrEmpty())
            {
                response = "The PlayerJoined announcement is not set in the config.";
                return true;
            }

            if (arguments.Count != 1)
            {
                response = "Syntax: ca pj <v/p>";
                return false;
            }

            switch (arguments.At(0))
            {
                case "p":
                case "play":
                    response = "Playing PlayerJoined announcement.";
                    Timing.RunCoroutine(Methods.PlayAnnouncement(Instance.Config.PlayerJoined));
                    return true;
                case "v":
                case "view":
                    response = Instance.Config.PlayerJoined.Message;
                    return true;
                default:
                    response = "Syntax: ca pj (v/p)";
                    return false;
            }
        }

        public string Command => "playerjoined";
        public string[] Aliases => new[] {"pj"};
        public string Description => "Views or plays the PlayerJoined announcement.";
    }
}