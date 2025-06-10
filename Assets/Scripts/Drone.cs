using UnityEngine;

public class Drone : MonoBehaviour
{
    [Header("Speed & Rotation")]
    public float minSpeed = 1f;
    public float maxSpeed = 5f;
    public float rotationSpeed = 180f;

    [Header("Distance")]
    public float minDistance = 10f;
    public float maxDistance = 60f;

    private float moveSpeed;
    private float moveDistance;

    private Vector3 startPoint;
    private Vector3 endPoint;
    private Vector3 moveDirection;

    private bool movingToEnd = true;
    private bool isRotating = false;
    private float rotatedAngle = 0f;

    void Start()
    {
        // Random speed and distance
        moveSpeed = Random.Range(minSpeed, maxSpeed);
        moveDistance = Random.Range(minDistance, maxDistance);

        // Random Y rotation at start
        float startYAngle = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0f, startYAngle, 0f);

        // Determine move direction based on initial facing
        moveDirection = new Vector3(transform.forward.x, 0f, transform.forward.z).normalized;

        // Setup patrol path
        startPoint = transform.position;
        endPoint = startPoint + moveDirection * moveDistance;
    }

    void Update()
    {
        if (isRotating)
        {
            RotateDrone();
        }
        else
        {
            MoveDrone();
        }
    }

    void MoveDrone()
    {
        Vector3 target = movingToEnd ? endPoint : startPoint;
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            isRotating = true;
            rotatedAngle = 0f;
        }
    }

    void RotateDrone()
    {
        float step = rotationSpeed * Time.deltaTime;

        transform.Rotate(0f, step, 0f, Space.World); // Y-axis rotation
        rotatedAngle += step;

        if (rotatedAngle >= 180f)
        {
            float overshoot = rotatedAngle - 180f;
            transform.Rotate(0f, -overshoot, 0f, Space.World);
            movingToEnd = !movingToEnd;
            isRotating = false;

            // Recalculate path with flat forward
            moveDirection = new Vector3(transform.forward.x, 0f, transform.forward.z).normalized;
            startPoint = transform.position;
            endPoint = startPoint + moveDirection * moveDistance;

            // Re-lock drone's rotation to flat
            Vector3 forward = transform.forward;
            forward.y = 0f;
            if (forward != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
        }
    }
}
