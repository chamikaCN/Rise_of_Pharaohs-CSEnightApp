using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paraohRotater : MonoBehaviour
{
    public float rotationspeed;
    Transform pharaohTransform;

    private void Start()
    {
        rotationspeed = 50f;
        pharaohTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        pharaohTransform.Rotate(new Vector3(0f, rotationspeed * Time.deltaTime, 0f ));
    }
}
