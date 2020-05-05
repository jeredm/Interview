// Copyright (c) 2020 Jered Myers
// 
// This software is released under the MIT License.
// https://opensource.org/licenses/MIT

using FluentAssertions;
using Xunit;

namespace StringManipulation.Tests
{
    public class SlidingWindowTests
    {
        [Fact]
        public void It_finds_length_of_null()
        {
            var slidingWindows = new SlidingWindows();
            var result = slidingWindows.SizeOfNoRepeatLetters(null);
            result.Should().Be(0);
        }

        [Fact]
        public void It_finds_length_of_empty()
        {
            var slidingWindows = new SlidingWindows();
            var result = slidingWindows.SizeOfNoRepeatLetters("");
            result.Should().Be(0);
        }

       [Fact]
        public void It_finds_length_of_qxxzyurg()
        {
            var slidingWindows = new SlidingWindows();
            var result = slidingWindows.SizeOfNoRepeatLetters("qxxzyuq");
            result.Should().Be(5);
        } 

        [Fact]
        public void It_finds_length_of_abbcpb()
        {
            var slidingWindows = new SlidingWindows();
            var result = slidingWindows.SizeOfNoRepeatLetters("abbcpb");
            result.Should().Be(3);
        }

        [Fact]
        public void It_finds_length_of_wwwwwwww()
        {
            var slidingWindows = new SlidingWindows();
            var result = slidingWindows.SizeOfNoRepeatLetters("wwwwwwww");
            result.Should().Be(1);
        }

        [Fact]
        public void It_finds_length_of_yuiyuiuu()
        {
            var slidingWindows = new SlidingWindows();
            var result = slidingWindows.SizeOfNoRepeatLetters("yuiyuiuu");
            result.Should().Be(3);
        }
    }
}
