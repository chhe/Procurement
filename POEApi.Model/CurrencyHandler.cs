using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace POEApi.Model
{
    internal class CurrencyHandler
    {
        private static Dictionary<OrbType, double> ratioCache;

        static CurrencyHandler()
        {
            ratioCache = new Dictionary<OrbType, double>();

            foreach (var type in Enum.GetValues(typeof(OrbType)).Cast<OrbType>())
                ratioCache[type] = getRatio(type);
        }

        private static double getRatio(OrbType type)
        {
            if (!Settings.CurrencyRatios.ContainsKey(type))
                return 0;

            return calculateRatio(Settings.CurrencyRatios[type]);
        }

        private static double calculateRatio(CurrencyRatio ratio)
        {
            if (ratio.OrbAmount == 1)
                return ratio.OrbAmount * ratio.ChaosAmount;

            return ratio.ChaosAmount / ratio.OrbAmount;
        }
        
        internal static double GetChaosValue(OrbType type)
        {
            return ratioCache[type];
        }

        public static double GetTotal(OrbType target, IEnumerable<Currency> currency)
        {
            double total = 0;

            foreach (var orb in currency)
                total += orb.StackInfo.Amount * orb.ChaosValue;

            var ratioToChaos = Settings.CurrencyRatios[target];

            total *= (ratioToChaos.OrbAmount / ratioToChaos.ChaosAmount);

            return total;
        }

        public static Dictionary<OrbType, double> GetTotalCurrencyDistribution(OrbType target, IEnumerable<Currency> currency)
        {
            return currency.Where(o => !o.TypeLine.Contains("Shard"))
                           .GroupBy(orb => orb.Type)
                           .Where(group => GetTotal(target, group) > 0)
                           .Select(grp => new { Key = grp.Key, Value = GetTotal(target, grp) })
                           .OrderByDescending(at => at.Value)
                           .ToDictionary(at => at.Key, at => at.Value);
        }

        public static Dictionary<OrbType, double> GetTotalCurrencyCount(IEnumerable<Currency> currency)
        {
            return currency.Where(o => !o.TypeLine.Contains("Shard"))
                           .GroupBy(orb => orb.Type)
                           .Select(grp => new { Key = grp.Key, Value = (double)grp.Sum(c => c.StackInfo.Amount) })
                           .OrderByDescending(at => at.Value)
                           .ToDictionary(at => at.Key, at => at.Value);
        }

        public static Dictionary<string, double> ConvertToDictionaryForDisplay(Dictionary<OrbType, double> orbDictionary)
        {
            Dictionary<string, double> dictionaryForDisplay = new Dictionary<string, double>();
            foreach (KeyValuePair<OrbType, double> entry in orbDictionary)
            {
                dictionaryForDisplay.Add(GetOrbNameForDisplay(entry.Key), entry.Value);
            }
            return dictionaryForDisplay;
        }

        private static string GetOrbNameForDisplay(OrbType orbType)
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
