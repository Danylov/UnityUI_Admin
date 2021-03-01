using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingBlock : MonoBehaviour
{
    [SerializeField] private RectTransform blockTransform;
    [SerializeField] private RectTransform dealsContainer;

    private const float minimizedHeight = 65;
    private const float maximizedHeight = 232f;

    private bool isMaximized = false;

    private void MinimizeDealsContainer()
    {
        isMaximized = false;

        dealsContainer.gameObject.SetActive(isMaximized);

        blockTransform.sizeDelta = new Vector2(blockTransform.sizeDelta.x, minimizedHeight);
    }

    private void MaximizeDealsContainer()
    {
        isMaximized = true;

        dealsContainer.gameObject.SetActive(isMaximized);

        blockTransform.sizeDelta = new Vector2(blockTransform.sizeDelta.x, maximizedHeight);
    }

    public void SwitchDealsContainerState()
    {
        if (isMaximized)
            MinimizeDealsContainer();
        else
            MaximizeDealsContainer();
    }
}