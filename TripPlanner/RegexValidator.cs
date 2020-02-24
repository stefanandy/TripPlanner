using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Business
{
    public class RegexValidator : IRegexValidator
    {
        public bool ValidateEmail(string email)
        {
            try
            {
                System.Net.Mail.MailAddress mailAdress = new System.Net.Mail.MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public bool ValidateName(string name)
        {
            
            Regex regex= new Regex("[A - Z][a - zA - Z][^#&<>\"~;$^%{}?]{1,20}$");
            if (regex.IsMatch(name))
            {
                return true;
            }

            return false;
        }

        public bool ValidatePhoneNumber(string phone)
        {
            Regex regex = new Regex("^[+]*[-]*[0-9]{1,4}[-\x20/0-9]*$");
            if (regex.IsMatch(phone))
            {
                return true;
            }

            return false;
        }
    }
}
