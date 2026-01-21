
using System.Security.Cryptography;
using System.Text;
using flowendpoint.DTOs;

namespace flowendpoint.HelperFunc;
public static class DecryptFlowRequest
{
    // This class is intentionally left empty for now.
    public static string DecryptFlow(FlowEncryptedRequest req,RSA rsa ,out byte[] aesKey, out byte[] requestIv   )
    {
        // 1. Decrypt the AES Key using RSA
        aesKey = rsa.Decrypt(Convert.FromBase64String(req.Encrypted_aes_key), RSAEncryptionPadding.OaepSHA256);
        // 2.
        requestIv = Convert.FromBase64String(req.Initial_vector);
        byte[] encryptedData = Convert.FromBase64String(req.Encrypted_flow_data);

         // 3. Split Tag (last 16 bytes) and Ciphertext
        byte[] ciphertext = encryptedData[..^16];
        byte[] tag = encryptedData[^16..];
        byte[] decryptedBytes = new byte[ciphertext.Length];

        // 4. Decrypt using AES-GCM
        using var aesGcm = new AesGcm(aesKey, 16);
        aesGcm.Decrypt(requestIv, ciphertext, tag, decryptedBytes);

        return Encoding.UTF8.GetString(decryptedBytes);
    }
}