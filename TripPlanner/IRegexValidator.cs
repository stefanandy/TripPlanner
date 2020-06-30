using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public interface IRegexValidator
    {
        public bool ValidateName(string name);
        public bool ValidateEmail(string email);
        public bool ValidatePhoneNumber(string phone);

    }
}
