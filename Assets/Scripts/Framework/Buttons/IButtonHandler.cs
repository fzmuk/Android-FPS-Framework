using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Buttons
{
    public interface IButtonHandler
    {
        void Click();
        void Pressed();
        void Released();
    }

}
