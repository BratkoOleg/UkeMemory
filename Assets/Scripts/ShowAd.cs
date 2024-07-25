// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ShowAd : MonoBehaviour
// {
//     public static int gamesPlayed = 0;
//     [SerializeField] InterstitialAds ad;

//     void OnDisable()
//     {
//         gamesPlayed++;

//         if(gamesPlayed >= 3)
//         {
//             ad.ShowAd();
//             gamesPlayed = 0;
//         }

//         Debug.Log("Games played: " + gamesPlayed);
//     }
// }
