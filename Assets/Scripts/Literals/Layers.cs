using UnityEngine;

namespace Literals
{
    public static class Layers
    {
         private const string _ignoreBalls = "Ignore balls";
         public static int IgnoreBallsLayer => LayerMask.NameToLayer(_ignoreBalls);
    }
}