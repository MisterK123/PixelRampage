using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private float fireRate = 0.2f;
    [SerializeField] private float fireTimer = 0f;
    private void Update(){
        if(Input.GetMouseButton(0) && fireTimer <= 0f){
            Shoot();
            fireTimer = fireRate;
        }
        else{
            fireTimer -= Time.deltaTime;
        }
    }
    private void Shoot(){
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
    }
}
