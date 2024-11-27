using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
   
    public int score;
    Rigidbody m_Rigidbody;
    public float m_Thrust = 2f;
    public event Action pickupEvent;
    public event Action finishLevelEvent;

    public void CollectScore()
    {
        // Zwiêksz wynik i zaktualizuj UI
        score += 1;

        pickupEvent?.Invoke();

        Debug.Log("+PUNKT! Wynik = " + score);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "finish")
        {
            finishLevelEvent?.Invoke();
        }
    }
    
    private void Movement()
    {

        if (Input.GetKey("w"))
        {
            m_Rigidbody.AddForce(Vector3.forward * m_Thrust);
        }
        if (Input.GetKey("s"))
        {
            m_Rigidbody.AddForce(new Vector3(0, 0, -1) * m_Thrust);
        }
        if (Input.GetKey("d"))
        {
            m_Rigidbody.AddForce(new Vector3(1, 0, 0) * m_Thrust);
        }
        if (Input.GetKey("a"))
        {
            m_Rigidbody.AddForce(new Vector3(-1, 0, 0) * m_Thrust);
        }
    }

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    } 
}
