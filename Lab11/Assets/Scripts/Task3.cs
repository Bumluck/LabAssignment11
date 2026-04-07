using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;

public class Task3 : MonoBehaviour
{

    #region VARIABLES

    public bool toggleTask;

                      //Spade,   Clubs,    Hearts,   Diamonds
    string[] suits = {"\u2660", "\u2663", "\u2665", "\u2666"};

    string[] ranks = { "K", "Q", "J", "A" };

    public List<string> cardDeck;

    public List<string> hand;

    Queue<string> cardQueue;

    System.Random rand;
    Queue deck;

    bool playing;
    bool playerWon;

    StringBuilder sb;

    #endregion

    private void Start()
    {
        if (toggleTask)
        {
            playerWon = false;
            playing = true;
            rand = new System.Random();
            sb = new StringBuilder();
            cardDeck = createDeck();
            hand = new List<string>();

            cardDeck = (cardDeck.OrderBy(_ => rand.Next())).ToList();

            cardQueue = new Queue<string>(cardDeck);

            for (int i = 0; i < 4; i++)
            {
                hand.Add(cardQueue.Dequeue());
            }

            if (WinCheck())
            {
                playerWon = true;
                playing = false;
            }

            while (playing)
            {
                string discard = hand[0];
                hand.Remove(hand[0]);
                string draw = cardQueue.Dequeue();
                hand.Add(draw);
                if (DeckIsEmpty())
                {
                    playing = false;
                }

                if (WinCheck())
                {
                    foreach (string s in hand)
                    {
                        sb.Append(s + " ");
                    }
                    string winningHand = sb.ToString();
                    sb.Clear();
                    Debug.Log("I discarded " + discard + " and drew " + draw + ". My hand is: " + winningHand + ". The game is WON.");
                    playing = false;
                    playerWon = true;
                }
                else
                {
                    foreach (string s in hand)
                    {
                        sb.Append(s + " ");
                    }
                    string currentHand = sb.ToString();
                    sb.Clear();
                    Debug.Log("I discarded " + discard + " and drew " + draw + ". My hand is: " + currentHand + ".");
                }
            }

            if (playerWon == false)
            {
                Debug.Log("The deck is empty. The game is LOST.");
            }
        }
    }

    public List<string> createDeck()
    {
        List<string> cardDeck = new List<string>();

        foreach (string r in ranks)
        {
            foreach (string s in suits)
            {
                sb.Append(r + s);
                cardDeck.Add(sb.ToString());
                sb.Clear();
            }
        }

        return cardDeck;
    }

    public bool WinCheck()
    {
        bool hasWon = false;
        Dictionary<char, int> suitCount = new Dictionary<char, int>();

        foreach (string s in hand)
        {
            IEnumerable<char> query = s.Where(str => str > 127);
            foreach (var c in query)
            {
                if (suitCount.ContainsKey(c))
                {
                    suitCount[c]++;
                }
                else
                {
                    suitCount.Add(c, 1);
                }
            }
        }

        foreach (KeyValuePair<char, int> kvp in suitCount)
        {
            if (suitCount[kvp.Key] >= 3)
            {
                hasWon = true;
                playerWon = true;
            }
        }
        return hasWon;
    }

    public bool DeckIsEmpty()
    {
        bool deckEmpty = false;

        if (cardQueue.Count() == 0)
        {
            deckEmpty = true;
        }

        return deckEmpty;
    }

}
