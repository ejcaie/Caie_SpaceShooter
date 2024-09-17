using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public float speed = 10f;
    Vector3 velocity = new Vector3(0, 0, 0);

    void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            velocity.y = speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity.x = -speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity.y = -speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity.x = speed;
        }
        transform.position = transform.position + velocity * Time.deltaTime;
        velocity = Vector3.zero;
    }
}
