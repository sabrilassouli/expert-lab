using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] HighscoreHandler highscoreHandler;
    [SerializeField] private GameObject VictoryDialogue = null;
    [SerializeField] private GameObject GameOverDialogue = null;

    public int currentscore = 0;
    public string playerName;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Victory()
    {
        VictoryDialogue.SetActive(true);
        AddScore();
    }
    public void GameOver()
    {
        GameOverDialogue.SetActive(true);
        AddScore();

    }
    public void AddScore()
    {
        highscoreHandler.AddHighscoreIfPossible(new HighscoreElement(playerName, currentscore));
    }
}
