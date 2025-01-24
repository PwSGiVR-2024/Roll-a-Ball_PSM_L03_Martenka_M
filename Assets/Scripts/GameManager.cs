using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int maxScore;
    private int currentScore = 0;
    [SerializeField]
    private int life;
    private int sceneID;
    private GameObject finish;
    private AudioSource LostLifeSound;

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
                movementController.PickupEvent += HandleCollectiblePickedUp;
                movementController.LostLifeEvent += HandleLifes;
            }
        }
        else
        {
            Debug.LogError("Nie znaleziono gracza w scenie!");
        }

        finish = GameObject.FindGameObjectWithTag("finish");
        if (finish != null)
        {
            finish.SetActive(false);
        }
        else
        {
            Debug.LogError("Nie znaleziono obiektu 'finish' w scenie!");
        }

        Scene currentScene = SceneManager.GetActiveScene();
        sceneID = currentScene.buildIndex;

        life = 3;
        LostLifeSound = GameObject.Find("LostLifeSound").GetComponent<AudioSource>();
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

    private void HandleLifes()
    {
        
        life--;
        if (LostLifeSound != null)
        {
            LostLifeSound.Play();
        }
        Debug.Log($"Gracz stracił życie. Pozostałe życia: {life}");

        if (life <= 0)
        {
            Debug.Log("brak żyć");
            SceneManager.LoadScene(sceneID);
        }
    }


    public void LoadNextLevel()
    {
        SceneManager.LoadScene(sceneID + 1);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadEnding()
    {
        SceneManager.LoadScene(4);
    }
}
