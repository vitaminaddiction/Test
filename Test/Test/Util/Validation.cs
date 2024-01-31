using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test.Util
{
    class Validation
    {
        public string v_string { get; set; }

        public bool checkEmpty()
        {
            return string.IsNullOrEmpty(v_string);
        }

        public bool checkPassword()
        {            
            //https://easy-coding.tistory.com/87
            //https://m.blog.naver.com/dnjswls23/222253252733
            Regex regex = new Regex(@"^(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            return regex.IsMatch(v_string);
        }

        public bool checkEmail()
        {
            //https://www.delftstack.com/ko/howto/csharp/validate-email-in-csharp/
            if (v_string == string.Empty)
            {
                return true;
            }
            else
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(v_string);
                    return addr.Address == v_string;
                }
                catch
                {
                    return false;
                }
            }
            
            //https://www.csharpstudy.com/Practical/Prac-validemail.aspx
            //https://ko.martech.zone/email-address-regex-functions/
            //Regex regex = new Regex(@"[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?");
            //return regex.IsMatch(v_string);
        }
    }
}
