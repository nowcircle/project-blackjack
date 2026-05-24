module Handfun

open Cardfun

type Hand () = 
    member val Cards = [] with get, set //list of Card
    member val Sum = 0 with get, set //sum of all card numbers
    member val Acnt = 0 with get, set //Number of Ace cards

    
    //Draw a new card and add it to the hand
    member this.hit () =
        let ncard = Card.draw()
        this.Cards <- ncard :: this.Cards

        //Decide the value of Ace between 11 and 1
        let rec decideA sum cnt =
            if sum > 21 && cnt > 0 then 
                decideA (sum - 10) (cnt - 1)
            else 
                this.Sum <- sum
                this.Acnt <- cnt

        let cnt = if ncard = Ace then this.Acnt + 1 else this.Acnt
        decideA (this.Sum + ncard.getInt()) cnt
    
    //closed: whether one of the dealer's cards is hidden
    member this.getStr closed=
        let mutable res = ""

        //Card list to a string
        let rec clist (lst: Card list) acc= 
            match lst with
            | [] -> acc
            | hd :: [] when closed -> "[?] " + acc
            | hd :: tl ->
                clist tl ($"[{hd.getStr()}] " + acc)
        res <- res + clist this.Cards ""

        //Sum of cards to a string
        if closed then
            res <- res + " | sum: ? "
        else
            res <- res + $" | sum: {string this.Sum} "

            //When the sum can be multiple depending on the value of Ace
            if this.Acnt > 0 then
                res <- res + "("
                let rec options sum cnt =
                    if cnt = 0 then
                        res <- res + ")"
                    else
                        res <- res + $"/{string (sum - 10)}"
                        options (sum - 10) (cnt - 1)
                options this.Sum this.Acnt

        res, String.length res