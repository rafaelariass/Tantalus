using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

// This is the game manager for the game that keeps track of 
// - monetary goals for the day
// - players current money amount for the day
public class GameManager : MonoBehaviour
{
    // The current dollar amount the player has
    public static float currentWealth = 0;
    // The slider that represents the total goal
    public Slider totalGoalSlider;
    // The text box that represents the current amount the player has
    public Text currentWealthText;
    // The current day the player is on
    public static int currentDay = 1;

    public static int numberOfItemsStolen = 0;

    public static int numberOfMedicineStolen = 0;

    public bool isLastDay;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        totalGoalSlider.value = currentWealth;
        currentWealthText.text = "$" + currentWealth;
    }
    // adds a given dollar amount to the player's 
    public static void DepositMoney(float amount)
    {
        
        if (currentWealth < 10000)
        {
            currentWealth += amount;
        }
        else
        {
            Debug.Log(currentWealth);
        }
       
    }
}
