using DG.Tweening;
using TMPro;
using UnityEngine;

namespace UI.Blocks
{
    public class UserBlockStudent : UnityEngine.MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI groupText;
        [SerializeField] private TextMeshProUGUI loginText;
        [SerializeField] private TextMeshProUGUI passwText;
        [SerializeField] private ToggleButtonUser toggleButtonUser;
        [SerializeField] private UnloadButton unloadButton;

        public TextMeshProUGUI NameText => nameText;
        public TextMeshProUGUI GroupText => groupText;
        public TextMeshProUGUI LoginText => loginText;
        public TextMeshProUGUI PasswText => passwText;
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
            groupText.transform.parent.gameObject.SetActive(true);
            loginText.transform.parent.gameObject.SetActive(true);
            passwText.transform.parent.gameObject.SetActive(true);
            changeButton.gameObject.SetActive(true);
        }

        private void Minimize()
        {
            isMaximized = false;

            blockContainer.DOSizeDelta(new Vector2(blockContainer.sizeDelta.x,
                MinimizedHeight), .15f);

            nameText.transform.parent.gameObject.SetActive(true);
            groupText.transform.parent.gameObject.SetActive(true);
            loginText.transform.parent.gameObject.SetActive(false);
            passwText.transform.parent.gameObject.SetActive(false);
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