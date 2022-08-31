using Neo.SmartContract.Framework.Services;
using System;
using System.Numerics;

namespace UNIV
{
    internal class IndexStorage
    {
        private static readonly StorageMap IndexMap = new(Storage.CurrentContext, 0x14);
        public static readonly int MaxIndex = 100;

        public static void Initial(string university) => IndexMap.Put(university, 0);

        public static BigInteger CurrentIndex(string university)
        {
            var curIndex = IndexMap.Get(university);
            if (curIndex == null) throw new Exception("The argument \"university\" is invalid");
            return (BigInteger)curIndex;
        }

        public static BigInteger NextIndex(string university)
        {
            var value = CurrentIndex(university) + 1;
            IndexMap.Put(university, value);
            return value;
        }
    }
}
