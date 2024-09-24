using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;
    public int i = -1;

    // Update is called once per frame
    void FixedUpdate()
    {
        DrawConsellation();
        i++;
        if (i >= starTransforms.Count - 1)  i = 0;
    }
    
    public void DrawConsellation()
    {
        Vector3 interpolation = Vector3.Lerp(starTransforms[i].position, starTransforms[i + 1].position, drawingTime);
        Debug.DrawLine(starTransforms[i].position, interpolation, Color.white);
    }
}
