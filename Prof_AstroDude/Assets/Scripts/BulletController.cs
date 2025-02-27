using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void shoot(Vector3 shotDir)
    {
        GetComponent<Rigidbody>().velocity = shotDir.normalized * speed;
        transform.right = shotDir;
    }

    void OnCollisionEnter2D(Collision2D col) {
        Destroy(gameObject);
    }
}
