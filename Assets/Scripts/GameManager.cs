using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public uint turn;
    public uint playerCount = 2; // Default to 2 players, can be changed as needed
    public List<int> playerIDs = new List<int>(); // List to hold player IDs
    public List<uint> playerHandValues = new List<uint>(); // List to hold player hand values
    public List<bool> playerStood = new List<bool>(); // Track if players have stood

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        turn = 0; // Initialize turn to 0 for the first player
    }

    public void NewGame()
    {
        turn = 0; // Reset turn for a new game
        playerIDs.Clear(); // Clear previous player IDs
        playerHandValues.Clear(); // Clear previous hand values

        // Initialize player IDs and hand values
        for (int i = -1; i <= 0; i++)
        {
            playerIDs.Add(i);
            playerHandValues.Add(0); // Initialize hand value to 0 for each player
        }
    }

    public void Hit(int playerID, uint handValue)
    {
        if (handValue > 21)
        {
            Bust(playerID, handValue);
        }
        else
        {
            playerHandValues[playerIDs.IndexOf(playerID)] = handValue; // Update the player's hand value
            turn = (turn + 1) % playerCount; // Move to the next player's turn
        }
    }

    private bool AllPlayersStood()
    {
        // Check if all players have stood
        foreach (bool stood in playerStood)
        {
            if (!stood)
            {
                return false; // If any player has not stood, return false
            }
        }
        return true; // All players have stood
    }

    public void Stand(int playerID, uint handValue)
    {
        // Change the player's hand value to indicate they have stood
        playerHandValues[playerIDs.IndexOf(playerID)] = handValue;
        // Move to the next player's turn
        turn = (turn + 1) % playerCount;

        // Check if all players have stood, if so, determine the winner
        if (AllPlayersStood())
        {
            DetermineWinner();
        }
    }

    public void Bust(int playerID, uint handValue)
    {
        // Handle bust logic for the player
        playerHandValues[playerIDs.IndexOf(playerID)] = 0; // Set hand value to 0 for bust
        playerStood[playerIDs.IndexOf(playerID)] = true; // Mark player as stood after bust
        turn = (turn + 1) % playerCount; // Move to the next player's turn

        // Check if all players have stood, if so, determine the winner
        if (AllPlayersStood())
        {
            DetermineWinner();
        }
    }

    public void DetermineWinner()
    {
        // Logic to determine the winner based on player hand values
        uint highestValue = 0;
        List<int> winners = new List<int>();
        for (int i = 0; i < playerIDs.Count-1; i++)
        {
            if (playerHandValues[i] > highestValue && playerHandValues[i] <= 21)
            {
                highestValue = playerHandValues[i];
                winners.Clear();
                winners.Add(playerIDs[i]);
            }
            else if (playerHandValues[i] == highestValue && playerHandValues[i] <= 21)
            {
                winners.Add(playerIDs[i]);
            }
        }

        // Handle the case where there are multiple winners or no valid hands
        if (winners.Count > 0)
        {
            Debug.Log("Winners: " + string.Join(", ", winners));
        }
        else
        {
            Debug.Log("No valid hands, no winner.");
        }
    }
}
