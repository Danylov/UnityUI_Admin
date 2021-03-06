﻿using UnityEngine;
using Image = UnityEngine.UI.Image;

public class PersDataCheck : MonoBehaviour
{
    Image m_Image;
    public Sprite m_Sprite1;
    public Sprite m_Sprite2;
    public bool persDataAgreed;
    
    public void persDataCheckStart()
    {
        m_Image = GetComponent<Image>();
        m_Image.sprite = m_Sprite1;
    }

    public void changeSprite()
    {
        persDataAgreed = !persDataAgreed;
        if (!persDataAgreed) m_Image.sprite = m_Sprite1;
        else m_Image.sprite = m_Sprite2;
    }

    public void ToNotAgreed()
    {
        persDataAgreed = false;
        m_Image.sprite = m_Sprite1;
    }
}