using CodiceApp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public List<float> radarPoints;
    public List<float> powerups;
    public Transform enemyTransform;
    public SpriteRenderer playerArt;
    public GameObject bombPrefab;
    public GameObject powerupPrefab;
    public Transform bombsTransform;
    public Vector3 offset = Vector3.zero;
    public float speed = 0.1f;
    public float maxSpeed = 10f;
    public float acceleration = 0.0001f;
    public float radius = 3;
    public float timer = 0.1f;
    public int powerupNumber = 2;
    public int currentPoint = 0;
    public int currentPowerup = 0;
    public int angle = 0;
    public int powerupAngle = 360;
    Vector3 velocity = new Vector3(0, 0, 0);
    Vector3 distance = Vector3.zero;

    private void Start()
    {
        if (radarPoints == null) radarPoints = new List<float>();

        for (int i = 0; i < 8; i++)
        {
            radarPoints.Add(angle);
            angle = angle + 45;
        }

        transform.position += offset;

        if (powerups == null) powerups = new List<float>();

        for (int i = 0; i < powerupNumber; i++)
        {
            powerups.Add(powerupAngle);
            powerupAngle = powerupAngle - (360 / powerupNumber);
        }
        timer = 11;
    }
    void FixedUpdate()
    {
        PlayerMovement();
        HitDetection();
        timer = timer + 1 * Time.deltaTime;
        //EnemyRadar(radius, 8);
        //SpawnPowerups(radius, powerupNumber);
    }
    public void SpawnPowerups(float radius, int numberOfPowerups)
    {
        currentPowerup = (currentPowerup + 1) % powerups.Count;
        float radians = Mathf.Deg2Rad * powerups[currentPowerup];
        float xPos = Mathf.Cos(radians);
        float yPos = Mathf.Sin(radians);

        Vector3 endPoint = transform.position + new Vector3(xPos, yPos, 0f) * radius;
        Instantiate(powerupPrefab, endPoint, Quaternion.identity);
    }
    public void EnemyRadar(float radius, int circlePoints)
    {
        currentPoint = (currentPoint + 1) % radarPoints.Count;
        float radians = Mathf.Deg2Rad * radarPoints[currentPoint];
        float xPos = Mathf.Cos(radians);
        float yPos = Mathf.Sin(radians);

        Vector3 endPoint = transform.position + new Vector3(xPos, yPos, 0f) * radius;
        distance = enemyTransform.position - transform.position;

        if (distance.magnitude < radius)
        {
            Debug.DrawLine(transform.position, endPoint, Color.red);
        }
        else
        {
            Debug.DrawLine(transform.position, endPoint, Color.green);
        }
    }

    public void HitDetection()
    {
        distance = enemyTransform.position - transform.position;
        if (distance.magnitude < 1)
        {
            timer = 0f;
            maxSpeed = 5;
        }
        playerArt.color = Color.Lerp(Color.red, Color.white, timer * 0.2f);
        maxSpeed = Mathf.Lerp(5, 10, timer * 0.2f);
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
