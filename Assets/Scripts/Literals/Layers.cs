using UnityEngine;

namespace Literals
{
    /// <summary>
    /// Container of layer index
    /// </summary>
    public static class Layers
    {
         public static int IgnoreBallsLayer => LayerMask.NameToLayer("Ignore balls");
    }
}