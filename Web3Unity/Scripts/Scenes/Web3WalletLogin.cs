using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Web3WalletLogin : MonoBehaviour
{
    public static Web3WalletLogin Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;                
            Application.deepLinkActivated += onDeepLinkActivated;
            if (!string.IsNullOrEmpty(Application.absoluteURL))
            {
                // Cold start and Application.absoluteURL not null so process Deep Link.
                onDeepLinkActivated(Application.absoluteURL);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnWeb3WalletLogin()
    {
        Application.OpenURL("https://chainsafe.github.io/game-web3wallet");
    }

    private void onDeepLinkActivated(string url)
    {
        // Decode the URL to determine action. 
        // In this example, the app expects a link formatted like this:
        // unitydl://unity?0xPrivateKey
        string privateKey = url.Split("?"[0])[1];
        try
        {
            // check if private key is valid
            Web3Wallet.Address(privateKey);
        }
        catch
        {
            return;
        }
        // set private key. Can save to PlayerPrefs or other storage
        Web3Wallet.PrivateKey = privateKey; 
        // move to next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);    
    }
}
