using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    public float sensitivity;
    public KeyCode pickAndDrop;

    private Vector3 currPos = Vector3.zero;
    bool enterFruit;
    bool plucked;
    public Transform fruitPos;

    public float timeToEnableColider;

    public Animator AppleAnimator;

    public Sprite HandSprite;
    public Sprite GrabSprite;
    private SpriteRenderer _spriteRenderer;

    public Transform dummyTransform;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
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

        if (enterFruit && Input.GetKey(pickAndDrop))
        {
            if (fruitPos != null)
            {
                fruitPos.position = transform.position;
            }
            plucked = true;
        }
        else if (plucked)
        {
            GetComponent<Collider2D>().isTrigger = true;
            plucked = false;
            if (AppleAnimator != null)
            {
                AppleAnimator.SetBool("appleShake", false);
            }

            StartCoroutine(waitForCollider());
            if (fruitPos.GetComponent<Rigidbody2D>() == null)
            {
                fruitPos.gameObject.AddComponent<Rigidbody2D>();
            }
            
        }

        if (Input.GetKey(pickAndDrop))
        {
            _spriteRenderer.sprite = GrabSprite;
        }
        else
        {
            _spriteRenderer.sprite = HandSprite;
        }

        Debug.Log(plucked); 
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "fruit")
        {
            Debug.Log("Called");
            enterFruit = true;
            fruitPos = collision.collider.transform;
            
            AppleAnimator = collision.transform.GetComponent<Animator>();
            AppleAnimator.SetBool("appleShake", true);
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