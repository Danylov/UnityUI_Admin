using DG.Tweening;
using UnityEngine;

public class UnderLineSelectedElement : MonoBehaviour
{
    [SerializeField] private RectTransform underlineImage;

    public void UnderlineToElement(RectTransform element)
    {
        underlineImage.DOAnchorPosX(element.anchoredPosition.x, .1f);
    }
}