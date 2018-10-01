using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CommonConstants
    {
        public enum error_code
        {
            success = 1,
            already_exists = -1,
            maximum_reach = - 2,
            unknow_error = -99,
            ureadable_data = -3,
            default_error = 0,
            not_correct_password = -5,
            not_found_username = -4
        }
        //public const int success = 1;
        //public const int already_exists = -1;
        //public const int maximum_reach = -2;
        //public const int unknow_error = -99;
        //public const int unreadable_data = -3;
        //public const int default_error = 0;
        //public const int not_correct_password = -5;
        //public const int not_found_username = -4;
    }
}
