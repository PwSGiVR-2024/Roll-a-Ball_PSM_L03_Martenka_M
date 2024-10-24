using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{
    public Text scoreText;
    public Text winText;
    public int score;
    Rigidbody m_Rigidbody;
    public float m_Thrust = 2f;
    public int collects;
    public GameObject WinButton;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "collectible")
        {
            score += 1;
            scoreText.text = "Score: " + score;
            other.gameObject.SetActive(false);
            Debug.Log("+PUNKT! Wynik = " + score);
            if (score == collects)
            {
                winText.gameObject.SetActive(true);
                print("Zdoby³eœ wszystkie punkty!");
                WinButton.gameObject.SetActive(true);
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

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            m_Rigidbody.AddForce(Vector3.forward * m_Thrust);
        }
        if (Input.GetKey("s"))
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            m_Rigidbody.AddForce(new Vector3(0,0,-1) * m_Thrust);
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
}
