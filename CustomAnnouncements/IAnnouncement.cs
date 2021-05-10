// -----------------------------------------------------------------------
// <copyright file="IAnnouncement.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomAnnouncements
{
    /// <summary>
    /// Defines the contract for announcement configs.
    /// </summary>
    public interface IAnnouncement
    {
        /// <summary>
        /// Gets or sets the announcement to be played.
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the announcement will have background noise.
        /// </summary>
        bool IsNoisy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the announcement can contain glitches and jams.
        /// </summary>
        bool IsGlitchy { get; set; }

        /// <summary>
        /// Gets or sets the percentage chance that a glitch can occur.
        /// </summary>
        float GlitchChance { get; set; }

        /// <summary>
        /// Gets or sets the percentage chance that a jam can occur.
        /// </summary>
        float JamChance { get; set; }

        /// <summary>
        /// Gets or sets the amount of seconds of delay from when the event fires to when the announcement will play.
        /// </summary>
        float Delay { get; set; }
    }
}