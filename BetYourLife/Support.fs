module Support

open System
open Handfun

//Output the dealer's line in a speech bubble
//Determine facial expressions based on emotion
let dealerSay emotion s =
    let line = String.replicate (String.length s + 2) "-"
    printf " ,,,   .%s.\n" line
    match emotion with
    | 0 -> printf "(°_°)" 
    | 1 -> printf "(^_^)"
    | 2 -> printf "(-_-)"
    | 3 -> printf "(\_/)"
    | _ -> ignore ()
    printf " <  %s |\n" s
    printf "/   \  '%s'\n" line

//Print the table status to the terminal
let printTable (dealer: Hand) (player: Hand) pturn =
        let d, dl = dealer.getStr pturn
        let p, pl = player.getStr false
        let l = max dl pl
        let line = String.replicate (20 + l) "-"
        let mline = "|" + (String.replicate (20 + l) " ") + "|"
        printf "\n.%s.\n" line
        printf "%s\n" mline
        printf "|  Dealer's hand >  %s%s |\n" d (String.replicate (l - dl) " ")
        printf "%s\n" mline
        printf "|  Your hand >      %s%s |\n" p (String.replicate (l - pl) " ")
        printf "%s\n" mline
        printf "'%s'\n" line

//Wait for Enter key between rounds
let stopper () = 
    printf "\n >> Press Enter"
    Console.ReadLine() |> ignore
    printf "\n==================================================\n"

//Receive bet input and check if it is invalid
let betting chip=
    dealerSay 0 "Place your bets, please."
    let rec ask () =
        printf ">> "
        match Int32.TryParse(Console.ReadLine().Trim()) with
        | false, _ ->
            dealerSay 3 "I deal cards, not riddles. Numbers, please."
            ask ()
        | true, bet when bet > chip -> 
            dealerSay 3 "Betting with chips you don't have? Lower it."
            ask ()
        | true, bet when bet < 0 ->
            dealerSay 3 "Are you trying to steal from me? Positive numbers only."
            ask ()
        | true, bet ->
            bet
    ask ()

//Print the final score when the entire game ends
let over chip debt =
    let chipl, debtl, scorel = string chip, string debt, string (chip - debt)
    let l = List.max [chipl.Length; debtl.Length; scorel.Length]
    printf "\n%s\n" (String.replicate (l + 19) "=")
    printf "%s[ RESULT ]\n" (String.replicate ((l + 9) / 2) " ")
    printf "%s\n" (String.replicate (l + 19) "=")
    printf " Chips you have : %s%s\n" (String.replicate (l - chipl.Length) " ") chipl
    printf " Chips you owe  : %s%s\n" (String.replicate (l - debtl.Length) " ") debtl
    printf "%s\n" (String.replicate (l + 19) "-")
    printf "FINAL SCORE     : %s%s\n" (String.replicate (l - scorel.Length) " ") scorel
    printf "%s\n" (String.replicate (l + 19) "=")