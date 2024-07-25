// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Advertisements;

// public class InterstitialAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
// {
//     [SerializeField] private string androidAdID = "Interstitial_Android";
//     [SerializeField] private string iOSAdID = "Interstitial_iOS";
//     private string adId;

//     public void OnUnityAdsAdLoaded(string placementId)
//     {
//         throw new NotImplementedException();
//     }

//     public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
//     {
//         throw new NotImplementedException();
//     }

//     public void OnUnityAdsShowClick(string placementId)
//     {
//         throw new NotImplementedException();
//     }

//     public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
//     {
//         Time.timeScale = 1;
//         LoadAd();
//     }

//     public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
//     {
//         throw new NotImplementedException();
//     }

//     public void OnUnityAdsShowStart(string placementId)
//     {
//         throw new NotImplementedException();
//     }

//     void Awake()
//     {
//         adId = (Application.platform == RuntimePlatform.IPhonePlayer)
//             ? iOSAdID
//             : androidAdID;
//             LoadAd();
//     }

//     private void LoadAd()
//     {
//         Debug.Log("loading ad: " + adId);
//         Advertisement.Load(adId, this);
//     }

//     public void ShowAd()
//     {
//         Time.timeScale = 0;
//         Debug.Log("Showing ad: " + adId);
//         Advertisement.Show(adId, this);
//     }
// }
