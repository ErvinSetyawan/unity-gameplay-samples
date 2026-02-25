using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class CharacterCustomManager : MonoBehaviour
{
    public CharacterEditor characterEditor;

    void Start()
    {
        // Check if the player is already registered
        CheckPlayerHasDataLogin();
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Error custom character");
        Debug.Log(error.GenerateErrorReport());
    }

    void CheckPlayerHasDataLogin()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnError);
    }

    void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Success login/create account");
        Debug.Log(result);
        GetCustomCharacter();
    }

    public void GetCustomCharacter()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataRecieved, OnError);
    }

    void OnDataRecieved(GetUserDataResult result)
    {
        Debug.Log("Recieved user data!");
        if (result.Data != null && result.Data.ContainsKey("Hair") && result.Data.ContainsKey("Eyebrow") && result.Data.ContainsKey("FaceAcc") && result.Data.ContainsKey("TorsoAcc")
            && result.Data.ContainsKey("HairMatsColor") && result.Data.ContainsKey("EyebrowMatsColor"))
        {
            characterEditor.SetAppearance(result.Data["Hair"].Value, result.Data["Eyebrow"].Value, result.Data["FaceAcc"].Value, result.Data["TorsoAcc"].Value,
                result.Data["HairMatsColor"].Value, result.Data["EyebrowMatsColor"].Value);
        }
        else
        {
            Debug.Log("Player data not complete!");
        }
    }

    //public void SaveCustomCharacter()
    //{
    //    var request = new UpdateUserDataRequest
    //    {
    //        Data = new Dictionary<string, string> {
    //            {"Eyes", characterEditor.Eyes },
    //            {"Eyebrow", characterEditor.Eyebrow },
    //            {"Hair", characterEditor.Hair },
    //            {"Head", characterEditor.Head },
    //            {"EyebrowMatsColor", characterEditor.EyebrowMatsColor },
    //            {"HairMatsColor", characterEditor.HairMatsColor },
    //            {"EyesMatsColor", characterEditor.EyesMatsColor }
    //        }
    //    };
    //    PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    //}

    //void OnDataSend(UpdateUserDataResult result)
    //{
    //    Debug.Log("Successful user data send!");
    //}
}
