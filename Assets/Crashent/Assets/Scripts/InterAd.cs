// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using GoogleMobileAds.Api;


// public class InterAd : MonoBehaviour
// {
//      private InterstitialAd interstitialAD;
//      private string interstitialUnityId = "ca-app-pub-3426561274035415/1130613332";
//     // Start is called before the first frame update
//     private void OnEnable()
//     {
//         interstitialAD = new InterstitialAd(interstitialUnityId);
//         AdRequest adRequest = new AdRequest.Builder().Build();
//         interstitialAD.LoadAd(adRequest);
//     }

//     public void ShowAd()
//     {
//         if(interstitialAD.IsLoaded())
//             interstitialAD.Show();
//     }

// }
