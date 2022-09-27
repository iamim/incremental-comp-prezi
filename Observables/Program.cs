// 1. a + b
// 2. a + a
// 3. plus, but no subs

using System.Reactive.Linq;
using System.Reactive.Subjects;

var a = new BehaviorSubject<int>(1);
var b = new BehaviorSubject<int>(2);

var plus = Observable.CombineLatest(a, b).Select(list =>
{
    Console.WriteLine($"> sum of {list[0]} and {list[1]}");
    return list[0] + list[1];
});

using var sub = plus.Subscribe(Console.WriteLine);

Console.WriteLine("> a := 100");
a.OnNext(100);