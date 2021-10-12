using System.Collections.Generic;

namespace ThirdPartyTools.Model
{
    public interface IArgumentsRepository
    {
        List<string> GetValidVersionArgs();
        List<string> GetValidSizeArgs();
    }
}
