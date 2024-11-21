using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 start;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        start = (player.transform.position - transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (player.transform.position - start);
    }
}
