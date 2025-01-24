using UnityEngine;
public class KeyCollectibles : Collectibles
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<MovementController>() != null)
        {
            collision.gameObject.GetComponent<MovementController>().CollectKey();
            PlayCollectSound();
        }
        obstacle.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

}

