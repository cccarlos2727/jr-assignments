using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMoocService
{
    public interface IVerificationCodeService
    {
        public int GenerateCode();
    }
}
