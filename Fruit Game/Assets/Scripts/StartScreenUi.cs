using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenUi : MonoBehaviour
{
    public float waitForSeconds = 1;
    public Animator FadeScreenAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void start()
    {
        FadeScreenAnimator.SetBool("start", true);
        StartCoroutine(waitForSec());
    }

    public void quit()
    {
        Application.Quit();
    }

    IEnumerator waitForSec()
    {
        yield return new WaitForSeconds(waitForSeconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }
}

