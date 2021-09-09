using UnityEngine;

public class MainManager : MonoBehaviour
{
    [SerializeField] private Animator mainContainer;

    [Header("Menus")] [SerializeField] private GameObject levelMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject creditsMenu;
    private GameObject activeObject;

    [SerializeField] private AudioClip select;
    [SerializeField] private AudioClip back;

    private Menu activeMenu = Menu.None;

    public void SetMenu(int id)
    {
        SetMenu((Menu)id);
    }

    private void SetMenu(Menu newMenu)
    {
        //close menu if user double clicks
        if (activeMenu == newMenu)
        {
            activeMenu = Menu.None;
            activeObject.GetComponent<Animator>().Play("mainMenu_panelClose", 0, 0);
            mainContainer.Play("mainMenu_moveRight");
            Helper.PlayAudio(back);
            return;
        }

        //play first time animation
        if (activeMenu == Menu.None)
        {
            mainContainer.Play("mainMenu_moveLeft");
        }
        else
        {
            activeObject.GetComponent<Animator>().Play("mainMenu_panelClose", 0, 0);
            //  activeObject.SetActive(false);
        }

        //open the right menu
        activeMenu = newMenu;
        activeObject = GetMenu(newMenu);
        activeObject.SetActive(true);
        activeObject.GetComponent<Animator>().Play("mainMenu_panelOpen", 0, 0);

        //play sfx
        Helper.PlayAudio(select);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public enum Menu
    {
        None, // 0
        Levels, // 1
        Options, // 2
        Credits // 3
    }

    private GameObject GetMenu(Menu menu)
    {
        switch (menu)
        {
            case Menu.Levels:
                return levelMenu;

            case Menu.Options:
                return optionsMenu;

            case Menu.Credits:
                return creditsMenu;

            default:
                return null;
        }
    }
}