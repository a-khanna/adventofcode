open System.IO

File.ReadAllLines("./d2p1_input.txt")
    |> Seq.map (fun l -> l.Split " " |> Seq.map (fun p -> p |> int) |> Seq.pairwise |> Seq.map (fun p -> fst p - snd p))
    |> Seq.map (fun seq -> Seq.forall (fun i -> i > 0 && i < 4) seq || Seq.forall (fun i -> i > -4 && i < 0) seq)
    |> Seq.sumBy (fun b -> if b then 1 else 0)
    |> printf "%i"