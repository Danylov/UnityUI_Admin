using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class StatsTableTab : MonoBehaviour
{
    [SerializeField] private RectTransform filterPanel;
    [SerializeField] private float maximizedSize = 211f;

    private bool isOpen = false;

    private void OpenPanel()
    {
        isOpen = true;

        filterPanel.gameObject.SetActive(true);

        filterPanel.DOSizeDelta(new Vector2(filterPanel.sizeDelta.x, maximizedSize),
            MenuUIManager.DefaultStretchSpeed);
    }

    private void ClosePanel()
    {
        isOpen = false;

        filterPanel.DOSizeDelta(new Vector2(filterPanel.sizeDelta.x, 0f),
            MenuUIManager.DefaultStretchSpeed).OnComplete(() => { filterPanel.gameObject.SetActive(false); });
    }

    public void SwitchPanelState()
    {
        if (isOpen)
            ClosePanel();
        else
            OpenPanel();
    }

    //[ContextMenu("GetValues")]
    private void GetValues()
    {
        maximizedSize = filterPanel.rect.height;
    }
}