using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float health = 10f;
    [SerializeField] private float speed = 5f;
    public GameObject healthBar;
    float startScale = 0.15433f;
    private float incriment;
    //public GameObject camera;
    private Rigidbody2D rb;
    private float mx;
    private float my;

    private Vector2 mousePos;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        incriment = startScale/(health+1);
    }
    private void Update() {
        mx = Input.GetAxisRaw("Horizontal");
        my = Input.GetAxisRaw("Vertical");

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        transform.localRotation = Quaternion.Euler(0,0,angle);

    
    }
    private void FixedUpdate() {
        rb.velocity = new Vector2(mx,my).normalized * speed;
        //camera.transform.position = transform.position;
    }
    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Enemy")){
            startScale-=incriment;
            healthBar.transform.localScale = new Vector3(startScale, 0.03216f, 0f);
            health-=1f;
            Debug.Log("hit");
        }
        if(health<0f){
            Destroy(gameObject);
            SceneManager.LoadScene(1);
        }
    }
}
