using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAddress.Interfaces
{
    public interface IAddressService
    {
        public string CreateAddress(string signingKeyPath, string verificationKeyPath);
    }
}
