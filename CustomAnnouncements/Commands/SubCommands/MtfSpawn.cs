namespace CustomAnnouncements.Commands.SubCommands
{
    using CommandSystem;
    using Exiled.Permissions.Extensions;
    using System;
    using static CustomAnnouncements;
    
    public class MtfSpawn : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender as CommandSender).CheckPermission("ca.ms"))
            {
                response = "Insufficient permission. Required: ca.ms";
                return false;
            }

            if (Instance.Config.MtfSpawn.IsNullOrEmpty())
            {
                response = "The MtfSpawn announcement is not set in the config.";
                return true;
            }
            
            if (arguments.Count != 1)
            {
                response = "Syntax: ca ms <v/p>";
                return false;
            }

            switch (arguments.At(0))
            {
                case "p":
                case "play":
                    response = "Playing MtfSpawn announcement.";
                    Instance.Methods.PlayAnnouncement(Instance.Config.MtfSpawn);
                    return true;
                case "v":
                case "view":
                    response = Instance.Config.MtfSpawn.Message;
                    return true;
                default:
                    response = "Syntax: ca ms (v/p)";
                    return false;
            }
        }

        public string Command => "mtfspawn";
        public string[] Aliases => new[] {"ms"};
        public string Description => "Views or plays the MtfSpawn announcement.";
    }
}