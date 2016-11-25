using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Diagrams;
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

    partial class Subprogram
    {
        /// <summary>
        /// Cannot move the children outside their children shape
        /// </summary>
        public override bool AllowsChildrenToResizeParent
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Cannot size down the parent shape if the children shapes were to move out of their
        /// parent’s boundary
        /// </summary>
        public override SizeD MinimumResizableSize
        {
            get
            {
                return this.CalculateMinimumSizeBasedOnChildren();
            }
        }

        /// <summary>
        /// Keeps the size of the expanded bounds of the shape
        /// </summary>
        protected RectangleD ExpandedBounds;
        /// <summary>
        /// Store the current bounds and set the size.
        /// </summary>
        protected override void Collapse()
        {
            base.Collapse();
            this.ExpandedBounds = this.Bounds;
            this.Bounds = this.AbsoluteBounds;
            this.AbsoluteBounds = new RectangleD
                   (this.Location, new SizeD(1.5, 0.3));
        }
        /// <summary> 
        /// When we expand the shape, we restore the expanded bounds
        /// </summary>
        protected override void Expand()
        {
            base.Expand();
            this.Bounds = this.ExpandedBounds;
        }
    }
}
