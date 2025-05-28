using System;
using System.Drawing;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public static Sprite[][] cardSpriteSheets = null;
    public SpriteRenderer cardRenderer;

    public int rank;
    public int suit;
    public Boolean hidden;
    public int color;

    void Start()
    {
        if (cardSpriteSheets == null)
            GetSpriteSheets();

        rank = 0;
        suit = 0;
        hidden = false;
        color = 0;

        UpdateSprite();
    }

    void Update()
    {
        UpdateSprite();
    }
    
    // Get the sprite sheet
    private void GetSpriteSheets()
    {
        cardSpriteSheets = new Sprite[5][];
        cardSpriteSheets[0] = Resources.LoadAll<Sprite>("Clubs");
        cardSpriteSheets[1] = Resources.LoadAll<Sprite>("Diamonds");
        cardSpriteSheets[2] = Resources.LoadAll<Sprite>("Hearts");
        cardSpriteSheets[3] = Resources.LoadAll<Sprite>("Spades");
        cardSpriteSheets[4] = Resources.LoadAll<Sprite>("Back");
    }

    public void UpdateSprite()
    {
        if (hidden)
            cardRenderer.sprite = cardSpriteSheets[4][color];
        else
            cardRenderer.sprite = cardSpriteSheets[suit][rank];
    }
}
