module Module1

let maximumFrames = 10
let score(frames: int list list) : int =
    let additionalSpareValue (frame : int list list) = if not frame.Tail.IsEmpty then frame.Tail.Head.Head else 0
    let additionalStrikeValue (frame : int list list) = 
        if not frame.Tail.IsEmpty then 
            if not frame.Tail.Head.Tail.IsEmpty then 
                frame.Tail.Head.Tail.Head
            else additionalSpareValue frame.Tail
        else 0

    let getFrameScore  (frame : int list list) =
        if List.sum frame.Head = 10 && frame.Head.Length = 1 then // is strike
            List.sum frame.Head + additionalSpareValue frame + additionalStrikeValue frame
        elif List.sum frame.Head = 10 then // is spare
            List.sum frame.Head + additionalSpareValue frame
        else List.sum frame.Head
    
    let rec sumFrames (frame : int list list, frameNumber) =
        getFrameScore frame +   if not frame.Tail.IsEmpty && frameNumber < maximumFrames then 
                                    sumFrames (frame.Tail, (frameNumber + 1)) 
                                else 0

    sumFrames (frames, 1)