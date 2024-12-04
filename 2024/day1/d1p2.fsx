open System.Collections.Generic
open System.IO

let mutable l1: int list = []
let mutable l2: int list = []

let dict = Dictionary<int, int>()

File.ReadAllLines("./d1p1_input.txt")
    |> Seq.map (fun line -> line.Split("   "))
    |> Seq.iter (fun lineitems -> 
        let key = lineitems.[1] |> int
        l1 <- l1 @ [ lineitems.[0] |> int ]
        l2 <- l2 @ [ key ]
        if dict.ContainsKey key then
            dict.[key] <- dict.[key] + 1
        else
            dict.[key] <- 1
    )

let sum = l1 |> Seq.sumBy (fun l -> if dict.ContainsKey l then l*dict.[l] else 0)
printf "%i" sum

