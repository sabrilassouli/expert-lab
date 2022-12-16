using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] HighscoreHandler highscoreHandler;
    [SerializeField] private GameObject Part1EndDialogue = null;
    [SerializeField] private GameObject Part2EndDialogue = null;
    [SerializeField] private GameObject GameOverDialogue = null;
    [SerializeField] private GameObject BombGameOverDialogue = null;
    [SerializeField] private GameObject TimerTextBox = null;

    public int currentscore = 5000;
    public int timer = 60;
    public int remainingTargets = 3;
    public int remainingBombs = 3;
    public string playerName;
    public playerController playerController;
    public Text TimerText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitforSomeSecondsPleaase());
    }
    void Update()
    {
        if (remainingTargets == 0)
        {
            Part1End();
            remainingTargets -= 1;
        }
        if (remainingBombs == 0)
        {
            Part2End();
            remainingBombs -= 1;
        }
        if (timer <= 0)
        {
            GameOver2();
        }
        TimerText.text = timer.ToString();
    }

    // Update is called once per frame
    public void Part1End()
    {
        Part1EndDialogue.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        playerController.talking();


    }
    public void Part2Start()
    {
        StartCoroutine(Timer());
        TimerTextBox.SetActive(true);

    }
    public void Part2End()
    {
        Part2EndDialogue.SetActive(true);
        Cursor.lockState = CursorLockMode.None;

        AddScore();

    }
    public void GameOver()
    {
        GameOverDialogue.SetActive(true);
        AddScore();
    }
    public void GameOver2()
    {
        BombGameOverDialogue.SetActive(true);
        AddScore();
    }
    public void AddScore()
    {
        highscoreHandler.AddHighscoreIfPossible(new HighscoreElement(playerName, currentscore));
    }
    public void IncreaseScore()
    {
        currentscore += 100;
    }
    public void LowerScore()
    {
        currentscore -= 500;
    }

    IEnumerator WaitforSomeSecondsPleaase()
    {
        yield return new WaitForSeconds(1);
        currentscore -= 10;
        Debug.Log(currentscore);
        StartCoroutine(WaitforSomeSecondsPleaase());
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        timer -= 1;
        Debug.Log(timer);
        StartCoroutine(Timer());
    }

}
