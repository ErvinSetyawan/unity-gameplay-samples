using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCustomColor : MonoBehaviour
{
    public static bool isClickBTNHair;
    public static bool isClickBTNEyebrow;

    public Color[] MatsColor;
    public Material HairMatOri;
    public Material HairMatOri001;
    public Material EyebrowMatOri;

    public int currentHairMatNumber = 0;
    public int currentEyebrowMatNumber = 0;

    public static CharacterCustomColor instance;

    private void Awake()
    {
        instance = this;
    }

    public void BTNHair_onClick() // Hair
    {
        if(!isClickBTNHair)
        {
            Material hairDefaultMat = Resources.Load("Male_Hair_Default_Mat", typeof(Material)) as Material;
            HairMatOri = hairDefaultMat;
            isClickBTNHair = true;
            isClickBTNEyebrow = true;
            ChracterCustomEyesColor.isClickBTNEyes = true;
            CharacterCustom.Instance.ScrollColorsHair.SetActive(true);
            CharacterCustom.Instance.ScrollColorsEyebrow.SetActive(false);
            //CharacterCustom.Instance.ScrollColorsEyes.SetActive(false);
        }
    }

    public void BTNEyebrow_onClick() // Eyebrow
    {
        if (!isClickBTNEyebrow)
        {
            Material eyebrowDefaultMat = Resources.Load("Eyebrow_Default_Mat_New", typeof(Material)) as Material;
            EyebrowMatOri = eyebrowDefaultMat;
            isClickBTNHair = true;
            isClickBTNEyebrow = true;
            ChracterCustomEyesColor.isClickBTNEyes = true;
            CharacterCustom.Instance.ScrollColorsHair.SetActive(false);
            CharacterCustom.Instance.ScrollColorsEyebrow.SetActive(true);
            //CharacterCustom.Instance.ScrollColorsEyes.SetActive(false);
        }
    }

    public void changeHairMatColor(int HairMatColorIndex)
    {
        currentHairMatNumber = HairMatColorIndex;
        if (CharacterCustom._instance.currentNumberHair == 0)
        {
            HairMatOri.color = MatsColor[HairMatColorIndex];
        }
        else if (CharacterCustom._instance.currentNumberHair == 1)
        {
            HairMatOri001.color = MatsColor[HairMatColorIndex];
        }
    }

    public void changeEyebrowMatColor(int EyebrowMatColorIndex)
    {
        currentEyebrowMatNumber = EyebrowMatColorIndex;
        EyebrowMatOri.color = MatsColor[EyebrowMatColorIndex];
    }
}
