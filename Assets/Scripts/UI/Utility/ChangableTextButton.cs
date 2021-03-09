using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ChangableTextButton : MonoBehaviour
{
    [FormerlySerializedAs("image")] [SerializeField]
    private TextMeshProUGUI textBox;

    [SerializeField] private string activeString = "+";
    [SerializeField] private string inactiveString = "-";

    [SerializeField] private Button button;

    private bool isActive = true;

    public void Start()
    {
        button.onClick.AddListener(Switch);
        
        if (isActive)
            SetActiveText();
        else
            SetInactiveText();
    }

    private void Switch()
    {
        isActive = !isActive;

        if (isActive)
            SetActiveText();
        else
            SetInactiveText();
    }

    private void SetActiveText()
    {
        textBox.text = activeString;
    }

    private void SetInactiveText()
    {
        textBox.text = inactiveString;
    }
}