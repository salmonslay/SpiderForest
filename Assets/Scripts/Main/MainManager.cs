using UnityEngine;

public class MainManager : MonoBehaviour
{
    [Header("Menus")] [SerializeField] private GameObject levelMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject creditsMenu;

    [SerializeField] private AudioClip select;

    private Menu activeMenu = Menu.Levels;

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
        settingsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        switch (newMenu)
        {
            case Menu.Levels:
                levelMenu.SetActive(true);
                break;

            case Menu.Settings:
                settingsMenu.SetActive(true);
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
        Levels, // 0
        Settings, // 1
        Credits // 2
    }
}