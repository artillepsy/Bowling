using UnityEngine;

namespace Literals
{
    public static class Layers
    {
         public static int IgnoreBallsLayer => LayerMask.NameToLayer("Ignore balls");
    }
}