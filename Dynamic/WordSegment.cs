// Copyright (c) 2020 Jered Myers
// 
// This software is released under the MIT License.
// https://opensource.org/licenses/MIT

using System.Collections.Generic;
using System.Linq;

namespace Dynamic
{
    // Dynamic programming examples using word segmentation.
    public class WordSegment
    {
        /// <summary>
        /// A dynamic programming example that dertemines if all of the letters can be matched to words in the word list.
        /// All of the letters must be used, but words appearing multiple times are allowed. Words cannot overlap.
        /// Each time a match is found, it is stored in lastValidMatch. This enables the Contains check to ensure
        /// it bumps up against a match.
        /// </summary>
        /// <param name="letter">The string of letters (lowercase)</param>
        /// <param name="wordList">A list of words to match against (lowercase)</param>
        /// <returns>true when all letters match words</returns>
        public bool HasMatches(string letters, List<string> wordList) 
        {
            var lastValidMatch = new bool[letters.Length + 1];
            lastValidMatch[0] = true;
            for(int i = 1; i < letters.Length + 1; ++i)
            {
                for(int j = 0; j < i; ++j)
                {
                    if(lastValidMatch[j] && wordList.Contains(letters.Substring(j,i-j)))
                    {
                        lastValidMatch[i] = true;
                        break;
                    }
                }
            }
            return lastValidMatch[letters.Length];
        }

        // This is a similar question to HasMatches except that you have to return the words.
        public List<string> GetMatches(string letters, List<string> wordList)
        {
            var lastValidMatch = new string[letters.Length + 1];
            lastValidMatch[0] = string.Empty;
            for(int i = 1; i < letters.Length + 1; ++i)
            {
                for(int j = 0; j < i; ++j)
                {
                    var word = letters.Substring(j,i-j);
                    if(!(lastValidMatch[j] is null) && wordList.Contains(word))
                    {
                        lastValidMatch[i] = word;
                        break;
                    }
                }
            }
            if (lastValidMatch[letters.Length] is null)
            {
                return new List<string>();
            }
            else
            {
                return lastValidMatch.Where(w => !string.IsNullOrEmpty(w)).ToList();
            }
        }
    }
}