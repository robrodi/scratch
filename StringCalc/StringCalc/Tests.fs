module Tests

open System
open NUnit.Framework
open System.Collections.Generic
open System.Linq
open Module1

[<TestFixture>]
type Awesome() = class
    [<Test>]
    member self.firstTest() = 
        Assert.AreEqual(1,1)

    [<Test>]
    member self.EmptyStringReturnsZero() = 
        let expected = 0
        let actual = StringCalc(String.Empty)
        Assert.AreEqual(1,1)

    [<Test>]
    member self.SingleNumberReturnsValue() =
        let values = Enumerable.Range(0, 5)

        for value in values do
            Assert.AreEqual(value, StringCalc(value.ToString()))
    [<Test>]
    member self.TwoNumbersCommaDelimitedReturnsSum() =
        let values = [| "1,2"; "1, 2" |]
        let expected = 3
        for value in values do
            Assert.AreEqual(expected, StringCalc(value))
    [<Test>]
    member self.TwoNumbersNewlineDelimitedReturnsSum() =
        let value = "1\n2"
        let expected = 3
        Assert.AreEqual(expected, StringCalc(value))
    
    [<Test>]
    member self.ThreeNumbersBothDelimitedReturnsSum() =
        let value = "1\n2,3"
        let expected = 6
        Assert.AreEqual(expected, StringCalc(value))
        
    [<Test>]
    member self.CustomDelimiter() =
        let value = "//;\n1;2"
        let expected = 3
        Assert.AreEqual(expected, StringCalc(value))

    [<Test>]
    member self.CustomMultiCharDelimiter() =
        let value = "//###\n1###2"
        let expected = 3
        Assert.AreEqual(expected, StringCalc(value))
    
    [<Test>]
    member self.NegativeNumbersThrow() =
        let value = "1,-2"
        try
            StringCalc(value) |> ignore
            Assert.Fail("Should Throw")
        with
            | :? ArgumentOutOfRangeException as ex -> printfn "Exception"

    [<Test>]
    member self.NegativeNumbersAggregateThenThrow() =
        let value = "1,-2,-3"
        try
            StringCalc(value) |> ignore
            Assert.Fail("Should Throw")
        with
            | :? ArgumentOutOfRangeException as ex -> 
                Console.WriteLine(ex.Message)
                Assert.IsTrue(ex.Message.Contains("-3"), "Should contain the second negative number")

end