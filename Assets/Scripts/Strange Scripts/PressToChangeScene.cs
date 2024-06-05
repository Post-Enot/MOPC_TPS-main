using UnityEngine;
using UnityEngine.SceneManagement;

namespace MOPC
{
    public sealed class PressToChangeScene : MonoBehaviour
    {
        [SerializeField] private string _sceneName;

        private bool _laptopFound;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && _laptopFound)
            {
                SceneManager.LoadScene(_sceneName);
            }
        }

        public void PressToChangeToScene()
        {
            _laptopFound = true;
        }
    }
}
