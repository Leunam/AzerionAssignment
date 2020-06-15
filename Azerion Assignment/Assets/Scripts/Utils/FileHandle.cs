#if UNITY_WINRT || NETFX_CORE
    using UnityEngine.Windows;
#else
    using System.IO;
#endif

namespace Common.IO
{
    public class FileHandle
    {

        public static bool Exists(string path)
        {
            return File.Exists(path);
        }

        public static string ReadAllText(string path)
        {
#if UNITY_WINRT || NETFX_CORE
            var data = ReadAllBytes(path);
            return Encoding.UTF8.GetString(data,0,data.Length);
#else
            return File.ReadAllText(path);
#endif
        }

        public static byte[] ReadAllBytes(string path)
        {
            return File.ReadAllBytes(path);
        }

        public static void WriteAllBytes(string path, byte[] data)
        {
            File.WriteAllBytes(path, data);
        }

        public static void WriteAllText(string path, string data)
        {
#if UNITY_WINRT
            WriteAllBytes(path, Encoding.UTF8.GetBytes(data));
#else
            File.WriteAllText(path, data);
#endif
        }

        public static void Delete(string path)
        {
            File.Delete(path);
        }
    }
}