using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // represents the total amount of time in a day (Note: 300 seconds is equivalent to 5 minutes)
    public float dayDuration = 300;
    // total amount of lives the player has for the day
    public static int playerHealth = 3;
    // text to display time remaining
    public Text timeText;
    // text for objectives
    public string[] objectives;
    // Text to display objective list
    public Text objectivesCanvas;
    // float to represent count of objectives done
    public float objectivesCompleted;

    public string nextLevel;

    public bool gotCaught;

    public static float dayWealth;

    public GameObject DayCanvas;

    public GameObject EndOfDayCanvas;
    // text to represent end of day information
    public Text gameText;
    public Text EndOfDayStats;

    public bool isDayOver;

    // Start is called before the first frame update
    void Start()
    {
        if(objectivesCanvas != null)
        {
            objectivesCanvas.enabled = false;
        }

        dayWealth = 0;
        isDayOver = false;
        gotCaught = false;

        GlobalControl.Instance.stoleMedsYesterday = GlobalControl.Instance.stoleMedsToday;
        GlobalControl.Instance.stoleMedsToday = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(objectivesCanvas != null)
        {
            updateTime();
            DisplayTime(dayDuration);
            if (ObjectivesScript.hasObjectives)
            {
                DisplayObjectives();
            }
        }
    }

    void updateTime()
    {
        
        if(!isDayOver)
        {
            if (dayDuration > 0 && !gotCaught)
            {
                dayDuration -= Time.deltaTime;
            }
            else
            {
                isDayOver = true;
                if (isLevelWon())
                {
                    LevelWon();
                }
                else
                {
                    LevelLost();
                }
            }

        }

    }

    public bool isLevelWon()
    {
        if(objectivesCompleted == objectives.Length && !gotCaught)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void LevelLost()
    {
        gameText.text = "DAY INCOMPLETED!";
        if (gotCaught)
        {
            EndOfDayStats.text = "You got caught stealing and was fired";
        }
        else
        {
            EndOfDayStats.text = "Your objectives have not been completed";
        }
       
        DayCanvas.SetActive(false);
        EndOfDayCanvas.SetActive(true);

        // removes the amount of money collected for the day
        GameManager.DepositMoney(-dayWealth);
        Invoke("LoadCurrentLevel", 5);
    }

    public void LevelWon()
    {
        gameText.text = "DAY COMPLETED";
        GameManager.DepositMoney(1350);
        EndOfDayStats.text = "Current Weatlth: " + GameManager.currentWealth + "\n"
            + "Number of Items Stolen: " + GameManager.numberOfItemsStolen + "\n"
            + "Number of Drugs Stolen: " + GameManager.numberOfMedicineStolen;

        DayCanvas.SetActive(false);
        EndOfDayCanvas.SetActive(true);

        if (!string.IsNullOrEmpty(nextLevel))
        {
            Invoke("LoadNextLevel", 5);
        }
        else
        {
            if (GameManager.currentWealth >= 10000)
            {
                gameText.text = "Congrats!";
                EndOfDayStats.text = "You can afford your parent's surgery!" + "\n" 
                    + "Current Weatlth: " + GameManager.currentWealth + "\n"
            + "Number of Items Stolen: " + GameManager.numberOfItemsStolen + "\n"
            + "Number of Drugs Stolen: " + GameManager.numberOfMedicineStolen;

            }
            else
            {
                gameText.text = "Sorry!";
                EndOfDayStats.text = "You can't afford your parent's surgery!" + "\n" 
                    +"Current Weatlth: " + GameManager.currentWealth + "\n"
            + "Number of Items Stolen: " + GameManager.numberOfItemsStolen + "\n"
            + "Number of Drugs Stolen: " + GameManager.numberOfMedicineStolen;
            }

            Invoke("LoadMainMenu", 5);
        }

    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevel);

    }

    void LoadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // removes one of the player lives
    public static void takeLife()
    {
        playerHealth -= 1;

        if (playerHealth <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void DisplayObjectives()
    {
        objectivesCanvas.enabled = true;
        objectivesCanvas.text = "Daily Tasks" + "\n";
        foreach(string x in objectives) {
            objectivesCanvas.text = objectivesCanvas.text + x + "\n";
        }
    }

    public void CompletedObjectives(string name)
    {
        for(int x = 0; x < objectives.Length; x++)
        {
            if (objectives[x].Contains(name))
            {
                Debug.Log("TESTING COMPLETION");
                objectives[x] = StrikeThroughObjective(objectives[x]);
                objectivesCompleted++;
            }
        }
    }

    string StrikeThroughObjective(string objectiveCrossed)
    {
        string strikethrough = "";
        foreach (char c in objectiveCrossed)
        {
            strikethrough = strikethrough + c + '\u0336';
        }

        objectiveCrossed = strikethrough;
        return objectiveCrossed;
    }
}
