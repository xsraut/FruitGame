using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] PosArr = new Transform[10];

    public int level = 1;
    private int prefLevel = 1;

    private int startAppleCount = 3;
    private int AppleCount;
    public int PluckedAppleCount;

    bool NextLevel;

    public GameObject ApplePrefab;
    // Start is called before the first frame update
    void Start()
    {
        prefLevel = PlayerPrefs.GetInt("level");
        if (level > prefLevel)
        {
            level = prefLevel;
        }

        for(int i = 0; i < level + startAppleCount - 1; i++)
        {
            Instantiate(ApplePrefab, PosArr[i].position, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PluckedAppleCount == AppleCount)
        {
            PlayerPrefs.SetInt("level", level++);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
