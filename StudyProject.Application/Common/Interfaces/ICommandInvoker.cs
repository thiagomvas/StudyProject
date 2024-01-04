using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyProject.Application.Common.Interfaces
{
    internal interface ICommandInvoker<T>
    {
        void Execute(ICommand command);
    }
}
