using System;
using System.Collections.Generic;

namespace ThirdPartyTools.Model
{
    public class ArgumentsRepository : IArgumentsRepository
    {
        private List<string> _validVersions;
        private List<string> _validSizes;

        public ArgumentsRepository()
        {
            _validVersions = new List<string>
            {
                "-v", "--v", "/v", "--version"
            };
            _validSizes = new List<string>
            {
                "-s", "--s", "/s", "--size"
            };
        }
        public List<string> GetValidSizeArgs()
        {
            return _validSizes;
        }

        public List<string> GetValidVersionArgs()
        {
            return _validVersions;
        }
    }
}
