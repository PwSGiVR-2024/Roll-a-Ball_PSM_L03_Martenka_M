using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<MovementController>().score += 1;
        gameObject.SetActive(false);
        
    }*/
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<MovementController>().score += 1;
        gameObject.SetActive(false);
        Debug.Log("+PUNKT! Wynik = " + other.gameObject.GetComponent<MovementController>().score);
        if(other.gameObject.GetComponent<MovementController>().score == 9)
        {
            print("Zdoby³eœ wszystkie punkty!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(20,20,0)*Time.deltaTime);  
    }
}
