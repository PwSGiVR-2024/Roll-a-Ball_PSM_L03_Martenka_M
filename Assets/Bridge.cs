using UnityEngine;

public class Bridge : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public MovementController movementcontroller;
    public GameObject bridge;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (movementcontroller.score == movementcontroller.maxScore)
        {
            bridge.SetActive(true);
        }
    }
}
