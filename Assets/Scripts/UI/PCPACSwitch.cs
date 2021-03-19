using NUnit.Framework.Internal;
using UnityEngine;

public class PCPACSwitch : MonoBehaviour
{
    [SerializeField] private RectTransform pcMenu;
    [SerializeField] private RectTransform pacMenu;

    [SerializeField] private ChangableButton pcButton;
    [SerializeField] private ChangableButton pacButton;

    [SerializeField] private GameObject pc12Text;
    
    public void ShowPCMenu()
    {
        pc12Text.SetActive(true);
        pcButton.SetActiveSprite();
        pacButton.SetInactiveSprite();
    }

    public void ShowPACMenu()
    {
        pc12Text.SetActive(value: false);
        pacButton.SetActiveSprite();
        pcButton.SetInactiveSprite();
    }
}