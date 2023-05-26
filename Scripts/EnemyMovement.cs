using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public GameObject healthBar;

    [SerializeField] public float speed = 3f;
    [SerializeField] public float health = 3f;
    public float rotateSpeed = 0.025f;
    private Rigidbody2D rb;
    float invincibility = 0f;
    float startScale = 0.3086587f;
    private float incriment;


    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        incriment = startScale/(health+1);
    }
    private void Update(){
        if(!target){
            GetTarget();
        }
        else{
            RotateTowardsTarget();
        }
    }
    private void FixedUpdate(){
        rb.velocity = transform.up * speed;
    }
    private void GetTarget(){
        if(GameObject.FindGameObjectWithTag("Player")){
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        
    }
    private void RotateTowardsTarget(){
        Vector2 targetDir = target.position - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0,0,angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }
    private void DecreaseHealthBar(){
        startScale-=incriment;
        healthBar.transform.localScale = new Vector3(startScale, 0.06432872f, 0f);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")){
            //Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Bullet")){
            Destroy(other.gameObject);
            health -= 1;
            DecreaseHealthBar();
            if(health < 0){
                Destroy(gameObject);
            }
        }
    }
}
