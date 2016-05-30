using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validator
{
    public class MRZ
    {
        public string PassportNum { get; set; }
        public char CheckDigit1 { get; set; }
        public string Nationality { get; set; }
        public string DOB { get; set; }
        public char CheckDigit2 { get; set; }
        public char Sex { get; set; }
        public string PassportExpDate { get; set; }
        public char CheckDigit3 { get; set; }
        public string PersonalNum { get; set; }
        public char CheckDigit4 { get; set; }
        public char FinalCheckDigit { get; set; }

        public MRZ(string x)
        {
            if (string.IsNullOrEmpty(x))
                return;

            if (x.Length != 44)
                return;

            PassportNum = x.Substring(0, 9);
            CheckDigit1 = x[9];
            Nationality = x.Substring(10, 3);
            DOB = x.Substring(13, 6);
            CheckDigit2 = x[19];
            Sex = x[20];
            PassportExpDate = x.Substring(21, 6);
            CheckDigit3 = x[27];
            PersonalNum = x.Substring(28, 14);
            CheckDigit4 = x[42];
            FinalCheckDigit = x[43];
        }

        public bool IsValidPassportNum
        {
            get
            {
                if (string.IsNullOrEmpty(PassportNum))
                    return false;

                return PassportNum.All(Char.IsLetterOrDigit);
            }
        }

        public bool IsValidCheckDigit1
        {
            get
            {
                return Char.IsDigit(CheckDigit1);
            }
        }

        public bool IsValidNationality
        {
            get
            {
                if (string.IsNullOrEmpty(Nationality))
                    return false;

                return Nationality.All(Char.IsLetter);
            }
        }

        public bool IsValidDOB
        {
            get
            {
                if (string.IsNullOrEmpty(DOB))
                    return false;

                bool b = true;
                if (!DOB.All(Char.IsDigit))
                    return b;

                b = IsValidateDate(DOB);
                if (!b)
                    return b;

                return b;
            }
        }

        public bool IsValidCheckDigit2
        {
            get
            {
                return Char.IsDigit(CheckDigit2);
            }
        }

        public bool IsValidSex
        {
            get
            {
                return Char.IsLetter(Sex);
            }
        }

        public bool IsValidPassportExpDate
        {
            get
            {
                if (string.IsNullOrEmpty(PassportExpDate))
                    return false;

                bool b = true;
                if (!PassportExpDate.All(Char.IsDigit))
                    return b;

                b = IsValidateDate(PassportExpDate);
                if (!b)
                    return b;

                return b;
            }
        }

        public bool IsValidCheckDigit3
        {
            get
            {
                return Char.IsDigit(CheckDigit3);
            }
        }

        public bool IsValidPersonalNum
        {
            get
            {
                if (string.IsNullOrEmpty(PersonalNum))
                    return false;

                return PersonalNum.All(Char.IsLetterOrDigit);
            }
        }

        public bool IsValidCheckDigit4
        {
            get
            {
                return Char.IsDigit(CheckDigit4);
            }
        }

        public bool IsValidFinalCheckDigit
        {
            get
            {
                return Char.IsDigit(FinalCheckDigit);
            }
        }

        private bool IsValidateDate(string x)
        {
            bool b = false;
            DateTime dt;

            try
            {
                b = DateTime.TryParseExact(x, "yyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
            }

            catch
            {

            }

            return b;
        }
    }
}
