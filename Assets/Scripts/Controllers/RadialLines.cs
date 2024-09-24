using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialLines : MonoBehaviour
{
    public Vector3 offset = Vector3.zero;
    public float radius = 3f;
    public List<float> angles;
    private int currentAngle = 0;
    public float delayInSeconds = 0.5f;
    private float elapsedTime = 0;

    private void Start()
    {
        if (angles == null) angles = new List<float>();
        
        for (int i = 0; i < 10; i++)
        {
            angles.Add(Random.value * 360);
        }

        transform.position += offset;
    }


    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > delayInSeconds)
        {
            currentAngle = (currentAngle + 1) % angles.Count;
        }

        float radians = Mathf.Deg2Rad * angles[currentAngle];
        float xPos = Mathf.Cos(radians);
        float yPos = Mathf.Sin(radians);

        Vector3 endPoint = transform.position + new Vector3(xPos, yPos, 0f) * radius;

        Debug.DrawLine(transform.position, endPoint, Color.magenta);
    }
}
