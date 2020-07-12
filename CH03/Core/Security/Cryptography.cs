/**********************************************************************************
 * Copyright 2019 PacktPub
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of 
 * this software and associated documentation files (the "Software"), to deal in 
 * the Software without restriction, including without limitation the rights to use, 
 * copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the 
 * Software, and to permit persons to whom the Software is furnished to do so, 
 * subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all 
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE 
 * SOFTWARE. 
 *********************************************************************************/
 
using System;

/// <summary>
/// The CH3.Core.Security namespace contains fundamental types used for the purpose
/// of implementing application security.
/// </summary>
namespace CH3.Core.Security
{
    /// <summary>
    /// Encrypts and decrypts provided strings based on the slected algorithm.
    /// </summary>
    public class Cryptography
    {
        /// <summary>
        /// Decrypts a string using the selected algorithm.
        /// </summary>
        /// <param name="text">The string to be decrypted.</param>
        /// <param name="algorithm">
        /// The cryptographic algorithm used to decrypt the string.
        /// </param>
        /// <returns>Decrypted string</returns>
        public string DecryptString(string text, SecurityAlgorithm algorithm)
        {
            // ...implementation... 
            throw new NotImplementedException();
        }

        /// <summary>
        /// Encrypts a string using the selected algorithm.
        /// </summary>
        /// <param name="text">The string to encrypt.</param>
        /// <param name="algorithm">
        /// The cryptographic algorithm used to encrypt the string.
        /// </param>
        /// <returns>Encrypted string</returns>
        public string EncryptString(string text, SecurityAlgorithm algorithm)
        {
            // ...implementation... 
            throw new NotImplementedException();
        }
    }
}
