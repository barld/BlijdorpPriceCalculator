module ConsoleInput
    
let GetMinInt message (onInvalid:Unit->'a) (onValid:int->'a) (minValue:int) : 'a =
    printfn message
    match System.Int32.TryParse(System.Console.ReadLine()) with
    | false,_ -> onInvalid ()
    | true, n when n<minValue -> onInvalid ()
    | true, n -> onValid n

