using UnityEngine;

public class InfoCollectibles : Collectibles
{
    public GameObject info;

    private void OnTriggerEnter(Collider collision)
    {
        info.gameObject.SetActive(true);
    }
    private void OnTriggerExit(Collider collision)
    {
        info.gameObject.SetActive(false);
    }
}

