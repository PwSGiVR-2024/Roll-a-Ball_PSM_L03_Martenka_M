using UnityEngine;

public class TaskCollectibles : Collectibles
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<MovementController>() != null)
        {
            collision.gameObject.GetComponent<MovementController>().CollectTaskScore();
        }
        PlayCollectSound();
        gameObject.SetActive(false);
    }
}
