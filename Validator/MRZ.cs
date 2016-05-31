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
        public string Line { get; set; }
        public string PassportNum { get; set; }
        public int CheckDigit1 { get; set; }
        public string Nationality { get; set; }
        public string DOB { get; set; }
        public int CheckDigit2 { get; set; }
        public string Sex { get; set; }
        public string PassportExpDate { get; set; }
        public int CheckDigit3 { get; set; }
        public string PersonalNum { get; set; }
        public int CheckDigit4 { get; set; }
        public int FinalCheckDigit { get; set; }

        public MRZ()
        {
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

        private int GetCheckDigit(string x)
        {
            int cd = 0;

            string ch = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int[] weight = new int[] { 7, 3, 1 };
            int sum = 0;

            for (int i = 0, j = 0; i < x.Length; i++)
            {
                char c = PassportNum[i];
                if (char.IsDigit(c))
                    sum += Convert.ToInt32(c) * weight[j];

                else if (char.IsLetter(c))
                {
                    int v = ch.IndexOf(c) + 10;
                    sum += v * weight[j];
                }

                if (j == 2)
                    j = 0;

                else
                    ++j;
            }

            cd = sum % 10;
            return cd;
        }

        public void SetPassportNum(string x)
        {
            int n = 9;
            if (string.IsNullOrEmpty(x))
                PassportNum = "".PadRight(n, '<');

            else
                PassportNum = x.ToUpper().PadRight(n, '<');

            CheckDigit1 = GetCheckDigit(PassportNum);
        }

        public void SetNationality(string x)
        {
            int n = 3;
            if (string.IsNullOrEmpty(x))
                Nationality = "".PadRight(n, '<');

            else
                Nationality = x.ToUpper().PadRight(n, '<');
        }

        public void SetDOB(string x)
        {
            if (string.IsNullOrEmpty(x))
                return;

            if (IsValidateDate(x))
            {
                DOB = x;
                CheckDigit2 = GetCheckDigit(DOB);
            }
        }

        public void SetSex(string x)
        {
            if (string.IsNullOrEmpty(x))
                Sex = "<";

            else
            {
                string g = x.ToUpper();
                if (g == "M" || g == "F")
                    Sex = g;

                else
                    Sex = "<";
            }
        }

        public void SetPassportExpDate(string x)
        {
            if (string.IsNullOrEmpty(x))
                return;

            if (IsValidateDate(x))
            {
                PassportExpDate = x;
                CheckDigit3 = GetCheckDigit(PassportExpDate);
            }
        }

        public void SetPersonalNum(string x)
        {
            int n = 14;
            if (string.IsNullOrEmpty(x))
                PersonalNum = "".PadRight(n, '<');

            else
                PersonalNum = x.ToUpper().PadRight(n, '<');

            CheckDigit4 = GetCheckDigit(PersonalNum);
        }
        
        public void SetFinalCheckDigit()
        {
            FinalCheckDigit = 0;

            StringBuilder sb = new StringBuilder();
            sb.Append(PassportNum + CheckDigit1)
                .Append(DOB + CheckDigit2)
                .Append(PassportExpDate + CheckDigit3 + PersonalNum + CheckDigit4);
            string s = sb.ToString();

            if (s.Length != 43)
                return;

            FinalCheckDigit = GetCheckDigit(s);
        }

        public bool IsValidCheckDigit1
        {
            get
            {
                bool b = false;
                if (string.IsNullOrEmpty(PassportNum))
                    return b;

                b = PassportNum.All(k => char.IsLetterOrDigit(k) || k == '<');
            }
        }

        public bool IsValidNationality
        {
            get
            {
                if (string.IsNullOrEmpty(Nationality))
                    return false;

                return Nationality.All(k => Char.IsLetter(k) || k == '<');
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
                return Char.IsLetter(Sex) || Sex == '<';
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

                return PersonalNum.All(k => Char.IsLetterOrDigit(k) || k == '<');
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
