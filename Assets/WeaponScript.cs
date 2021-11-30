using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class WeaponScript : MonoBehaviour
{
    
    public float luodinnopeus = 5f;
    public float maxLuodinnopeus = 200f;
    public GameObject bulletPrefab;
    Camera FPSCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        FPSCamera = Camera.main;
    }
 
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButton("Fire1")) {
            
            luodinnopeus += Time.deltaTime * 50;
            
            if (luodinnopeus > maxLuodinnopeus) {
                luodinnopeus = maxLuodinnopeus;
            }
            
        }
        
        if (Input.GetButtonUp("Fire1")) {
            Shoot();
            luodinnopeus = 5f;
        }
        
    }
    
    public void Shoot() {
        
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        
        bullet.GetComponent<Rigidbody>().AddForce(FPSCamera.transform.forward * luodinnopeus,
            ForceMode.Impulse);
        
    }
    
    
    
}
 