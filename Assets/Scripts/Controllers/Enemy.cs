using UnityEngine;
using System.Collections;
using UnityEditor.Experimental.GraphView;

public class Enemy : MonoBehaviour
{
    public Vector3 direction = new Vector3();
    public float speed = 1f;
    public float boost = 1f;
    public float timer = 0f;
    public float acceleration = 0.1f;

    private void Start()
    {
        direction.x = Random.Range(-100, 100);
        direction.y = Random.Range(-100, 100);
    }
    private void Update()
    {
        EnemyMovement();
    }

    public void EnemyMovement()
    {
        speed = speed + acceleration;
        if (speed > 20) speed = 20;
        transform.position = transform.position + direction.normalized * speed * boost * Time.deltaTime;

        if (transform.position.x < -22)
        {
            direction.x = -direction.x;
            boost = 1.5f;
        }
        if (transform.position.x > 22)
        {
            direction.x = -direction.x;
            boost = 1.5f;
        }
        if (transform.position.y < -10)
        {
            direction.y = -direction.y;
            boost = 1.5f;
        }
        if (transform.position.y > 10)
        {
            direction.y = -direction.y;
            boost = 1.5f;
        }


        if (boost > 1.1)
        {
            timer = timer + 1 * Time.deltaTime;
            if (timer > 0.5)
            {
                boost = 1;
                timer = 0;
            }
        }
    }
}
