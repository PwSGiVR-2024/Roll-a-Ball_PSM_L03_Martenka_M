using System;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public int score;
    public int key;
    public int life = 3;
    public int TaskScore;
    public int TaskScore2;
    Rigidbody m_Rigidbody;
    public float m_Thrust = 5f;
    public event Action PickupEvent;
    public event Action LostLifeEvent;
    public event Action PickupKeyEvent;
    public event Action PickupTaskObject;
    public event Action PickupTaskObject2;
    public float jumpForce = 5.0f;
    private bool isGrounded;
    private Transform cameraTransform;
    private Vector3 StartPosition;
    private float maxPosition = -10f;

    void Start()
    {
        // Pobierz Rigidbody i transformacjê kamery
        m_Rigidbody = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
        StartPosition = transform.position;
    }

    public void OutOfBounds()
    {
        if (transform.position.y < maxPosition)
        {
            life -= 1;
            transform.position = StartPosition;
            LostLifeEvent?.Invoke();
        }
    }
    public void CollectScore()
    {
        score += 1;
        PickupEvent?.Invoke();
        Debug.Log("+PUNKT! Wynik = " + score);
    }
    public void CollectTaskScore()
    {
        TaskScore += 1;
        PickupTaskObject?.Invoke();
    }
    public void CollectTaskScore2()
    {
        TaskScore2 += 1;
        PickupTaskObject2?.Invoke();
    }
    public void CollectKey()
    {
        key += 1;
        PickupKeyEvent?.Invoke();
        Debug.Log("+KLUCZ" + key);
    }
    public void CollectBad()
    {
        life -= 1;
        LostLifeEvent?.Invoke();
        Debug.Log("Gracz straci³ ¿ycie. Pozosta³e ¿ycia:" + life);
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
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            life -= 1;
            transform.position = StartPosition;
            LostLifeEvent?.Invoke();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        Movement();
        OutOfBounds();
    }
}
