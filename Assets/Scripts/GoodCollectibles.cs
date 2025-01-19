using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodCollectibles : Collectibles
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<MovementController>() != null)
        {
            collision.gameObject.GetComponent<MovementController>().CollectScore();
            PlayCollectSound();
            gameObject.SetActive(false);
        }
    }
   /* public override void Collect()
    {
        PlayCollectSound();
        gameObject.SetActive(false);
    }*/
}
