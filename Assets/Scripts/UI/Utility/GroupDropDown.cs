using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GroupDropDown : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private RectTransform viewport;
    [SerializeField] private RectTransform dropdownContent;
    [SerializeField] private TMP_Text targetText;
    [SerializeField] private ChangableButton arrow;
    
    private List<GroupItem> dropdownItems;

    public IReadOnlyList<GroupItem> DropdownItems => dropdownItems;

    private bool isMaximized = false;
    private GroupItem selectedItem = null;
    private const float maximizedHeight = 100f;

    private void Start()
    {
        dropdownItems = new List<GroupItem>();

        int counter = 0;

        foreach (Transform itemTransform in dropdownContent.transform)
        {
            var item = itemTransform.GetComponent<GroupItem>();

            dropdownItems.Add(item);

            item.SetUpListItems(counter == 0, this);

            counter++;
        }
    }

    public void AddItem(string itemText)
    {
        var newItem = Instantiate(dropdownItems[0].gameObject, dropdownContent)
            .GetComponent<GroupItem>();

        dropdownItems.Insert(1, newItem);
        newItem.transform.SetSiblingIndex(1);

        newItem.SetUpListItems(false, this);

        newItem.SetText(itemText);
        
        newItem.ItemEditButton.onClick.Invoke();
    }

    public void SetSelectedItem(GroupItem item)
    {
        selectedItem = item;

        targetText.text = item.Placeholder.text;
        
        Minimize();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isMaximized)
            Minimize();
        else
            Maximize();
    }

    private void Maximize()
    {
        arrow.SetActiveSprite();
        
        isMaximized = true;
        
        viewport.gameObject.SetActive(true);

        viewport.sizeDelta = new Vector2(viewport.sizeDelta.x, 0f);

        viewport.DOSizeDelta(new Vector2(viewport.sizeDelta.x, maximizedHeight),
            MenuUIManager.DefaultStretchSpeed);
    }

    private void Minimize()
    {
        arrow.SetInactiveSprite();
        
        isMaximized = false;
        
        viewport.DOSizeDelta(new Vector2(viewport.sizeDelta.x, 0f),
            MenuUIManager.DefaultStretchSpeed).OnComplete(() => viewport.gameObject.SetActive(false));
    }
}