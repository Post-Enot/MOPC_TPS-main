using UnityEngine;
using Yarn.Unity;

namespace MOPC
{
    public sealed class DialogueStart : MonoBehaviour
    {
        [SerializeField] private DialogueRunner _dialogueRunner;
        [SerializeField] private string _dialogueNodeName;

        public void StartDialog()
        {
            _dialogueRunner.StartDialogue(_dialogueNodeName);
        }
    }
}
