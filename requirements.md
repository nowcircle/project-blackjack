**Project Title:** BetYourLife (CLI Blackjack) 

**Overview:** This project is a command-line blackjack game where the player bets chips and plays against a computer dealer. The final score is determined by the number of chips acquired by the end of the game. 

**Requirements:**

1. The player starts with 100 chips and 0 debt. 
2. Betting Phase: At the start of each round, the user is prompted to enter an integer value to bet. If the input exceeds the player's current chips, the game will ask the user to re-enter the bet. If the user enters 0, the game ends immediately. 
3. Dealing Phase: After a bet is placed, the player and the dealer each randomly receive two cards. One of the dealer's cards is printed as hidden (e.g., [?]). 
4. Card Values: There are 13 types of cards (A, 2-10, J, Q, K). J, Q, and K are calculated as 10. An A (Ace) is initially calculated as 11, but if the total sum exceeds 21, it is automatically calculated as 1. 
5. Player's Turn: The player inputs either hit or stand. 
6. If hit is selected, the player receives one additional random card. If the total sum exceeds 21, the player "Busts" and immediately loses the round. If the sum does not exceed 21, the player is prompted to choose hit or stand again. 
7. Dealer's Turn: If the player inputs stand, the dealer's hidden card is revealed. The dealer then automatically draws random cards until its total sum reaches 17 or higher. 
8. Settlement Phase: If the dealer busts or the player's total is closer to 21, the player wins and gains chips equal to the bet amount. Conversely, if the dealer is closer to 21 or the player busts, the player loses the bet amount. If the totals are the same (tie), the chips remain unchanged.  
9. After settlement, if the player's chip count is not zero, the game returns to the betting phase and starts a new round. 
10. Loan: If the chip count is zero, the player can choose whether to take out a loan. If they do, they gain 100 chips, but a debt of 200 is added, and a new round begins. Otherwise, the game ends. 
11. Game Over: When the game ends (either by betting 0 or declining a loan), the final score is calculated as (Current Chips - Debt) and printed to the screen, after which the program terminates. 

**Example Interaction:** The game displays the bet prompt, and user enters 10. The player's hand is [8, 6] and the dealer's is [7, ?]. The user enters hit, gets a 5 (total 19), and enters stand. The dealer reveals a 9 (total 16), draws a 10 and busts (total 26). The player wins 10 chips. The game displays the new bet prompt.
