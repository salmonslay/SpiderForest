using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VN_Textbox : MonoBehaviour
{
    public Text nametag;
    public Text text;
    public Image portrait;

    [Tooltip("If cancel == true, this object will print out all text directly.")]
    public bool cancel = false;

    private void Start()
    {
        //reset text in this box at start
        text.text = "";
    }

    public void Print(string textToPrint)
    {
        StartCoroutine(PrintTextSlowly(textToPrint));
    }

    private IEnumerator PrintTextSlowly(string textToPrint)
    {
        foreach (char character in textToPrint)
        {
            //cancel this loop if user wants to skip
            if (cancel) break;

            text.text += character;
            yield return new WaitForSecondsRealtime(0.1f);
        }
        text.text = textToPrint;
    }
}