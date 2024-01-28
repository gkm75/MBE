namespace MBE.Core

module Encoder =
    [<Literal>]
    let private HEXSTR = "0123456789abcdef";
    
    let private hex (hiChar: char) (loChar: char) =
        let hi = HEXSTR.IndexOf hiChar |> byte
        let lo = HEXSTR.IndexOf loChar |> byte
        (hi <<< 4) ||| lo

    let encode binary = ()

    let decode (mangion: char list) =
        let rec looper (encoded: char list) (bs: byte list) =
            match encoded with
            | '\\' :: 'x' :: hi :: lo :: ms -> 
                    let value = hex hi lo
                    looper ms (value::bs)

            | '\\' :: '\\' :: ms ->
                    looper ms (byte '\\' :: bs)

            | m::ms ->
                    looper ms (byte m :: bs)

            | [] -> List.rev bs

        looper mangion []

        