using UnityEngine;

public class PCPACSwitch : MonoBehaviour
{
    [SerializeField] private RectTransform pcMenu;
    [SerializeField] private RectTransform pacMenu;

    [SerializeField] private ChangableButton pcButton;
    [SerializeField] private ChangableButton pacButton;

    public void ShowPCMenu()
    {
        pcButton.SetActiveSprite();
        pacButton.SetInactiveSprite();
    }

    public void ShowPACMenu()
    {
        pacButton.SetActiveSprite();
        pcButton.SetInactiveSprite();
    }
}