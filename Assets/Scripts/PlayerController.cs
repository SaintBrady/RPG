using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 12f;
    public GameObject Camera;

    private const float gravity = 9.81f;

    private Rigidbody rb;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        movement = Camera.transform.TransformDirection(movement);
        movement.y = 0.0f;

        //controller.Move(movement * speed * Time.deltaTime);
        rb.velocity = movement * speed;// new Vector3(moveHorizontal * speed, -1.0f, moveVertical * speed);// * Time.deltaTime;
    }
}
