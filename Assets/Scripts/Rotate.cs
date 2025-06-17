using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 30f; // Degrees per second

    void Update()
    {
        // Rotate smoothly around the Y axis
        transform.Rotate(0f,0f, rotationSpeed * Time.deltaTime);
    }
}
