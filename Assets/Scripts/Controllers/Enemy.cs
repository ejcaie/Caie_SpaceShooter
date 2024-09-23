using UnityEngine;
using System.Collections;
using UnityEditor.Experimental.GraphView;

public class Enemy : MonoBehaviour
{
    public Vector3 direction = new Vector3();
    public float speed = 1f;
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
        transform.position = transform.position + direction.normalized * speed * Time.deltaTime;
    }
}
