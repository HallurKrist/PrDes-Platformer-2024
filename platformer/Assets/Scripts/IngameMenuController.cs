using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameMenuController : MonoBehaviour
{

    public GameObject menuPanel;
    public MovementController player;

    // Start is called before the first frame update
    void Start()
    {
        menuPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                menuPanel.SetActive(false);
                player.enabled = true;
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
                menuPanel.SetActive(true);
                player.enabled = false;
            }
        }
    }
}
