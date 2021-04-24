using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMenu : MonoBehaviour
{

    public GameObject map;
    public bool mapToggled;

    public GameObject characterChart;
    public bool chartToggled;
    // Start is called before the first frame update
    void Start()
    {
        mapToggled = false;
        chartToggled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if(!mapToggled)
            {
                characterChart.SetActive(false);
                map.SetActive(true);
                mapToggled = true;
            }
            else
            {
                map.SetActive(false);
                mapToggled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!chartToggled)
            {
                map.SetActive(false);
             
                characterChart.SetActive(true);
                chartToggled = true;
            }
            else
            {
                characterChart.SetActive(false);
                chartToggled = false;
            }
        }


    }
}
