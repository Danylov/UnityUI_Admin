using DG.Tweening;
using TMPro;
using UnityEngine;

namespace UI.Blocks
{
    public class UserBlockTeacher : UnityEngine.MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI jobText;
        [SerializeField] private TextMeshProUGUI loginText;
        [SerializeField] private ToggleButtonUser toggleButtonUser;
        [SerializeField] private UnloadButton unloadButton;

        public TextMeshProUGUI NameText => nameText;
        public TextMeshProUGUI JobText => jobText;
        public TextMeshProUGUI LoginText => loginText;
        public ToggleButtonUser ToggleButtonUser => toggleButtonUser;
        public UnloadButton UnloadButton => unloadButton;

        [SerializeField] private RectTransform blockContainer;
        [SerializeField] private Transform changeButton;

        private const float MinimizedHeight = 78f;
        private const float MaximizedHeight = 267f;

        private bool isMaximized = false;

        private void Maximize()
        {
            isMaximized = true;

            blockContainer.DOSizeDelta(new Vector2(blockContainer.sizeDelta.x,
                MaximizedHeight), .15f);

            nameText.transform.parent.gameObject.SetActive(true);
            jobText.transform.parent.gameObject.SetActive(true);
            loginText.transform.parent.gameObject.SetActive(true);
            changeButton.gameObject.SetActive(true);
        }

        private void Minimize()
        {
            isMaximized = false;

            blockContainer.DOSizeDelta(new Vector2(blockContainer.sizeDelta.x,
                MinimizedHeight), .15f);

            nameText.transform.parent.gameObject.SetActive(true);
            jobText.transform.parent.gameObject.SetActive(true);
            loginText.transform.parent.gameObject.SetActive(false);
            changeButton.gameObject.SetActive(false);
        }

        public void SwitchState()
        {
            if (isMaximized)
                Minimize();
            else
                Maximize();
        }
    }
}