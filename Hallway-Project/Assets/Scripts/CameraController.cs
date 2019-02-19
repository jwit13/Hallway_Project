using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    Vector2 mouseLook;
    Vector2 smoothVector;
    public float sensitivity;
    public float smoothing;

    public float minY;
    public float maxY;
    public static bool menuUp;

    GameObject player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            GameObject.Destroy(gameObject);
        }
        instance = this;
        menuUp = true;

    }

    void Start()
    {
        player = this.transform.parent.gameObject;
    }

    void Update()
    {
        if (menuUp != true)
        {
            Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

            mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
            smoothVector.x = Mathf.Lerp(smoothVector.x, mouseDelta.x, 1f / smoothing);
            smoothVector.y = Mathf.Lerp(smoothVector.y, mouseDelta.y, 1f / smoothing);
            mouseLook += smoothVector;
            mouseLook.y = Mathf.Clamp(mouseLook.y, minY, maxY);

            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
            player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
        }
    }
}
