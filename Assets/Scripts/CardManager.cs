using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CardManager : MonoBehaviour
{
    public static CardManager instance = null;
    public List<uint> deck = new List<uint>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            NewDeck();
            Shuffle();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void NewDeck()
    {
        deck.Capacity = 52;
        deck.Clear();
        for (uint i = 0; i < 4; i++)
        {
            for (uint j = 0; j < 13; j++)
            {
                deck.Add((i * 13) + j);
            }
        }
    }

    private void Shuffle()
    {
        for (int i = 0; i < deck.Count*10; i++)
        {
            int j = Random.Range(0, deck.Count);
            uint temp = deck[i];
            deck[i] = deck[j];
            deck[j] = temp;
        }
    }

    public uint DealCard()
    {
        if (deck.Count <= 0)
        {
            NewDeck();
            Shuffle();
        }

        return deck[Random.Range(0, deck.Count)];
    }

    // Helper functions

    public uint GetHandValue(List<uint> hand)
    {
        uint value = 0;
        int aces = 0;

        foreach (uint card in hand)
        {
            uint rank = card >> 2;
            if (rank == 0) // Ace
            {
                aces++;
                value += 11; // Count as 11 initially
            }
            else if (rank >= 10) // Face cards
            {
                value += 10;
            }
            else
            {
                value += rank + 1; // Convert to 1-13 range
            }
        }

        // Adjust for Aces if value exceeds 21
        while (value > 21 && aces > 0)
        {
            value -= 10; // Count Ace as 1 instead of 11
            aces--;
        }

        return value;
    }
}
