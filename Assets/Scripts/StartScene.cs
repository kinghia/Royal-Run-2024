using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    
    
    public void LoadGameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
