using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class StatsTableTab : MonoBehaviour
{
    [SerializeField] private RectTransform filterPanel;
    [SerializeField] private float maximizedSize = 211f;

    [SerializeField] private bool generateBlocker = true;
    private ChangableButton filterButton = null;
    private GameObject blocker = null;
    private Canvas thisCanvas = null;

    private bool isOpen = false;

    private void Start()
    {
        if (generateBlocker)
        {
            var go = new GameObject("Blocker");
            go.transform.SetParent(transform);
            go.transform.SetAsFirstSibling();
            RectTransform rect = go.AddComponent<RectTransform>();
            rect.sizeDelta = new Vector2(2000, 2000);
            rect.anchoredPosition = Vector2.zero;
            ;
            go.transform.localScale = Vector3.one;
            go.AddComponent<Image>().color = new Color(255, 255, 255, 0);
            go.AddComponent<Button>().onClick.AddListener(HidePanel);

            thisCanvas = GetComponent<Canvas>();
            
            if (!thisCanvas)
            {
                thisCanvas = gameObject.AddComponent<Canvas>();
                gameObject.AddComponent<GraphicRaycaster>();
            }


            blocker = go;

            go.SetActive(false);

            filterButton = GetComponentInChildren<ChangableButton>();
        }
    }

    private void OpenPanel()
    {
        blocker.SetActive(true);

        thisCanvas.overrideSorting = true;
        thisCanvas.sortingOrder = 3;

        isOpen = true;

        filterPanel.gameObject.SetActive(true);

        filterPanel.sizeDelta = new Vector2(filterPanel.sizeDelta.x, 0f);

        filterPanel.DOSizeDelta(new Vector2(filterPanel.sizeDelta.x, maximizedSize),
            MenuUIManager.DefaultStretchSpeed);

        if (filterButton != null)
        {
            filterButton.SetActiveSprite();
        }
    }

    private void HidePanel()
    {
        blocker.SetActive(false);

        thisCanvas.overrideSorting = false;

        isOpen = false;

        filterPanel.DOSizeDelta(new Vector2(filterPanel.sizeDelta.x, 0f),
            MenuUIManager.DefaultStretchSpeed).OnComplete(() => { filterPanel.gameObject.SetActive(false); });

        if (filterButton != null)
        {
            filterButton.SetInactiveSprite();
        }
    }

    public void SwitchPanelState()
    {
        if (isOpen)
            HidePanel();
        else
            OpenPanel();
    }

    //[ContextMenu("GetValues")]
    private void GetValues()
    {
        maximizedSize = filterPanel.rect.height;
    }
}