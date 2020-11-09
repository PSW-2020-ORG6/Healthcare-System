using System.Collections.Generic;

namespace GraphicEditor.HelpClasses
{
    /// <summary>
    /// Class with static Constants
    /// </summary>
    public class Constants
    {
        // Constant
        public const string BACK = "back";

        // Constants used in MainWindowViewModel
        public const string MAP = "map";
        public const string LOGIN = "login";
        public const string BUILDING = "building";

        // Constants used in HospitalMapUserControlViewModel
        public const string EMERGENCY = "emergency";
        public const string CARDIOLOGY = "cardiology";
        public const string ORTHOPEDICS = "orthopedics";
        public const string PEDIATRICS = "pediatrics";
        public const string DERMATOLOGY = "dermatology";
        public const string ONCOLOGY = "oncology";

        // Constants used for building floors
        public static readonly Dictionary<string, string> FLOOR_MAP = new Dictionary<string, string>()
        {
            {BASEMENT , "Basement"},
            {GROUND , "Ground floor"},
            {FIRST, "First floor"},
            {SECOND, "Second floor" },
            {THIRD, "Third floor" },
            {FOURTH, "Fourth floor" },
        };

        public const string BASEMENT = "basement";
        public const string GROUND = "ground";
        public const string FIRST = "first";
        public const string SECOND = "second";
        public const string THIRD = "third";
        public const string FOURTH = "fourth";
        public const string FIFTH = "fifth";
        public const string SIXTH = "sixth";
        public const string SEVENTH = "seventh";
        public const string EIGHTH = "eighth";
        public const string NINTH = "ninth";
    }
}
