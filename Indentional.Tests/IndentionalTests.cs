using Xunit;
using static Indentional.Indentional;

namespace Indentional.Tests
{
    public class IndentionalTests
    {
        [Fact]
        public void RemovesCommonIndention()
        {
            var actual = _(@"
                my first line
                my second line");

            Assert.Equal("my first line my second line", actual);
        }

        [Fact]
        public void RemovesCommonIndentionWithDoubleNewline()
        {
            var actual = _(@"
                my first line

                my second line");

            Assert.Equal("my first line\r\n\r\nmy second line", actual);
        }

        [Fact]
        public void CalculatesCommonIndentFromFirstLineWithText()
        {
            var actual = _(@"

                my first line
                my second line");

            Assert.Equal("my first line my second line", actual);
        }

        [Fact]
        public void IfFirstLineHasNoIndentItCalculatesCommonIndentFromSecondLineWithText()
        {
            var actual = _(
                @"my first line
                my second line
                my third line");

            Assert.Equal("my first line my second line my third line", actual);
        }

        [Fact]
        public void KeepsFurtherIdentation()
        {
            var actual = _(@"
                my first line

                    my second line

                my third line");

            Assert.Equal("my first line\r\n\r\n    my second line\r\n\r\nmy third line", actual);
        }

        [Fact]
        public void HandlesEmptyString()
        {
            var actual = _(@"");

            Assert.Equal("", actual);
        }

        [Fact]
        public void HandlesStringWithLineBreak()
        {
            var actual = _(@"
");

            Assert.Equal("", actual);
        }

        [Fact]
        public void HandlesStringWithLineBreak2()
        {
            var actual = _(@"hallo
");

            Assert.Equal("hallo", actual);
        }

        [Fact]
        public void TrimsEnds() // Except for last line, where you clearly can see the spaces
        {
            var actual = _(@"
                my first line    
                my second line ");

            Assert.Equal("my first line my second line ", actual);
        }

        [Fact]
        public void TestReadme()
        {
            var actual = _(@"
                You tried to do something tricky, but something was not true twice in i row.
                It might be better to do this:

                    DoDoingDone(checkForSomethingTrue: false);
                
                Don't ya think?");

            Assert.Equal("You tried to do something tricky, but something was not true twice in i row. It might be better to do this:\r\n\r\n    DoDoingDone(checkForSomethingTrue: false);\r\n\r\nDon't ya think?", actual);
        }

        [Fact]
        public void Bug1()
        {
            var actual = _("Der b�r ikke oprettes energim�rkningsrapporter, der indeholder mere end\r\n                      ca. 15 bygninger/zoner p� en enkelt sag. Anbefalingen gives dels p� baggrund af\r\n                      energim�rkningsrapportens l�sevenlighed, dels for at kunne sikre at Energy10 k�rer\r\n                      hurtigt og stabilt. Vi arbejder p� at l�se problemet med hastigheden p� meget store sager.");

            Assert.Equal("Der b�r ikke oprettes energim�rkningsrapporter, der indeholder mere end ca. 15 bygninger/zoner p� en enkelt sag. Anbefalingen gives dels p� baggrund af energim�rkningsrapportens l�sevenlighed, dels for at kunne sikre at Energy10 k�rer hurtigt og stabilt. Vi arbejder p� at l�se problemet med hastigheden p� meget store sager.", actual);
        }

        [Fact]
        public void ReplaceOutputNewLine()
        {
            var actual = _("\n", @"
                my first line

                    my second line

                my third line");

            Assert.Equal("my first line\n\n    my second line\n\nmy third line", actual);
        }

        [Fact]
        public void DontTrimOnliners()
        {
            var actual = _("Der b�r ikke oprettes energim�rkningsrapporter, der indeholder mere end ");

            Assert.Equal("Der b�r ikke oprettes energim�rkningsrapporter, der indeholder mere end ", actual);
        }
    }
}
