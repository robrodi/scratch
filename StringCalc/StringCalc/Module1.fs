// Learn more about F# at http://fsharp.net
module Module1
open System
open System.Collections.Generic
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
            let negatives = new List<int>()
            for i in numbers do
                let n = Int32.Parse(i.Trim())
                if n >= 0 then sum <- sum + n
                else 
                    negatives.Add(n)
            if negatives.Count > 0 then
                raise (ArgumentOutOfRangeException("text", "Negative Numbers: " + negatives.Select(fun n -> n.ToString()).Aggregate(fun cat n -> cat + " " + n)))
            else                 
                sum
        else
            0
