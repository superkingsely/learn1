
namespace flowendpoint.DTOs;
 public sealed record FlowEncryptedRequest(
            string Encrypted_flow_data,
            string Encrypted_aes_key,
            string Initial_vector
        );