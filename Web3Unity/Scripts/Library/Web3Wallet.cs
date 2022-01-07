using System.Numerics;
using Nethereum.Signer;
using Nethereum.Hex.HexConvertors.Extensions;

public class Web3Wallet
{
    public static string SignTransaction(string _privateKey, string _transaction, string _chainId)
    {
        EthECKey key = new EthECKey(_privateKey);
        // convert transaction
        byte[] hashByteArr = HexByteConvertorExtensions.HexToByteArray(_transaction);
        // parse chain id
        BigInteger chainId = BigInteger.Parse(_chainId);
        // sign transaction
        string signature = EthECDSASignature.CreateStringSignature(key.SignAndCalculateV(hashByteArr, chainId)); 
        return signature;
    }

    public static string Address(string _privateKey)
    {
        EthECKey key = new EthECKey(_privateKey);
        return key.GetPublicAddress();
    }
}
