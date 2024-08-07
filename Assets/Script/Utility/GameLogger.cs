using UnityEngine;


namespace Utility
{
    /// <summary>
    /// Separate class for logging, turn separate loggers off when needed
    /// </summary>
    public static class GameLogger
    {
        /// <summary>
        /// Loggaa yleisiä tapahtumia koodissa.
        /// </summary>
        /// <param name="text"></param>
        public static void Log(string text)
        {
            if (true)
            {
                Debug.Log(text);
            }

        }

        /// <summary>
        /// Loggaa tärkeät ilmoitukset.
        /// </summary>
        /// <param name="text"></param>
        public static void LogImportant(string text)
        {
            if (true)
            {
                Debug.Log(text);
            }

        }

        /// <summary>
        /// Loggaa jos jotain menee pieleen.
        /// </summary>
        /// <param name="text"></param>
        public static void LogWarning(string text)
        {
            if (true)
            {
                Debug.LogWarning(text);
            }

        }

        /// <summary>
        /// loggaa koodia testatessa.
        /// </summary>
        /// <param name="text"></param>
        public static void LogTest(string text)
        {
            if (true)
            {
                Debug.Log(text);
            }

        }
    }
}
