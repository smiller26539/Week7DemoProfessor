using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update

    public float mzFlashTime;
    private float mzFlashTimer;
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

        if(Input.GetButtonDown("Fire1")) {
            GameObject g = Instantiate(bulletPrefab, spawnPointTran.position, Quaternion.identity);
            g.GetComponent<Rigidbody2D>().velocity = shotDir * 5;
            g.transform.right = shotDir;
        }

        mzFlashTimer -= Time.deltaTime;

        
    }
}
