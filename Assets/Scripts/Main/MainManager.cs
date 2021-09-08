using UnityEngine;

public class MainManager : MonoBehaviour
{
    [Header("Menus")] [SerializeField] private GameObject levelMenu;
    [SerializeField] private GameObject settingsMenu;

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

        activeMenu = newMenu;

        //toggle the right menu
        levelMenu.SetActive(false);
        settingsMenu.SetActive(false);
        switch (newMenu)
        {
            case Menu.Levels:
                levelMenu.SetActive(true);
                break;

            case Menu.Settings:
                settingsMenu.SetActive(true);
                break;
        }

        Helper.PlayAudio(select);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public enum Menu
    {
        Levels, // 0
        Settings // 1
    }
}