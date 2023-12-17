namespace AdventOfCode2023
open System.IO

module Utils =
    let readLines (path: string) = seq {
        use stream = new StreamReader(path)
        while not stream.EndOfStream do
        yield stream.ReadLine()
    }