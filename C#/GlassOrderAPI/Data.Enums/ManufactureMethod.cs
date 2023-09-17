using System.Runtime.Serialization;

namespace Data.Enums
{
    public enum ManufactureMethod
    {
        [EnumMember(Value = "None")]
        None = 0,

        [EnumMember(Value = "LocalMounting")]
        LocalMounting = 1,

        [EnumMember(Value = "RemoteMounting")]
        RemoteMounting = 2,

        [EnumMember(Value = "InhouseProduction")]
        InhouseProduction = 3,

        [EnumMember(Value = "OutsourcedProduction")]
        OutsourcedProduction = 4
    }
}
