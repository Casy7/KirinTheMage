using System;
using System.Collections.Generic;
using System.Text;

namespace KiriTheMage.Contracts
{
    public interface ISystemInteractor
    {
        void TeleportCursorAndClick(double x, double y);
        string GetTextFromActiveWindow();
    }
}
