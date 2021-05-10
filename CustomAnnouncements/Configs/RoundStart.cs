// -----------------------------------------------------------------------
// <copyright file="RoundStart.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomAnnouncements.Configs
{
    /// <inheritdoc cref="IAnnouncement"/>
    public class RoundStart : IAnnouncement
    {
        /// <inheritdoc />
        public string Message { get; set; }

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