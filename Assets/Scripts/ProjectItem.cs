using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProjectItem : MonoBehaviour
{
    public TextMeshProUGUI Title;
    public TextMeshProUGUI StartDate;
    public TextMeshProUGUI EndDate;
    public Image ProgressBar;
    
    private Project _project;
    
    public void SetData(Project project)
    {
        _project = project;
        Title.text = project.Title;
        StartDate.text = project.StartDate.ToString("dd/MM/yyyy");
        EndDate.text = project.EndDate.ToString("dd/MM/yyyy");
        
        var totalDays = (project.EndDate - project.StartDate).Days;
        var daysPassed = (System.DateTime.Now - project.StartDate).Days;
        var progress = (float)daysPassed / totalDays;
        ProgressBar.fillAmount = progress;
    }
    
    public void OpenProject()
    {
        SaveSystem.SaveCurrentProject(_project);
        SceneManager.LoadScene("Main");
    }
    
    public void RemoveProject()
    {
        SaveSystem.RemoveProject(_project);
        Destroy(gameObject);
    }
}
