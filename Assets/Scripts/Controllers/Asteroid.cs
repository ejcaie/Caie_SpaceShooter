using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed = 0.05f;
    public float arrivalDistance = 0.2f;
    public float maxFloatDistance = 2f;
    Vector3 movePoint = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        PickPoint();
    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();
        transform.position = transform.position + movePoint * moveSpeed * Time.deltaTime;
        if (transform.position.magnitude - movePoint.magnitude > arrivalDistance) PickPoint();
    }
    public void AsteroidMovement()
    {
        Vector3.Lerp(transform.position, movePoint, moveSpeed);
    }
    public void PickPoint()
    {
        movePoint.x = Random.Range(-maxFloatDistance, maxFloatDistance);
        movePoint.y = Random.Range(-maxFloatDistance, maxFloatDistance);
    }
}
