using UnityEngine;
using UnityEngine.SceneManagement;

namespace MOPC
{
    public sealed class ChangeScene : MonoBehaviour
    {
        [SerializeField] private string _sceneName;

        public void ChangeToScene()
        {
            SceneManager.LoadScene(_sceneName);
        }
    }
}
