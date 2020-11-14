namespace CustomAnnouncements.Commands.SubCommands
{
    using CommandSystem;
    using Exiled.Permissions.Extensions;
    using System;
    using static CustomAnnouncements;
    
    public class RoundEnd : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender as CommandSender).CheckPermission("ca.re"))
            {
                response = "Insufficient permission. Required: ca.re";
                return false;
            }

            if (Instance.Config.RoundEnd.IsNullOrEmpty())
            {
                response = "The RoundEnd announcement is not set in the config.";
                return true;
            }
            
            if (arguments.Count != 1)
            {
                response = "Syntax: ca re <v/p>";
                return false;
            }

            switch (arguments.At(0))
            {
                case "p":
                case "play":
                    response = "Playing RoundEnd announcement.";
                    Instance.Methods.PlayAnnouncement(Instance.Config.RoundEnd);
                    return true;
                case "v":
                case "view":
                    response = Instance.Config.RoundEnd.Message;
                    return true;
                default:
                    response = "Syntax: ca re (v/p)";
                    return false;
            }
        }

        public string Command => "roundend";
        public string[] Aliases => new[] {"re"};
        public string Description => "Views or plays the RoundEnd announcement.";
    }
}