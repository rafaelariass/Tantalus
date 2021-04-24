using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndOfDayInfo : MonoBehaviour
{

    public Text currentDay;
    public Text objectivesDone;
    public Text currentWealth;
    public LevelManager lv;
    public float time = 10;
    public AudioClip endOfDayTune;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(endOfDayTune, Camera.main.transform.position);
        currentDay.text = "Day " + GameManager.currentDay + " is complete.";
        currentWealth.text = GameManager.currentWealth + " is your current wealth.";
        if(lv.objectives.Length > lv.objectivesCompleted)
        {
            objectivesDone.text = "You have not completed all objectives." + "\n" + "Let's try that again.";
        } else
        {
            objectivesDone.text = "You have completed all tasks. " + "\n" + "Day " + GameManager.currentDay + " will be starting soon.";
        }
    }

    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            Application.LoadLevel("GreyBoxing");
        }
    }
}
