using UnityEngine;
using UnityEngine.UI;

public class VN_Core : MonoBehaviour
{
    [Tooltip("ID of the story text file.")]
    public string ID;

    [Tooltip("All actions this visual novel contains")]
    public string[] actions;

    [Tooltip("Current visual novel index")]
    private int index = 0;

    [Tooltip("Whether the user wants to skip this text or not")]
    public bool skip = false;

    [Tooltip("Whether the VN is waiting to continue or not")]
    public bool waiting = true;

    private void Start()
    {
        VisualNovel.FreezeScene();
        actions = (Resources.Load($"VisualNovel/novel_{ID}") as TextAsset).ToString().Split('\n');
        RunNext();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (waiting)
                RunNext();
            else
                skip = true;
        }
    }

    /// <summary>
    /// Process the next line in this VN
    /// </summary>
    public void RunNext()
    {
        //split line into arguments
        string[] line = actions[index++].Split('|');

        //cancel if this line is blank
        if (line.Length < 2)
        {
            RunNext();
            return;
        }

        //first argument in this line
        string action = line[0].ToLower();

        //destroy earlier textbox
        Destroy(GameObject.Find($"{name}/Textbox"));

        switch (action)
        {
            case "t":
                Text(line);
                break;

            case "bg":
                SetBackground(line[1]);
                break;

            default:
                Debug.LogWarning($"Visual Novel action \"{action}\" not valid (INDEX {index}).");
                RunNext();
                break;
        }
    }

    #region ACTIONS

    private void Text(string[] args)
    {
        GameObject textboxObject = Instantiate(Resources.Load("VisualNovel/Prefabs/Textbox"), transform, false) as GameObject;
        VN_Textbox textbox = textboxObject.GetComponent<VN_Textbox>();

        textbox.name = "Textbox";
        textbox.core = this;
        textbox.portrait.sprite = Resources.Load<Sprite>($"VisualNovel/{args[1]}");
        textbox.nametag.text = args[2];
        StartCoroutine(textbox.Print(args[3]));
    }

    private void SetBackground(string file)
    {
        print(file);
        GameObject background = Instantiate(Resources.Load("VisualNovel/Prefabs/Background"), transform, false) as GameObject;
        background.GetComponent<Image>().sprite = Resources.Load<Sprite>($"VisualNovel/{file.Trim()}");

        //set layer dependent on index
        Vector3 pos = background.transform.localPosition;
        background.transform.localPosition = new Vector3(pos.x, pos.y, index);

        RunNext();
    }

    #endregion ACTIONS
}