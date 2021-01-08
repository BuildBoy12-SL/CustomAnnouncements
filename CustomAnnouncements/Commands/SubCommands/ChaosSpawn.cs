namespace CustomAnnouncements.Commands.SubCommands
{
    using CommandSystem;
    using Exiled.Permissions.Extensions;
    using System;

    public class ChaosSpawn : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("ca.chs"))
            {
                response = "Insufficient permission. Required: ca.chs";
                return false;
            }

            if (CustomAnnouncements.Singleton.Config.ChaosSpawn.IsNullOrEmpty())
            {
                response = "The ChaosSpawn announcement is not set in the config.";
                return true;
            }

            if (arguments.Count == 1)
                return Methods.ViewOrPlay(CustomAnnouncements.Singleton.Config.ChaosSpawn, "chs", arguments.At(0),
                    out response);

            response = "Syntax: ca chs <v/p>";
            return false;
        }

        public string Command => "chaosspawn";
        public string[] Aliases => new[] {"chs"};
        public string Description => "Views or plays the ChaosSpawn announcement.";
    }
}