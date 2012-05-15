// Learn more about F# at http://fsharp.net

module Module1

let score(frames: int list list) : int =
    let isSpare frame = List.sum frame = 10
    let isStrike frame = List.sum frame = 10 && frame.Length = 1
    let additionalSpareValue (frame : int list list) = if not frame.Tail.IsEmpty then frame.Tail.Head.Head else 0
    let additionalStrikeValue (frame : int list list) = 
        if not frame.Tail.IsEmpty then 
            if not frame.Tail.Head.Tail.IsEmpty then 
                frame.Tail.Head.Tail.Head
            else additionalSpareValue frame.Tail
        else 0
    // if the second value in the next frame, otherwise first value in second frame
    let frameSumX  (frame : int list list) =
        let frameScore = List.sum frame.Head
        if isStrike frame.Head then 
            frameScore + additionalSpareValue frame + additionalStrikeValue frame
        elif isSpare frame.Head then
            frameScore + additionalSpareValue frame
        else
            frameScore

    let rec frameSum2 (frame : int list list) =
        if frame.Tail.IsEmpty then
            frameSumX frame
        else
            frameSumX frame  + frameSum2 frame.Tail
   
    frameSum2 frames
    (*
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

            yield List.sum frame ::  strikeValue :: spareValue
    }

//    Seq.sum frameScores
*)