using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace POEApi.Model
{
    class OrbTypeHelper
    {
        public static string GetOrbNameForDisplay(OrbType orbType)
        {
            Type type = orbType.GetType();
            MemberInfo[] memInfo = type.GetMember(orbType.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {

                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }

            }

            return orbType.ToString();
        }
    }
}
