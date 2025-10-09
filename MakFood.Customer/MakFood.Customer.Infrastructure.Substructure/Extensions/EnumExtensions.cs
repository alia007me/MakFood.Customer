using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Customer.Infrastructure.Substructure.Extensions
{
    public static class EnumExtensions
    {
        public static T GetNextItem<T>(this T currentItem, bool throwIfFailed = true) where T : struct, Enum
        {
            var enumItems = Enum.GetValues<T>();

            var found = false;
            foreach (var enumItem in enumItems)
            {
                if (found)
                    return enumItem;

                found = enumItem.Equals(currentItem);
            }

            if (throwIfFailed)
                throw new Exception("Failed to retrieve enum!");

            return currentItem;
        }

        public static T GetPreItem<T>(this T currentItem, bool throwIfFailed = true) where T : struct, Enum
        {
            var enumItems = Enum.GetValues<T>().Reverse();

            var found = false;
            foreach (var enumItem in enumItems)
            {
                if (found)
                    return enumItem;

                found = enumItem.Equals(currentItem);
            }

            if (throwIfFailed)
                throw new Exception("Failed to retrieve enum!");

            return currentItem;
        }
    }
}
