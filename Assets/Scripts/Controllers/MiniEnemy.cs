using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniEnemy : MonoBehaviour
{
    public List<float> radar;
    public Vector3 direction = new Vector3();
    public Vector3 distance = Vector3.zero;
    public Transform enemyTransform;
    public Transform target;
    public float speed = 0f;
    public float angle = 0f;
    public float radarLength = 1.5f;
    public int currentPoint = 0;
    public bool following = false;

    private void Start()
    {
        speed = Random.Range(16, 19);
        if (radar == null) radar = new List<float>();

        for (int i = 0; i < 180; i++)
        {
            radar.Add(angle);
            angle = angle + 2;
        }
        currentPoint = Random.Range(0, 180);
    }

    private void Update()
    {
        distance = enemyTransform.position - transform.position;
        if (following == false) RadarLines();
        if (following) MiniMovement();
    }

    public void RadarLines()
    {
        currentPoint = (currentPoint + 1) % radar.Count;
        float radians = Mathf.Deg2Rad * radar[currentPoint];
        float xPos = Mathf.Cos(radians);
        float yPos = Mathf.Sin(radians);

        Vector3 endPoint = transform.position + new Vector3(xPos, yPos, 0f) * radarLength;
        Debug.DrawLine(transform.position, endPoint, Color.red);
        if (distance.magnitude < radarLength) following = true;
    }

    public void MiniMovement()
    {
        direction = target.position - transform.position;
        transform.position = transform.position + direction.normalized * speed * Time.deltaTime;
    }
}
