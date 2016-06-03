// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

type ATM = 
    {
        Active:bool
        DayLimit:float32
        CurrentAmount:float32
    }

type Account =
    {
        Saldo:float32
        CreditLimit:float32
    }

type ATMAction =
    | Take of float32

type ATMResult =
    | Message of string
    | Money of float32

let executeAction (atm:ATM) (account:Account) (action:ATMAction) : ATMResult =
    if not atm.Active then
        Message("the ATM is not active")
    else
        match action with
        | Take(m) -> 
            if m < account.Saldo || abs account.Saldo - m |> abs < account.CreditLimit then
                if atm.DayLimit < m then
                    Message("day limit is already reached")
                else if atm.CurrentAmount < m then
                    Message("not enough money in this ATM")
                else
                    Money(m)
            else
                Message("not enough money and creditlimit")

let tryAgain () = printfn "please try again" 
let rec getActive () = ConsoleInput.getBool "is the machine Active?" (tryAgain >> getActive) (fun b -> b)
let rec getFloat message () = ConsoleInput.getFloat32 message (tryAgain >> (getFloat message)) (fun f -> f)

let CreateATMOnConsole () =    
    {
        Active = getActive()
        DayLimit = getFloat "What is the DayLimit" ()
        CurrentAmount = getFloat "what is the amount of money in the ATM" ()
    }

let CreatAccountOnConsole () =
    {
        Saldo = getFloat "what is the saldo" ()
        CreditLimit = getFloat "what is the credit limit" ()
    }

let rec getInt () = ConsoleInput.GetMinInt "how much money do you want?" (tryAgain >> getInt) (fun i -> i) 0

[<EntryPoint>]
let rec main argv = 
    let atm = CreateATMOnConsole ()
    let account = CreatAccountOnConsole ()
    let m = getInt () |> float32
    printfn "result = %A" (executeAction atm account (Take(m)))

    do main argv |> ignore

    System.Console.Read()
