using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cam;
    public Transform body;

    private float zoom;
    private float zoomMultiplier = 50f;
    private float velocity = 0f;
    private float smoothTime = 0.25f;

    float mouseX;
    Vector3 camPos;
    void Start()
    {
        zoom = cam.fieldOfView;


        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * 100 * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Q)) {
            body.Rotate(Vector3.up * -45);
            // Debug.Log("Camera angle changed");
        } else if (Input.GetKeyDown(KeyCode.E)) {
            body.Rotate(Vector3.up * 45);
            // Debug.Log("Camera angle changed");
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        zoom -= scroll * zoomMultiplier;
        zoom = Mathf.Clamp(zoom, 25f, 90f);
        cam.fieldOfView = Mathf.SmoothDamp(cam.fieldOfView, zoom, ref velocity, smoothTime);
        // if (scroll > 0) {
        //     camPos -= new Vector3(0,1,-1);
        //     cam.transform.position = new Vector3(0, camPos.y, camPos.y);
        //     Debug.Log("Close-up Camera");
        // } else if (scroll < 0) {
        //     camPos += new Vector3(0,1,-1);
        //     cam.transform.position = new Vector3(0, camPos.y, camPos.y);
        //     Debug.Log("Camera away");
        // }
    }

    // public float angleCam() {

    // }
}
