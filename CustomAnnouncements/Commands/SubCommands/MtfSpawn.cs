namespace CustomAnnouncements.Commands.SubCommands
{
    using CommandSystem;
    using Exiled.Permissions.Extensions;
    using System;

    public class MtfSpawn : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("ca.ms"))
            {
                response = "Insufficient permission. Required: ca.ms";
                return false;
            }

            if (CustomAnnouncements.Singleton.Config.MtfSpawn.IsNullOrEmpty())
            {
                response = "The MtfSpawn announcement is not set in the config.";
                return true;
            }

            if (arguments.Count == 1)
                return Methods.ViewOrPlay(CustomAnnouncements.Singleton.Config.MtfSpawn, "ms", arguments.At(0),
                    out response);

            response = "Syntax: ca ms <v/p>";
            return false;
        }

        public string Command => "mtfspawn";
        public string[] Aliases => new[] {"ms"};
        public string Description => "Views or plays the MtfSpawn announcement.";
    }
}