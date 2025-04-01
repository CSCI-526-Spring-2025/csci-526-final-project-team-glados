using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsManager : MonoBehaviour
{
    public GameObject controlsPanel; // Assign this in the Inspector

    void Start()
    {
        // Ensure the panel is hidden at the start
        if (controlsPanel != null)
        {
            controlsPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ShowControls();
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            HideControls();
        }
    }

    void ShowControls()
    {
        if (controlsPanel != null)
        {
            controlsPanel.SetActive(true);
            Debug.Log("Control Panel Shown"); // Debug Log
            Time.timeScale = 0; // Pause Game
        }
        else
        {
            Debug.LogError("Controls Panel is NOT assigned in the Inspector!");
        }
    }

    void HideControls()
    {
         if (controlsPanel != null)
        {
            controlsPanel.SetActive(false);
            Debug.Log("Control Panel Hidden"); // Debug Log
            Time.timeScale = 1; // Resume Game
        }
    }

}
