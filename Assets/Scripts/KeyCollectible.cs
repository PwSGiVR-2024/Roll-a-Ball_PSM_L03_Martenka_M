using UnityEngine;
public class KeyCollectibles : Collectibles
{
    public GameObject bridge;
    public override void Collect()
    {
  
    }
    private void OnTriggerEnter(Collider collision)
    {
        bridge.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}

