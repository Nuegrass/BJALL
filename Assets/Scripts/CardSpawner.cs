using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    // This variable is in reference to the currently attached card prefab
    public GameObject cardPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 4; i++) {
            Vector2 pos = new Vector2(i * 2.0f, 0 );
            Instantiate(cardPrefab, pos, Quaternion.identity);
            Debug.Log("Card " + i + " spawned at position: " + pos);
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
