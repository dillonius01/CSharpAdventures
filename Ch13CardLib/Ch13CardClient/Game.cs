﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ch13CardLib;

namespace Ch13CardClient
{
    public class Game
    {
        private int currentCard;
        private Deck playDeck;
        private Player[] players;
        private Cards discardedCards;
        public Game()
        {
            currentCard = 0;
            playDeck = new Deck(true);
            playDeck.LastCardDrawn += Reshuffle;
            playDeck.Shuffle();
            discardedCards = new Cards();
        }

        private void Reshuffle(object sender, EventArgs e)
        {
            Console.WriteLine("Discarded cards reshuffled into deck.");
            ((Deck)sender).Shuffle();
            discardedCards.Clear();
            currentCard = 0;
        }
        public void SetPlayers(Player[] newPlayers)
        {
            if (newPlayers.Length > 7)
            {
                throw new ArgumentException(
                    "A maximum of 7 players may play this game.");
            }
            if (newPlayers.Length < 2)
            {
                throw new ArgumentException(
                    "A minimum of 2 players may play this game.");
            }
            players = newPlayers;
        }
        private void DealHands()
        {
            for (int p = 0; p < players.Length; p++)
            {
                for (int c = 0; c < 7; c++)
                {
                    players[p].PlayHand.Add(playDeck.GetCard(currentCard++));
                }
            }
        }
        public int PlayGame()
        {
            // only if players exist
            if (players == null)
            {
                return -1;
            }
            // Deal initial hands
            DealHands();
            // Initialize game vars, including card to place on table
            bool GameWon = false;
            int currentPlayer;
            Card playCard = playDeck.GetCard(currentCard++);
            discardedCards.Add(playCard);
            // Main game loop, continues until GameWon == true
            do
            {
                // Loop thru players in each game round
                for (currentPlayer = 0; currentPlayer < players.Length; currentPlayer++)
                {
                    // write out curr player, hand, and card on table
                    Console.WriteLine($"{players[currentPlayer].Name}'s turn.");
                    Console.WriteLine("Current hand:");
                    foreach (Card card in players[currentPlayer].PlayHand)
                    {
                        Console.WriteLine(card);
                    }
                    Console.WriteLine($"Card in play: {playCard}");
                    // prompt player to pick up card on table or draw a new one.
                    bool inputOK = false;
                    do
                    {
                        Console.WriteLine("Press T to take card in play or D to draw:");
                        string input = Console.ReadLine();
                        if (input.ToLower() == "t")
                        {
                            // Add card from table to player hand
                            Console.WriteLine($"Drawn: {playCard}");
                            // Remove from discarded cards if possible
                            // if deck is reshuffled, won't be any more
                            if (discardedCards.Contains(playCard))
                            {
                                discardedCards.Remove(playCard);
                            }
                            players[currentPlayer].PlayHand.Add(playCard);
                            inputOK = true;
                        }
                        if (input.ToLower() == "d")
                        {
                            // Add new card from deck to player hand
                            Card newCard;
                            // only add card if it isn't already in a player hand
                            // or in the discard pile
                            bool cardIsAvailable;
                            do
                            {
                                newCard = playDeck.GetCard(currentCard++);
                                // Check if card is in discard pile
                                cardIsAvailable = !discardedCards.Contains(newCard);
                                if (cardIsAvailable)
                                {
                                    // Loop through all player hands to see if newCard
                                    // is already in a hand
                                    foreach (Player testPlayer in players)
                                    {
                                        if (testPlayer.PlayHand.Contains(newCard))
                                        {
                                            cardIsAvailable = false;
                                            break;
                                        }
                                    }
                                }
                            } while (!cardIsAvailable);
                            // Add card found to player hand.
                            Console.WriteLine($"Drawn: {newCard}");
                            players[currentPlayer].PlayHand.Add(newCard);
                            inputOK = true;
                        }
                    } while (inputOK == false);
                    // Display new hand with cards numbered.
                    Console.WriteLine("New hand: ");
                    for (int i = 0; i < players[currentPlayer].PlayHand.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}: " +
                                          $"{players[currentPlayer].PlayHand[i]}");
                    }
                    // Prompt player for a card to discard
                    inputOK = false;
                    int choice = -1;
                    do
                    {
                        Console.WriteLine("Choose card to discard.");
                        string input = Console.ReadLine();
                        try
                        {
                            // Attemp to convert input to valid card number.
                            choice = Convert.ToInt32(input);
                            if ((choice > 0) && (choice <= 8))
                            {
                                inputOK = true;
                            }
                        }
                        catch
                        {
                            // Ignore failed conversions, just continue prompting
                        }
                    } while (inputOK == false);
                    // Place ref to removed card in playCard
                    // place the card on the table
                    // then remove card from player hand and add to discarded pile
                    playCard = players[currentPlayer].PlayHand[choice - 1];
                    discardedCards.Add(playCard);
                    Console.WriteLine($"Discarding: {playCard}");
                    Console.WriteLine();
                    // check to see if player has won game
                    GameWon = players[currentPlayer].HasWon();
                    if (GameWon == true)
                    {
                        break;
                    }
                }
            } while (GameWon == false);
            // End game
            return currentPlayer;
        }
    }
}
