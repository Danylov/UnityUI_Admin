using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FontChangeHelper : MonoBehaviour
{
    [SerializeField] private TMP_FontAsset newFont;

    [ContextMenu("Change")]
    public void Help()
    {
        var uguis = (TextMeshProUGUI[]) Resources.FindObjectsOfTypeAll(typeof(TextMeshProUGUI));

        foreach (var ugui in uguis)
        {
            ugui.font = newFont;
        }
    }

    [SerializeField] private Sprite lfSpite;

    [ContextMenu("HadleToSliced")]
    public void HadleToSliced()
    {
        var uguis = (Scrollbar[]) Resources.FindObjectsOfTypeAll(typeof(Scrollbar));

        foreach (var ugui in uguis)
        {
            if (ugui.gameObject.name == "Scrollbar Vertical")
            {
                var oldRect = ugui.GetComponent<RectTransform>();

                ugui.GetComponent<RectTransform>().sizeDelta = new Vector2(8f, oldRect.sizeDelta.y);
            }
        }
    }
}