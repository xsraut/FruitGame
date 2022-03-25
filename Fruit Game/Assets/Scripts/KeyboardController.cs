using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    public float sensitivity;
    public Transform handTransform;
    public KeyCode pickAndDrop;

    private Vector3 currPos = Vector3.zero;
    bool enterFruit;
    bool plucked;
    private Transform fruitPos;

    public float timeToEnableColider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            currPos.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            currPos.x = 1;
        }
        else
        {
            currPos.x = 0;
        }

        if (Input.GetKey(KeyCode.W))
        {
            currPos.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            currPos.y = -1;
        }
        else
        {
            currPos.y = 0;
        }


        transform.position += currPos * sensitivity * Time.deltaTime;

        if(enterFruit && Input.GetKey(pickAndDrop))
        {
            fruitPos.position = transform.position;
            plucked = true;
        }
        else if(plucked)
        {
            GetComponent<Collider2D>().isTrigger = true;
            StartCoroutine(waitForCollider());
            fruitPos.gameObject.AddComponent<Rigidbody2D>();
            plucked = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "fruit")
        {
            enterFruit = true;
            fruitPos = collision.collider.transform;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "fruit")
        {
            enterFruit = false;
        }
    }

    IEnumerator waitForCollider()
    {
        yield return new WaitForSeconds(timeToEnableColider);
        GetComponent<Collider2D>().isTrigger = false;

    }
}
