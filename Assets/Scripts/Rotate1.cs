using UnityEngine;

public class Rotate1 : MonoBehaviour
{
    public float rotationSpeed = 30f;

    private Vector3 initialPosition;

    void Start()
    {
        // Record the starting position
        initialPosition = transform.position;
    }

    void Update()
    {
       

        // Rotate smoothly around Y-axis
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.Self);

        // Reset position to lock it in place
        transform.position = initialPosition;
    }
}
