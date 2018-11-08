using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.libraries.Utilities
{
    public static class Utilities
    {
        #region Parse a give string to contain Alpha Numeric and specified special characters "'.&#"
        //  A-Z (65 to 90), a-z (97 to 122), # (35), & (38), ' (39), . (46), [SPACE] (32), 0-9 (48 to 57)
        
        public static String cleanString(String value)
        {
            String retCleanString = String.Empty;

            value = value.Trim();

            for (int i = 0; i < value.Length; i++ )
            {
                if (((int)value[i] >= 48 && (int)value[i] <= 57) ||
                    ((int)value[i] >= 65 && (int)value[i] <= 90) ||
                    ((int)value[i] >= 97 && (int)value[i] <= 122) ||
                    (int)value[i] == 35 || (int)value[i] == 38 || 
                    (int)value[i] == 39 || (int)value[i] == 46 || (int)value[i] == 32)
                {
                    // If the current character is a space character
                    // Handling of removing n recurrences of spaces inside the string.
                    if ((int)value[i] == 32)
                    {
                        if ((int)retCleanString[retCleanString.Length - 1] != 32)
                        { 
                            retCleanString = retCleanString + value[i];
                        }
                    }
                    else
                    {
                        // append the current character to the clean string.
                        retCleanString = retCleanString + value[i];
                    }
                }
            }
            
            return retCleanString;
        }
        
        #endregion
    }
}
