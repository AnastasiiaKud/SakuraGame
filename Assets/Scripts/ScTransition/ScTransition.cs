
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScTransition : MonoBehaviour
{
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
