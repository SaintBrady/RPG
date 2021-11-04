using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP_CameraController : MonoBehaviour
{
    private const float Y_ANGLE_MAX = 10f;
    private const float Y_ANGLE_MIN = -12.5f;

    public Transform Target;
    public float Distance = -5.0f;
    public float Max_Distance = -10.0f;
    public float Min_Distance = -2.0f;
    public float X_Sensitivity = 8.0f;
    public float Y_Sensitivity = 4.0f;

    private float _currentX = 0.0f;
    private float _currentY = 0.0f;

    void Start()
    {
        Cursor.visible = true;
    }

    private void Update()
    {
        if(Input.GetButtonUp("Fire2"))
        {
            Cursor.visible = true;
        }
        else if(Input.GetButtonDown("Fire2"))
        {
            Cursor.visible = false;
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            _currentX += Input.GetAxis("Mouse X");
            _currentY += Input.GetAxis("Mouse Y");
            _currentY = Mathf.Clamp(_currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            Distance = Mathf.Clamp(Distance + Input.GetAxis("Mouse ScrollWheel"), Max_Distance, Min_Distance);
        }
    }
    void LateUpdate()
    {
        Vector3 direction = new Vector3(0.0f, 0.0f, -1 * Distance);
        Quaternion rotation = Quaternion.Euler(Y_Sensitivity * _currentY, X_Sensitivity * _currentX, 0.0f);
        transform.position = Target.position + rotation * direction;
        transform.LookAt(Target.position);
    }
}