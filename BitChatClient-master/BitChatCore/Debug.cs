
*/

using System;

namespace BitChatCore
{
    public static class Debug
    {
        #region variables

        static object _lockObj = new object();
        static IDebug _debug;

        #endregion

        #region public static

        public static void SetDebug(IDebug debug)
        {
            _debug = debug;
        }

        public static void Write(string source, Exception ex)
        {
            if (_debug != null)
            {
                lock (_lockObj)
                {
                    _debug.Write(DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss") + "\t" + source + "\t" + ex.Message + "\r\nStack Trace: \r\n\t" + ex.StackTrace + "\r\n\r\n");
                }
            }
        }

        public static void Write(string source, string message)
        {
            if (_debug != null)
            {
                lock (_lockObj)
                {
                    _debug.Write(DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss") + "\t" + source + "\t" + message + "\r\n\r\n");
                }
            }
        }

        #endregion
    }
}
