using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Transform target;
    public int speed;

    // LineRenderer component for drawing orbit trajectory
    private LineRenderer lineRenderer;
    private List<Vector3> orbitPoints = new List<Vector3>();

    void Start()
    {
        // Initialize LineRenderer component
        // lineRenderer = gameObject.AddComponent<LineRenderer>();
        // lineRenderer.positionCount = 0;
        // lineRenderer.startWidth = 0.05f;
        // lineRenderer.endWidth = 0.05f;
        // lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        // lineRenderer.startColor = Color.white;
        // lineRenderer.endColor = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate around the target (sun)
        transform.RotateAround(target.position, Vector3.up, speed * Time.deltaTime);

        // Add current position to the orbitPoints list
        // orbitPoints.Add(transform.position);

        // // Update orbit trajectory
        // UpdateOrbitTrajectory();
    }

    // Function to update orbit trajectory
    // void UpdateOrbitTrajectory()
    // {
    //     // Set the number of points to be equal to the number of elements in orbitPoints
    //     lineRenderer.positionCount = orbitPoints.Count;

    //     // Update the positions of LineRenderer based on orbitPoints
    //     for (int i = 0; i < orbitPoints.Count; i++)
    //     {
    //         lineRenderer.SetPosition(i, orbitPoints[i]);
    //     }
    // }
}
