// -----------------------------------------------------------------------
// <copyright file="ChaosSpawn.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomAnnouncements.Configs
{
    using System.ComponentModel;

    /// <inheritdoc cref="IAnnouncement"/>
    public class ChaosSpawn : IAnnouncement
    {
        /// <inheritdoc />
        [Description("The message CASSIE will say. Leave empty to disable an announcement.")]
        public string Message { get; set; } = "Unauthorized Personnel Detected . . on Surface . . Chaos Insurgency .";

        /// <inheritdoc />
        [Description("If there should be background static and the starting/stopping noise.")]
        public bool IsNoisy { get; set; } = false;

        /// <inheritdoc />
        [Description("If there should be glitches and jams randomly in the broadcast.")]
        public bool IsGlitchy { get; set; } = true;

        /// <inheritdoc />
        [Description("Chance that a glitch can occur.")]
        public float GlitchChance { get; set; } = 1;

        /// <inheritdoc />
        [Description("Chance that a jam can occur.")]
        public float JamChance { get; set; } = 1;

        /// <inheritdoc />
        [Description("Seconds before the announcement will play after the event fires.")]
        public float Delay { get; set; }
    }
}