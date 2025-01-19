using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text scoreText; // Referencja do UI Text
    public Text keyText;
    private MovementController playerController;
    private int max;
    private int keymax;


    private void UpdateScore()
    {
        if (playerController != null)
        {
            // Aktualizuj tekst z wynikiem
            scoreText.text = "Score: " + playerController.score + "/" + max;
            keyText.text = "Keys: " + playerController.key + "/" + keymax;

        }
    }
    // Start is called once before the first execution of Update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<MovementController>();

        playerController.PickupEvent += UpdateScore;
        
        GameObject[] collectibles = GameObject.FindGameObjectsWithTag("collectible");
        max = collectibles.Length;
        
        GameObject[] key = GameObject.FindGameObjectsWithTag("key");
        keymax = key.Length;

        playerController.PickupKeyEvent += UpdateScore;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }
}
