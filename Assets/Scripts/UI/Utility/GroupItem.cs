using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GroupItem : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private bool isEditButton;
    public bool IsEditButton => isEditButton;

    [SerializeField] TMP_InputField itemIF;
    [SerializeField] private Button itemEditButton;

    public Button ItemEditButton => itemEditButton;

    [SerializeField] private TMP_Text placeholder;

    public TMP_Text Placeholder => placeholder;

    private string oldItemText = string.Empty;

    private GroupDropDown refDropDown;

    public void SetUpListItems(bool _isEditButton, GroupDropDown refDropDown)
    {
        isEditButton = _isEditButton;
        this.refDropDown = refDropDown;

        //itemIF.onDeselect.AddListener(SubmitChanges);
        itemIF.onSubmit.AddListener(SubmitChanges);
        itemIF.onEndEdit.AddListener(SubmitChanges);

        if (isEditButton)
        {
            itemEditButton.gameObject.SetActive(false);

            placeholder.color = Color.white;
            placeholder.fontStyle = FontStyles.Bold;

            itemIF.interactable = false;
            itemIF.readOnly = true;
        }
        else
        {
            itemIF.readOnly = true;
            itemEditButton.gameObject.SetActive(true);

            placeholder.color = new Color(1f, 1f, 1f, .5f);

            itemEditButton.onClick.AddListener(() =>
            {
                itemEditButton.gameObject.SetActive(false);
                itemIF.readOnly = false;
                itemIF.interactable = true;

                itemIF.ActivateInputField();
                itemIF.Select();
            });
        }
    }

    public void SetText(string text)
    {
        placeholder.text = text;
    }

    private void OnDestroy()
    {
        itemIF.onDeselect.RemoveListener(SubmitChanges);
        itemIF.onSubmit.RemoveListener(SubmitChanges);
        itemIF.onEndEdit.RemoveListener(SubmitChanges);
    }

    private void SubmitChanges(string changes)
    {
        if (changes != string.Empty)
        {
            placeholder.text = changes;
        }

        itemIF.text = string.Empty;

        //EventSystem.current.SetSelectedGameObject(null);

        itemIF.readOnly = true;
        itemIF.interactable = false;
        itemIF.DeactivateInputField();
        EventSystem.current.SetSelectedGameObject(null);
        itemEditButton.gameObject.SetActive(true);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isEditButton)
        {
            refDropDown.AddItem("Новая группа");
        }
        else
        {
            refDropDown.SetSelectedItem(this);
        }
    }
}