using UnityEngine;
using UnityEngine.UI;

public class ChangableButton : MonoBehaviour
{
    public int studentId;

    [SerializeField] private Image image;

    [SerializeField] private Sprite activeSprite;
    [SerializeField] private Sprite inactiveSprite;

    [SerializeField] private bool setNativeSize = false;
    [SerializeField] private bool changeOnClick = true;
    [SerializeField] private Button button;

    private bool isActive;
    public bool IsActive => isActive;

    public void Start()
    {
        if (changeOnClick)
        {
            button.onClick.AddListener(Switch);
        }
    }

    private void Switch()
    {
        if (isActive)
            SetInactiveSprite();
        else
            SetActiveSprite();
    }

    public void SetActiveSprite()
    {
        isActive = true;
        
        image.sprite = activeSprite;

        if (setNativeSize)
            image.SetNativeSize();
    }

    public void SetInactiveSprite()
    {
        isActive = false;
        
        image.sprite = inactiveSprite;

        if (setNativeSize)
            image.SetNativeSize();
    }
}