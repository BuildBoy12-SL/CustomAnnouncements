namespace CustomAnnouncements.Commands
{
    using CommandSystem;
    using SubCommands;
    using System;
    using System.Collections.Generic;

    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class CustomAnnouncementsCmd : ParentCommand
    {
        public CustomAnnouncementsCmd() => LoadGeneratedCommands();

        public sealed override void LoadGeneratedCommands()
        {
            RegisterCommand(new ChaosSpawn());
            RegisterCommand(new EscapeClassD());
            RegisterCommand(new EscapeScientist());
            RegisterCommand(new FakeMtf());
            RegisterCommand(new FakeScp());
            RegisterCommand(new MtfSpawn());
            RegisterCommand(new PlayerJoined());
            RegisterCommand(new RoundEnd());
            RegisterCommand(new RoundStart());
        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender,
            out string response)
        {
            List<string> commands = new List<string>();
            foreach (var command in AllCommands)
                commands.Add(command.Command + (command.Aliases.Length > 0
                    ? $" | Aliases: {string.Join(", ", command.Aliases)}"
                    : string.Empty));

            response = $"Please enter a valid subcommand! Available:\n{string.Join("\n", commands)}";
            return false;
        }

        public override string Command => "customannouncements";
        public override string[] Aliases => new[] {"ca"};
        public override string Description => "Parent command of CustomAnnouncements.";
    }
}