using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody Rb;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3();
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movement.z = horizontal;
        movement.x = vertical;

        Rb.velocity = new Vector3(movement.x * Speed, Rb.velocity.y , movement.z * Speed);
        
    }
}
