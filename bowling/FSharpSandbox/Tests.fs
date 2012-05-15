module Tests

open NUnit.Framework
open System.Collections.Generic
open System.Linq
open Module1

[<TestFixture>]
type Awesome() = class
    let zeroFrame = [0;0]
    let strike = [ 10 ]

    [<Test>]
    member self.SomeTest() = 
        let i = 1
        let j = 1
        Assert.AreEqual(i, j)

    [<Test>]
    member self.empyGame() =
        let scores = List.replicate 10 zeroFrame
        let actual = score(scores)
        Assert.AreEqual(0, actual)

    [<Test>]
    member self.OnePin() = 
        let expected = 1;
        let scores = [ 1; 0 ] :: List.replicate 9 zeroFrame
        let actual = score(scores)
        Assert.AreEqual(expected, actual)

    [<Test>]
    member self.OnePinOnEachRoll() = 
        let expected = 20;
        let scores = List.replicate 10 [ 1; 1 ]
        let actual = score(scores)
        Assert.AreEqual(expected, actual)

    [<Test>]
    member self.Spare() = 
        let expected = 15;
        let scores = [ 5; 5 ] :: [ 2; 1 ] :: List.replicate 8 zeroFrame
        let actual = score(scores)
        Assert.AreEqual(expected, actual)

    [<Test>]
    member self.Strike() = 
        let expected = 24;
        let scores = strike :: [ 3; 4 ] :: List.replicate 8 zeroFrame
        let actual = score(scores)
        Assert.AreEqual(expected, actual)

    [<Test>]
    member self.TwelveStrike() = 
        let expected = 300;
        let scores = List.replicate 12 strike
        let actual = score(scores)
        Assert.AreEqual(expected, actual)    
end