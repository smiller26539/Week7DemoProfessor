using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D myBod;
    MouseController mouseCon;
    Animator myAnim;

    public bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        myBod = GetComponent<Rigidbody2D>();
        mouseCon = GameObject.Find("Main Camera").GetComponent<MouseController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        myBod.velocity = 5 * (new Vector2(h, v));

        Vector3 mousePos = mouseCon.getWorldMousePos();
        facingRight = transform.position.x < mousePos.x;
        if(facingRight) {
            transform.localScale =  new Vector3(1, 1, 1);
        }
        else {
            transform.localScale =  new Vector3(-1, 1, 1);
        }
    }
}
