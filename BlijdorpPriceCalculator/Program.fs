type PayChoise =
    | Online

[<EntryPoint>]
let main argv = 
    match PayChoise.Online with
    | Online ->
        let PayInfo = Online.collectInput ()
        printfn "the price = %f" (Online.calculateNote PayInfo)
    
    System.Console.Read()
