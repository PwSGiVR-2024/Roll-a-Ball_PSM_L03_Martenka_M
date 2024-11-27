using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text scoreText; // Referencja do UI Text
    private MovementController playerController;


    private void UpdateScore()
    {
        if (playerController != null)
        {
            // Aktualizuj tekst z wynikiem
            scoreText.text = "Score: " + playerController.score;
        }
    }
    // Start is called once before the first execution of Update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<MovementController>();

        playerController.pickupEvent += UpdateScore;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }
}
