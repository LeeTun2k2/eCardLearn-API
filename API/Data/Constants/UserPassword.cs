﻿namespace API.Data.Constants
{
    /// <summary>
    /// User password constants
    /// </summary>
    public class UserPassword
    {
        /// <summary>
        /// Length constants
        /// </summary>
        public static class Length
        {
            /// <summary>
            /// Minimum length
            /// </summary>
            public const int Min = 8;

            /// <summary>
            /// Maximum length
            /// </summary>
            public const int Max = int.MaxValue;
        }

        /// <summary>
        /// Require digit
        /// </summary>
        public const bool RequireDigit = true;

        /// <summary>
        /// Require lowercase
        /// </summary>
        public const bool RequireLowercase = true;

        /// <summary>
        /// Require non alphanumeric
        /// </summary>
        public const bool RequireNonAlphanumeric = true;

        /// <summary>
        /// Require uppercase
        /// </summary>
        public const bool RequireUppercase = true;

        /// <summary>
        /// Required unique chars
        /// </summary>
        public const int RequiredUniqueChars = 0;
    }
}
