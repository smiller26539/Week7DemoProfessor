using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;

    MouseController mouseCon;
    PlayerController playerCon;
    Transform spawnPointTran;
    SpriteRenderer muzzleFlash;

    public float mzFlashTime;
    private float mzFlashTimer;

    public float shootTime;
    private float shootTimer;

    // Start is called before the first frame update
    void Start()
    {
        mouseCon = GameObject.Find("Main Camera").GetComponent<MouseController>();
        playerCon = transform.GetComponentInParent<PlayerController>();
        spawnPointTran = transform.Find("SpawnPoint").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 shotDir = mouseCon.getWorldMousePos() - transform.position;
        if(playerCon.facingRight) {
            transform.right = shotDir;
        }
        else {
            transform.right = -shotDir;
        }

        //if(Input.GetButtonDown("Fire1")) Desktop Version
        if (shootTimer <= 0 && Input.touches.Length < 0)
        {   Touch t = Input.touches[0];
        if(t.phase == TouchPhase.Ended) //Mobile Version
            {
            GameObject g = Instantiate(bulletPrefab, spawnPointTran.position, Quaternion.identity);
            g.transform.localScale = 2 * Vector3.one;
            g.GetComponent<Rigidbody2D>().velocity = shotDir * 5;
            muzzleFlash.enabled = true;
            mzFlashTimer = mzFlashTime;
            shootTimer = shootTime;
            }
        }

        mzFlashTimer -= Time.deltaTime;

        
    }
}
