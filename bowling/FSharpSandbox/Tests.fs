module Tests

open NUnit.Framework
open System.Collections.Generic
open System.Linq
open Module1

[<TestFixture>]
type Awesome() = class
    let zeroes = [| 0; 0 |]

    [<Test>]
    member self.SomeTest() = 
        let i = 1
        let j = 1
        Assert.AreEqual(i, j)

    [<Test>]
    member self.empyGame() =
        let scores = Enumerable.Repeat(zeroes, 10)
        let actual = score(scores)
        Assert.AreEqual(0, actual)

    [<Test>]
    member self.OnePin() = 
        let expected = 1;
        let scores = [| [| 1; 0 |]; zeroes; zeroes; zeroes; zeroes; zeroes; zeroes; zeroes; zeroes; zeroes |]
        let actual = score(scores)
        Assert.AreEqual(expected, actual)

    [<Test>]
    member self.OnePinOnEachRoll() = 
        let expected = 20;
        let scores = Enumerable.Repeat([| 1; 1 |], 10)
        let actual = score(scores)
        Assert.AreEqual(expected, actual)

    [<Test>]
    member self.Spare() = 
        let expected = 15;
        let scores = [| [| 5; 5 |]; [| 2; 1 |]; zeroes; zeroes; zeroes; zeroes; zeroes; zeroes; zeroes; zeroes; |]
        let actual = score(scores)
        Assert.AreEqual(expected, actual)

    [<Test>]
    member self.Strike() = 
        let expected = 24;
        let scores = [| [| 10 |]; [| 3; 4 |]; zeroes; zeroes; zeroes; zeroes; zeroes; zeroes; zeroes; zeroes; |]
        let actual = score(scores)
        Assert.AreEqual(expected, actual)

    [<Test>]
    member self.TwelveStrike() = 
        let expected = 300;
        let scores = Enumerable.Repeat([| 10; |], 12)
        let actual = score(scores)
        Assert.AreEqual(expected, actual)    
end