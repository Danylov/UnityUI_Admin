using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DG.Tweening;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class StretchingList : MonoBehaviour
{
    [SerializeField] private RectTransform blockTransform;

    [FormerlySerializedAs("lContainer")] [SerializeField]
    private RectTransform listContainer;

    [SerializeField] private Button resizeButton;

    [SerializeField] private List<StretchingList> innerLists;
    public IReadOnlyList<StretchingList> InnerLists => innerLists;

    [SerializeField] private float defaultBlockHeight = 75f;

    private bool isMaximized = false;

    [SerializeField] private float executionDelay = .05f;

    public void AddInnerList(StretchingList list)
    {
        if (list != null)
        {
            if (!innerLists.Contains(list))
            {
                innerLists.Add(list);

                list.resizeButton.onClick.AddListener(CountHeight);
            }
        }
    }

    public void RemoveInnerList(StretchingList list)
    {
        if (list != null)
        {
            if (innerLists.Contains(list))
            {
                innerLists.Remove(list);

                list.resizeButton.onClick.AddListener(CountHeight);
            }
        }
    }

    private void Awake()
    {
        resizeButton.onClick.AddListener(SwitchThigsContainerState);

        foreach (StretchingList stretchingList in innerLists)
        {
            Sub(stretchingList);
        }
    }

    private void Sub(StretchingList list)
    {
        list.resizeButton.onClick.AddListener(CountHeight);

        foreach (var inList in list.innerLists)
        {
            Sub(inList);
        }
    }

    private void MinimizeThingsContainer()
    {
        isMaximized = false;

        listContainer.gameObject.SetActive(isMaximized);
    }

    private void MaximizeThingsContainer()
    {
        isMaximized = true;

        listContainer.gameObject.SetActive(isMaximized);
    }

    public void SwitchThigsContainerState()
    {
        if (isMaximized)
            MinimizeThingsContainer();
        else
            MaximizeThingsContainer();

        CountHeight();
    }

    private void CountHeight()
    {
        StartCoroutine(DelayCount());
    }

    private IEnumerator DelayCount()
    {
        yield return new WaitForSeconds(executionDelay);
        
        float height = defaultBlockHeight;

        if (isMaximized)
        {
            height += listContainer.rect.height;
        }

        blockTransform.sizeDelta = new Vector2(blockTransform.sizeDelta.x, height);
    }
}