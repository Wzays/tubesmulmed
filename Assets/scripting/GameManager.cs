using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("Game Over UI")]

    public GameObject gameOverText;
    
    [HideInInspector]
    public bool isGameOver = false;

    void Awake()
    {
        Instance = this;
    }
    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            Debug.Log("GAME OVER");
            if (gameOverText != null)
                gameOverText.SetActive(true);

            StartCoroutine(ReturnToMainMenu());
        }
    }
    
    private System.Collections.IEnumerator ReturnToMainMenu()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("main menu");
    }
}