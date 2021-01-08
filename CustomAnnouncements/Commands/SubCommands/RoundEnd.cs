namespace CustomAnnouncements.Commands.SubCommands
{
    using CommandSystem;
    using Exiled.Permissions.Extensions;
    using System;

    public class RoundEnd : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("ca.re"))
            {
                response = "Insufficient permission. Required: ca.re";
                return false;
            }

            if (CustomAnnouncements.Singleton.Config.RoundEnd.IsNullOrEmpty())
            {
                response = "The RoundEnd announcement is not set in the config.";
                return true;
            }

            if (arguments.Count == 1)
                return Methods.ViewOrPlay(CustomAnnouncements.Singleton.Config.RoundEnd, "re", arguments.At(0),
                    out response);

            response = "Syntax: ca re <v/p>";
            return false;
        }

        public string Command => "roundend";
        public string[] Aliases => new[] {"re"};
        public string Description => "Views or plays the RoundEnd announcement.";
    }
}