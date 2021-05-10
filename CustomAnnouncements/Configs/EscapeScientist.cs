// -----------------------------------------------------------------------
// <copyright file="EscapeScientist.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomAnnouncements.Configs
{
    /// <inheritdoc cref="IAnnouncement"/>
    public class EscapeScientist : IAnnouncement
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

        /// <summary>
        /// Gets or sets a value indicating whether the announcement should only be played on the first escape.
        /// </summary>
        public bool OnlyPlayFirst { get; set; }
    }
}