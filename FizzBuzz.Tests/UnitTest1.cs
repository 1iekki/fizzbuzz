namespace FizzBuzz.Tests;

public class UnitTest1
{
    [Fact]
    public void DontReplaceAnything()
    {
        string input = "Mary had";
        
        FizzBuzzDetector fizzBuzzDetector = new FizzBuzzDetector();
        OutputObject output = fizzBuzzDetector.getOverlappings(input);

        Assert.Equal("Mary had" ,output.OutputString);
    }

    [Fact]
    public void ReplaceThirdWord()
    {
        string input = "Mary had a";
        
        FizzBuzzDetector fizzBuzzDetector = new FizzBuzzDetector();
        OutputObject output = fizzBuzzDetector.getOverlappings(input);

        Assert.Equal("Mary had Fizz" ,output.OutputString);
    }

    [Fact]
    public void SignleLineReplacementTest()
    {
        string input = "Mary had a little lamb Little lamb, little lamb Mary had a little lamb It's fleece was white as snow";
        
        FizzBuzzDetector fizzBuzzDetector = new FizzBuzzDetector();
        OutputObject output = fizzBuzzDetector.getOverlappings(input);

        Assert.Equal("Mary had Fizz little Buzz Fizz lamb, little Fizz Buzz had Fizz little lamb FizzBuzz fleece was Fizz as Buzz" ,output.OutputString);
    }

    [Fact]
    public void ReplaceMentCountingTest()
    {
        string input = "Mary had a little lamb Little lamb, little lamb Mary had a little lamb It's fleece was white as snow";
        
        FizzBuzzDetector fizzBuzzDetector = new FizzBuzzDetector();
        OutputObject output = fizzBuzzDetector.getOverlappings(input);
        Assert.Equal(9, output.Count);
    }

    [Fact] public void MultiLineReplaceMentTest()
    {
        string input = "Mary had a little lamb\nLittle lamb, little lamb\nMary had a little lamb\nIt's fleece was white as snow";
        
        FizzBuzzDetector fizzBuzzDetector = new FizzBuzzDetector();
        OutputObject output = fizzBuzzDetector.getOverlappings(input);
        
        Assert.Equal("Mary had Fizz little Buzz\nFizz lamb, little Fizz\nBuzz had Fizz little lamb\nFizzBuzz fleece was Fizz as Buzz" ,output.OutputString);
    }
}
