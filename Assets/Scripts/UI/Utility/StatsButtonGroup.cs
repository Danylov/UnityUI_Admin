using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class StatsButtonGroup : MonoBehaviour
{
    [SerializeField] private Graphic[] trackedGraphics;

    private Color activeColor = new Color32(58, 255, 113, 255);
    private Color inactiveColor = new Color32(255, 255, 255, 128);

    public void GreenOutButton(Graphic graphic)
    {
        foreach (var _graphic in trackedGraphics)
        {
            _graphic.color = _graphic == graphic ? activeColor : inactiveColor;
        }
    }
}