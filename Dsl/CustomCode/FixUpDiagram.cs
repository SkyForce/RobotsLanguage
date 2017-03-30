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
    
    partial class Start
    {
        protected override void InitializeShapeFields(IList<ShapeField> shapeFields)
        {
            // Fields set up according to DSL Definition:  
            base.InitializeShapeFields(shapeFields);
            // Find and update comment field:  
            //ImageField imageField = ShapeElement.FindShapeField(shapeFields, "ImageField") as ImageField;
            // Use the standard font for comments:  
            //imageField.DefaultImage = SPbSU.RobotsLanguage.Properties.Resources.initialBlock;//ImageHelper.GetImage(RobotsLanguageDomainModel.SingletonResourceManager.GetObject("initialBlock"));


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
        HashSet<String> hs = new HashSet<string>();
        [ValidationMethod(ValidationCategories.Menu)]
        private void Validate(ValidationContext context)
        {
            this.context = context;
            ValidateSubprogram(this);
            foreach(SubprogramNode sub in SubprogramNode)
            {
                ValidateSubprogram(sub);
            }
        }
        void ValidateSubprogram(Compound elem)
        {
            AbstractNode st = null;
            foreach (AbstractNode an in elem.AbstractNode)
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
                    if(!AbstractNodeReferencesTargetAbstractNode.GetLinksToTargetAbstractNode(an).Any(obj => obj.Condition == "true"))
                    {
                        context.LogError("No true link", "true", an);
                    }
                    if (an.TargetAbstractNode.Count == 3 && !AbstractNodeReferencesTargetAbstractNode.GetLinksToTargetAbstractNode(an).Any(obj => obj.Condition == "out"))
                    {
                        context.LogError("No out for cycle", "out", an);
                    }

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
                    if (an.SourceAbstractNode.Count != 2)
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
                    if (!SubprogramNode.Any(obj => obj.ElemName == (an as SubprogramCallNode).Subprogram))
                    {
                        context.LogError("No subprogram with such name", "subprogram", an);
                    }
                    if (an.SourceAbstractNode.Count == 2 && !AbstractNodeReferencesTargetAbstractNode.GetLinksToTargetAbstractNode(an).Any(obj => obj.Condition == "out"))
                    {
                        context.LogError("No out for cycle", "out", an);
                    }
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
                    if (AbstractNodeReferencesTargetAbstractNode.GetLinksToTargetAbstractNode(an).Count(obj => obj.Condition == "") > 1)
                        context.LogError("Only one link must be default", "default", an);
                    if (an.SourceAbstractNode.Count == 2 && !AbstractNodeReferencesTargetAbstractNode.GetLinksToTargetAbstractNode(an).Any(obj => obj.Condition == "out"))
                    {
                        context.LogError("No out for cycle", "out", an);
                    }
                }
                else if (an is EndSwitchNode)
                {
                    if (an.SourceAbstractNode.Count < 1)
                        context.LogError("Incorrect source elements", "source", an);
                    if (an.TargetAbstractNode.Count != 1)
                        context.LogError("Incorrect target elements", "target", an);
                }
                else if (an is WaitSensorNode || an is DelayNode || an is MotorsNode || an is MotorsOffNode || an is WaitTouchNode)
                {
                    if (an.SourceAbstractNode.Count < 1 || an.SourceAbstractNode.Count > 2)
                        context.LogError("Incorrect source elements", "source", an);
                    if (an.TargetAbstractNode.Count != 1 && an.SourceAbstractNode.Count == 1 || an.TargetAbstractNode.Count != 2 && an.SourceAbstractNode.Count == 2)
                        context.LogError("Incorrect target elements", "target", an);
                    
                    if (an.SourceAbstractNode.Count == 2 && !AbstractNodeReferencesTargetAbstractNode.GetLinksToTargetAbstractNode(an).Any(obj => obj.Condition == "out"))
                    {
                        context.LogError("No out for cycle", "out", an);
                    }
                    if(an is WaitSensorNode && (((WaitSensorNode)an).Port.Equals(String.Empty) || ((WaitSensorNode)an).ReceivedValue.Equals(String.Empty)))
                    {
                        context.LogError("Fields must be non-empty", "fields", an);
                    }
                    else if (an is MotorsNode && (((MotorsNode)an).Ports.Equals(String.Empty)))
                    {
                        context.LogError("Fields must be non-empty", "fields", an);
                    }
                    else if (an is MotorsOffNode && (((MotorsOffNode)an).Ports.Equals(String.Empty)))
                    {
                        context.LogError("Fields must be non-empty", "fields", an);
                    }
                    else if (an is WaitTouchNode && (((WaitTouchNode)an).Port.Equals(String.Empty)))
                    {
                        context.LogError("Fields must be non-empty", "fields", an);
                    }
                }
                else context.LogError("unknown", "unknown", an);

            }
            if (context.CurrentViolations.Count == 0)
            {
                nodes.Clear();
                nodes.Add(st.ElemName);
                hs.Clear();
                hs.Add("");
                generate(st.TargetAbstractNode[0], "FinishNode", true, false, "", "");
            }
        }
        AbstractNode generate(AbstractNode f, String end, bool flag, bool isCycle, String subName, String thread)
        {
            while (f != null && (isCycle || (flag ? !f.ElemName.StartsWith(end) : !f.ElemName.Equals(end))))
            {
                if (!isCycle && !(f is FinishNode) && !(f is EndParallelNode))
                {
                    if(nodes.Contains(f.ElemName))
                    {
                        context.LogError("Incorrect cycle found", "cycle");
                        return null;
                    }
                    nodes.Add(f.ElemName);
                }
                if (!isCycle && !(f is FinishNode) && (f is IterationsNode && f.SourceAbstractNode.Count == 3 || (f is EndIfNode) && f.SourceAbstractNode.Count == 3 || !(f is IterationsNode) && !(f is EndIfNode) && !(f is EndParallelNode) && f.SourceAbstractNode.Count == 2))
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
                    AbstractNode g = null, g1 = null;
                    for (int i = 0; i < f.TargetAbstractNode.Count; i++)
                    {
                        String cond = AbstractNodeReferencesTargetAbstractNode.GetLinksToTargetAbstractNode(f)[i].Condition;
                        if (cond.Equals("out"))
                            continue;
                        else if (cond.Equals("true"))
                            g = generate(f.TargetAbstractNode[i], "EndIfNode", true, false, subName, thread);
                        else
                            g1 = generate(f.TargetAbstractNode[i], "EndIfNode", true, false, subName, thread);
                    }

                    if (g1 == null)
                    {
                        f = g;
                    }
                    else if (g == null)
                    {
                        f = g1;
                    }
                    else if (f != g)
                    {
                        context.LogError("EndIF must be the same", "if", f);
                        return null;
                    }

                }
                else if (f is SubprogramCallNode)
                {
                    for (int i = 0; i < f.TargetAbstractNode.Count; i++)
                    {
                        String cond = AbstractNodeReferencesTargetAbstractNode.GetLinksToTargetAbstractNode(f)[i].Condition;
                        if (cond.Equals("out"))
                            continue;
                        f = f.TargetAbstractNode[i];
                    }
                }
                else if (f is IterationsNode)
                {
                    for (int i = 0; i < f.TargetAbstractNode.Count; i++)
                    {
                        String cond = AbstractNodeReferencesTargetAbstractNode.GetLinksToTargetAbstractNode(f)[i].Condition;
                        if (cond.Equals("out"))
                            continue;
                        f = generate(f.TargetAbstractNode[i], f.ElemName, false, false, subName, thread);
                    }
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
                    if (list.Count(obj => obj.Condition == thread) != 1)
                    {
                        context.LogError("Only one link must be the same thread", "thread", f);
                        return null;
                    }
                    for (int i = 0; i < list.Count; i++)
                        if (!thread.Equals(list[i].Condition))
                        {
                            if (hs.Contains(list[i].Condition))
                            {
                                context.LogError("Repeatable thread name", "thread", f);
                                return null;
                            }
                            hs.Add(list[i].Condition);

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
                        if (cond.Equals("out"))
                            continue;
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
                else if (f is WaitSensorNode || f is DelayNode || f is MotorsNode || f is MotorsOffNode || f is WaitTouchNode)
                {
                    f = AbstractNodeReferencesTargetAbstractNode.GetLinksToTargetAbstractNode(f).First(obj => obj.Condition != "out").TargetAbstractNode;

                }

                isCycle = false;
            }
            if (f != null) nodes.Add(f.ElemName);
            if (f == null) return null;
            for (int i = 0; i < f.TargetAbstractNode.Count; i++)
            {
                String cond = AbstractNodeReferencesTargetAbstractNode.GetLinksToTargetAbstractNode(f)[i].Condition;
                if (cond.Equals("out"))
                    return f.TargetAbstractNode[i];
            }
            return f.TargetAbstractNode.Count > 0 ? f.TargetAbstractNode[f.TargetAbstractNode.Count - 1] : null;

        }
    }
}
