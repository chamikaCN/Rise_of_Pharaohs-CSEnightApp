using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obeliskmover : MonoBehaviour
{

    float horizontalxMove, horizontalzMove;
    Rigidbody RB;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalxMove = Input.GetAxisRaw("Horizontal");
        horizontalzMove = Input.GetAxisRaw("Vertical");
        RB.velocity = new Vector3(horizontalxMove, RB.velocity.y, horizontalzMove);
    }
}