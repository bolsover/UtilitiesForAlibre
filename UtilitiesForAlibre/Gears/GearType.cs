using System.Collections.Generic;
using System.Linq;

namespace Bolsover.Gears
{
    public class GearType
    {
        public static readonly GearType EXTERNAL_SPUR = new("EXTERNAL_SPUR", "Standard External Spur");

        public static readonly GearType EXTERNAL_PROFILE_SHIFT_SPUR =
            new("EXTERNAL_PROFILE_SHIFT_SPUR", "Profile Shifted External Spur");

        // public static readonly GearType EXTERNAL_HELICAL = new("EXTERNAL_HELICAL", "Standard External Helical");
        //
        // public static readonly GearType EXTERNAL_PROFILE_SHIFT_HELICAL =
        //     new("EXTERNAL_PROFILE_SHIFT_HELICAL", "Profile Shifted External Helical");

        public static IEnumerable<GearType> Values
        {
            get
            {
                //  yield return EXTERNAL_SPUR;
                yield return EXTERNAL_PROFILE_SHIFT_SPUR;
                // yield return EXTERNAL_HELICAL;
                //   yield return EXTERNAL_PROFILE_SHIFT_HELICAL;
            }
        }

        public static GearType[] Types()
        {
            return Values.ToArray();
        }

        public GearType(string title, string name)
        {
            (Title, Name) = (title, name);
        }


        public string Title { get; private set; }
        public string Name { get; private set; }

        public override string ToString()
        {
            return Name;
        }
    }
}