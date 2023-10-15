using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class SaveSystem
{
    public static void CreateProject(Project project)
    {
        List<int> ids = StringToIntList(PlayerPrefs.GetString("ProjectIds", ""));
        int id = ids.Count > 0 ? ids.Max() + 1 : 0;
        ids.Add(id);
        project.Id = id;
        SaveProject(project);
        PlayerPrefs.SetString("ProjectIds", IntListToString(ids));
    }
    
    public static void RemoveProject(Project project)
    {
        List<int> ids = StringToIntList(PlayerPrefs.GetString("ProjectIds", ""));
        ids.Remove(project.Id);
        PlayerPrefs.SetString("ProjectIds", IntListToString(ids));
        PlayerPrefs.DeleteKey(project.Id.ToString());
    }
    
    public static void SaveCurrentProject(Project project)
    {
        PlayerPrefs.SetInt("CurrentProjectId", project.Id);
    }
    public static void SaveProject(Project project)
    {
        int key = project.Id;
        string value = ProjectToString(project);
        PlayerPrefs.SetString(key.ToString(), value);
    }
    
    public static void SaveProjects(Project[] projects)
    {
        foreach (Project project in projects)
        {
            SaveProject(project);
        }
    }
    
    public static Project LoadProject(int id)
    {
        string value = PlayerPrefs.GetString(id.ToString());
        Project project = StringToProject(value);
        return project;
    }
    
    public static Project LoadCurrentProject()
    {
        int id = PlayerPrefs.GetInt("CurrentProjectId", -1);
        if (id == -1)
        {
            return null;
        }
        return LoadProject(id);
    }
    
    public static List<Project> LoadProjects()
    {
        List<Project> projects = new List<Project>();
        List<int> ids = StringToIntList(PlayerPrefs.GetString("ProjectIds", ""));
        foreach (int id in ids)
        {
            projects.Add(LoadProject(id));
        }
        
        return projects;
    }
    
    public static int GetProjectCount()
    {
        return StringToIntList(PlayerPrefs.GetString("ProjectIds", "")).Count;
    }
    
    private static string IntListToString(List<int> array)
    {
        string result = "";
        foreach (int i in array)
        {
            result += i.ToString() + ",";
        }
        return result;
    }
    
    private static List<int> StringToIntList(string str)
    {
        List<int> result = new List<int>();
        string[] array = str.Split(',');
        foreach (string s in array)
        {
            if (s != "")
            {
                result.Add(int.Parse(s));
            }
        }
        return result;
    }
    
    private static string ProjectToString(Project project)
    {
        string result = "";
        result += project.Id + ",";
        result += project.Title + ",";
        result += project.StartDate.ToString() + ",";
        result += project.EndDate.ToString() + ",";
        return result;
    }
    
    private static Project StringToProject(string str)
    {
        string[] array = str.Split(',');
        int Id = int.Parse(array[0]);
        string Title = array[1];
        DateTime StartDate = DateTime.Parse(array[2]);
        DateTime EndDate = DateTime.Parse(array[3]);
        Project result = new Project(Id, Title, StartDate, EndDate);
        return result;
    }
}
