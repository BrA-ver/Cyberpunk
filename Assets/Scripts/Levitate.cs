using UnityEngine;

public class Levitate : MonoBehaviour
{
    public float amplitude;  // Height of the float
    public float speed;      // Lower = slower, smoother float

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Use a smoother curve: Mathf.Sin gives natural ease-in/ease-out at the peaks
        float offsetY = Mathf.Sin(Time.time * speed * Mathf.PI * 2) * amplitude;

        // Apply the float offset
        transform.position = startPos + new Vector3(0f, offsetY, 0f);
    }
}
