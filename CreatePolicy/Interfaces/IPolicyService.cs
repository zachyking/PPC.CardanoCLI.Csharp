using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatePolicy.Interfaces
{
    public interface IPolicyService
    {
        public string CreatePolicy(string signingKeyPath, string verificationKeyPath, string policyName, int validForMinutes = 0);
    }
}
