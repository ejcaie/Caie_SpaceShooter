using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public float speed = 0.1f;
    public float maxSpeed = 10f;
    public float acceleration = 0.0001f;
    Vector3 velocity = new Vector3(0, 0, 0);

    void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            while (speed < maxSpeed) speed = speed + acceleration;
            velocity.y = speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            while (speed < maxSpeed) speed = speed + acceleration;
            velocity.x = -speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            while (speed < maxSpeed) speed = speed + acceleration;
            velocity.y = -speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            while (speed < maxSpeed) speed = speed + acceleration;
            velocity.x = speed;
        }
        transform.position = transform.position + velocity * Time.deltaTime;
        if (Input.anyKeyDown == false)
        {
            while (speed > 0.1) speed = speed - acceleration;
            if (speed <= 0.1) velocity = Vector3.zero;
        }
    }
}
