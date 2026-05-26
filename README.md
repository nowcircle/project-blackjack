# BetYourLife (CLI Blackjack)

A command-line blackjack game built with F#.
The player bets chips and plays against a computer dealer. 

---

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)  
  Verify with: `dotnet --version` (should show `10.x.x`)

### Run

```bash
dotnet run
```

### Build

```bash
dotnet build
```

---

## How to Play

### 1. Betting Phase

1. You start the game with **100 chips** and **0 debt**.
2. At the start of a round, the dealer prompts you to bet.
3. Type an integer and press **Enter**.
   - If you enter `0`, you leave the table and the game ends immediately.
   - If the bet is invalid (negative or exceeds your current chips), the dealer will ask you to try again.


### 2. Dealing & Player Turn

1. After betting, you and the dealer receive two cards. One of the dealer's cards is hidden `[?]`.
2. The board is printed showing both hands and your total sum.
3. You are prompted: `[h/s] >>`
   - **`h` (Hit)**: You receive another random card. If your total exceeds 21, you **Bust** and lose the bet immediately.
   - **`s` (Stand)**: Your turn ends, and the dealer's turn begins.
  
**Card Values** - Keep in mind how cards are valued:
| Rank | Value |
|------|-------|
| **2–10** | Calculated at face value. |
| **J, Q, K** | Calculated as **10**. |
| **A (Ace)** | Initially calculated as **11**, but automatically reduces to **1** if the total hand value exceeds 21. |


### 3. Dealer Turn & Settlement

After you stand, the dealer's hidden card is revealed. The dealer automatically hits until their total reaches **17 or higher**.

| Result | Condition | Chip Change |
|--------|-----------|-------------|
| **You win** | Dealer busts, or your total is closer to 21 than the dealer's. | + Bet Amount |
| **Dealer wins** | You bust, or the dealer's total is closer to 21. | - Bet Amount |
| **Tie (Draw)** | Both have the exact same total without busting. | No change |


### 4. Bankruptcy & Loan

1. If your chips reach `0`, the dealer will offer you a loan.
2. You are prompted: `[y/n] >>`
  - **`y` (Yes)**: You receive **100 chips**, but a penalty of **200 debt** is added to your account. A new round begins.
  - **`n` (No)**: You leave the table and the game ends.


### 5. Game Over & Final Score

When the game terminates (by betting `0` or declining a loan), your final performance is printed on a scoreboard.
  - The **Final Score** is calculated using the following formula:
  ```
  Final Score = Current Chips - Debt
  ```
  - *Note: Your final score can be negative if your accumulated debt exceeds your remaining chips.*

---

## Example Session

```
=======================$BetYourLife$========================
 ,,,   .--------------------------------------------.
(^_^) <  Welcome to the table. Please, take a seat. |
/   \  '--------------------------------------------'

[ You have 100 chips ]
 ,,,   .--------------------------.
(°_°) <  Place your bets, please. |
/   \  '--------------------------'
>> 50
 ,,,   .----------------------------------.
(^_^) <  Your chips are in. Best of Luck. |
/   \  '----------------------------------'

 ,,,   .-------------.
(°_°) <  Take these. |
/   \  '-------------'

.---------------------------------------.
|                                       |
|  Dealer's hand >  [?] [7]  | sum: ?   |
|                                       |
|  Your hand >      [J] [4]  | sum: 14  |
|                                       |
'---------------------------------------'
 ,,,   .---------------.
(°_°) <  Hit or Stand? |
/   \  '---------------'
[h/s] >>  h
 ,,,   .-------------.
(°_°) <  Take these. |
/   \  '-------------'

.-------------------------------------------.
|                                           |
|  Dealer's hand >  [?] [7]  | sum: ?       |
|                                           |
|  Your hand >      [J] [4] [4]  | sum: 18  |
|                                           |
'-------------------------------------------'
 ,,,   .---------------.
(°_°) <  Hit or Stand? |
/   \  '---------------'
[h/s] >>  s
 ,,,   .------------------------------.
(°_°) <  Let's see how this play out. |
/   \  '------------------------------'

.-------------------------------------------.
|                                           |
|  Dealer's hand >  [9] [7] [2]  | sum: 18  |
|                                           |
|  Your hand >      [J] [4] [4]  | sum: 18  |
|                                           |
'-------------------------------------------'

[ Draw ]
 ,,,   .---------------------------.
(°_°) <  Keep your chips. For now. |
/   \  '---------------------------'
```

---

## Project Structure

```
BetYourLife/
├── betyourlife.fsproj  # .NET 10 F# project file
├── README.md           # This file
├── requirements.md     # Project proposal & rules
└── BetYourLife/
    ├── Cardfun.fs      # Card type, and draw logic
    ├── Handfun.fs      # Hand type, sum calculation, and convert-to-string logic
    ├── Support.fs      # Console UI, betting input validation, and result formatting
    ├── Game.fs         # Game loop, and win/loss evaluation
    └── Program.fs      # Entry point, betting and play-again loop, and loan system
```

---

## Rules Summary

- You always start with **100 chips** and **0 debt**.
- The dealer always plays automatically, drawing cards until their total reaches **17 or higher**.
- Card values: **2–10** are face value. **J, Q, K** are 10. **Ace** is 11, but automatically reduces to 1 if the total exceeds 21.
- Entering an invalid bet or action reprompts you — the game does **not** advance.
- Going over 21 is a **Bust**, resulting in an automatic loss for that round.
- If you lose all your chips, you face a choice: quit, or take a **loan** (+100 chips, +200 debt).
- Your final score is calculated as `(Current Chips - Debt)`.


## LLM Usage

### Dealer's line
  Used AI: Gemini 3.1 Pro
  ```
  I need to ask how many chips to bet to make a blackjack game. Please recommend a practical sentence to write in English.
  ```
