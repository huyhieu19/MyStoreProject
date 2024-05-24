using System.ComponentModel;

namespace Common.Enum
{
    public enum PaymentType
    {
        [Description("Cashing")]
        Cashing = 1,

        [Description("Banking")]
        Banking = 2,
    }
}