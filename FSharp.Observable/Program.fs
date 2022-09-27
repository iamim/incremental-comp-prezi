// 1. a + b
// 2. a + a
// 3. plus, but no subs

open System.Reactive.Linq
open System.Reactive.Subjects

let a = new BehaviorSubject<int>(1)
let b = new BehaviorSubject<int>(2)

let plus =
    Observable
        .CombineLatest(a, a)
        .Select(fun list ->
            printfn $"> summing {list[0]} and {list[1]}"
            list[0] + list[1])
        
plus.Subscribe(fun a -> printfn $"{a}") |> ignore

printfn "> a := 100"
a.OnNext(100)
