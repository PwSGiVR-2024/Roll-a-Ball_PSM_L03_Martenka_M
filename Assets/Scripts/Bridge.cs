using UnityEngine;

public class Bridge : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameManager gameManager;
    public GameObject bridge;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.currentScore == gameManager.maxScore)
        {
            bridge.SetActive(true);
        }
    }
}
