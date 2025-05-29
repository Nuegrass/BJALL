using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<uint> hand = new List<uint>();
    public int money = 0;
    public int playerID;

    void Start()
    {
        playerID = 0; // Player ID can be set to a unique value, e.g., 0 for the first player
    }

    public void Hit()
    {
        uint newCard = CardManager.instance.DealCard();
        hand.Add(newCard);

        uint handValue = CardManager.instance.GetHandValue(hand);
        GameManager.instance.Hit(playerID, handValue);
    }

    public void Stand()
    {
        uint handValue = CardManager.instance.GetHandValue(hand);
        GameManager.instance.Stand(playerID, handValue);
    }
}
