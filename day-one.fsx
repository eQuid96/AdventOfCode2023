#load "utils.fs"
open AdventOfCode2023
open Utils
open System
open System.IO
let isNumber (value: char): bool =
    Char.IsDigit(value)

let getFirstAndLastNumber (value: string) =
    let numbers = Seq.toList value
                |> List.filter isNumber
                
    if numbers.Length > 0 then
       let first = numbers.Head
       let last = numbers[numbers.Length - 1]
       let combined = $"{first}{last}"
       Int32.Parse(combined)
    else
        0
        
let result =
    Path.Join(__SOURCE_DIRECTORY__, "day-one-input.txt")
    |> readLines
    |> Seq.map getFirstAndLastNumber
    |> Seq.sum
    
printfn $"Result is: {result}"