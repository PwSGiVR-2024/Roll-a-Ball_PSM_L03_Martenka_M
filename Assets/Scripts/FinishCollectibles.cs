using System;
using UnityEngine;
using UnityEngine.UI;

public class FinishCollectibles : Collectibles
{
    public Text winText;
    public GameObject WinButton;
    public event Action finishLevelEvent;
  
    private void OnTriggerEnter(Collider collision)
    {
        finishLevelEvent?.Invoke();
        winText.gameObject.SetActive(true);
        print("Zdobyłeś wszystkie punkty!");
        WinButton.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
}

