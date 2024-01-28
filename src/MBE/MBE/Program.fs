open System.IO
open MBE.Core



[<EntryPoint>]
let Main args =

    printfn "MBE"

    if args.Length <> 1 then failwith "no file name passed"

    let text = File.ReadAllText (args.[0])
    let encoding = [for c in text -> c]
    let binary = Encoder.decode encoding
    let decoded = Array.ofList binary

    File.WriteAllBytes ($"{args.[0]}.mbe.out", decoded) |> ignore
    0
