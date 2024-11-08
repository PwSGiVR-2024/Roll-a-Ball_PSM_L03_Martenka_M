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
        // Zapisz pocz¹tkow¹ pozycjê obiektu
        StartPosition = transform.position;
    }

    void Update()
    {
        // SprawdŸ, czy obiekt spad³ poni¿ej okreœlonego poziomu
        if (transform.position.y < maxPosition)
        {
            // Przywróæ obiekt do pocz¹tkowej pozycji
            RestorePosition();
        }
    }
}
