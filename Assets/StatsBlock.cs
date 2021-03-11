using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsBlock : MonoBehaviour
{
    [SerializeField] private RectTransform blockTransform;
    [SerializeField] private RectTransform thingsContainer;

    private const float defaultBlockHeight = 75f;

    private bool isMaximized = false;

    private void MinimizeThingsContainer()
    {
        isMaximized = false;

        thingsContainer.gameObject.SetActive(isMaximized);
    }

    private void MaximizeThingsContainer()
    {
        isMaximized = true;

        thingsContainer.gameObject.SetActive(isMaximized);
    }

    public void SwitchThigsContainerState()
    {
        if (isMaximized)
            MinimizeThingsContainer();
        else
            MaximizeThingsContainer();
    }

    private void CountHeight()
    {
        float height = defaultBlockHeight;

        if (thingsContainer.gameObject.activeSelf)
        {
            foreach (RectTransform child in thingsContainer)
            {
                height += child.sizeDelta.y;
            }
        }

        blockTransform.sizeDelta = new Vector2(blockTransform.sizeDelta.x, height);
    }

    private void Update()
    {
        CountHeight();
    }
}