open System
open Game
open Support

[<EntryPoint>]
let main _ =
    printf "\n=======================$BetYourLife$========================\n"
    dealerSay 1 "Welcome to the table. Please, take a seat."

    //Execute the entire game by repeating blackjack rounds
    let rec round chip debt =
        printf "\n[ You have %d chips ]\n" chip
        let bet = betting chip

        //When quit the game
        if bet = 0 then
            dealerSay 2 "Leaving so soon? Goodbye."
            over chip debt

        else
            dealerSay 1 "Your chips are in. Best of Luck."
            printf "\n"
            let result = blackjack ()

            if result > 0 then //Player wins
                printf "\n[ You win! ]\n"
                dealerSay 2 "Enjoy it while it lasts..."
                stopper ()
                round (chip + bet) debt
            else if result = 0 then //Tie
                printf "\n[ Draw ]\n"
                dealerSay 0 "Keep your chips. For now."
                stopper ()
                round chip debt
            else //Player loses
                printf "\n[ You lose... ]\n"
                dealerSay 1 "Thanks for the donation."
                if chip - bet > 0 then
                    stopper ()
                    round (chip - bet) debt
                
                //When the player's chips become 0, offer a loan
                else
                    printf "\n"
                    dealerSay 0 "Cleaned out already? I can lend you some."
                    let rec ask () =
                        printf "[y/n] >> "
                        match Console.ReadLine().Trim().ToLower() with
                        | "y" ->
                            printf "\n[ You borrowed 100 chips ]\n"
                            dealerSay 1 "Brave. Don't lose it again."
                            printf "\n[ Your debt is %d chips ]\n" (debt + 200)
                            stopper ()
                            round 100 (debt + 200)
                        | "n" ->
                            dealerSay 2 "No chips, no game. Time to leave."
                            over 0 debt
                        | _ ->
                            dealerSay 3 "It's not complicated. y for yes, n for no."
                            ask ()
                    ask ()

    //Start with 100 chips
    round 100 0
    0
