open System.IO

let insertNum (list: int List) (num: int) =
    let rec findposition (list:int list) (left: int) (right: int) =
        if left > right then left
        else
            let mid = (left + right) / 2
            if list.[mid] > num then
                findposition list left (mid - 1)
            else
                findposition list (mid + 1) right

    match list with
    | [] -> [num]
    | _ ->
        let idx = findposition list 0 (list.Length - 1)
        if idx = 0 then [num] @ list else list.[0..idx-1] @ [num] @ list.[idx..]

let mutable l1: int list = []
let mutable l2: int list = []

File.ReadAllLines("./d1p1_input.txt")
    |> Seq.map (fun line -> line.Split("   "))
    |> Seq.iter (fun lineitems -> 
        l1 <- insertNum l1 (lineitems.[0] |> int)
        l2 <- insertNum l2 (lineitems.[1] |> int)
    )

let mutable sum = 0
for i in [0..l1.Length - 1] do
    sum <- sum + System.Math.Abs (l1.[i] - l2.[i])

printf "%i" sum