using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
/// <summary>
/// Read version and print text version on screen
/// </summary>
public class PrintAppVersion : MonoBehaviour {

	void Start () {    
            this.GetComponent<TextMeshProUGUI>().text = "v."+Application.version;
        }
}