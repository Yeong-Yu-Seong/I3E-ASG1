/* 
* Author: Yeong Yu Seong
* Date: 11 June 2025
* Description: This script is used to manage all the UI screens (game start, game screen, game end)
* Credits: This code is implemented with the help of ChatGPT.
*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startCanvas;
    public GameObject gameCanvas;
    public GameObject endCanvas;
    public void StartGame()
    {
        startCanvas.SetActive(false);
        gameCanvas.SetActive(true);
        Time.timeScale = 1f; // Resume game
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void EndGame()
    {
        endCanvas.SetActive(true);
        gameCanvas.SetActive(false);
        Time.timeScale = 0f;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startCanvas.SetActive(true);
        gameCanvas.SetActive(false);
        endCanvas.SetActive(false);
        Time.timeScale = 0f; // Pause the game until Start is pressed
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
