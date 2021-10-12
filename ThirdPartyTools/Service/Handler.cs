using Microsoft.Extensions.Logging;
using System;
using ThirdPartyTools.Model;

namespace ThirdPartyTools.Service
{
    public class Handler : IHandler
    {
        private readonly ILogger _logger;
        private readonly IArgumentsRepository _argumentsRepository;
        private readonly IFileDetails _fileDetails;

        public Handler(ILogger<Handler> logger, IArgumentsRepository argumentsRepository, IFileDetails fileDetails)
        {
            _logger = logger ?? throw new ArgumentNullException("Logger can not be null");
            _argumentsRepository = argumentsRepository;
            _fileDetails = fileDetails;
        }

        public string GetResponse(string[] args)
        {
            string version = null;
            int size = 0;
            try
            {
                if (_argumentsRepository.GetValidVersionArgs().Contains(args[0]))
                {
                    version = GetVersion(args[1]);
                }
                else if (_argumentsRepository.GetValidSizeArgs().Contains(args[0]))
                {
                    size = GetSize(args[1]);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetResponse");
                throw;
            }
            return version ?? size.ToString();
        }

        public string GetVersion(string path)
        {
            string version = _fileDetails.Version(path);
            _logger.LogInformation(version);
            return version;
        }

        public int GetSize(string path)
        {
            int size = _fileDetails.Size(path);
            _logger.LogInformation(size.ToString());
            return size;
        }
    }
}
