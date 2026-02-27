using System.Runtime.Serialization;

namespace MODELS.Enum;


public enum Gender
{
        [EnumMember(Value = "Male")]
        Male,
        [EnumMember(Value = "Female")]
        Female,
        [EnumMember(Value = "Other")]
        Other
}
