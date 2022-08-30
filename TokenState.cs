using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services;
using System;
using System.Numerics;

namespace university
{
    public class TokenState : Nep11TokenState
    {
        public byte University;
        public BigInteger Number;
        public string Image;

        public TokenState(string university, BigInteger number)
        {
            Owner = ((Transaction)Runtime.ScriptContainer).Sender;
            Name = university;
            Number = number;
            Image = "https://neo.org/" + Name + ".png";
        }

        public void CheckAdmin()
        {
            if (Runtime.CheckWitness(Owner)) return;
            throw new InvalidOperationException("No authorization.");
        }
    }
}
