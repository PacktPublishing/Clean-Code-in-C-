using System;

/// <summary>
/// The CH3.Core.Security namespace contains fundamental types used for the purpose
/// of implementing application security.
/// </summary>
namespace CH3.Core.Security
{
    /// <summary>
    /// Provides the available cryptographic options.
    /// </summary>
    [Flags]
    public enum SecurityAlgorithm
    {
        /// <summary>
        /// Use AES encryption
        /// </summary>
        Aes,
        /// <summary>
        /// Use AESCNG encryption.
        /// </summary>
        AesCng,
        /// <summary>
        /// Use MD5 encryption.
        /// </summary>
        MD5,
        /// <summary>
        /// Use SHA256 encryption
        /// </summary>
        SHA256
    }
}
