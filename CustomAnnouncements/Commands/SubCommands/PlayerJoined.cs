namespace CustomAnnouncements.Commands.SubCommands
{
    using CommandSystem;
    using Exiled.Permissions.Extensions;
    using System;

    public class PlayerJoined : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("ca.pj"))
            {
                response = "Insufficient permission. Required: ca.pj";
                return false;
            }

            if (CustomAnnouncements.Singleton.Config.PlayerJoined.IsNullOrEmpty())
            {
                response = "The PlayerJoined announcement is not set in the config.";
                return true;
            }

            if (arguments.Count == 1)
                return Methods.ViewOrPlay(CustomAnnouncements.Singleton.Config.PlayerJoined, "pj", arguments.At(0),
                    out response);

            response = "Syntax: ca pj <v/p>";
            return false;
        }

        public string Command => "playerjoined";
        public string[] Aliases => new[] {"pj"};
        public string Description => "Views or plays the PlayerJoined announcement.";
    }
}