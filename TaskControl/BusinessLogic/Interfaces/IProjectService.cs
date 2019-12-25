using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    interface IProjectService
    {
        string GetStatusProjectImplem(int? id);
    }
}
