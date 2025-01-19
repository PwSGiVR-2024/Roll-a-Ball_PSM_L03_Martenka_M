using UnityEngine;

public class InfoCollectibles : Collectibles
{
    public GameObject info;
    /*public override void Collect()
    {
        
    }*/

    private void OnTriggerEnter(Collider collision)
    {
        info.gameObject.SetActive(true);
    }
    private void OnTriggerExit(Collider collision)
    {
        info.gameObject.SetActive(false);
    }
}

