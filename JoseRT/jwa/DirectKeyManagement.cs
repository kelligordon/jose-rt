﻿using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Json;
using JoseRT.Serialization;
using JoseRT.util;

namespace JoseRT.jwa
{
    public sealed class DirectKeyManagement : IJwaAlgorithm
    {
        public Part[] WrapNewKey(int cekSizeBits, object key, JsonObject header)
        {
            return new[] {new Part(Ensure.Type<byte[]>(key, "DirectKeyManagement expectes key to be byte[] array.")), new Part(new byte[0])};
        }

        public byte[] Unwrap([ReadOnlyArray] byte[] encryptedCek, object key, int cekSizeBits, JsonObject header)
        {
            Ensure.IsEmpty(encryptedCek, "DirectKeyManagement expects empty content encryption key");

            return Ensure.Type<byte[]>(key, "DirectKeyManagement expectes key to be byte[] array.");
        }

        public string Name
        {
            get { return JwaAlgorithms.DIR; }            
        }
    }
}