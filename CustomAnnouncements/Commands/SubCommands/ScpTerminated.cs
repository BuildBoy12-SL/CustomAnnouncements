namespace CustomAnnouncements.Commands.SubCommands
{
    using CommandSystem;
    using Exiled.Permissions.Extensions;
    using System;
    using static CustomAnnouncements;

    /*public class ScpTerminated : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender as CommandSender).CheckPermission("ca.st"))
            {
                response = "Insufficient permission. Required: ca.st";
                return false;
            }

            if (Instance.Config.ScpTerminated.IsNullOrEmpty())
            {
                response = "The ScpTerminated announcement is not set in the config.";
                return true;
            }
            
            if (arguments.Count != 1)
            {
                response = "Syntax: ca st <v/p>";
                return false;
            }

            switch (arguments.At(0))
            {
                case "p":
                case "play":
                    response = "Playing ScpTerminated announcement.";
                    Instance.Methods.PlayAnnouncement(Instance.Config.ScpTerminated);
                    return true;
                case "v":
                case "view":
                    response = Instance.Config.ScpTerminated.Message;
                    return true;
                default:
                    response = "Syntax: ca st (v/p)";
                    return false;
            }
        }

        public string Command => "scpterminated";
        public string[] Aliases => new[] {"st"};
        public string Description => "Views or plays the ScpTerminated announcement.";
    }*/
}