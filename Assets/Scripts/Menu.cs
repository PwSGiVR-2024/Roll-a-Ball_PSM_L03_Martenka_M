using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    public GameObject options;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        options.gameObject.SetActive(true);
        menu.gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ExitOptions()
    {
        options.gameObject.SetActive(false);
        menu.gameObject.SetActive(true);
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadSecondLevel()
    {
        SceneManager.LoadScene(2);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
