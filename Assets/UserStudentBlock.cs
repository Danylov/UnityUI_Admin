using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class UserStudentBlock : UnityEngine.MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI nameText;
   [SerializeField] private TextMeshProUGUI loginText;
   [SerializeField] private TextMeshProUGUI orgTypeText;
   [SerializeField] private TextMeshProUGUI jobText;
   [SerializeField] private TextMeshProUGUI tabNumText;

   public TextMeshProUGUI NameText => nameText;
   public TextMeshProUGUI LoginText => loginText;
   public TextMeshProUGUI OrgTypeText => orgTypeText;
   public TextMeshProUGUI JobText => jobText;
   public TextMeshProUGUI TabNumText => tabNumText;
}
