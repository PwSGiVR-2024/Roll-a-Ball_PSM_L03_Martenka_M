using UnityEngine;
using UnityEngine.UI;

public class NPC_Task2 : MonoBehaviour
{
    public GameObject StartTaskPanel;
    public GameObject EndTaskPanel;
    public GameObject ScoreLabel;
    public Text score;
    private MovementController playerController;
    private GameObject NPC_woman;
    private GameObject rewardBlockage;

    private void GetCanTask()
    {
        if (playerController.TaskScore2 < 10)
        {
            StartTaskPanel.SetActive(true);
            ScoreLabel.SetActive(true);
        }
        else if (playerController.TaskScore2 == 10)
        {
            EndTaskPanel.SetActive(true);
            rewardBlockage.gameObject.SetActive(false);
        }
    }
    public void CollectTask()
    {
        score.text = playerController.TaskScore2.ToString();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetCanTask();
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
            if (EndTaskPanel != null)
            {
                EndTaskPanel.SetActive(false);
            }
            if (playerController.TaskScore2 == 10)
            {
                playerController.TaskScore2 = 0;
                BoxCollider boxCollider = NPC_woman.gameObject.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }
                ScoreLabel.SetActive(false);
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NPC_woman = GameObject.FindGameObjectWithTag("NPC_woman");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<MovementController>();
        if (player != null)
        {
            MovementController movementController = player.GetComponent<MovementController>();
            if (movementController != null)
            {
                movementController.PickupTaskObject2 += CollectTask;
            }
        }
        rewardBlockage = GameObject.FindGameObjectWithTag("CanReward");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
