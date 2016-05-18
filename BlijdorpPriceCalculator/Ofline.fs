﻿module Ofline

open ConsoleInput

type NoteInput =
    {
        Subscribers:int
        Supervisors:int
        Addults:int
        Childs:int
    }

let collectInput () =
    let tryAgain () = printfn "the input is wrong! Please try again"
    let rec aInput () = GetMinInt "how much addults? (from age of 13)" (tryAgain >> aInput) (fun n -> n) 1
    let rec cInput () = GetMinInt "how much children?" (tryAgain >> cInput) (fun n -> n) 0
    let rec sInput () = GetMinInt "how much subscribers?" (tryAgain >> sInput) (fun n -> n) 0
    let rec svInput () = GetMinInt "how much supervisors?" (tryAgain >> sInput) (fun n -> n) 0
    {
        Subscribers = sInput ()
        Supervisors = svInput ()
        Addults = aInput ()
        Childs = cInput ()
    }

let calculateNote (ni:NoteInput) = 
    let calculateDisCount (ni:NoteInput) =
        let rec loop (ni:NoteInput) (discounts:int) =
            match discounts with
            | 0 -> 0.f
            | n ->
                match ni with
                | ni when ni.Addults > 0 -> 0.25f * 20.f + loop {ni with Addults = ni.Addults-1} (n-1)
                | ni when ni.Childs > 0 -> 0.25f * 15.5f + loop {ni with Childs = ni.Childs-1} (n-1)
                | _ -> 0.f
        loop ni (ni.Subscribers*4)
    
    match ni.Addults+ni.Childs+ni.Supervisors+ni.Subscribers with    
    | n when n < 20 ->
        float32 ni.Addults * 22.f + 
        float32 ni.Childs * 17.5f
    | n ->
        float32 ni.Addults * 20.f + 
        float32 ni.Childs * 15.5f

    + float32 ni.Supervisors * 12.f