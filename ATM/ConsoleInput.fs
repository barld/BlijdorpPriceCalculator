module ConsoleInput

open System
    
let GetMinInt message (onInvalid:Unit->'a) (onValid:int->'a) (minValue:int) : 'a =
    printfn message
    match System.Int32.TryParse(System.Console.ReadLine()) with
    | false,_ -> onInvalid ()
    | true, n when n<minValue -> onInvalid ()
    | true, n -> onValid n

let getFloat32 message (onInvalid: Unit->'a) (onValid:float32->'a) : 'a =
    printfn message
    match System.Double.TryParse(Console.ReadLine()) with
    | false,_ -> onInvalid()
    | true, d -> onValid (float32 d)

let getBool message (onInvalid:Unit->'a) (onValid:bool->'a) =
    printfn message
    printfn "(Y) for yes and (N) for no"
    match Console.ReadLine().ToUpper() with
    | input when input = "Y" -> onValid true
    | input when input = "N" -> onValid true
    | _ -> onInvalid ()

