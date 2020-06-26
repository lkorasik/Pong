using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IDebuggable
    {
        /// <summary>
        /// Get information for debug
        /// </summary>
        /// <returns>String with debug data</returns>
        string GetDebugDisplayInfo();

        /// <summary>
        /// Count of lines in debug info
        /// </summary>
        /// <returns>Count of lines</returns>
        int GetDebugDisplayInfoLinesCount();
    }
}
