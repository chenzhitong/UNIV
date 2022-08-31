using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services;
using System;
using System.Numerics;

namespace UNIV
{
    public class TokenState : Nep11TokenState
    {
        public string University;
        public BigInteger Number;
        public string Image;

        public TokenState(UInt160 owner, string university, BigInteger number)
        {
            Owner = owner;
            Name = university + " #" + number;
            Number = number;
            Image = "https://neo.org/" + Name + ".png";
        }
    }
}
