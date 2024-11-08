using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Goal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public MovementController movementcontroller;
    public bool isGoal = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            movementcontroller.GoalScored();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
