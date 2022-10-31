using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    [SerializeField] int maxItems = 3;
    [SerializeField] int timeLimit = 180;
    private int itemsCollected = 0;

    private GUIStyle style = new GUIStyle();

    public void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        style.fontSize = 20;
        style.normal.textColor = Color.white;
    }

    private void End()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        if (Items >= maxItems)
        {
            Win();
        }
        if (Time.time > timeLimit)
        {
            Lose();
        }
    }

    public int Items
    {
        get { return itemsCollected; }
        set { itemsCollected = value; }
    }

    public void Lose()
    {
        End();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Loss");
    }

    public void Win()
    {
        End();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Win");
    }

    public void OnGUI()
    {
        GUI.Box(new Rect(20, 50, 150, 25), "Treasure found: " + itemsCollected + "/" + maxItems
        + "\nCurrent time: " + (int) Time.time + "/" + timeLimit, style);
        // GUI.Box(new Rect(20, 50, 150, 25), , style);
    }
}
