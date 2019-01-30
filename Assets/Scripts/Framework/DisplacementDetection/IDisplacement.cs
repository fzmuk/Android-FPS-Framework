using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DisplacementDetection
{
    /// <summary>
    /// An interface intended for the classes which detect entry of the players.
    /// </summary>
    public interface IDisplacement
    {
        Vector2 Shift { get; }
    }
}

