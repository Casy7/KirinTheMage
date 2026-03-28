using System;
using System.Collections.Generic;
using System.Text;

namespace KiriTheMage.Contracts
{
    public interface IMemoryService
    {
        void SaveInteraction(string userQuery, string agentResponse);
        string GetRecentContext(int depth);
        string GetUserProfile();
    }
}
