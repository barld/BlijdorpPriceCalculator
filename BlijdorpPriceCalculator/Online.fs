module Online

open ConsoleInput

type NoteInput =
    {
        Addults:int
        Childs:int
    }

let collectInput () =
    let rec aInput () = GetMinInt "how much addults? (from age of 13)" aInput (fun n -> n) 1
    let rec cInput () = GetMinInt "how much children?" cInput (fun n -> n) 0
    {
        Addults = aInput ()
        Childs = cInput ()
    }

let calculateNote (ni:NoteInput) = float32 ni.Addults * 20.f + float32 ni.Childs * 15.5f