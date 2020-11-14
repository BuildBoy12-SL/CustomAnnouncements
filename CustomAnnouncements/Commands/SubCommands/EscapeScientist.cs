namespace CustomAnnouncements.Commands.SubCommands
{
    using CommandSystem;
    using Exiled.Permissions.Extensions;
    using System;
    using static CustomAnnouncements;
    
    public class EscapeScientist : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender as CommandSender).CheckPermission("ca.es"))
            {
                response = "Insufficient permission. Required: ca.es";
                return false;
            }

            if (Instance.Config.EscapeScientist.IsNullOrEmpty())
            {
                response = "The EscapeScientist announcement is not set in the config.";
                return true;
            }
            
            if (arguments.Count != 1)
            {
                response = "Syntax: ca es <v/p>";
                return false;
            }

            switch (arguments.At(0))
            {
                case "p":
                case "play":
                    response = "Playing EscapeScientist announcement.";
                    Instance.Methods.PlayAnnouncement(Instance.Config.EscapeScientist);
                    return true;
                case "v":
                case "view":
                    response = Instance.Config.EscapeScientist.Message;
                    return true;
                default:
                    response = "Syntax: ca es (v/p)";
                    return false;
            }
        }

        public string Command => "escapescientist";
        public string[] Aliases => new[] {"es"};
        public string Description => "Views or plays the EscapeScientist announcement.";
    }
}