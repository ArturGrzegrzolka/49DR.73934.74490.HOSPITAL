using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FixItYourselfHospital.Extensions
{
    public static class ValidationExt
    {
        private static int PwzLength { get { return 7; } }
        private static int PasswordLength { get { return 10; } }

        // pesel validation taken from http://kozub.net.pl/2012/03/22/c-extension-methods-uzupelnienie/
        public static bool IsValidPesel(this string input)
        {
            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            bool result = false;
            if (input.Length == 11)
            {
                var controlSum = CalculateControlSum(input, weights);
                int controlNum = controlSum % 10;
                controlNum = 10 - controlNum;
                if (controlNum == 10)
                {
                    controlNum = 0;
                }
                int lastDigit = int.Parse(input[input.Length - 1].ToString());
                result = controlNum == lastDigit;
            }
            return result;
        }

        // email validation taken from https://stackoverflow.com/questions/1365407/c-sharp-code-to-validate-email-address
        public static bool IsValidEmail(this string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidName(this string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;

            if (!char.IsUpper(Convert.ToChar(name[0])))
                return false;

            var regex = new Regex(
                "^([A-Za-z]+)$",
                RegexOptions.IgnoreCase | RegexOptions.CultureInvariant
            );

            if (regex.IsMatch(name))
                return true;

            return false;
        }

        public static bool IsValidPassword(this string pass)
        {
            if (string.IsNullOrEmpty(pass))
                return false;

            if (pass.Length > PasswordLength)
                return false;

            if (pass.Any(c => char.IsWhiteSpace(c)))
                return false;

            return true;
        }

        public static bool IsValidPwzNumber(this string pwz)
        {
            if (string.IsNullOrEmpty(pwz))
                return false;

            if (pwz.Length != PwzLength)
                return false;

            if (Convert.ToInt32(pwz[0]).Equals(0))
                return false;

            return true;
        }

        private static int CalculateControlSum(string input, int[] weights, int offset = 0)
        {
            int controlSum = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                controlSum += weights[i + offset] * int.Parse(input[i].ToString());
            }
            return controlSum;
        }
    }
}
