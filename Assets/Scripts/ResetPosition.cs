using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour { 

    private Vector3 StartPosition;
    public float maxPosition = -10f;

    private void RestorePosition()
    {
        transform.position = StartPosition;
    }

    void Start()
    {
        StartPosition = transform.position;
    }

    void Update()
    {
        if (transform.position.y < maxPosition)
        {
            RestorePosition();
        }
    }
}
