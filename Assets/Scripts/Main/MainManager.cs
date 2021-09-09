using UnityEngine;

public class MainManager : MonoBehaviour
{
    [Header("Menus")] [SerializeField] private GameObject levelMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject creditsMenu;

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

        //toggle the right menu
        activeMenu = newMenu;
        levelMenu.SetActive(false);
        creditsMenu.SetActive(false);
        optionsMenu.SetActive(false);
        switch (newMenu)
        {
            case Menu.Levels:
                levelMenu.SetActive(true);
                break;

            case Menu.Options:
                optionsMenu.SetActive(true);
                break;

            case Menu.Credits:
                creditsMenu.SetActive(true);
                break;
        }

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
}