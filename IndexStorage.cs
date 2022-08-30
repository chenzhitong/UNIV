using Neo.SmartContract.Framework.Services;
using System;
using System.Numerics;

namespace university
{
    /// <summary>
    /// 存储各学校的NFT的最新编号
    /// </summary>
    internal class IndexStorage
    {
        private static readonly StorageMap IndexMap = new(Storage.CurrentContext, 0x14);

        public static BigInteger CurrentIndex(int type)
        {
            if (type < 0 || type > 14) throw new Exception("The argument \"type\" is invalid");
            return (BigInteger)IndexMap.Get(type.ToString());
        }

        public static BigInteger NextIndex(int type)
        {
            var value = CurrentIndex(type) + 1;
            IndexMap.Put(type.ToString(), value);
            return value;
        }

        public static void Initial()
        {
            for (int i = 0; i < 15; i++)
            {
                IndexMap.Put(i.ToString(), 0);
            }
        }
    }
}
