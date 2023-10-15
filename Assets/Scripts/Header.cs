using System;
using TMPro;
using UnityEngine;


public class Header : MonoBehaviour
{
    public TextMeshProUGUI Title;
    public TextMeshProUGUI StartDate;
    public TextMeshProUGUI EndDate;
    
    private string title;
    private DateTime startDate;
    private DateTime endDate;
    
    public void SetTitle(string title)
    {
        this.title = title;
        Title.text = title;
    }
    
    public void SetStartDate(DateTime startDate)
    {
        this.startDate = startDate;
        StartDate.text = startDate.ToString("dd/MM/yyyy");
    }
    
    public void SetEndDate(DateTime endDate)
    {
        this.endDate = endDate;
        EndDate.text = endDate.ToString("dd/MM/yyyy");
    }

}

