using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    // public Transform dummyTransform;


    public bool grabable = true;
    private bool collided = false; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.collider.tag == "basket")
        {
            if (!collided)
            {
                FindObjectOfType<KeyboardController>().fruitPos = FindObjectOfType<KeyboardController>().dummyTransform;
                collided = true;
            }
            GetComponent<CircleCollider2D>().enabled = false;
            Destroy(GetComponent<Rigidbody2D>());

            Destroy(GetComponent<Animator>());

            FindObjectOfType<ScoreSystem>().score++;                                    // SCORE

            FindObjectOfType<LevelManager>().appleDrops++;
        }

        if (collision.collider.tag == "ground")
        {
            GetComponent<Animator>().SetBool("groundHit", true);

            Destroy(GetComponent<Rigidbody2D>());
            //transform.localScale = Vector3.zero;

            GetComponent<CircleCollider2D>().enabled = false;

            FindObjectOfType<ScoreSystem>().score--;                                      // SCORE

            FindObjectOfType<KeyboardController>().fruitPos = FindObjectOfType<KeyboardController>().dummyTransform;

            FindObjectOfType<LevelManager>().appleDrops++;

        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GetComponent<Animator>().SetBool("appleShake", false);
    }

}
