using UnityEngine;

public class Dealer : Player
{
    void Start()
    {
        playerID = -1; // Dealer has a unique ID, typically -1
    }

    public void PlayTurn()
    {
        // Dealer plays according to the rules: hits until reaching 17 or higher
        if (CardManager.instance.GetHandValue(hand) < 17)
        {
            Hit();
            return;
        }

        Stand();
    }
}
