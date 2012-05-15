﻿// Learn more about F# at http://fsharp.net

module Module1

let score(frames: int list list) : int =
    let frameSum (frame : int list) = if frame.Length = 2 then frame.[0] + frame.[1] else frame.[0]
    let isSpare frame = frameSum frame = 10
    let isStrike frame = frameSum frame = 10 && frame.Length = 1

    let frameScores = seq {
        for i = 0 to min (frames.Length - 1)  9 do
            let frame = frames.[i]

            let hasNextFrame = (i + 1) < frames.Length
            let spareValue = if isSpare frame && hasNextFrame then frames.[i + 1].[0] else 0
            let strikeValue = 
                if isStrike frame && hasNextFrame then
                    if frames.[i + 1].Length = 2 then
                        frames.[i + 1].[1]
                    elif (i + 2) < frames.Length then
                        frames.[i + 2].[0]
                    else 0
                else
                    0

            yield (frameSum frame) + strikeValue + spareValue
    }

    Seq.sum frameScores
