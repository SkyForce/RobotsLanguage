using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Diagrams;
using Microsoft.VisualStudio.Modeling.Validation;
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

    [ValidationState(ValidationState.Enabled)]
    public partial class RobotModel
    {
        ValidationContext context;
        HashSet<string> nodes = new HashSet<string>();
        [ValidationMethod(ValidationCategories.Menu)]
        private void Validate(ValidationContext context)
        {
            this.context = context;
            AbstractNode st = null;
            foreach (AbstractNode an in AbstractNode)
            {
                if (an is StartNode)
                {
                    if (st != null)
                    {
                        context.LogError("Start node must be one", "start", an);
                    }
                    st = an;
                    if (an.SourceAbstractNode.Count != 0)
                        context.LogError("Incorrect source elements", "source", an);
                    if (an.TargetAbstractNode.Count != 1)
                        context.LogError("Incorrect target elements", "target", an);
                }
                else if (an is FinishNode)
                {
                    if (an.TargetAbstractNode.Count != 0)
                        context.LogError("Incorrect target elements", "target", an);
                }
                else if (an is IfNode)
                {
                    if (an.SourceAbstractNode.Count > 2 || an.SourceAbstractNode.Count == 0)
                        context.LogError("Incorrect source elements", "source", an);
                    if (an.TargetAbstractNode.Count != 2 && an.SourceAbstractNode.Count == 1 || an.TargetAbstractNode.Count != 3 && an.SourceAbstractNode.Count == 2)
                        context.LogError("Incorrect target elements", "target", an);

                }
                else if (an is EndIfNode)
                {
                    if (an.SourceAbstractNode.Count < 1 || an.SourceAbstractNode.Count > 2)
                        context.LogError("Incorrect source elements", "source", an);
                    if (an.TargetAbstractNode.Count != 1)
                        context.LogError("Incorrect target elements", "target", an);
                }
                else if (an is IterationsNode)
                {
                    if (an.SourceAbstractNode.Count < 2 || an.SourceAbstractNode.Count > 3)
                        context.LogError("Incorrect source elements", "source", an);
                    if (an.TargetAbstractNode.Count != 2)
                        context.LogError("Incorrect target elements", "target", an);
                }
                else if (an is SubprogramCallNode)
                {
                    if (an.SourceAbstractNode.Count < 1 || an.SourceAbstractNode.Count > 2)
                        context.LogError("Incorrect source elements", "source", an);
                    if (an.TargetAbstractNode.Count != 1 && an.SourceAbstractNode.Count == 1 || an.TargetAbstractNode.Count != 2 && an.SourceAbstractNode.Count == 2)
                        context.LogError("Incorrect target elements", "target", an);
                }
                else if (an is ParallelNode)
                {
                    if (an.SourceAbstractNode.Count != 1)
                        context.LogError("Incorrect source elements", "source", an);
                    if (an.TargetAbstractNode.Count < 2)
                        context.LogError("Incorrect target elements", "target", an);
                }
                else if (an is EndParallelNode)
                {
                    if (an.SourceAbstractNode.Count < 2)
                        context.LogError("Incorrect source elements", "source", an);
                    if (an.TargetAbstractNode.Count != 1)
                        context.LogError("Incorrect target elements", "target", an);
                }
                else if (an is BreakNode)
                {
                    if (an.SourceAbstractNode.Count != 1)
                        context.LogError("Incorrect source elements", "source", an);
                    if (an.TargetAbstractNode.Count != 0)
                        context.LogError("Incorrect target elements", "target", an);
                }
                else if (an is SwitchNode)
                {
                    if (an.SourceAbstractNode.Count < 1 || an.SourceAbstractNode.Count > 2)
                        context.LogError("Incorrect source elements", "source", an);
                    if (an.TargetAbstractNode.Count < 1 && an.SourceAbstractNode.Count == 1 || an.TargetAbstractNode.Count < 2 && an.SourceAbstractNode.Count == 2)
                        context.LogError("Incorrect target elements", "target", an);
                }
                else if (an is EndSwitchNode)
                {
                    if (an.SourceAbstractNode.Count < 1)
                        context.LogError("Incorrect source elements", "source", an);
                    if (an.TargetAbstractNode.Count != 1)
                        context.LogError("Incorrect target elements", "target", an);
                }
                else context.LogError("unknown", "unknown", an);
                
            }
            nodes.Clear();
            nodes.Add(st.ElemName);
            generate(st.TargetAbstractNode[0], "FinishNode", true, false, "", "");

            context.LogMessage(nodes.Count.ToString() + " elements", "count");
        }

        AbstractNode generate(AbstractNode f, String end, bool flag, bool isCycle, String subName, String thread)
        {
            while (f != null && (isCycle || (flag ? !f.ElemName.StartsWith(end) : !f.ElemName.Equals(end))))
            {
                if (!isCycle && !(f is FinishNode))
                {
                    if(nodes.Contains(f.ElemName))
                    {
                        context.LogError("Incorrect cycle found", "cycle");
                        return null;
                    }
                    nodes.Add(f.ElemName);
                }
                if (!isCycle && (f is IterationsNode && f.SourceAbstractNode.Count == 3 || (f is EndIfNode) && f.SourceAbstractNode.Count == 3 || !(f is IterationsNode) && !(f is EndIfNode) && !(f is EndParallelNode) && f.SourceAbstractNode.Count == 2))
                {
                    
                    f = generate(f, f.ElemName, false, true, subName, thread);
                    
                }
                else if (f is FinishNode)
                {
                    break;
                }
                //Warning(f.GetType().ToString());
                else if (f is IfNode)
                {
                    
                    AbstractNode g = generate(f.TargetAbstractNode[0], "EndIfNode", true, false, subName, thread);

                    AbstractNode g1 = generate(f.TargetAbstractNode[1], "EndIfNode", true, false, subName, thread);

                    if (g1 == null)
                    {
                        f = g;
                    }
                    else if (g == null)
                    {
                        f = g1;
                    }
                    else if(f != g)
                    {
                        context.LogError("EndIF must be the same", "if", f);
                        return null;
                    }

                }
                else if (f is SubprogramCallNode)
                {
                    
                    f = f.TargetAbstractNode[0];
                }
                else if (f is IterationsNode)
                {

                    f = generate(f.TargetAbstractNode[0], f.ElemName, false, false, subName, thread);

                }
                else if (f is EndParallelNode)
                {
                    if (!AbstractNodeReferencesTargetAbstractNode.GetLinksToTargetAbstractNode(f)[0].Condition.Equals(thread))
                    {
                        break;
                    }
                    else
                    {
                        var list = AbstractNodeReferencesTargetAbstractNode.GetLinksToSourceAbstractNode(f);
                        
                        f = f.TargetAbstractNode[0];
                    }

                }
                else if (f is ParallelNode)
                {
                    var list = AbstractNodeReferencesTargetAbstractNode.GetLinksToTargetAbstractNode(f);
                    AbstractNode g = null, g0 = null;
                    int cur = 0;
                    for (int i = 0; i < list.Count; i++)
                        if (!thread.Equals(list[i].Condition))
                        {
                            AbstractNode g1 = generate(list[i].TargetAbstractNode, "FinishNode", true, false, "", list[i].Condition);
                            if (g0 != null && g1 != g0)
                            {
                                context.LogError("EndParallel must be the same", "parallel", f);
                                return null;
                            }
                            else
                            {
                                g0 = g1;
                            }
                            cur++;
                                  
                        }
                        else
                            g = f.TargetAbstractNode[i];

                    f = g;

                }
                else if (f is BreakNode)
                {
                    break;
                }
                else if (f is SwitchNode)
                {
                    AbstractNode g, g0 = null;

                    for (int i = 0; i < f.TargetAbstractNode.Count; i++)
                    {
                        String cond = AbstractNodeReferencesTargetAbstractNode.GetLinksToTargetAbstractNode(f)[i].Condition;
                        
                        g = generate(f.TargetAbstractNode[i], "EndSwitch", true, false, subName, thread);

                        if (g != null)
                        {
                            if (g0 != null && g != g0)
                            {
                                context.LogError("EndSwitch must be the same", "switch", f);
                                return null;
                            }
                            else g0 = g;
                        }
                    }

                    f = g0;

                }
                
                isCycle = false;
            }
            if (f != null) nodes.Add(f.ElemName);
            if (f == null) return null;
            return f.TargetAbstractNode.Count > 0 ? f.TargetAbstractNode[f.TargetAbstractNode.Count - 1] : null;

        }
    }
}
