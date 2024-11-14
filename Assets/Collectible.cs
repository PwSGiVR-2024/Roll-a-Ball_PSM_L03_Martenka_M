using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    AudioSource collect;
    bool collect_play;
    bool collect_ToggleChange;

    void collect_sound()
    {
        //Check to see if you just set the toggle to positive
        if (collect_play == true && collect_ToggleChange == true)
        {
            //Play the audio you attach to the AudioSource component
            collect.Play();
            //Ensure audio doesn’t play more than once
            collect_ToggleChange = false;
        }
        //Check if you just set the toggle to false
        if (collect_play == false && collect_ToggleChange == true)
        {
            //Stop the audio
            collect.Stop();
            //Ensure audio doesn’t play more than once
            collect_ToggleChange = false;
        }
    }
        // Start is called before the first frame update
        void Start()
    {
        collect = GetComponent<AudioSource>();
        collect_play = true;
    }
    
        /*private void OnCollisionEnter(Collision collision)
        {
            collision.gameObject.GetComponent<MovementController>().score += 1;
            gameObject.SetActive(false);

        }*/
        /*private void OnTriggerEnter(Collider other)
        {
            other.gameObject.GetComponent<MovementController>().score += 1;
            gameObject.SetActive(false);
            Debug.Log("+PUNKT! Wynik = " + other.gameObject.GetComponent<MovementController>().score);
            if(other.gameObject.GetComponent<MovementController>().score == 9)
            {
                print("Zdoby³eœ wszystkie punkty!");
            }
        }*/

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(new Vector3(20, 20, 0) * Time.deltaTime);
        }
    }

