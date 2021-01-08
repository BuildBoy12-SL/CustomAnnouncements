namespace CustomAnnouncements.Commands.SubCommands
{
    using CommandSystem;
    using Exiled.Permissions.Extensions;
    using System;

    public class EscapeScientist : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("ca.es"))
            {
                response = "Insufficient permission. Required: ca.es";
                return false;
            }

            if (CustomAnnouncements.Singleton.Config.EscapeScientist.IsNullOrEmpty())
            {
                response = "The EscapeScientist announcement is not set in the config.";
                return true;
            }

            if (arguments.Count == 1)
                return Methods.ViewOrPlay(CustomAnnouncements.Singleton.Config.RoundStart, "es", arguments.At(0),
                    out response);

            response = "Syntax: ca es <v/p>";
            return false;
        }

        public string Command => "escapescientist";
        public string[] Aliases => new[] {"es"};
        public string Description => "Views or plays the EscapeScientist announcement.";
    }
}