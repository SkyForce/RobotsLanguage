using Microsoft.VisualStudio.Modeling.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPbSU.RobotsLanguage
{
    [ValidationState(ValidationState.Enabled)]
    public class Validator
    {
        RobotModel model;
        public Validator(RobotModel rm)
        {
            model = rm;
        }
        [ValidationMethod(ValidationCategories.Menu)]
        private void Validate(ValidationContext context)
        {
            context.LogError("hi", "123");
        }
    }
}
