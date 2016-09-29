using Xunit;

namespace Indentional.Tests
{
    public class IndentionalTests
    {
        [Fact]
        public void RemovesCommonIndention()
        {
            var actual = Indentional._(@"
                my first line
                my second line");

            Assert.Equal(@"my first line
my second line", actual);
        }

        [Fact]
        public void CalculatesCommonIndentFromFirstLineWithText()
        {
            var actual = Indentional._(@"

                my first line
                my second line");

            Assert.Equal(@"
my first line
my second line", actual);
        }

        [Fact]
        public void IfFirstLineHasNoIndentItCalculatesCommonIndentFromSecondLineWithText()
        {
            var actual = Indentional._(
              @"my first line
                my second line
                my third line");

            Assert.Equal(@"my first line
my second line
my third line", actual);
        }

        [Fact]
        public void KeepsFurtherIdentation()
        {
            var actual = Indentional._(@"
                my first line
                    my second line
                my third line");

            Assert.Equal(@"my first line
    my second line
my third line", actual);
        }

        [Fact]
        public void HandlesEmptyString()
        {
            var actual = Indentional._(@"");

            Assert.Equal(@"", actual);
        }

        [Fact]
        public void HandlesStringWithLineBreak()
        {
            var actual = Indentional._(@"
");

            Assert.Equal(@"", actual);
        }

        [Fact]
        public void HandlesStringWithLineBreak2()
        {
            var actual = Indentional._(@"hallo
");

            Assert.Equal(@"hallo
", actual);
        }
    }
}
