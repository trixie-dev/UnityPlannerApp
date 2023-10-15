using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsTab : MonoBehaviour
{
    public TextMeshProUGUI Days;
    public TextMeshProUGUI Weeks;
    public TextMeshProUGUI Months;
    public TextMeshProUGUI Years;
    public TextMeshProUGUI PercentText;
    public Image ProgressBar;
    
    private DateTime startDate;
    private DateTime endDate;
    
    public void SetDate(DateTime startDate, DateTime endDate)
    {
        this.startDate = startDate;
        this.endDate = endDate;
        
        var totalDays = (endDate - startDate).Days;
        var daysPassed = (System.DateTime.Now - startDate).Days;
        
        // 54<size=80%><color=#A6A6A6> / 150
        Days.text = $"{daysPassed}<size=80%><color=#A6A6A6> / {totalDays}";
        Weeks.text = $"{(daysPassed / 7)}<size=80%><color=#A6A6A6> / {(totalDays / 7)}";
        Months.text = $"{(daysPassed / 30)}<size=80%><color=#A6A6A6> / {(totalDays / 30)}";
        Years.text = $"{(daysPassed / 365)}<size=80%><color=#A6A6A6> / {(totalDays / 365)}";
        PercentText.text = $"{(int)(daysPassed / (float)totalDays * 100)}%";
        
        var progress = (float)daysPassed / totalDays;
        ProgressBar.fillAmount = progress;
        
    }

}