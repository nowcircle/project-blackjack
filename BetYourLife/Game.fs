module Game

open System
open Cardfun
open Handfun
open Support

//Execute a blackjack round
let blackjack () =
    let dealer = Hand ()
    let player = Hand ()
    
    //Player's turn (Return false when burst, otherwise true)
    let rec playerTurn () =
        dealerSay 0 "Take these."
        if player.Sum > 21 then
            printTable dealer player false
            dealerSay 1 "Too greedy. Bust!"
            false
        else
            printTable dealer player true
            dealerSay 0 "Hit or Stand?"
            let rec ask () =
                printf "[h/s] >>  "
                match Console.ReadLine().Trim().ToLower() with
                | "h" ->
                    player.hit()
                    playerTurn ()
                | "s" -> 
                    dealerSay 0 "Let's see how this play out."
                    true
                | _ ->
                    dealerSay 3 "It's not complicated. h for hit, s for stand."
                    ask ()
            ask ()
    
    //Dealer's turn
    let rec dealerTurn () =
        if dealer.Sum < 17 then
            dealer.hit()
            dealerTurn ()
    
    for i = 1 to 2 do
        dealer.hit()
        player.hit()
    
    //Return a positive number if the player wins,
    //a negative number if the player loses, 
    //and 0 for a tie
    if playerTurn () then
        dealerTurn ()
        printTable dealer player false
        if dealer.Sum > 21 then 1
        else player.Sum - dealer.Sum
    else
        -1