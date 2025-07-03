using IMoocService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoocService
{
    public class VerificationCodeService: IVerificationCodeService
    {
        public int code { get; set; }

        public int GenerateCode()
        {
            Random randomNum = new Random();
            code = randomNum.Next(1000, 9999);
            return code;
        }

    }
}
