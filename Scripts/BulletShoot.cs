using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 10f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
    }
    private void FixedUpdate(){
        rb.velocity = transform.up * speed;
    }
}
