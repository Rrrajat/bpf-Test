﻿namespace ThirdPartyTools
{
    public interface IFileDetails
    {
        int Size(string filePath);
        string Version(string filePath);
    }
}