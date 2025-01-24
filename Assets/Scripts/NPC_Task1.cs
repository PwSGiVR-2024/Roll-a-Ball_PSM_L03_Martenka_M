using UnityEngine;
using UnityEngine.UI;

public class NPC_Task1 : MonoBehaviour
{
    public GameObject StartTaskPanel;
    public GameObject EndTaskPanel;
    public GameObject ScoreLabel;
    public Text score;
    private GameObject Rydze;
    private MovementController playerController;
    private GameObject Key;
    private GameObject NPC_key;

    private void GetKeyTask()
    {
        if (playerController.TaskScore < 5)
        {
            StartTaskPanel.SetActive(true);
            ScoreLabel.SetActive(true);
            Rydze.SetActive(true);
        }
        else if (playerController.TaskScore == 5)
        {
            EndTaskPanel.SetActive(true);
            
        }
    }
    public void CollectTask()
    {
        score.text = playerController.TaskScore.ToString();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetKeyTask();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<MovementController>() != null)
        {   
            if (StartTaskPanel != null)
            {
                StartTaskPanel.SetActive(false);
            }
            if(EndTaskPanel != null)
            {
                EndTaskPanel.SetActive(false);
            }
            if(playerController.TaskScore == 5)
            {
                playerController.TaskScore = 0;
                score.text = null;
                BoxCollider boxCollider = NPC_key.gameObject.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
                BoxCollider keyCollider = Key.gameObject.GetComponent<BoxCollider>();
                if (keyCollider != null)
                {
                    keyCollider.enabled = true;
                }
                ScoreLabel.SetActive(false);
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NPC_key = GameObject.FindGameObjectWithTag("NPC_key");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<MovementController>();
        if (player != null)
        {
            MovementController movementController = player.GetComponent<MovementController>();
            if (movementController != null)
            {
                movementController.PickupTaskObject += CollectTask;
            }
        }
        Rydze = GameObject.FindGameObjectWithTag("rydz");
        if (Rydze != null)
        {
            Rydze.SetActive(false);
        }
        Key = GameObject.FindGameObjectWithTag("key");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
