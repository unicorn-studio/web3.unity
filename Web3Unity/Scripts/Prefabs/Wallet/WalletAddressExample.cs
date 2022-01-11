using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletAddressExample : MonoBehaviour
{
    void Start()
    {
        // private key of account
        string privateKey = "0x78dae1a22c7507a4ed30c06172e7614eb168d3546c13856340771e63ad3c0081"; // Web3Wallet.PrivateKey        
        // get account from private key
        string account = Web3Wallet.Address(privateKey);
        Debug.Log("Account: " + account);
    }
}
