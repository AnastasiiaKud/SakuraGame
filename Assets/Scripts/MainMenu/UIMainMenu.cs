
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : LevelManager
{
    public void NewGame()
    {
        ResetProgress();
        ChangeColorButton(Color.red);
        //SceneManager.LoadScene("Levels");
    }    
    
    public void Continue()
    {
        //SceneManager.LoadScene("Levels");
        ChangeColorButton(Color.green);
    }    
    
    public void Options()
    {
        SceneManager.LoadScene("OptionsMenu");
    }    
    
    public void Exit()
    {
        Application.Quit();
    }
    
    public void TestBlock()
    {
        SceneManager.LoadScene("TestBlock");
    }     
    
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ChangeColorButton(Color color)
    {
        Button buttonClicked = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        buttonClicked.image.color = color; 
    }
}
