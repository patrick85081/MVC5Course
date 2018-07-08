using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.Validation
{
    public class 身份證字號驗證Attribute : DataTypeAttribute
    {
        public 身份證字號驗證Attribute() : base(DataType.Text)
        {
            ErrorMessage = "請輸入正確的身份證字號";
        }

        public override bool IsValid(object value)
        {
            string str = (string) value;

            return IsIdentificationId(str);
        }

        public bool IsIdentificationId(string identify)
        {
            if (string.IsNullOrEmpty(identify))
                return true;

            var d = false;
            if (identify.Length == 10)
            {
                identify = identify.ToUpper();
                if (identify[0] >= 0x41 && identify[0] <= 0x5A)
                {
                    var a = new[]
                    {
                        10, 11, 12, 13, 14, 15, 16, 17, 34, 18, 19, 20, 21, 22, 35, 23, 24, 25, 26, 27, 28, 29, 32, 30,
                        31, 33
                    };
                    var b = new int[11];
                    b[1] = a[(identify[0]) - 65] % 10;
                    var c = b[0] = a[(identify[0]) - 65] / 10;
                    for (var i = 1; i <= 9; i++)
                    {
                        b[i + 1] = identify[i] - 48;
                        c += b[i] * (10 - i);
                    }

                    if (((c % 10) + b[10]) % 10 == 0)
                    {
                        d = true;
                    }
                }
            }

            return d;
        }
    }
}