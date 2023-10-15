using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ProjectList: MonoBehaviour
{
    public List<Project> Projects = new List<Project>();

    public TextMeshProUGUI TabTitle;
    
    public Transform ProjectContainer;
    public GameObject ProjectConstructorTab;
    public GameObject ProjectPrefab;
    
    [SerializeField] private TMP_InputField _titleInput;
    
    [SerializeField] private TMP_InputField _startDateInputDay;
    [SerializeField] private TMP_InputField _startDateInputMonth;
    [SerializeField] private TMP_InputField _startDateInputYear;
    
    [SerializeField] private TMP_InputField _endDateInputDay;
    [SerializeField] private TMP_InputField _endDateInputMonth;
    [SerializeField] private TMP_InputField _endDateInputYear;

    private void Awake()
    {
        Projects = SaveSystem.LoadProjects();
        foreach (Project project in Projects)
        {
            SpawnProjectItem(project);
        }
    }
    
    private void SpawnProjectItem(Project project)
    {
        GameObject projectItem = Instantiate(ProjectPrefab, ProjectContainer);
        projectItem.transform.SetAsFirstSibling();
        projectItem.GetComponent<ProjectItem>().SetData(project);
        ChangeContainerSize(SaveSystem.GetProjectCount() + 2);
    }

    public void OpenProjectConstructorTab()
    {
        TabTitle.text = "Create Timer: ";
        ProjectConstructorTab.SetActive(true);
    }
    
    public void CloseProjectConstructorTab()
    {
        TabTitle.text = "Timers: ";
        ProjectConstructorTab.SetActive(false);
    }
    
    public void CreateProject()
    {
        bool canCreate = true;
        
        canCreate &= CheckInputField(_titleInput);
        canCreate &= CheckInputField(_startDateInputDay);
        canCreate &= CheckInputField(_startDateInputMonth);
        canCreate &= CheckInputField(_startDateInputYear);
        canCreate &= CheckInputField(_endDateInputDay);
        canCreate &= CheckInputField(_endDateInputMonth);
        canCreate &= CheckInputField(_endDateInputYear);
        
        if (!canCreate)
        {
            return;
        }
        
        string title = _titleInput.text;
        
        int startDay = int.Parse(_startDateInputDay.text);
        int startMonth = int.Parse(_startDateInputMonth.text);
        int startYear = int.Parse(_startDateInputYear.text);
        int endDay = int.Parse(_endDateInputDay.text);
        int endMonth = int.Parse(_endDateInputMonth.text);
        int endYear = int.Parse(_endDateInputYear.text);
        
        

        DateTime startDate = new DateTime(startYear, startMonth, startDay);
        DateTime endDate = new DateTime(endYear, endMonth, endDay);
        
        Project project = new Project(0, title, startDate, endDate);
        SaveSystem.CreateProject(project);
        Projects.Add(project);
        SpawnProjectItem(project);
        CloseProjectConstructorTab();
    }
    
    private bool CheckInputField(TMP_InputField inputField)
    {
        if (inputField.text.Length == 0)
        {
            Image image = inputField.GetComponent<Image>();
            image.DOColor(Color.red, 0.5f)
                .SetEase(Ease.InOutSine)
                .SetLoops(2, LoopType.Yoyo)
                .OnComplete(() => image.color = Color.white);
            
            image.transform.DOShakePosition(1f, 2f, 10, 90f, false, true);
            
            return false;
        }
        else
        {
            return true;
        }
        
    }
    
    private void ChangeContainerSize(int count)
    {
        int height = count / 2 * 100 + 100;
        ProjectContainer.GetComponent<RectTransform>().sizeDelta = new Vector2(0, height > 220 ? height : 220);
    }
}



[Serializable]
public class Project
{
    public int Id;
    public string Title;
    public DateTime StartDate;
    public DateTime EndDate;
    
    public Project(int id, string title, DateTime startDate, DateTime endDate)
    {
        Id = id;
        Title = title;
        StartDate = startDate;
        EndDate = endDate;
    }
}

