﻿using DG.Tweening;
using TMPro;
using UnityEngine;

namespace UI.Blocks
{
    public class UserBlock : UnityEngine.MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI loginText;

        public TextMeshProUGUI NameText => nameText;
        public TextMeshProUGUI LoginText => loginText;

        [SerializeField] private RectTransform blockContainer;
        [SerializeField] private Transform changeButton;

        private const float MinimizedHeight = 78f;
        private const float MaximizedHeight = 122f;

        private bool isMaximized = false;

        private void Maximize()
        {
            isMaximized = true;

            blockContainer.DOSizeDelta(new Vector2(blockContainer.sizeDelta.x,
                MaximizedHeight), .15f);

            loginText.transform.parent.gameObject.SetActive(true);
            changeButton.gameObject.SetActive(true);
        }

        private void Minimize()
        {
            isMaximized = false;

            blockContainer.DOSizeDelta(new Vector2(blockContainer.sizeDelta.x,
                MinimizedHeight), MenuUIManager.DefaultStretchSpeed);

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