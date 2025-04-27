/// this code its a redy not me thx
using System.Collections.Generic;
using DZCP.API.Interfaces;

namespace DZCP.API
{
    /// <summary>
    /// Comparator implementation for execution priorities.
    /// </summary>
    public sealed class ExecutionPriorityComparer : IComparer<IMod<IConfig>>
    {
        /// <summary>
        /// Gets the static instance.
        /// </summary>
        public static ExecutionPriorityComparer Instance => new();

        /// <inheritdoc/>
        public int Compare(IMod<IConfig> x, IMod<IConfig> y)
        {
            return 0;
        }
    }
}