using Neo;
using Neo.SmartContract;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Attributes;
using Neo.SmartContract.Framework.Native;
using Neo.SmartContract.Framework.Services;
using System;
using System.ComponentModel;
using System.Numerics;

namespace UNIV
{
    [DisplayName("UNIV")]
    [SupportedStandards("NEP-11")]
    [ContractPermission("*", "onNEP11Payment")]
    public partial class UNIV : Nep11Token<TokenState>
    {
        [InitialValue("NSuyiLqEfEQZsLJawCbmXW154StRUwdWoM", ContractParameterType.Hash160)]
        static readonly UInt160 Owner = default;

        [Safe]
        public override string Symbol() => "UNIV";

        [Safe]
        public static UInt160 GetOwner()
        {
            var owner = OwnerMap.Get("owner");
            return owner != null ? (UInt160)owner : Owner;
        }

        [Safe]
        public override Map<string, object> Properties(ByteString tokenId)
        {
            StorageMap tokenMap = new(Storage.CurrentContext, Prefix_Token);
            TokenState token = (TokenState)StdLib.Deserialize(tokenMap[tokenId]);
            Map<string, object> map = new();
            map["name"] = token.Name;
            map["owner"] = token.Owner;
            map["number"] = token.Number;
            map["image"] = token.Image;
            return map;
        }

        public static void MintUniv(string university)
        {
            if (IndexStorage.CurrentIndex(university) >= IndexStorage.MaxIndex)
                throw new Exception("The school's NFTs have all been claimed.");
            var token = new TokenState(university, IndexStorage.NextIndex(university));
            Mint(token.Name, token);
        }

        [Safe]
        public static BigInteger TotalMint(string university) => IndexStorage.CurrentIndex(university);
    }
}
