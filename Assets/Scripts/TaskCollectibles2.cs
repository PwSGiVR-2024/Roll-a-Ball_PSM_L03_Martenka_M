using UnityEngine;

public class TaskCollectibles2 : Collectibles
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<MovementController>() != null)
        {
            collision.gameObject.GetComponent<MovementController>().CollectTaskScore2();
        }
        PlayCollectSound();
        gameObject.SetActive(false);
    }
}
