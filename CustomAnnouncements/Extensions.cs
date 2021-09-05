// -----------------------------------------------------------------------
// <copyright file="Extensions.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomAnnouncements
{
    using System;
    using System.Text;
    using NorthwoodLib.Pools;

    /// <summary>
    /// Contains an assortment of various extension methods.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Returns a value which indicates whether the announcement's message is null or empty.
        /// </summary>
        /// <param name="announcement">The announcement to check.</param>
        /// <returns>Whether the <see cref="IAnnouncement.Message"/> was null.</returns>
        public static bool IsNullOrEmpty(this IAnnouncement announcement) => string.IsNullOrEmpty(announcement.Message);

        /// <summary>
        /// Optimized method that replaces a <see cref="string"/> based on an <see cref="Tuple{T,T}"/>.
        /// </summary>
        /// <param name="source">The string to use as source.</param>
        /// <param name="token">The starting token.</param>
        /// <param name="valuePairs">The value pairs (tuples) to use as "key -> value".</param>
        /// <returns>The string after replacement.</returns>
        public static string ReplaceAfterToken(this string source, char token, Tuple<string, object>[] valuePairs)
        {
            if (valuePairs == null)
            {
                throw new ArgumentNullException(nameof(valuePairs));
            }

            StringBuilder builder = StringBuilderPool.Shared.Rent();

            int sourceLength = source.Length;

            for (int i = 0; i < sourceLength; i++)
            {
                // Append characters until you find the token
                char auxChar = token == char.MaxValue ? (char)(char.MaxValue - 1) : char.MaxValue;
                for (; i < sourceLength && (auxChar = source[i]) != token; i++)
                    builder.Append(auxChar);

                // Ensures no weird stuff regarding token being null
                if (auxChar == token)
                {
                    int movePos = 0;

                    // Try to find a tuple
                    int length = valuePairs.Length;
                    for (int ind = 0; ind < length; ind++)
                    {
                        Tuple<string, object> kvp = valuePairs[ind];
                        int j, k;
                        for (j = 0, k = i + 1; j < kvp.Item1.Length && k < source.Length && source[k] == kvp.Item1[j]; j++, k++)
                        {
                        }

                        // General condition for "key found"
                        if (j == kvp.Item1.Length)
                        {
                            movePos = j;
                            builder.Append(kvp.Item2); // append what we're replacing the key with
                            break;
                        }
                    }

                    // Don't skip the token if you didn't find the key, append it
                    if (movePos == 0)
                        builder.Append(token);
                    else
                        i += movePos;
                }
            }

            return StringBuilderPool.Shared.ToStringReturn(builder);
        }
    }
}