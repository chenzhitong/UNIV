using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Native;
using Neo.SmartContract.Framework.Services;
using System;

namespace UNIV
{
    public partial class UNIV
    {
        private static readonly StorageMap OwnerMap = new(Storage.CurrentContext, 0x16);

        private static bool IsOwner() => Runtime.CheckWitness(GetOwner());

        public static bool Verify() => IsOwner();

        public static UInt160 SetOwner(UInt160 newOwner)
        {
            if (!IsOwner()) throw new Exception("No authorization.");
            if (!newOwner.IsValid) throw new Exception("SetOwner: UInt160 is invalid.");

            OwnerMap.Put("owner", newOwner);
            return GetOwner();
        }

        public static void Initialize(string university) => IndexStorage.Initial(university);

        public static void _deploy(object _, bool update)
        {
            if (update) return;
        }

        public static void Update(ByteString nefFile, string manifest)
        {
            if (!IsOwner()) throw new Exception("No authorization.");
            ContractManagement.Update(nefFile, manifest, null);
        }

        public static void Destroy()
        {
            if (!IsOwner()) throw new Exception("No authorization.");
            ContractManagement.Destroy();
        }
    }
}
