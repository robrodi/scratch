// Learn more about F# at http://fsharp.net

module Module1
open System
open System.Collections.Generic
open System.Linq

let score(frames: IEnumerable<int[]>) : int =
    let mutable sum = 0;
    let framesArray = frames.ToArray()
    if framesArray.Length > 0 then
        for i = 0 to Math.Min(framesArray.Length - 1, 9) do
            let frame = framesArray.[i]
            let frameSum = if frame.Length = 2 then frame.[0] + frame.[1] else frame.[0]
            let isSpare = frameSum = 10
            let isStrike = frame.[0] = 10
            sum <- sum + frameSum

            let hasNextFrame = (i + 1) < framesArray.Length
            if isSpare && hasNextFrame then 
                sum <- sum + framesArray.[i + 1].[0]

            if isStrike && hasNextFrame then 
                if framesArray.[i + 1].Length = 2 then
                    sum <- sum + framesArray.[i + 1].[1]
                elif (i + 2) < framesArray.Length then
                    sum <- sum + framesArray.[i + 2].[0]
            
//            let arg1 = if frame.Length = 2 then frame.[1].ToString() else "X"
//            Console.WriteLine("{0} {1} {2} {3} {4}", frame.[0], arg1, sum, isSpare, isStrike)
    sum