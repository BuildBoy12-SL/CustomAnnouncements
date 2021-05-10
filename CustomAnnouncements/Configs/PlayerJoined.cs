// -----------------------------------------------------------------------
// <copyright file="PlayerJoined.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomAnnouncements.Configs
{
    using System.Collections.Generic;
    using System.ComponentModel;

    /// <inheritdoc cref="IAnnouncement"/>
    public class PlayerJoined : IAnnouncement
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
        /// Gets or sets the collection of user ids which will trigger this announcement.
        /// </summary>
        [Description("The collection of user ids which will trigger this announcement.")]
        public List<string> UserIds { get; set; } = new List<string>
        {
            "mysteamid@steam",
            "mydiscordid@discord",
        };
    }
}