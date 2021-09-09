using UnityEngine;

public class MainManager : MonoBehaviour
{
    [SerializeField] private Animator mainContainer;

    [Header("Menus")] [SerializeField] private GameObject levelMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject creditsMenu;
    private GameObject activeObject;

    [SerializeField] private AudioClip select;

    private Menu activeMenu = Menu.None;

    public void SetMenu(int id)
    {
        SetMenu((Menu)id);
    }

    private void SetMenu(Menu newMenu)
    {
        //only do stuff if menu changes
        if (activeMenu == newMenu) return;

        //play first time animation
        if (activeMenu == Menu.None)
        {
            mainContainer.Play("mainMenu_moveLeft");
        }
        else
        {
            activeObject.SetActive(false);
        }

        //open the right menu
        activeMenu = newMenu;
        activeObject = GetMenu(newMenu);
        activeObject.SetActive(true);

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