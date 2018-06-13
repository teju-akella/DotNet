using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomPasswordGenerateLibrary
{
    public class Randopwd
    {
        
		const string CAPS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string small = "abcdefghijklmnopqrstuvwxyz";
        const string num = "0123456789";
        const string spl = "!@._*";
        Random rand = new Random();

        public string ranpwd()
        {
            StringBuilder pwd = new StringBuilder();
            for (int i = 1; i <= 2; i++)
            {
                char CapLetter = GenChar(CAPS);
                PwdConcat(pwd, CapLetter);
            }
            for (int i = 1; i <= 2; i++)
            {
                char smallLetter = GenChar(small);
                PwdConcat(pwd, smallLetter);
            }
            for (int i = 1; i <= 2; i++)
            {
                char number = GenChar(num);
                PwdConcat(pwd, number);
            }
            for (int i = 1; i <= 2; i++)
            {
                char special = GenChar(spl);
                PwdConcat(pwd, special);
            }
            return pwd.ToString();
        }

        public void PwdConcat(StringBuilder pass, char pwdChar)
        {
            int position = rand.Next(pass.Length + 1);
            pass.Insert(position, pwdChar);

        }

        public char GenChar(string tempStr)
        {
            int index = rand.Next(tempStr.Length);
            char randChar = tempStr[index];
            return randChar;
        }

    }
}
