using System;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public int score;
    public int key;
    Rigidbody m_Rigidbody;
    public float m_Thrust = 5f;
    public event Action PickupEvent;
    public event Action PickupKeyEvent;
    public float jumpForce = 5.0f;
    private bool isGrounded;
    private Transform cameraTransform;

    void Start()
    {
        // Pobierz Rigidbody i transformacj� kamery
        m_Rigidbody = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
    }

    public void CollectScore()
    {
        score += 1;
        PickupEvent?.Invoke();
        Debug.Log("+PUNKT! Wynik = " + score);
    }
    public void CollectKey()
    {
        key += 1;
        PickupKeyEvent?.Invoke();
        Debug.Log("+KLUCZ" + key);
    }
    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = forward * vertical + right * horizontal;

        m_Rigidbody.AddForce(moveDirection * m_Thrust);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            m_Rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
}
