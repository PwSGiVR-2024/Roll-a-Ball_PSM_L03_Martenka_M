using System;
using UnityEngine;
using UnityEngine.UI;

public class FinishCollectibles : Collectibles
{
    public GameObject endPanel;
    public event Action finishLevelEvent;
  
    private void OnTriggerEnter(Collider collision)
    {
        finishLevelEvent?.Invoke();
        endPanel.gameObject.SetActive(true);
        print("Zdobyłeś wszystkie punkty!");
        Cursor.lockState = CursorLockMode.None;
    }
}

