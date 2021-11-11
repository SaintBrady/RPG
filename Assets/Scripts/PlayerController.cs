using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 12f;
    public Camera FP_Camera, TP_Camera;

    private const float gravity = 9.81f;

    private Rigidbody rb;
    private CharacterController controller;
    private Camera cam;
    private Vector3 movement;
    private GameObject[] enemies;

    private int health = 100;
    private int maxHealth = 100;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        cam = TP_Camera;
        FP_Camera.enabled = false;

        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            SwapCam();
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject enemy in enemies)
            {
                enemy.GetComponent<Enemy_AI>().TakeDamage(50);
            }
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movement = new Vector3(moveHorizontal, 0f, moveVertical);
        movement = cam.transform.TransformDirection(movement);
        movement.y = 0.0f;

        transform.rotation = Quaternion.Euler(0f, cam.transform.eulerAngles.y, 0f);
        rb.velocity = movement * speed;
    }

    private void SwapCam()
    {
        FP_Camera.enabled = !FP_Camera.enabled;
        TP_Camera.enabled = !TP_Camera.enabled;

        if (cam == TP_Camera)
        {
            cam = FP_Camera;
        }
        else
        {
            cam = TP_Camera;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
    }
}
