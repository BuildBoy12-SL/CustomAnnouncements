using Exiled.API.Features;

namespace CustomAnnouncements.Commands.SubCommands
{
    using CommandSystem;
    using Exiled.Permissions.Extensions;
    using System;

    public class FakeMtf : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("ca.fmtf"))
            {
                response = "Insufficient permission. Required: ca.es";
                return false;
            }

            response = "Syntax: ca mtfa (mtf letter) (mtf number) (scps left)";
            if (arguments.Count != 3)
                return false;

            if (!char.TryParse(arguments.At(0), out char unitDesignation) ||
                !int.TryParse(arguments.At(1), out int unitNumber) ||
                !int.TryParse(arguments.At(2), out int scpsRemaining))
                return false;

            Cassie.Message($"MtfUnit epsilon 11 designated nato_{unitDesignation} {unitNumber} " +
                           $"HasEntered AllRemaining {(scpsRemaining == 0 ? "NoScpsLeft" : $"AwaitingRecontainment {scpsRemaining} {(scpsRemaining == 1 ? "scpsubject" : "scpsubjects")}")}");
            response = "Playing announcement.";
            return true;
        }

        public string Command => "fakemtf";
        public string[] Aliases => new[] {"mtfa", "fmtf"};
        public string Description => "Fakes a Mtf spawn announcement.";
    }
}