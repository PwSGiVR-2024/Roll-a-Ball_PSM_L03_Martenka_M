using UnityEngine;
public class KeyCollectibles : Collectibles
{
    public override void Collect()
    {
  
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<MovementController>() != null)
        {
            collision.gameObject.GetComponent<MovementController>().CollectKey();
        }
        obstacle.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

}

