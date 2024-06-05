using UnityEngine;
using System.Collections.Generic;
using Yarn.Unity;

namespace MOPC
{
    public sealed class TriggerTriggered : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _trackedObjects;
        [SerializeField] private DialogueRunner _dialogueRunner;
        [SerializeField] private string _dialogueNodeName;

        private bool _isPlayed;

        private void Update()
        {
            bool allObjectsMatchColor = true;
            foreach (GameObject trackedObject in _trackedObjects)
            {
                if (trackedObject.TryGetComponent(out Renderer renderer) &&
                    (renderer.sharedMaterial.color != new Color(0, 255, 0, 255)))
                {
                    allObjectsMatchColor = false;
                    break;
                }
            }

            if (allObjectsMatchColor && (_isPlayed == false))
            {
                _dialogueRunner.StartDialogue(_dialogueNodeName);
                _isPlayed = true;
            }
        }
    }
}
