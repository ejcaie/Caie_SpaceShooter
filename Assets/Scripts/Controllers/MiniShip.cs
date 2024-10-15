using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MiniShip : MonoBehaviour
{
    public List<float> radar;
    public Vector3 direction = new Vector3();
    public Vector3 distance = Vector3.zero;
    public Transform playerTransform;
    public Transform target;
    public float speed = 0f;
    public float angle = 0f;
    public float radarLength = 2f;
    public int currentPoint = 0;
    public bool following = false;

    private void Start()
    {
        speed = Random.Range(3, 8);
        if (radar == null) radar = new List<float>();

        for (int i = 0; i < 360; i++)
        {
            radar.Add(angle);
            angle = angle + 1;
        }
        currentPoint = Random.Range(0, 360);
    }

    private void Update()
    {
        distance = playerTransform.position - transform.position;
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
        Debug.DrawLine(transform.position, endPoint, Color.green);
        if (distance.magnitude < radarLength) following = true;
    }

    public void MiniMovement()
    {
        direction = target.position - transform.position;
        transform.position = transform.position + direction.normalized * speed * Time.deltaTime;
    }
}
