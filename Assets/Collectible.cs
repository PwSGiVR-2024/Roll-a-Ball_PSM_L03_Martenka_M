using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    AudioSource collect;
    
        // Start is called before the first frame update
        void Start()
        {
        collect =
        GameObject.Find("PickUpSound").GetComponent<AudioSource>();
        }
    
        private void OnTriggerEnter(Collider collision)
        {
            collision.gameObject.GetComponent<MovementController>().CollectScore();
            collect.Play();
            gameObject.SetActive(false);

        }
   
        // Update is called once per frame
        void Update()
        {
            transform.Rotate(new Vector3(20, 20, 0) * Time.deltaTime);
        }
}

