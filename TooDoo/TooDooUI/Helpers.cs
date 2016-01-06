using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TooDooUI
{
    public static class Helpers
    {
        // Metod som kontrollerar om påståendet 1) är en int och 2) om den är en int, finns den i det angivna intervallet
        //1. Kolla om inmatat värde är en int
        //1.1 Om inte int - returnera false
        //1.2 Om int - skriv resulutatet till "result" och kontrollera om inten finns i den angivna rangen 
        //1.2.1 Om inten inte finns i rangen - returnera false
        //1.2.2 Om inten finns i rangen - tilldela värdet från result till validNumber och returnera true, skickar tillbaka info om felmeddelande till variabel

        public static bool TryParseIntWithRange(string input, int minValue, int maxValue, out int validNumber, out string errorMessage)
        {

            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("minValue måste vara mindre än eller lika med maxValue!");
            }

            int result;
            
            var convertionSucceeded = int.TryParse(input, out result);

            if (!convertionSucceeded)
            {
                validNumber = -1;
                errorMessage = (string.Format("Värdet måste vara ett tal mellan {0} och {1}", minValue, maxValue));
                return false;
            }
            else
            {
                if (result >= minValue && result <= maxValue)
                {
                    validNumber = result;
                    errorMessage = "";
                    return true;                    
                }
                else
                {
                    validNumber = -1;
                    errorMessage = (string.Format("Värdet måste vara ett tal mellan {0} och {1}", minValue, maxValue));
                    return false;
                }
            }

            
        }
    }
}
