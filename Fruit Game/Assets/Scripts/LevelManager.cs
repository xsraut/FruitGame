using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    GameObject[] Apples = new GameObject[15];
    public Transform[] PosArray;
    public GameObject ApplePrefab;
    public int initialApples = 3;
    public int increaseApplePerLevel = 1;   
    private int currentApples;
    int level=1 ;
    bool levelFinished;
    public int appleDrops;
    bool deleteApplesBool = true;

    public Text TotalScore;
    public Animator UiAnimator;
    public GameObject handCursor;
    private bool retryBool;
    // Start is called before the first frame update
    void Start()
    {
        handCursor.SetActive(true);
        level = StaticClass.Level;
        initialApples = StaticClass.InitialApples;
        if (!retryBool)
        {
            currentApples = initialApples + increaseApplePerLevel;
        }
        TotalScore.text = currentApples.ToString();
        for(int i = 0; i < currentApples; i++)
        {
            Apples[i] = Instantiate(ApplePrefab, PosArray[i].position, transform.rotation);
        }

        levelFinished = false;
        deleteApplesBool = true;
        appleDrops = 0;

        Debug.Log(level);
    }

    // Update is called once per frame
    void Update()
    {
        if (levelFinished && deleteApplesBool)
        {
            handCursor.SetActive(false);
            deleteApples();
            UiAnimator.SetBool("levelComplete", true);
        }

        if(appleDrops == currentApples)
        {
            levelFinished = true;
            Debug.Log("Lev finished");
        }
    }

    void deleteApples()
    {
        for(int i = 0; i < currentApples; i++)
        {
            Destroy(Apples[i]);
        }
        deleteApplesBool = false;
    }

    public void nextLevel()
    {
        StaticClass.Level++;
        StaticClass.InitialApples++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void Retry()
    {
        StaticClass.Level = level;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void quit()
    {
        Application.Quit(); 
    }

}
