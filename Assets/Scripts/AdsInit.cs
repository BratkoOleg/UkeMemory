// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Advertisements;

// public class AdsInit : MonoBehaviour, IUnityAdsInitializationListener
// {
//     [SerializeField] string androidGameID = "5627523";
//     [SerializeField] string iOSGameID = "5627522";
//     [SerializeField] bool testMode = true;
//     private string gameID;

//     public void OnInitializationComplete()
//     {
//         Debug.Log("Ads complete");
//     }

//     public void OnInitializationFailed(UnityAdsInitializationError error, string message)
//     {
//         Debug.Log("Ads failed");
//     }

//     void Awake()
//     {
//         InitializeAds();
//     }

//     private void InitializeAds()
//     {
//         gameID = (Application.platform == RuntimePlatform.IPhonePlayer) ? iOSGameID : androidGameID;
//         Advertisement.Initialize(gameID, testMode, this);
//     }
// }
