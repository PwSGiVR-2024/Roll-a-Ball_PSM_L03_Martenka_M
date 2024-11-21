using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject[] Collectibles;
    public int maxScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Collectibles = GameObject.FindGameObjectsWithTag("collectible");
        maxScore = Collectibles.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
