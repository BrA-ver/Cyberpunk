using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    InputReader input;

    [SerializeField] Vector2 mouseSens = new Vector2(0.09f, 0.09f);
    float xRotation, yRotation;

    Transform player;

    private void Awake()
    {
        input = GetComponentInParent<InputReader>();
        player = transform.parent;
    }

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        yRotation = player.eulerAngles.y;
    }

    private void LateUpdate()
    {
        MouseLook();
    }

    void MouseLook()
    {
        Vector2 mouseDelta = input.LookInput;

        // Up-Down Look
        xRotation -= mouseDelta.y * mouseSens.x;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Left-Right Look
        yRotation += mouseDelta.x * mouseSens.y;

        player.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}
