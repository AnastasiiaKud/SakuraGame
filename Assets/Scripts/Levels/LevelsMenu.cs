using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsMenu : CoinCheck
{
    [SerializeField] private int nextLevel;
    private void Awake()
    {
        PlayerScale();
    }
    public void StartLevel()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void BackToLevelMenu()
    {
        SceneManager.LoadScene("Levels");
    }
    
    public void ToNextLevel()
    {
        SceneManager.LoadScene(DataBaseManager.currentLevel + 1);
    }    
    
    public void PlayerScale()
    {
        DisplayScale();
    }
    
    public void ChangeButtonColor(Color color)
    {
        Button buttonClicked = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        if(buttonClicked != null)
        {
            buttonClicked.image.color = color; 
        }
        else
        {
            Debug.LogError("Button reference is null!");
        }
    }
    
    public void TurnAllMusic()
    {
        MusicManager musicManager = FindObjectOfType<MusicManager>();
    
        if (musicManager != null)
        {
            if (musicManager.IsAnySoundOn()) 
            {
                musicManager.TurnOffAllSounds();
                ChangeButtonColor(Color.red);
            }
            else
            {
                musicManager.TurnOnAllSounds(); 
                ChangeButtonColor(Color.green);
            }
        }
        else
        {
            Debug.LogWarning("MusicManager не знайдено."); 
        }
    }

    
}
