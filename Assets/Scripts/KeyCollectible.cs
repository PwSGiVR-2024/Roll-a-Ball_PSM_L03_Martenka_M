using UnityEngine;
public class KeyCollectibles : Collectibles
{
    public override void Collect()
    {
  
    }
    private void OnTriggerEnter(Collider collision)
    {
        obstacle.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

}

