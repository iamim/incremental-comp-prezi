open FSharp.Data.Adaptive

let a = cval 1
let b = cval 2
let c = cval 3

let if_fn =
    AVal.map3 (fun a b c ->
        printfn $"> choosing if {a} > 0 then {b} else {c}"
        if a > 0 then b else c)
    
let if_branch = if_fn a b c

// force twice - result is cached
printfn $"{AVal.force if_branch}"
printfn $"{AVal.force if_branch}"

if_branch.AddMarkingCallback (fun () -> printfn "> if_branch is dirty") |> ignore

printfn "> a := 100"
transact(fun () -> a.Value <- 100)

printfn $"{AVal.force if_branch}"

// 2. change 5 - should be dirty?
// printfn "> c := 5"
// transact(fun () -> c.Value <- 100)
//
// printfn $"{AVal.force if_branch}"

// 3. replace with this
// let if_fn =
//     AVal.bind (fun a -> if a > 0 then b else c)

// let if_branch = if_fn a
