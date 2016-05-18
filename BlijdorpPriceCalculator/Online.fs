module Online

open ConsoleInput

type NoteInput =
    {
        Addults:int
        Childs:int
    }

let collectInput () =
    let tryAgain () = printfn "the input is wrong! Please try again"
    let rec aInput () = GetMinInt "how much addults? (from age of 13)" (tryAgain >> aInput) (fun n -> n) 1
    let rec cInput () = GetMinInt "how much children?" (tryAgain >> cInput) (fun n -> n) 0
    {
        Addults = aInput ()
        Childs = cInput ()
    }

let calculateNote (ni:NoteInput) = float32 ni.Addults * 20.f + float32 ni.Childs * 15.5f