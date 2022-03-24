using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public Vector3 StartPosition;
    public Vector3 EndPosition;
    public Vector3 Direction;
    public float speed;

    private Vector3 currPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Direction * speed * Time.deltaTime;
        if(transform.position.x >= EndPosition.x)
        {
            transform.position = new Vector3(StartPosition.x, transform.position.y, transform.position.z);
        }
    }
}
