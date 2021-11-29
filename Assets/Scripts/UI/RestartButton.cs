using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShootTheRagdoll.UI
{
    public class RestartButton : MonoBehaviour
    {
        public void Restart()
        {
            int sceneID = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(sceneID);
        }
    }
}
