using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform player;
    public float distance = 5f;
    public float mouseSensitivity = 300f;
    private float yrot = 0f;
    private float xrot = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        Cursor.lockState = CursorLockMode.Locked; // Zablokowanie kursora
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yrot += mouseX;
        xrot -= mouseY;
        xrot = Mathf.Clamp(xrot, -90f, 90f);

        Vector3 offset = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(xrot, yrot, 0);
        transform.position = player.position + rotation * offset;
        transform.LookAt(player);
    }
}
