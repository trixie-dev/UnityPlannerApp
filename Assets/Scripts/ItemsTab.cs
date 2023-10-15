using System;
using TMPro;
using UnityEngine;

public enum TimeItem
{
    Day,
    Week,
    Month,
    Year
}

public class ItemsTab : MonoBehaviour
{
    public TimeItem Mode = TimeItem.Week;
    
    public Transform ItemContainer;
    public GameObject ItemPrefab;
    public TextMeshProUGUI ModeText;
    public GameObject Footer;
    
    private DateTime start;
    private DateTime end;

    public void SetDate(DateTime start, DateTime end)
    {
        this.start = start;
        this.end = end;
        SetMode(Mode);
    }
    
    public void SetMode(TimeItem Mode = TimeItem.Week)
    {
        foreach (Transform child in ItemContainer)
        {
            Destroy(child.gameObject);
        }
        SpawnItems(Mode);
        ChangeModeText();
    }
    
    public void NextMode()
    {
        Mode = (TimeItem)(((int)Mode + 1) % 4);
        SetMode(Mode);
    }
    
    public void PrevMode()
    {
        Mode = (TimeItem)(((int)Mode + 3) % 4);
        SetMode(Mode);
    }

    private void SpawnItems(TimeItem Mode = TimeItem.Week)
    {
        this.Mode = Mode;
        int allCount = 0;
        int toCurrentCount = 0;
        switch (Mode)
        {
            case TimeItem.Day:
                allCount = (int)(end - start).TotalDays;
                toCurrentCount = (int)(DateTime.Now - start).TotalDays;
                break;
            case TimeItem.Week:
                allCount = (int)(end - start).TotalDays / 7;
                toCurrentCount = (int)(DateTime.Now - start).TotalDays / 7;
                break;
            case TimeItem.Month:
                allCount = (end.Year - start.Year) * 12 + end.Month - start.Month;
                toCurrentCount = (DateTime.Now.Year - start.Year) * 12 + DateTime.Now.Month - start.Month;
                break;
            case TimeItem.Year:
                allCount = end.Year - start.Year;
                toCurrentCount = DateTime.Now.Year - start.Year;
                break;
            default:
                break;
        }
        ChangeContainerSize(allCount);
        for (int i = 0; i < allCount; i++)
        {
            GameObject obj = Instantiate(ItemPrefab, ItemContainer);
            if (i < toCurrentCount)
            {
                obj.GetComponent<Item>().Fill();
            }
        }
    }
    
    private void ChangeContainerSize(int count)
    {
        int height = count / 10 * 30;
        ItemContainer.GetComponent<RectTransform>().sizeDelta = new Vector2(0, height);
    }
    
    private void ChangeModeText()
    {
        switch (Mode)
        {
            case TimeItem.Day:
                ModeText.text = "Days";
                break;
            case TimeItem.Week:
                ModeText.text = "Weeks";
                break;
            case TimeItem.Month:
                ModeText.text = "Months";
                break;
            case TimeItem.Year:
                ModeText.text = "Years";
                break;
            default:
                break;
        }
    }

    
    
}