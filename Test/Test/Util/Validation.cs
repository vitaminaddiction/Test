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
        public int v_intager { get; set; }
        public string v_string { get; set; }

        public bool checkEmpty()
        {
            
            return string.IsNullOrEmpty(v_string);
        }

        public bool checkPassword()
        {            
            //https://easy-coding.tistory.com/87
            //https://m.blog.naver.com/dnjswls23/222253252733
            Regex regex = new Regex(@"^(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{7,}$");
            return regex.IsMatch(v_string);
        }

        public bool checkEmail()
        {
            //https://www.csharpstudy.com/Practical/Prac-validemail.aspx
            //https://ko.martech.zone/email-address-regex-functions/
            Regex regex = new Regex(@"[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?");
            return regex.IsMatch(v_string);
        }
    }
}
