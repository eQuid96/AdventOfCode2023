
// List Initializations
let l = [1;2;3]
// Create a list of 10 elements and run lambda function for each element
let l1 = List.init<int> 10 (fun i -> i)
let inl = [ 1 .. 10 ]

// Accessing elements
l1.Head //Get first element
l1.Tail // Get rest of elements without head
l1[1]
l1[..2] // only first two elements
l1[2..] //from 3 to 10


//find element 3
l1 |> List.find (fun x -> x = 3) // if not found throws error

l1 |> List.tryFind (fun x -> x = 200) // not throw return an option

[200] |> List.append l1 // add at the end

l1 |> List.append [-99] // add to start

// Map return a copy of transformations
l1 |> List.map (fun elem -> elem * 2)

//Iterate over a collection 
l1 |> List.iter (fun elem -> printfn $"{elem}")

l1 |> List.sumBy (fun elem -> elem)

l1 |> List.filter (fun elem -> elem > 4)

l1 |> List.sort

l1 |> List.sortDescending


//Conversions to array or sequences
let arrOfInt = l1 |> Array.ofList
let seqOfInt = l1 |> Seq.ofList

// array
let arr = [|1;2;3;|]
let arrl = [|1 .. 10|]

let arr1 = Array.init<int> 10 (id)
let arr2 = Array2D.init<int> 3 3 (fun x _ -> x)

// sequence
let s = seq {1;2;3}
let sl = seq {1..5}
let s1 = Seq.init<int> 10 (fun i -> i)
let sInfinite = Seq.initInfinite<int> (fun i -> i)