// Learn more about F# at http://fsharp.net

module Module1
open System
open System.Collections.Generic
open System.Linq

let score(frames: IEnumerable<int[]>) : int =
    let mutable sum = 0;
    let frameSum (frame : int[]) = if frame.Length = 2 then frame.[0] + frame.[1] else frame.[0]
//    let flatSum list = List.fold (fun acc elem -> acc + elem) 0 list
    let isSpare frame = frameSum frame = 10
    let isStrike frame = frameSum frame = 10 && frame.Length = 1

    let framesArray = frames.ToArray()

    if framesArray.Length > 0 then
        for i = 0 to Math.Min(framesArray.Length - 1, 9) do
            let frame = framesArray.[i]

            let hasNextFrame = (i + 1) < framesArray.Length
            let spareValue = if isSpare frame && hasNextFrame then framesArray.[i + 1].[0] else 0
            
            let strikeValue = 
                if isStrike frame && hasNextFrame then
                    if framesArray.[i + 1].Length = 2 then
                        framesArray.[i + 1].[1]
                    elif (i + 2) < framesArray.Length then
                       framesArray.[i + 2].[0]
                    else 0
                else
                    0

            sum <- sum + (frameSum frame) + strikeValue + spareValue
    sum