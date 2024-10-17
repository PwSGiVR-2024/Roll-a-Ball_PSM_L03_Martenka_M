using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 start;
    public GameObject player;
    public MovementController playerController;
    // Start is called before the first frame update
    void Start()
    {
      start = (player.transform.position - transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (player.transform.position - start);
    }
}
