using Microsoft.VisualStudio.Modeling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPbSU.RobotsLanguage
{
    partial class FixUpDiagram
    {
        private ModelElement GetParentForSubprogramNode(SubprogramNode elem)
        {
            return elem.Compound;
        }
    }
}
