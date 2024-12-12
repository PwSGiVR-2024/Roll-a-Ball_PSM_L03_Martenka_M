using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstrakcyjna klasa Collectibles
public abstract class Collectibles : MonoBehaviour
{
    protected AudioSource collect;
    private float floatSpeed = 0.7f;
    private float floatAmplitude = 0.2f;
    private Vector3 startPosition;
    public abstract void Collect();
    protected void PlayCollectSound()
    {
        if (collect != null)
        {
            collect.Play();
        }
    }
    protected void MovementCollectible()
    {

        transform.Rotate(new Vector3(0, 20, 0) * Time.deltaTime);
        Vector3 newPosition = startPosition;
        newPosition.y += Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = newPosition;
    }
    protected virtual void Start()
    {
        collect = GameObject.Find("PickUpSound").GetComponent<AudioSource>();
        startPosition = transform.position;
    }
    protected virtual void Update()
    {
        MovementCollectible();
    }
}
