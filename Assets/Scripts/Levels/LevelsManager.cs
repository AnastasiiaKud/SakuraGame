
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    int levelUnLock;
    public Button[] levelNumber;

    void Start()
    {
        levelUnLock = PlayerPrefs.GetInt("levels", 1);

        for (int i = 0; i < levelNumber.Length; i++)
        {
            levelNumber[i].interactable = false;
        }

        for (int i = 0; i < levelUnLock; i++)
        {
            levelNumber[i].interactable = true;
        }
    }

    public void loadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
    
    public void ResetProgress()
    {
        PlayerPrefs.SetInt("levels", 1);
        
        if (levelNumber != null && levelNumber.Length > 0)
        {
            for (int i = 0; i < levelNumber.Length; i++)
            {
                levelNumber[i].interactable = (i == 0);
            }
        }
    }

    public void UnlockProgress()
    {
        levelUnLock = levelNumber.Length;
        PlayerPrefs.SetInt("levels", levelUnLock);

        if (levelNumber != null && levelNumber.Length > 0)
        {
            for (int i = 0; i < levelNumber.Length; i++)
            {
                levelNumber[i].interactable = true;
            }
        }
    }
}
