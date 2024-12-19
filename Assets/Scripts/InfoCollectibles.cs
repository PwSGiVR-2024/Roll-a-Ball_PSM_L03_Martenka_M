using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoCollectibles : Collectibles
{
    public GameObject info;
    public override void Collect()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        info.gameObject.SetActive(true);
    }
    private void OnTriggerExit(Collider collision)
    {
        info.gameObject.SetActive(false);
    }
}

