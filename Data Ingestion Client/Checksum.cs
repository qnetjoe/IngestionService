// <copyright file="Checksum.cs" company="Joe Daily">
// Copyright (c) Joe Daily. All rights reserved.
// </copyright>

namespace Ingestion.Client.Checksum
{
    using System;
    using System.Security.Cryptography;

    /// <summary>
    /// Types of Hashing Algorithms.
    /// </summary>
    public enum HashingAlgoTypes
    {
        /// <summary> MD5 Algorithm. </summary>
        MD5,

        /// <summary> SHA1 Algorithm </summary>
        SHA1,

        /// <summary> SHA256 Algorithm </summary>
        SHA256,

        /// <summary> SHA384 Algorithm </summary>
        SHA384,

        /// <summary> SHA512 Algorithm </summary>
        SHA512,
    }

    /// <summary>
    /// Help class for checksum handling.
    /// Based off of https://makolyte.com/csharp-get-a-files-checksum-using-any-hashing-algorithm-md5-sha256/.
    /// </summary>
    public static class Checksum
    {
        /// <summary>
        /// Get a file checksum based on the specified hashing algorithms.
        /// </summary>
        /// <param name="hashingAlgoType">The desired hashing algorith.</param>
        /// <param name="filename">The desired file to generate the hash for.</param>
        /// <returns>A string with the hash.</returns>
        public static string GetChecksum(HashingAlgoTypes hashingAlgoType, string filename)
        {
            using var hasher = HashAlgorithm.Create(hashingAlgoType.ToString());
            using var stream = System.IO.File.OpenRead(filename);
            if (hasher != null)
            {
                byte[] hash = hasher.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", string.Empty);
            }
            else
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Get a file checksum based on the specified hashing algorithms.
        /// </summary>
        /// <param name="hashingAlgoType">The desired hashing algorithm.</param>
        /// <param name="filename">The desired file to generate the hash for.</param>
        /// <returns>A byte array of hash.</returns>
        public static byte[] GetChecksumBytes(HashingAlgoTypes hashingAlgoType, string filename)
        {
            using var hasher = HashAlgorithm.Create(hashingAlgoType.ToString());
            using var stream = System.IO.File.OpenRead(filename);
            if (hasher != null)
            {
                return hasher.ComputeHash(stream);
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
