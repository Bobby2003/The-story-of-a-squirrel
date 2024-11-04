using UnityEngine;
using UnityEngine.SceneManagement; // 引入场景管理

public class SceneController : MonoBehaviour
{
    // 切换到指定场景
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); // 根据场景名称加载场景
    }
}
