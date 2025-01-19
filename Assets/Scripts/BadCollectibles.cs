using UnityEngine;
public class BadCollectibles : Collectibles
{
    /*public override void Collect()
    {

    }*/
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<MovementController>() != null)
        {
            collision.gameObject.GetComponent<MovementController>().CollectBad();
        }
        gameObject.SetActive(false);
    }

}

