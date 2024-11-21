using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{
    public GameObject finishflag;
    public Text scoreText;
    public Text winText;
    public int score;
    Rigidbody m_Rigidbody;
    public float m_Thrust = 2f;
    public int maxScore;
    public GameObject WinButton;
    public Goal goal;
    Scene currentScene;
    public event Action pickupEvent;
    public GameObject bridge;


    // Start is called before the first frame update

    /* private void OnTriggerEnter(Collider other)
     {
         if (other.tag == "collectible")
         {
             score += 1;
             scoreText.text = "Score: " + score;
             Collectible collectible = other.GetComponent<Collectible>();
             other.gameObject.SetActive(false);

             Debug.Log("+PUNKT! Wynik = " + score);
             if (currentScene.buildIndex == 1 && score == collects)
             {
                 Finish();
             }
         }

         else if(other.tag == "finish")
         {
             winText.gameObject.SetActive(true);
             print("Zdoby�e� wszystkie punkty!");
             WinButton.gameObject.SetActive(true);
         }
     }*/
    public void CollectScore()
    {
        // Zwi�ksz wynik i zaktualizuj UI
        score += 1;
        /*pickupEvent();*/
        scoreText.text = "Score: " + score;

        Debug.Log("+PUNKT! Wynik = " + score);

        // Sprawd�, czy uko�czono poziom
        if (currentScene.buildIndex == 2 && score == maxScore)
        {
            bridge.SetActive(true);
        }
        if (currentScene.buildIndex == 1 && score == maxScore)
        {
            Finish();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "finish")
        {
            winText.gameObject.SetActive(true);
            print("Zdoby�e� wszystkie punkty!");
            WinButton.gameObject.SetActive(true);
        }
    }
    private void Finish()
    {
        finishflag.SetActive(true);
    }
    public void GoalScored()
    {
        goal.isGoal = true;
        Finish();
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
    private void Movement()
    {

        if (Input.GetKey("w"))
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            m_Rigidbody.AddForce(Vector3.forward * m_Thrust);
        }
        if (Input.GetKey("s"))
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            m_Rigidbody.AddForce(new Vector3(0, 0, -1) * m_Thrust);
        }
        if (Input.GetKey("d"))
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            m_Rigidbody.AddForce(new Vector3(1, 0, 0) * m_Thrust);
        }
        if (Input.GetKey("a"))
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            m_Rigidbody.AddForce(new Vector3(-1, 0, 0) * m_Thrust);
        }
    }

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
        currentScene = SceneManager.GetActiveScene();
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    } 
}
