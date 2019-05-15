using System;
using System.Collections.Generic;
using System.Security;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib
{
    public static class VariablesClass
    {
        public static Dictionary<string, string> Senders
        {
            get { return dicSenders; }
        }

        private static Dictionary<string, string> dicSenders = new Dictionary<string, string>()
        {
            
        };
    }

    public static class PasswordClass
    {
        public static string getPassword(string p_sPassw)
        {
            string passw = "";
            foreach(char a in p_sPassw)
            {
                char ch = a;
                ch--;
                passw += ch;
            }
            return passw;
        }

        public static string getCodPassword(string p_sPassword)
        {
            string sCode = "";
            foreach(char a in p_sPassword)
            {
                char ch = a;
                ch++;
                sCode += ch;
            }
            return sCode;
        }
    }
}
