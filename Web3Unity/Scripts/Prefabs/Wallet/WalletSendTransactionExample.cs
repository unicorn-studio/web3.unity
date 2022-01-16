using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class WalletSendTransactionExample : MonoBehaviour
{
    async public void OnSendTransaction()
    {
        // private key of account
        string privateKey = "0x78dae1a22c7507a4ed30c06172e7614eb168d3546c13856340771e63ad3c0081";
        // set chain: ethereum, moonbeam, polygon etc
        string chain = "ethereum";
        // set network mainnet, testnet
        string network = "rinkeby";
        // account of player        
        string account = Web3Wallet.Address(privateKey);
        // account to send to
        string to = "0xdD4c825203f97984e7867F11eeCc813A036089D1";
        // value in wei
        string value = "123";
        // optional rpc url
        string rpc = "";

        string chainId = await EVM.ChainId(chain, network, rpc);
        string gasPrice = await EVM.GasPrice(chain, network, rpc);
        string data = "";
        string gasLimit = "21000";
        string transaction = await EVM.CreateTransaction(chain, network, account, to, value, data, gasPrice, gasLimit, rpc);
        string signature = Web3Wallet.SignTransaction(privateKey, transaction, chainId);
        string response = await EVM.BroadcastTransaction(chain, network, account, to, value, data, signature, gasPrice, gasLimit, rpc);
        print(response);
        Application.OpenURL("https://rinkeby.etherscan.io/tx/" + response);
    }
}
