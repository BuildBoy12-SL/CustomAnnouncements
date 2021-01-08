namespace CustomAnnouncements.Commands.SubCommands
{
    using CommandSystem;
    using Exiled.Permissions.Extensions;
    using System;

    public class RoundStart : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("ca.rs"))
            {
                response = "Insufficient permission. Required: ca.rs";
                return false;
            }

            if (CustomAnnouncements.Singleton.Config.RoundStart.IsNullOrEmpty())
            {
                response = "The RoundStart announcement is not set in the config.";
                return true;
            }

            if (arguments.Count == 1)
                return Methods.ViewOrPlay(CustomAnnouncements.Singleton.Config.RoundStart, "rs", arguments.At(0),
                    out response);

            response = "Syntax: ca rs <v/p>";
            return false;
        }

        public string Command => "roundstart";
        public string[] Aliases => new[] {"rs"};
        public string Description => "Views or plays the RoundStart announcement.";
    }
}