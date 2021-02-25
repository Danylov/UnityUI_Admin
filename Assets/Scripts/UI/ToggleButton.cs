using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class ToggleButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private Image tickImage;
        [SerializeField] bool isOn;

        public bool IsOn => isOn;

        public void Start()
        {
            button.onClick.AddListener(Switch);
        }

        private void Switch()
        {
            isOn = !isOn;

            tickImage.gameObject.SetActive(isOn);
        }
    }
}