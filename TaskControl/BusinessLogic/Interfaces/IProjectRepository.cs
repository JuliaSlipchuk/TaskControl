using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    interface IProjectRepository
    {
        string GetStatusProjectImplem(int? id);
    }
}
