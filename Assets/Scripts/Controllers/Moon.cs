using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    public List<float> OrbitPoints;
    public Vector3 offset = Vector3.zero;
    public float radius = 2;
    public float orbitalSpeed = 1f;
    public int currentPoint = 0;
    public int angle = 0;
    public int orbitPoints = 360;

    void Start()
    {
        if (OrbitPoints == null) OrbitPoints = new List<float>();

        for (int i = 0; i < 360; i++)
        {
            OrbitPoints.Add(angle);
            angle = angle + 1;
        }

        planetTransform.position += offset;
    }

    void FixedUpdate()
    {
        OrbitalMotion(radius,orbitalSpeed, orbitPoints);
    }
    public void OrbitalMotion(float radius, float speed, int orbitPoints)
    {
        currentPoint = (currentPoint + 1) % orbitPoints;
        float radians = Mathf.Deg2Rad * OrbitPoints[currentPoint] * speed;
        float xPos = Mathf.Cos(radians);
        float yPos = Mathf.Sin(radians);

        Vector3 endPoint = planetTransform.position + new Vector3(xPos, yPos, 0f) * radius;
        transform.position = endPoint;
    }
}
