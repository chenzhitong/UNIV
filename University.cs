using Neo;
using Neo.SmartContract;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Attributes;
using Neo.SmartContract.Framework.Native;
using Neo.SmartContract.Framework.Services;
using System;
using System.ComponentModel;
using System.Numerics;

namespace university
{
    [DisplayName("NFT-University")]
    [SupportedStandards("NEP-11")]
    [ContractPermission("*", "onNEP11Payment")]
    public partial class University : Nep11Token<TokenState>
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

        public void MintUniv(string secritCode)
        {
            string university;
            BigInteger number = 0;
            byte type = 0;
            switch (secritCode)
            {
                case "AAFwefe":
                    university = "university A";
                    number = IndexStorage.NextIndex(0);
                    break;
                case "BBFwfefe":
                    university = "university B";
                    number = IndexStorage.NextIndex(1);
                    break;
                //TODO
                default: throw new Exception("Incorrect secrit code");
            }
            if (IndexStorage.CurrentIndex(type) > 99)
                throw new Exception("The school's NFTs have all been claimed");
            var token = new TokenState(university, number);
            Mint(token.Name, token);
        }

        [Safe]
        public static BigInteger TotalMint(byte type) => IndexStorage.CurrentIndex(type);
    }
}
