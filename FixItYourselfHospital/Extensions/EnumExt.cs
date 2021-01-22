using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixItYourselfHospital.Extensions
{
    public static class EnumExt
    {
        // enum extension for getting enum's description
        // UPDATE - we don't need that anymore because we've got RoleModel and SpecializationModel, so enums were deleted
        // Why? We need to keep it as configurable as we can and having enums is need to update two places - db and enum
        // instead of inserting new Role into db and that's all.
        public static string GetDescription<T>(this T e) where T : IConvertible
        {
            string description = string.Empty;

            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var descriptionAttribute = memInfo[0]
                            .GetCustomAttributes(typeof(DescriptionAttribute), false)
                            .FirstOrDefault() as DescriptionAttribute;

                        if (descriptionAttribute != null)
                        {
                            return descriptionAttribute.Description;
                        }
                    }
                }
            }

            return description;
        }

    }
}
