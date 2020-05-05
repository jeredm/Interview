// Copyright (c) 2020 Jered Myers
// 
// This software is released under the MIT License.
// https://opensource.org/licenses/MIT

using System;
using System.Collections.Generic;

namespace StringManipulation
{
    public class SlidingWindows
    {
        // Gets the largest amount of consecutive letters that do not repeat.
        public int SizeOfNoRepeatLetters(string s) 
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return 0;
            }
            
            var anchor = 0;
            var result = 0;
            var used = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                var letter = s[i];
                if (used.ContainsKey(letter) && used[letter] >= anchor)
                {
                    anchor = used[letter] + 1;
                }
                else
                {
                    result = Math.Max(result, i - anchor + 1);
                }
                used[letter] = i;
            }

            return result;
        }
    }
}