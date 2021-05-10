// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomAnnouncements
{
    using CustomAnnouncements.Configs.SubConfigs;
    using Exiled.API.Interfaces;

    /// <inheritdoc cref="IConfig"/>
    public class Config : IConfig
    {
        /// <inheritdoc />
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets the configs used when a chaos insurgency announcement is played.
        /// </summary>
        public ChaosSpawn ChaosSpawn { get; set; } = new ChaosSpawn();

        /// <summary>
        /// Gets or sets the configs used when a classd escape announcement is played.
        /// </summary>
        public EscapeClassD EscapeClassD { get; set; } = new EscapeClassD();

        /// <summary>
        /// Gets or sets the configs used when a scientist escape announcement is played.
        /// </summary>
        public EscapeScientist EscapeScientist { get; set; } = new EscapeScientist();

        /// <summary>
        /// Gets or sets the configs used when a MTF spawn announcement is played.
        /// </summary>
        public MtfSpawn MtfSpawn { get; set; } = new MtfSpawn();

        /// <summary>
        /// Gets or sets the configs used when a player join announcement is played.
        /// </summary>
        public PlayerJoined PlayerJoined { get; set; } = new PlayerJoined();

        /// <summary>
        /// Gets or sets the configs used when a round end announcement is played.
        /// </summary>
        public RoundEnd RoundEnd { get; set; } = new RoundEnd();

        /// <summary>
        /// Gets or sets the configs used when a round start announcement is played.
        /// </summary>
        public RoundStart RoundStart { get; set; } = new RoundStart();
    }
}