using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DisplacementDetection
{
    public interface IDisplacement
    {
        Vector2 Shift { get; }
    }
}

