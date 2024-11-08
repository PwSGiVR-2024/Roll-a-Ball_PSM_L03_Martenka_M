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
        // Zapisz pocz�tkow� pozycj� obiektu
        StartPosition = transform.position;
    }

    void Update()
    {
        // Sprawd�, czy obiekt spad� poni�ej okre�lonego poziomu
        if (transform.position.y < maxPosition)
        {
            // Przywr�� obiekt do pocz�tkowej pozycji
            RestorePosition();
        }
    }
}
