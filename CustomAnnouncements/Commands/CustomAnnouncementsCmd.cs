namespace CustomAnnouncements.Commands
{
    using CommandSystem;
    using SubCommands;
    using System;

    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class CustomAnnouncementsCmd : ParentCommand
    {
        public CustomAnnouncementsCmd() => LoadGeneratedCommands();
        
        public sealed override void LoadGeneratedCommands()
        {
            RegisterCommand(new ChaosSpawn());
            RegisterCommand(new EscapeClassD());
            RegisterCommand(new EscapeScientist());
            RegisterCommand(new MtfSpawn());
            RegisterCommand(new PlayerJoined());
            RegisterCommand(new RoundEnd());
            RegisterCommand(new RoundStart());
            //RegisterCommand(new ScpTerminated());
        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "Please enter a valid subcommand! Available:\nchs, ed, es, ms, pj, re, rs, st";
            return false;
        }

        public override string Command => "customannouncements";
        public override string[] Aliases => new[] {"ca"};
        public override string Description => "Parent command of CustomAnnouncements.";
    }
}