using System.ComponentModel;

namespace RyłkoWeb_TestFramework.Rylko_Pages.Enums
{
    public enum MainPageTopPanelLogoOptions
    {
        [Description("Znajdź nas")]
        ZnajdzNasLink,

        [Description("Lookbook")]
        LookbookLink,

        [Description("Katalog")]
        KatalogLink,
    
        [Description("Zaloguj się")]
        Zaloguj,

        [Description("Strefa klienta")]
        StrefaKlienta,

        [Description("i-loupe")]
        SzukajIcon,

        [Description("i-cupboard")]
        UlubioneIcon,

        [Description("i-cart")]
        KoszykIcon
    }
}
