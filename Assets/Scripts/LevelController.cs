using UnityEngine;
using UnityEngine.SceneManagement;

// Unfinished!!!
public class LevelController : MonoBehaviour
{
    void Update()
    {
        KeyCode[] keys = new KeyCode[] {
            KeyCode.Alpha0,
            KeyCode.Alpha1,
            KeyCode.Alpha2,
            KeyCode.Alpha3,
            KeyCode.Alpha4,
            KeyCode.Alpha5,
            KeyCode.Alpha6,
            KeyCode.Alpha7,
            KeyCode.Alpha8,
            KeyCode.Alpha9
        };

        foreach (KeyCode key in keys)
        {  

        }
    }

    void SwitchScene(int id)
    {
        Debug.Log("Switching scene: " + id);
        SceneManager.LoadScene(id);
    }
}
