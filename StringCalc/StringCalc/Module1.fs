// Learn more about F# at http://fsharp.net
module Module1
open System
open System.Linq
open System.Text.RegularExpressions
let numbersRegex = new Regex("^(//(?'delimiter'.+)\n)?(?'numbers'(-?\d+([,\n]|\k<delimiter>)? ?)+)$", RegexOptions.ExplicitCapture)

let StringCalc(text: string) : int =
    if String.IsNullOrWhiteSpace(text) then 0
    else 
        let m = numbersRegex.Match(text)
        if (m.Success) then
            let text = m.Groups.["numbers"].Value
            let standardDelimiters = [|","; "\n" |];
            let delimiters = if String.IsNullOrEmpty(m.Groups.["delimiter"].Value) then standardDelimiters else standardDelimiters.Concat([| m.Groups.["delimiter"].Value |]).ToArray()
            let numbers = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
            let mutable sum = 0
            for i in numbers do
                sum <- sum + Int32.Parse(i.Trim())
            sum
        else
            0
