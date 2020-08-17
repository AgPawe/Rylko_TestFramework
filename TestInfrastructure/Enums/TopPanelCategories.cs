using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyłkoWeb_TestFramework.TestInfrastructure.Enums
{
    public enum TopPanelCategories
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
