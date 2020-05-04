// Copyright (c) 2020 Jered Myers
// 
// This software is released under the MIT License.
// https://opensource.org/licenses/MIT

using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Dynamic.Tests
{
    public class WordSegmentTests
    {
        [Fact]
        public void It_has_matches_when_letters_are_a_two_word_string()
        {
            var wordList = new List<string>
            {
                "car",
                "parts"
            };
            var letters = "carparts";
            var wordSementor = new WordSegment();

            var matches = wordSementor.HasMatches(letters, wordList);

            matches.Should().BeTrue();
        }

        [Fact]
        public void It_has_matches_when_words_are_repeated()
        {
            var wordList = new List<string>
            {
                "car",
                "parts"
            };
            var letters = "carpartscar";
            var wordSementor = new WordSegment();

            var matches = wordSementor.HasMatches(letters, wordList);

            matches.Should().BeTrue();
        }

        [Fact]
        public void It_does_not_have_matches_when_all_leters_are_not_used()
        {
            var wordList = new List<string>
            {
                "car",
                "parts"
            };
            var letters = "caraparts";
            var wordSementor = new WordSegment();

            var matches = wordSementor.HasMatches(letters, wordList);

            matches.Should().BeFalse();
        }

        [Fact]
        public void It_gets_matches_when_letters_are_a_two_word_string()
        {
            var wordList = new List<string>
            {
                "car",
                "parts"
            };
            var letters = "carparts";
            var wordSementor = new WordSegment();

            var matches = wordSementor.GetMatches(letters, wordList);

            matches.Should().ContainInOrder(wordList);
        }

        [Fact]
        public void It_gets_matches_when_words_are_repeated()
        {
            var wordList = new List<string>
            {
                "car",
                "parts"
            };
            var letters = "carpartscar";
            var wordSementor = new WordSegment();

            var matches = wordSementor.GetMatches(letters, wordList);

            matches.Should().ContainInOrder(wordList);
        }

        [Fact]
        public void It_gets_matches_when_words_are_repeated_and_out_of_order()
        {
            var wordList = new List<string>
            {
                "car",
                "parts"
            };
            var expected = new List<string>
            {
                "parts",
                "car"
            };
            var letters = "partscarparts";
            var wordSementor = new WordSegment();

            var matches = wordSementor.GetMatches(letters, wordList);

            matches.Should().ContainInOrder(expected);
        }

        [Fact]
        public void Its_list_is_empty_when_all_letters_do_not_match()
        {
            var wordList = new List<string>
            {
                "car",
                "parts"
            };
            var letters = "caraparts";
            var wordSementor = new WordSegment();

            var matches = wordSementor.GetMatches(letters, wordList);

            matches.Should().BeEmpty();
        }
    }
}
