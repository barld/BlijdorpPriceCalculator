
[<EntryPoint>]
let main argv = 
    printfn "Do you want to pay online (Y)"
    let answer = System.Console.ReadLine()
    match answer.ToUpper() = "Y" with
    | true ->
        let PayInfo = Online.collectInput ()
        printfn "the price = %f" (Online.calculateNote PayInfo)
    | false ->
        let payInfo = Ofline.collectInput ()
        printfn "the price = %f" (Ofline.calculateNote payInfo)
    System.Console.Read()
