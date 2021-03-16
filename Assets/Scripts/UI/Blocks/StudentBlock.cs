using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Blocks
{
    public class StudentBlock : UnityEngine.MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI taskText;
        [SerializeField] private TextMeshProUGUI timerText;

        public TextMeshProUGUI NameText => nameText;
        public TextMeshProUGUI TaskText => taskText;
        public TextMeshProUGUI TimerText => timerText;
    }
}