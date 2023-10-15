using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AppManager : MonoBehaviour
{
    public Header header;
    public ItemsTab itemsTab;
    public StatsTab statsTab;
    public Transform TabsContainer;
    private ScrollRect _tabsScrollRect;
    
    public bool isItemsTab = true;

    private void Awake()
    {
        _tabsScrollRect = TabsContainer.parent.GetComponent<ScrollRect>();
    }
    private void Start()
    {
        Project project = SaveSystem.LoadCurrentProject();
        header.SetTitle(project.Title);
        header.SetStartDate(project.StartDate);
        header.SetEndDate(project.EndDate);
        
        itemsTab.SetDate(project.StartDate, project.EndDate);
        
        statsTab.SetDate(project.StartDate, project.EndDate);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ChangeTab()
    {
        // if (isItemsTab)
        // {
        //     if(TabsContainer.transform.position.x <= -25)
        //     {
        //         _tabsScrollRect.enabled = false;
        //         TabsContainer.transform.DOMoveX(-275, 1f).OnComplete(() =>
        //         {
        //             _tabsScrollRect.enabled = true;
        //         });
        //     }
        // }
        // else
        // {
        //     if(TabsContainer.transform.position.x >= -250)
        //     {
        //         _tabsScrollRect.enabled = false;
        //         TabsContainer.transform.DOMoveX(0, 1f).OnComplete(() =>
        //         {
        //             _tabsScrollRect.enabled = true;
        //         });
        //     }
        // }
        
    }
    
    

}
