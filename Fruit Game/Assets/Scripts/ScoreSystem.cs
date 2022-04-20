using UnityEngine.UI;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{

    public int score = 0;
    Text scoreText;
    public Text FinalScore;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (score < 0)
        {
            score = 0;
        }
        scoreText.text = score.ToString();
        FinalScore.text = scoreText.text;
    }
}
