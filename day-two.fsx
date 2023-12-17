#load "utils.fs"
open System
open System.IO
open System.Text.RegularExpressions
open AdventOfCode2023
open Microsoft.FSharp.Collections
open Microsoft.FSharp.Core
open Utils


type CubeColor =
    | Red of int
    | Green of int
    | Blue of int


let IsValidMatch cubeColor =
    match cubeColor with
    | Some color ->
        match color with
        | Red r -> r <= 12
        | Green g -> g <= 13
        | Blue b -> b <= 14
    | None -> false

let getCubeColor (line: string): CubeColor option =
    let pattern = @"(\d+) (blue|green|red)"
    let matchResult = Regex.Match(line, pattern)
    let numberPart = matchResult.Groups.[1].Value |> int
    let colorPart = matchResult.Groups.[2].Value
    match colorPart with
        | "green" -> Some (Green numberPart)
        | "red" -> Some (Red numberPart)
        | "blue" -> Some (Blue numberPart)
        | _ -> None
    

let getGameId (line: string) =
    let gameId = Regex.Match(line, "Game (\d*)")
    if gameId.Success then
       Convert.ToInt32 gameId.Groups[1].Value |> Some
    else
        None
        

let getOnlyValidMatchId (line: string) =
    let values = line.Split(":")
    let gameId, games = getGameId values[0], values[1]
    let matches = games.Split(";")
    let isValidMatch = matches
                        |> Array.map (fun m ->
                            m.Split(",")
                            |> Array.map getCubeColor
                            |> Array.forall IsValidMatch
                            )
                       |> Array.forall (fun x -> x)
    match isValidMatch with
    | true -> Option.defaultValue 0 gameId
    | false -> 0
let result =
    Path.Join(__SOURCE_DIRECTORY__, "day-two-input.txt")
    |> readLines
    |> Seq.map getOnlyValidMatchId
    |> Seq.sum

result