using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCustom : MonoBehaviour
{
    public SkinnedMeshRenderer hairMesh;
    public SkinnedMeshRenderer[] hairMeshs;

    public SkinnedMeshRenderer avatarhairMesh;
    public SkinnedMeshRenderer[] avatarhairMeshs;

    public SkinnedMeshRenderer eyebrowMesh;
    public SkinnedMeshRenderer[] eyebrowMeshs;

    public SkinnedMeshRenderer avatareyebrowMesh;
    public SkinnedMeshRenderer[] avatareyebrowMeshs;

    //public SkinnedMeshRenderer eyesMesh;
    //public SkinnedMeshRenderer[] eyesMeshs;

    //public SkinnedMeshRenderer avatareyesMesh;
    //public SkinnedMeshRenderer[] avatareyesMeshs;

    public SkinnedMeshRenderer faceAccMesh;
    public SkinnedMeshRenderer[] faceAccMeshs;

    public SkinnedMeshRenderer avatarfaceAccMesh;
    public SkinnedMeshRenderer[] avatarfaceAccMeshs;

    public SkinnedMeshRenderer torsoAccMesh;
    public SkinnedMeshRenderer[] torsoAccMeshs;

    public SkinnedMeshRenderer avatartorsoAccMesh;
    public SkinnedMeshRenderer[] avatartorsoAccMeshs;

    public int currentNumberHair = 0;
    public int currentNumberEyebrow = 0;
    //public int currentNumberEyes = 0;
    public int currentNumberFaceAcc = 0;
    public int currentNumberTorsoAcc = 0;

    public GameObject ScrollColorsHair;
    public GameObject ScrollColorsEyebrow;
    //public GameObject ScrollColorsEyes;
    public GameObject BTNArrowTop;
    public GameObject BTNArrowBottom;

    // Singleton
    public static CharacterCustom _instance;
    public static CharacterCustom Instance => _instance;

    public CharacterCustomColor characterCustomColor;
    public ChracterCustomEyesColor characterCustomEyesColor;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        ScrollColorsHair.SetActive(false);
        ScrollColorsEyebrow.SetActive(false);
        //ScrollColorsEyes.SetActive(false);
        BTNArrowTop.SetActive(false);
        BTNArrowBottom.SetActive(false);
    }

    public void ChangeHair(int hairIndex)
    {
        currentNumberHair = hairIndex;
        hairMesh.sharedMesh = hairMeshs[hairIndex].sharedMesh;
        hairMesh.sharedMaterials = hairMeshs[hairIndex].sharedMaterials;
        avatarhairMesh.sharedMesh = hairMeshs[hairIndex].sharedMesh;
        avatarhairMesh.sharedMaterials = hairMeshs[hairIndex].sharedMaterials;
        if (currentNumberHair == 0)
        {
            characterCustomColor.HairMatOri = hairMeshs[hairIndex].sharedMaterial;
            ScrollColorsHair.SetActive(true);
            ScrollColorsEyebrow.SetActive(false);
            //ScrollColorsEyes.SetActive(false);
            BTNArrowTop.SetActive(true);
            BTNArrowBottom.SetActive(true);
        }
        else if (currentNumberHair == 1)
        {
            characterCustomColor.HairMatOri001 = hairMeshs[hairIndex].sharedMaterial;
            ScrollColorsHair.SetActive(true);
            ScrollColorsEyebrow.SetActive(false);
            //ScrollColorsEyes.SetActive(false);
            BTNArrowTop.SetActive(true);
            BTNArrowBottom.SetActive(true);
        }
        else
        {
            if (currentNumberHair == 0)
            {
                characterCustomColor.HairMatOri = hairMeshs[0].sharedMaterial;
            }
            else if (currentNumberHair == 1)
            {
                characterCustomColor.HairMatOri001 = hairMeshs[1].sharedMaterial;
            }
            ScrollColorsHair.SetActive(false);
            ScrollColorsEyebrow.SetActive(false);
            //ScrollColorsEyes.SetActive(false);
            BTNArrowTop.SetActive(false);
            BTNArrowBottom.SetActive(false);
        }
    }

    public void ChangeEyebrow(int eyebrowIndex)
    {
        currentNumberEyebrow = eyebrowIndex;
        eyebrowMesh.sharedMesh = eyebrowMeshs[eyebrowIndex].sharedMesh;
        eyebrowMesh.sharedMaterials = eyebrowMeshs[eyebrowIndex].sharedMaterials;
        avatareyebrowMesh.sharedMesh = eyebrowMeshs[eyebrowIndex].sharedMesh;
        avatareyebrowMesh.sharedMaterials = eyebrowMeshs[eyebrowIndex].sharedMaterials;
        characterCustomColor.EyebrowMatOri = eyebrowMeshs[eyebrowIndex].sharedMaterial;
        ScrollColorsHair.SetActive(false);
        ScrollColorsEyebrow.SetActive(true);
        //ScrollColorsEyes.SetActive(false);
        BTNArrowTop.SetActive(true);
        BTNArrowBottom.SetActive(true);
    }

    //public void ChangeEyes(int eyesIndex)
    //{
    //    currentNumberEyes = eyesIndex;
    //    eyesMesh.sharedMesh = eyesMeshs[eyesIndex].sharedMesh;
    //    eyesMesh.sharedMaterials = eyesMeshs[eyesIndex].sharedMaterials;
    //    if(currentNumberEyes == 0)
    //    {
    //        //characterCustomEyesColor.MatOri = eyesMeshs[eyesIndex].sharedMaterial;
    //        ScrollColorsEyes.SetActive(true);
    //        ScrollColorsEyebrow.SetActive(false);
    //        ScrollColorsHair.SetActive(false);
    //    }
    //    else
    //    {
    //        //characterCustomEyesColor.MatOri = eyeMeshs[eyesIndex].sharedMaterial;
    //        ScrollColorsEyes.SetActive(false);
    //        ScrollColorsEyebrow.SetActive(false);
    //        ScrollColorsHair.SetActive(false);
    //    }
    //}

    public void ChangeFaceAcc(int eyebrowIndex)
    {
        currentNumberFaceAcc = eyebrowIndex;
        faceAccMesh.sharedMesh = faceAccMeshs[eyebrowIndex].sharedMesh;
        faceAccMesh.sharedMaterials = faceAccMeshs[eyebrowIndex].sharedMaterials;
        avatarfaceAccMesh.sharedMesh = faceAccMeshs[eyebrowIndex].sharedMesh;
        avatarfaceAccMesh.sharedMaterials = faceAccMeshs[eyebrowIndex].sharedMaterials;
        ScrollColorsHair.SetActive(false);
        ScrollColorsEyebrow.SetActive(false);
        //ScrollColorsEyes.SetActive(false);
        BTNArrowTop.SetActive(false);
        BTNArrowBottom.SetActive(false);
    }

    public void ChangeTorsoAcc(int eyebrowIndex)
    {
        currentNumberTorsoAcc = eyebrowIndex;
        torsoAccMesh.sharedMesh = torsoAccMeshs[eyebrowIndex].sharedMesh;
        torsoAccMesh.sharedMaterials = torsoAccMeshs[eyebrowIndex].sharedMaterials;
        avatartorsoAccMesh.sharedMesh = torsoAccMeshs[eyebrowIndex].sharedMesh;
        avatartorsoAccMesh.sharedMaterials = torsoAccMeshs[eyebrowIndex].sharedMaterials;
        ScrollColorsHair.SetActive(false);
        ScrollColorsEyebrow.SetActive(false);
        //ScrollColorsEyes.SetActive(false);
        BTNArrowTop.SetActive(false);
        BTNArrowBottom.SetActive(false);
    }

    //public void ChangeHead(int headIndex)
    //{
    //    currentNumberHead = headIndex;
    //    headMesh.sharedMesh = headMeshs[headIndex].sharedMesh;
    //    headMesh.sharedMaterials = headMeshs[headIndex].sharedMaterials;
    //}
}
