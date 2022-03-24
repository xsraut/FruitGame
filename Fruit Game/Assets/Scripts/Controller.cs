using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    bool mouseDropped;
    private void Start()
    {
        
    }

    private void Update()
    {

    }

    void OnMouseDown()
    {

        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

    }

    private void OnMouseUpAsButton()
    {
        gameObject.AddComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "ground")
        {
            Debug.Log("Score--");
        }
        if(collision.collider.tag == "basket")
        {
            Debug.Log("Score++");
            GetComponent<CircleCollider2D>().enabled = false;
            Destroy(GetComponent<Rigidbody2D>());
        }
    }

}