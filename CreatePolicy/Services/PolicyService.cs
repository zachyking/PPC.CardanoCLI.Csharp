using CreatePolicy.Interfaces;
using CS.Csharp.CardanoCLI;
using CS.Csharp.CardanoCLI.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace CreatePolicy.Services
{
    public class PolicyService : IPolicyService
    {
        public readonly string _network = ConfigurationManager.AppSettings["CLI_NETWORK"];//"--testnet-magic 1097911063"; //--mainnet
        public readonly string _cardano_cli_location = ConfigurationManager.AppSettings["CLI_PATH"];//$"/home/azureuser/cardano-node-1.27.0/cardano-cli"; //.exe for windows
        public readonly string _working_directory = ConfigurationManager.AppSettings["CLI_WORKING_DIR"];//"/home/azureuser/cardano-node-1.27.0";

        private readonly CLI _cli;
        private readonly ILogger<PolicyService> _logger;

        public PolicyService(ILogger<PolicyService> logger)
        {
            _cli = new CLI(_network, _cardano_cli_location, _working_directory, new CliLogger(logger));
            _logger = logger;
        }

        public string CreatePolicy(string signingKeyPath, string verificationKeyPath, string policyName, int validForMinutes = 0)
        {
            Policies policies = new(_cli);

            policies.Create(new PolicyParams
            {
                PolicyName = policyName,
                TimeLimited = validForMinutes != 0,
                ValidForMinutes = validForMinutes,
                SigningKeyFile = signingKeyPath,
                VerificationKeyFile = verificationKeyPath
            });

            return policies.GeneratePolicyId(policyName);
        }
    }
}
