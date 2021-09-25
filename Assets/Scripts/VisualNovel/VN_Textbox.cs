using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VN_Textbox : MonoBehaviour
{
    public VN_Core core;

    public Text nametag;
    public Text text;
    public Image portrait;

    public IEnumerator Print(string textToPrint)
    {
        string parsedText = textToPrint.Replace("{PLAYER}", System.Environment.UserName);
        core.waiting = false;
        text.text = "";

        foreach (char character in parsedText)
        {
            //cancel this loop if user wants to skip
            if (core.skip) break;

            text.text += character;
            yield return new WaitForSecondsRealtime(0.05f);
        }

        core.skip = false;
        core.waiting = true;
        text.text = parsedText;
    }
}