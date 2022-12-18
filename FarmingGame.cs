using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FarmingGame : MonoBehaviour
{
    float timer = 0f;

List<Crop> inventory = new List<Crop>();

Vector2 resolution = new Vector2(1920, 1080);

bool audioEnabled = true;

void Update()
{
    timer += Time.deltaTime;

    for (int i = 0; i < inventory.Count; i++)
    {
        if (inventory[i].ReadyToHarvest())
        {
            Debug.Log($"Harvested {inventory[i].name}");
            inventory.RemoveAt(i);
            i--;
        }
    }
}

void OnGUI()
{
    if (GUI.Button(new Rect(10, 10, 100, 30), "Plant Wheat"))
    {
        inventory.Add(new Wheat());
    }
    if (GUI.Button(new Rect(10, 50, 100, 30), "Plant Carrots"))
    {
        inventory.Add(new Carrots());
    }
    if (GUI.Button(new Rect(10, 90, 100, 30), "Plant Tomatoes"))
    {
        inventory.Add(new Tomatoes());
    }

    if (GUI.Button(new Rect(10, 130, 100, 30), "Sell"))
    {
        int totalSellValue = 0;
        for (int i = 0; i < inventory.Count; i++)
        {
            totalSellValue += inventory[i].sellValue;
        }
        Debug.Log($"Sold {inventory.Count} crops for {totalSellValue} coins");
        inventory.Clear();
    }

    if (GUI.Button(new Rect(10, 90, 100, 30), "Inventory"))
    {
    string inventoryString = string.Join(", ", inventory.Cast<object>());
        Debug.Log($"Inventory: {inventoryString}");
    }

    if (GUI.Button(new Rect(10, 130, 100, 30), "Settings"))
    {
        ShowSettingsMenu();
    }
}

void ShowSettingsMenu()
{
    GUI.BeginGroup(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 175));
    if (GUI.Button(new Rect(0, 0, 100, 30), "Exit"))
    {
        Application.Quit();
    }
    if (GUI.Button(new Rect(0, 40, 100, 30), "Resolution"))
    {
        resolution = ShowResolutionMenu();
    }
    if (GUI.Button(new Rect(0, 80, 100, 30), audioEnabled ? "Disable Audio" : "Enable Audio"))
    {
        audioEnabled = !audioEnabled;
    }
        GUI.EndGroup();
    }

    Vector2 ShowResolutionMenu()
    {
        GUI.BeginGroup(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 175));
        if (GUI.Button(new Rect(0, 0, 100, 30), "1920x1080"))
        {
            GUI.EndGroup();
            return new Vector2(1920, 1080);
        }
        if (GUI.Button(new Rect(0, 40, 100, 30), "1280x720"))
        {
            GUI.EndGroup();
            return new Vector2(1280, 720);
        }
        if (GUI.Button(new Rect(0, 80, 100, 30), "640x480"))
        {
            GUI.EndGroup();
            return new Vector2(640, 480);
        }
        GUI.EndGroup();
        return resolution;
    }
}

public abstract class Crop
{
    public string name;
    public float growTime;
    public int sellValue;
    protected float timer;

    public bool ReadyToHarvest()
    {
        timer += Time.deltaTime;
        return timer >= growTime;
    }
}

public class Wheat : Crop
{
    public Wheat()
    {
        name = "Wheat";
        growTime = 10f;
        sellValue = 5;
    }
}

public class Carrots : Crop
{
    public Carrots()
    {
        name = "Carrots";
        growTime = 15f;
        sellValue =8;
    }
}

public class Tomatoes : Crop
{
    public Tomatoes()
    {
        name = "Tomatoes";
        growTime = 20f;
        sellValue = 10;
    }
}
