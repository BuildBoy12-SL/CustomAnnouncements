namespace CustomAnnouncements.Commands.SubCommands
{
    using CommandSystem;
    using Exiled.Permissions.Extensions;
    using MEC;
    using System;
    using static CustomAnnouncements;

    public class EscapeClassD : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender as CommandSender).CheckPermission("ca.ed"))
            {
                response = "Insufficient permission. Required: ca.ed";
                return false;
            }

            if (Instance.Config.EscapeClassD.IsNullOrEmpty())
            {
                response = "The EscapeClassD announcement is not set in the config.";
                return true;
            }

            if (arguments.Count != 1)
            {
                response = "Syntax: ca ed <v/p>";
                return false;
            }

            switch (arguments.At(0))
            {
                case "p":
                case "play":
                    response = "Playing EscapeClassD announcement.";
                    Timing.RunCoroutine(Methods.PlayAnnouncement(Instance.Config.EscapeClassD));
                    return true;
                case "v":
                case "view":
                    response = Instance.Config.EscapeClassD.Message;
                    return true;
                default:
                    response = "Syntax: ca es (v/p)";
                    return false;
            }
        }

        public string Command => "escapeclassd";
        public string[] Aliases => new[] {"ed"};
        public string Description => "Views or plays the EscapeClassD announcement.";
    }
}