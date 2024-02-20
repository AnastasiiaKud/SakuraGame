using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishDot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        GetCurrentLevel();
        if (collider.gameObject.CompareTag("Finish"))
        {
            UnLockLevel();
            Application.LoadLevel("EndLevel");
        }
    }
    
    public void UnLockLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if(currentLevel >= PlayerPrefs.GetInt("levels"))
        {
            PlayerPrefs.SetInt("levels", currentLevel + 1);
        }
    }

    public void GetCurrentLevel()
    {
        DataBaseManager.currentLevel = SceneManager.GetActiveScene().buildIndex;
    }
}
