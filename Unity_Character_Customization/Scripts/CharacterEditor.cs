using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEditor : MonoBehaviour
{
    public CharacterCustom[] selectors;
    public CharacterCustomColor[] selectorscolor;
    //public ChracterCustomEyesColor[] selectorseyescolor;

    public string Hair
    {
        get
        {
            return selectors[0].currentNumberHair.ToString();
        }
    }

    public string Eyebrow
    {
        get
        {
            return selectors[1].currentNumberEyebrow.ToString();
        }
    }

    //public string Eyes
    //{
    //    get
    //    {
    //        return selectors[2].currentNumberEyes.ToString();
    //    }
    //}

    public string FaceAcc
    {
        get
        {
            return selectors[2].currentNumberFaceAcc.ToString();
        }
    }

    public string TorsoAcc
    {
        get
        {
            return selectors[3].currentNumberTorsoAcc.ToString();
        }
    }

    public string HairMatsColor
    {
        get
        {
            return selectorscolor[0].currentHairMatNumber.ToString();
        }
    }

    public string EyebrowMatsColor
    {
        get
        {
            return selectorscolor[1].currentEyebrowMatNumber.ToString();
        }
    }

    //public string EyesMatsColor
    //{
    //    get
    //    {
    //        return selectorseyescolor[0].currentEyesMatNumber.ToString();
    //    }
    //}

    public void SetAppearance(string hair, string eyebrow, string faceacc, string torsoacc, string hairmatscolor, string eyebrowmatscolor)
    {
        selectors[0].ChangeHair(int.Parse(hair));
        selectors[1].ChangeEyebrow(int.Parse(eyebrow));
        //selectors[2].ChangeEyes(int.Parse(eyes));
        selectors[2].ChangeFaceAcc(int.Parse(faceacc));
        selectors[3].ChangeTorsoAcc(int.Parse(torsoacc));
        selectorscolor[0].changeHairMatColor(int.Parse(hairmatscolor));
        selectorscolor[1].changeEyebrowMatColor(int.Parse(eyebrowmatscolor));
        //selectorseyescolor[0].changeEyesMatColor(int.Parse(eyesmatscolor));
    }
}
