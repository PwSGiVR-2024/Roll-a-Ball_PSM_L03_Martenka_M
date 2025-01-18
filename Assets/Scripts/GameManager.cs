using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int maxScore;
    private int currentScore = 0;
    public Text winText;
    public GameObject WinButton;
    private GameObject finish;

    void Start()
    {
        // Znajdź collectibles i ustal maxScore
        GameObject[] collectibles = GameObject.FindGameObjectsWithTag("collectible");
        maxScore = collectibles.Length;

        // Subskrybuj event w MovementController
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            MovementController movementController = player.GetComponent<MovementController>();
            if (movementController != null)
            {
                movementController.pickupEvent += HandleCollectiblePickedUp;
            }
        }
        else
        {
            Debug.LogError("Nie znaleziono gracza w scenie!");
        }

        // Upewnij się, że finish jest domyślnie nieaktywny
        finish = GameObject.FindGameObjectWithTag("finish");
        if (finish != null)
        {
            finish.SetActive(false);
        }
        else
        {
            Debug.LogError("Nie znaleziono obiektu 'finish' w scenie!");
        }
    }

    private void HandleCollectiblePickedUp()
    {
        currentScore++;

        Debug.Log($"GameManager: Zebrano punkt! {currentScore}/{maxScore}");

        if (currentScore >= maxScore)
        {
            Debug.Log("GameManager: Wszystkie punkty zebrane!");

            if (finish != null)
            {
                finish.SetActive(true);
                Debug.Log("Obiekt 'finish' został aktywowany.");
            }
            else
            {
                Debug.LogError("Obiekt 'finish' jest null i nie może zostać aktywowany.");
            }
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(2);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadEnding()
    {
        SceneManager.LoadScene(3);
    }
}
