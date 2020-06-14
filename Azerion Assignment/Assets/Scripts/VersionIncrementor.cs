#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class VersionIncrementor
{
    static VersionIncrementor()
    {
        EditorApplication.update += RunOnce;
    }

    static void RunOnce()
    {
        EditorApplication.update -= RunOnce;
        ReadVersionAndIncrementBundle();
    }

    /// <summary>
    /// Read version and Increment for ProjectSettings
    /// </summary>
    static void ReadVersionAndIncrementBundle()
    {
        string versionText = PlayerSettings.bundleVersion;

        if (versionText != null)
        {
            versionText = versionText.Trim(); //clean up whitespace if necessary
            string[] lines = versionText.Split('.');
            Debug.Log("lines.length -> " + lines.Length);

            if (lines.Length == 2) //This is the Default Unity version number, I recomend to change to next format 0.1.000.buildCodeName for better build control
            {
                int MajorVersion = int.Parse(lines[0]);
                int MinorVersion = int.Parse(lines[1]) + 1;

                versionText = MajorVersion.ToString("0") + "." +
                              MinorVersion.ToString("0");
            }
            else
            {
                int MajorVersion = int.Parse(lines[0]);         //Major build version number, controls compatibility 
                int MinorVersion = int.Parse(lines[1]);         //Number version to control project updates
                int SubMinorVersion = int.Parse(lines[2]) + 1;  //To know in which build the project is
                string SubVersionText = lines[3].Trim();        //Build code name

                versionText = MajorVersion.ToString("0") + "." +
                              MinorVersion.ToString("0") + "." +
                              SubMinorVersion.ToString("000") + "." +
                              SubVersionText;
            }

            PlayerSettings.bundleVersion = versionText;
            Debug.Log("Version Incremented " + PlayerSettings.bundleVersion);
        }
    }
}
#endif