using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        //set custom cursor!
        //Cursor.SetCursor(...)
    }

    public Vector3 getWorldMousePos() {
        Vector3 p = cam.ScreenToWorldPoint(Input.mousePosition);
        p.z = 0;
        return p;
    }
}
