﻿using UnityEngine;
using UnityEngine.UI;

public class ChangableButton : MonoBehaviour
{
    [SerializeField] private Image image;

    [SerializeField] private Sprite activeSprite;
    [SerializeField] private Sprite inactiveSprite;

    [SerializeField] private bool setNativeSize = false;
    [SerializeField] private bool changeOnClick = true;
    [SerializeField] private Button button;

    private bool isActive = false;

    public void Start()
    {
        if (changeOnClick)
        {
            button.onClick.AddListener(Switch);
        }
    }

    private void Switch()
    {
        isActive = !isActive;

        if (isActive)
            SetActiveSprite();
        else
            SetInactiveSprite();
    }

    public void SetActiveSprite()
    {
        image.sprite = activeSprite;

        if (setNativeSize)
            image.SetNativeSize();
    }

    public void SetInactiveSprite()
    {
        image.sprite = inactiveSprite;

        if (setNativeSize)
            image.SetNativeSize();
    }
}