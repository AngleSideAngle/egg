using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    [SerializeField] int maxItems = 3;
    private int itemsCollected = 0;

    private GUIStyle style = new GUIStyle();

    public void Start()
    {
        style.fontSize = 20;
        style.normal.textColor = Color.white;
    }

    void Update()
    {
        if (Items >= maxItems)
        {
            Win();
        }
    }

    public int Items
    {
        get { return itemsCollected; }
        set { itemsCollected = value; }
    }

    public void Lose()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Loss");
    }

    public void Win()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Win");
    }

    public void OnGUI()
    {
        GUI.Box(new Rect(20, 50, 150, 25), "Treasure found: " + itemsCollected + "/" + maxItems, style);
    }
}
