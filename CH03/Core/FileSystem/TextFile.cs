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
/// Contains all the types used for manipulating the file system.
/// </summary>
namespace CH3.Core.FileSystem
{
    /// <summary>
    /// Contains the methods for reading and writing strings to a text file.
    /// </summary>
    public class TextFile
    {
        /// <summary>
        /// Reads text from the text file.
        /// </summary>
        /// <param name="filename">The name of the text file to be opened and read.</param>
        /// <returns>The text contained within the textfile.</returns>
        public string ReadTextFromFile(string filename)
        {
            // ...implementation... 
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves text to the tet file.
        /// </summary>
        /// <param name="text">The text to be written to the file.</param>
        /// <param name="filename">The name of the file that the text is to be written too.</param>
        public void SaveTextToFile(string text, string filename)
        {
            // ...implementation... 
            throw new NotImplementedException();
        }
    }
}
