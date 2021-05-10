// -----------------------------------------------------------------------
// <copyright file="RoundEnd.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomAnnouncements.Configs
{
    using System.ComponentModel;

    /// <inheritdoc cref="IAnnouncement"/>
    public class RoundEnd : IAnnouncement
    {
        /// <inheritdoc />
        [Description("Broadcast to be played if the broadcast for the win condition is not set.")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the broadcast played in a MTF victory.
        /// </summary>
        [Description("Broadcast played in a MTF victory.")]
        public string MtfMessage { get; set; }

        /// <summary>
        /// Gets or sets the broadcast played in a CHI victory.
        /// </summary>
        [Description("Broadcast played in a CHI victory.")]
        public string ChiMessage { get; set; }

        /// <summary>
        /// Gets or sets the broadcast played in a SCP victory.
        /// </summary>
        [Description("Broadcast played in a SCP victory.")]
        public string ScpMessage { get; set; }

        /// <summary>
        /// Gets or sets the broadcast played in a draw.
        /// </summary>
        [Description("Broadcast played in a Draw.")]
        public string DrawMessage { get; set; }

        /// <inheritdoc />
        public bool IsNoisy { get; set; }

        /// <inheritdoc />
        public bool IsGlitchy { get; set; }

        /// <inheritdoc />
        public float GlitchChance { get; set; }

        /// <inheritdoc />
        public float JamChance { get; set; }

        /// <inheritdoc />
        public float Delay { get; set; }
    }
}