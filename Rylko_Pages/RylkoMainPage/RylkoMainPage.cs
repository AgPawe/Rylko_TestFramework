using RyłkoWeb_TestFramework.Rylko_Pages.Enums;
using RyłkoWeb_TestFramework.Rylko_Pages.Rylko_MainPage;
using RyłkoWeb_TestFramework.TestInfrastructure.Enums;

namespace RyłkoWeb_TestFramework.Rylko_Pages
{
    public class RylkoMainPage
    {
       
        public void NavigateToLeftCornerOption(MainPageTopPanelOptions option)
        {
           TopPanel.GoToLeftSideOption(option);
        }

        public void SelectLanguage(Languages language)
        {
            TopPanel.SelectLanguage(language);
        }

        public void GoToCategory(TopPanelCategories category)
        {
            TopPanel.GoToCategory(category);
        }

        public RylkoMainPage() 
        {
            TopPanel = new RylkoTopPanelSubPage();
        }
       
        
       private RylkoTopPanelSubPage TopPanel { get; }
    }
}

