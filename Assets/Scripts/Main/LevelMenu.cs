using System.Collections.Generic;
using UnityEngine;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] private GameObject scrollView;
    [SerializeField] private GameObject levelTemplate;
    [SerializeField] private RectTransform rect;
    [SerializeField] private List<Level> levels;

    private void Start()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            GameObject obj = Instantiate(levelTemplate);
            LevelCard level = obj.GetComponent<LevelCard>();

            level.ID = levels[i].ID;
            level.levelName.text = levels[i].levelName;
            level.levelDescription.text = levels[i].levelDescription;
            level.levelIcon.sprite = levels[i].levelIcon;

            obj.transform.SetParent(scrollView.transform, false);
            obj.transform.localPosition = new Vector3(0, i * -110);
        }
        rect.sizeDelta = new Vector2(rect.sizeDelta.x, levels.Count * 110 + 100);
    }
}