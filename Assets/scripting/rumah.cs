using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    public GameObject winText; // UI teks yang muncul saat menang
    public float delayBeforeSceneLoad = 3f; // Waktu tunggu sebelum pindah scene

    private bool isFinished = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!isFinished && collider.CompareTag("Player"))
        {
            isFinished = true;

            if (winText != null)
                winText.SetActive(true);

            StartCoroutine(LoadStageClear());
             StartCoroutine(ReturnToMainMenu());
        }
    }

    private System.Collections.IEnumerator LoadStageClear()
    {
        yield return new WaitForSeconds(delayBeforeSceneLoad);
        SceneManager.LoadScene("Stage Clear");
    }
   private System.Collections.IEnumerator ReturnToMainMenu()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("main menu");
    }
}