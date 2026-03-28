using System;
using System.Collections.Generic;
using System.Text;

namespace KiriTheMage.Contracts
{
    public interface IAvatarViewModel
    {
        void PlayAnimation(string stateName);
        void MoveTo(double screenX, double screenY);
    }
}
