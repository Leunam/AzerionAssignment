
using UnityEngine;
using Common.IO;

public class CommonUtils
{
    
	/// <summary>
	/// Reads a text file 
	/// </summary>
	/// <returns>The text file.</returns>
	/// <param name="sFileName">S file name.</param>
	public static string ReadTextFile(string sFileName)
    {
        //Check to see if the specified filename exists, if not try adding '.txt', otherwise fail
        string sFileNameFound = "";
        if (FileHandle.Exists(sFileName))
        {
            sFileNameFound = sFileName; //file found
        }
        else if (FileHandle.Exists(sFileName + ".txt"))
        {
            sFileNameFound = sFileName + ".txt";
        }
        else
        {
            Debug.Log("Could not find file '" + sFileName + "'.");
            return null;
        }

        string fileContents = FileHandle.ReadAllText(sFileNameFound);

        return fileContents;
    }
}