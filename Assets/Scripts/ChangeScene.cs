using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void MoveToScene(string scenePath)
    {
        SceneManager.LoadScene(scenePath);
    }
}
