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
    | Take of amount: float32

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

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code
