using System.ComponentModel;

namespace RyłkoWeb_TestFramework.TestInfrastructure.Enums
{
    public enum MainPageTopPanelShoppingOption
    {
        [Description("NOWOŚCI")]
        New=1,

        [Description("KOBIETA")]
        Women,

        [Description("MĘŻCZYZNA")]
        Men,

        [Description("TOREBKI I DODATKI")]
        Bags,

        [Description("AKCESORIA")]
        Accesories,

        [Description("WYPRZEDAŻ")]
        Sale
    }
}
