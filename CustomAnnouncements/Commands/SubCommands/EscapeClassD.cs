namespace CustomAnnouncements.Commands.SubCommands
{
    using CommandSystem;
    using Exiled.Permissions.Extensions;
    using System;

    public class EscapeClassD : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("ca.ed"))
            {
                response = "Insufficient permission. Required: ca.ed";
                return false;
            }

            if (CustomAnnouncements.Singleton.Config.EscapeClassD.IsNullOrEmpty())
            {
                response = "The EscapeClassD announcement is not set in the config.";
                return true;
            }

            if (arguments.Count == 1)
                return Methods.ViewOrPlay(CustomAnnouncements.Singleton.Config.EscapeClassD, "ed", arguments.At(0),
                    out response);

            response = "Syntax: ca ed <v/p>";
            return false;
        }

        public string Command => "escapeclassd";
        public string[] Aliases => new[] {"ed"};
        public string Description => "Views or plays the EscapeClassD announcement.";
    }
}