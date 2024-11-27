using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private int maxScore;
    private int currentScore = 0;
    public GameObject finishflag;
    public Text winText;
    public GameObject WinButton;
    public GameObject bridge;
    Scene currentScene;

    void Start()
    {
        // Znajdü collectibles i ustal maxScore
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
                movementController.finishLevelEvent += Finish;
            }
        }
        else
        {
            Debug.LogError("Nie znaleziono gracza w scenie!");
        }
        currentScene = SceneManager.GetActiveScene();
    }

    private void HandleCollectiblePickedUp()
    {
        currentScore++;

        Debug.Log($"GameManager: Zebrano punkt! {currentScore}/{maxScore}");

        // Sprawdü, czy gracz zebra≥ wszystkie punkty
        if (currentScore >= maxScore)
        {
            Debug.Log("GameManager: Wszystkie punkty zebrane!");
        }
        if (currentScene.buildIndex == 2 && currentScore == maxScore)
        {
            bridge.SetActive(true);
        }
        if (currentScore == maxScore)
        {
            if (currentScene.buildIndex == 2)
            {
                bridge.SetActive(true);
            }
            Debug.Log("Warunek spe≥niony, uruchamiam Finish()");
            finishflag.SetActive(true);
        }
    }
    private void Finish()
    {
        winText.gameObject.SetActive(true);
        print("Zdoby≥eú wszystkie punkty!");
        WinButton.gameObject.SetActive(true);
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