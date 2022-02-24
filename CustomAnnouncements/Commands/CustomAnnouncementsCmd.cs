// -----------------------------------------------------------------------
// <copyright file="CustomAnnouncementsCmd.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomAnnouncements.Commands
{
    using System;
    using System.Text;
    using CommandSystem;
    using CustomAnnouncements.Commands.SubCommands;
    using NorthwoodLib.Pools;

    /// <summary>
    /// A parent command to all commands which play or interact with announcements.
    /// </summary>
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class CustomAnnouncementsCmd : ParentCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomAnnouncementsCmd"/> class.
        /// </summary>
        public CustomAnnouncementsCmd() => LoadGeneratedCommands();

        /// <inheritdoc />
        public override string Command => "customannouncements";

        /// <inheritdoc />
        public override string[] Aliases { get; } = { "ca" };

        /// <inheritdoc />
        public override string Description => "Parent command of CustomAnnouncements.";

        /// <inheritdoc />
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

        /// <inheritdoc />
        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            StringBuilder stringBuilder = StringBuilderPool.Shared.Rent();
            stringBuilder.AppendLine("Please specify a valid subcommand! Available:");
            foreach (ICommand command in AllCommands)
            {
                stringBuilder.AppendLine(command.Aliases.Length > 0
                    ? $"{command.Command} | Aliases: {string.Join(", ", command.Aliases)}"
                    : command.Command);
            }

            response = StringBuilderPool.Shared.ToStringReturn(stringBuilder).TrimEnd();
            return false;
        }
    }
}