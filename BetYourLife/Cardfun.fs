module Cardfun

open System
let rand = Random()

//Card data type
type Card =
    | Number of int
    | Ace | Jack | Queen | King

    //Create a random card instance
    static member draw () =
        match rand.Next(1,14) with
        | 1 -> Ace
        | 11 -> Jack
        | 12 -> Queen
        | 13 -> King
        | n -> Number n
    
    member this.getInt () =
        match this with
        | Number n -> n
        | Jack | Queen | King -> 10
        | Ace -> 11

    member this.getStr () =
        match this with
        | Number n -> string n
        | Ace -> "A"
        | Jack -> "J"
        | Queen -> "Q"
        | King -> "K"