using System;
using System.Collections.Generic;
using System.Text;

namespace KiriTheMage.Contracts
{
    public interface IAiBrainService
    {
        string GenerateResponse(string systemContext, string userPrompt);
    }
}
