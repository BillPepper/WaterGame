using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionLevelSkip : MonoBehaviour
{ 
    public void OnTriggerEnter2D(Collider2D collision)
    {
        string collisionObjTag = collision.gameObject.tag;
        if (collisionObjTag == "LevelEnd")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
