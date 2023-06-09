using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObjectFollow : MonoBehaviour
{
    public GameObject target;
    public float speed = 0.75f;

    public Vector2 minBoundary; // The minimum X and Y for the camera
    public Vector2 maxBoundary; // The maximum X and Y for the camera

    private Vector3 targetPosition;

    void Start()
    {
        this.targetPosition = this.transform.position;
    }
    
    void FixedUpdate()
    {
        if (this.target)
        {
            var targetPos = new Vector3(this.target.transform.position.x, this.transform.position.y, this.transform.position.z);
            targetPos = Vector3.Lerp(this.transform.position, targetPos, this.speed);

            // Limit the camera position to be within the boundaries
            float camHalfHeight = Camera.main.orthographicSize;
            float camHalfWidth = camHalfHeight * Camera.main.aspect;

            float minX = minBoundary.x + camHalfWidth;
            float maxX = maxBoundary.x - camHalfWidth;

            targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);

            this.transform.position = targetPos;
        }
    }
}
