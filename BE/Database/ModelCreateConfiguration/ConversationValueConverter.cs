using Common.Enum;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Database.ModelCreateConfiguration;

public sealed class ConversationValueConverter : ValueConverter<PaymentType, string>
{
    public ConversationValueConverter() : base(
        v => v.ToString(), // Convert enum to string
        s => Enum.Parse<PaymentType>(s, false) // Convert string to enum
    )
    {
    }
}