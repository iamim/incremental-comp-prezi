open FSharp.Data.Adaptive

let a = cval 1
let b = cval 2

let plus_fn =
    AVal.map2 (fun a b ->
        printfn $"> summing {a} and {b}"
        a + b)

let plus = plus_fn a a

// force twice - result is cached
printfn $"{AVal.force plus}"
printfn $"{AVal.force plus}"

plus.AddMarkingCallback (fun () -> printfn "> plus is dirty") |> ignore

printfn "> a := 100"
transact(fun () -> a.Value <- 100)

printfn $"{AVal.force plus}"
