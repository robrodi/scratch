// Learn more about F# at http://fsharp.net
module Module1
open System
open System.Text.RegularExpressions
    let numbersRegex = new Regex("^(-?\d+[,\n]? ?)+$")

    let StringCalc(text: string) : int =
        if String.IsNullOrWhiteSpace(text) then 0
        else 
            let m = numbersRegex.Match(text)
            if (m.Success) then
                
                let text = m.Groups.[0].Value
                let numbers = text.Split([|','; '\n' |], StringSplitOptions.RemoveEmptyEntries)
                let mutable sum = 0
                for i in numbers do
                    Console.WriteLine(">" + i.Trim() + "<")
                    sum <- sum + Int32.Parse(i.Trim())
                Console.WriteLine(sum.ToString())
                sum
            else
                Console.WriteLine("Fail")
                0
