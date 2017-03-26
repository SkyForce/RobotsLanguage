using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.TextTemplating;
using Microsoft.VisualStudio.Modeling.Validation;

namespace SPbSU.RobotsLanguage
{
    public class Generator
    {
        RobotModel RobotModel;
        RuntimeTextTemplate1 writer;

        public Generator(RobotModel r, RuntimeTextTemplate1 w)
        {
            RobotModel = r;
            writer = w;
            //controller = (RobotsLanguageDocData) this.CurrentDocData.ValidationController;
        }
        public void Start()
        {
            //controller.ValidateCustom(RobotModel, "ValidateAll");
            foreach (SubprogramNode element in RobotModel.SubprogramNode)
            {
                go(element, "");
            }
            foreach (AbstractNode n in RobotModel.AbstractNode)
            {
                if (n is ParallelNode)
                {
                    int cur = 0;
                    var list = AbstractNodeReferencesTargetAbstractNode.GetLinksToTargetAbstractNode(n);
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (!list[i].Condition.Equals(AbstractNodeReferencesTargetAbstractNode.GetLinksToSourceAbstractNode(n)[0].Condition))
                        {

                            writer.WriteLine("function " + n.ElemName + "_" + cur + "() {");
                            writer.PushIndent("    ");

                            generate(n.TargetAbstractNode[i], "FinishNode", true, false, "", list[i].Condition);

                            writer.PopIndent();
                            writer.WriteLine("}");

                            cur++;
                        }
                    }
                }
            }
            AbstractNode f = null;
            writer.WriteLine("function main() {");
            writer.PushIndent("    ");
            foreach (AbstractNode ab in RobotModel.AbstractNode)
            {
                if (ab is StartNode)
                {
                    f = ab;
                    break;
                }
            }

            generate(f.TargetAbstractNode[0], "FinishNode", true, false, "", "");
            writer.PopIndent();
            writer.WriteLine("}");
        }

        void go(SubprogramNode elem, String par)
        {
            foreach (SubprogramNode n in elem.SubprogramNode)
            {
                go(n, par + elem.ElemName);
            }
            AbstractNode f = null;

            writer.WriteLine("function " + par + elem.ElemName + "() {");
            writer.PushIndent("    ");
            foreach (AbstractNode ab in elem.AbstractNode)
            {
                if (ab is StartNode)
                {
                    f = ab;
                    break;
                }
            }
            generate(f.TargetAbstractNode[0], "FinishNode", true, false, par + elem.ElemName, "");//AbstractNodeReferencesTargetAbstractNode.GetLinksToSourceAbstractNode(f)[0].Condition);
            writer.PopIndent();
            writer.WriteLine("}");


        }

        AbstractNode generate(AbstractNode f, String end, bool flag, bool isCycle, String subName, String thread)
        {
            while (isCycle || (f != null && (flag ? !f.ElemName.StartsWith(end) : !f.ElemName.Equals(end))))
            {

                if (!isCycle && !(f is FinishNode) && (f is IterationsNode && f.SourceAbstractNode.Count == 3 || (f is EndIfNode) && f.SourceAbstractNode.Count == 3 || !(f is IterationsNode) && !(f is EndIfNode) && !(f is EndParallelNode) && f.SourceAbstractNode.Count == 2))
                {
                    writer.WriteLine("while(true) {");
                    writer.PushIndent("    ");
                    f = generate(f, f.ElemName, false, true, subName, thread);
                    writer.PopIndent();
                    writer.WriteLine("}");
                    //f = null;
                }
                else if (f is FinishNode)
                {
                    writer.WriteLine("return;");
                    break;
                }
                //Warning(f.GetType().ToString());
                else if (f is IfNode)
                {

                    AbstractNode g = null;
                    for (int i = 0; i < f.TargetAbstractNode.Count; i++)
                    {
                        String cond = AbstractNodeReferencesTargetAbstractNode.GetLinksToTargetAbstractNode(f)[i].Condition;
                        if (cond.Equals("out"))
                            continue;
                        else if (cond.Equals("true"))
                        {
                            writer.WriteLine("if (" + (f as IfNode).condition + ") {");
                            writer.PushIndent("    ");
                            g = generate(f.TargetAbstractNode[i], "EndIfNode", true, false, subName, thread);
                            writer.PopIndent();
                            writer.WriteLine("}");
                        }
                    }
                    for (int i = 0; i < f.TargetAbstractNode.Count; i++)
                    {
                        String cond = AbstractNodeReferencesTargetAbstractNode.GetLinksToTargetAbstractNode(f)[i].Condition;
                        if (cond.Equals("out"))
                            continue;
                        else if (!cond.Equals("true"))
                        {
                            writer.WriteLine("else {");
                            writer.PushIndent("    ");
                            f = generate(f.TargetAbstractNode[i], "EndIfNode", true, false, subName, thread);
                            writer.PopIndent();
                            writer.WriteLine("}");
                            break;
                        }
                    }
                    if (f == null)
                    {
                        f = g;
                    }

                }
                else if (f is SubprogramCallNode)
                {
                    writer.WriteLine(((SubprogramCallNode)f).Subprogram + "();");
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
                    writer.WriteLine(String.Format("for ({0} = 0; {0} < {1}; {0}++) {{", f.ElemName, (f as IterationsNode).number));
                    writer.PushIndent("    ");
                    for (int i = 0; i < f.TargetAbstractNode.Count; i++)
                    {
                        String cond = AbstractNodeReferencesTargetAbstractNode.GetLinksToTargetAbstractNode(f)[i].Condition;
                        if (cond.Equals("out"))
                            continue;
                        f = generate(f.TargetAbstractNode[i], f.ElemName, false, false, subName, thread);
                    }
                    writer.PopIndent();
                    writer.WriteLine("}");
                }
                else if (f is EndParallelNode)
                {
                    if (!AbstractNodeReferencesTargetAbstractNode.GetLinksToTargetAbstractNode(f)[0].Condition.Equals(thread))
                    {
                        writer.WriteLine("return;");
                        break;
                    }
                    else
                    {
                        var list = AbstractNodeReferencesTargetAbstractNode.GetLinksToSourceAbstractNode(f);
                        for (int i = 0; i < list.Count; i++)
                            if (!thread.Equals(list[i].Condition))
                                writer.WriteLine("Threading.joinThread(\"{0}\");", list[i].Condition.Equals("") ? "main" : list[i].Condition);

                        f = f.TargetAbstractNode[0];
                    }

                }
                else if (f is ParallelNode)
                {
                    var list = AbstractNodeReferencesTargetAbstractNode.GetLinksToTargetAbstractNode(f);
                    AbstractNode g = null;
                    int cur = 0;
                    for (int i = 0; i < list.Count; i++)
                        if (!thread.Equals(list[i].Condition))
                        {
                            writer.WriteLine("Threading.startThread(\"{0}\", \"{1}\");", list[i].Condition, subName + f.ElemName + "_" + cur);
                            cur++;
                        }
                        else
                            g = f.TargetAbstractNode[i];

                    f = g;

                }
                else if (f is BreakNode)
                {
                    writer.WriteLine("break;");
                    break;
                }
                else if (f is SwitchNode)
                {
                    writer.WriteLine(String.Format("switch ({0}) {{", ((SwitchNode)f).Condition));
                    AbstractNode g, g0 = null;
                    writer.PushIndent("    ");

                    for (int i = 0; i < f.TargetAbstractNode.Count; i++)
                    {
                        String cond = AbstractNodeReferencesTargetAbstractNode.GetLinksToTargetAbstractNode(f)[i].Condition;
                        if (cond.Equals("out"))
                            continue;
                        else if (cond.Equals(""))
                            writer.WriteLine("default:");
                        else
                            writer.WriteLine(String.Format("case {0}:", AbstractNodeReferencesTargetAbstractNode.GetLinksToTargetAbstractNode(f)[i].Condition));
                        writer.PushIndent("    ");
                        g = generate(f.TargetAbstractNode[i], "EndSwitch", true, false, subName, thread);
                        writer.WriteLine("break;");
                        writer.PopIndent();
                        if (g != null)
                        {
                            g0 = g;
                        }
                    }
                    writer.PopIndent();
                    writer.WriteLine("}");

                    f = g0;

                }
                else if (f is MotorsNode)
                {
                    String[] ports = ((MotorsNode)f).Ports.Split(',');
                    int power = ((MotorsNode)f).Power;
                    foreach (String s in ports)
                    {
                        writer.WriteLine("brick.motor({0}).setPower({1});", s, power);
                    }
                    f = AbstractNodeReferencesTargetAbstractNode.GetLinksToTargetAbstractNode(f).First(obj => obj.Condition != "out").TargetAbstractNode;

                }
                else if (f is DelayNode)
                {
                    int ms = ((DelayNode)f).Time;
                    writer.WriteLine("script.wait({0});", ms);
                    f = AbstractNodeReferencesTargetAbstractNode.GetLinksToTargetAbstractNode(f).First(obj => obj.Condition != "out").TargetAbstractNode;

                }
                else if (f is WaitSensorNode)
                {
                    int dist = ((WaitSensorNode)f).Distance;
                    string rv = ((WaitSensorNode)f).ReceivedValue;
                    string port = ((WaitSensorNode)f).Port;
                    writer.WriteLine("while (!(brick.sensor({0}).read() {1} {2})) {{", port, rv, dist);
                    writer.PushIndent("    ");
                    writer.WriteLine("script.wait(10)");
                    writer.PopIndent();
                    writer.WriteLine("}");
                    f = AbstractNodeReferencesTargetAbstractNode.GetLinksToTargetAbstractNode(f).First(obj => obj.Condition != "out").TargetAbstractNode;
                    
                }
                else if (f is WaitTouchNode)
                {
                    string port = ((WaitTouchNode)f).Port;
                    writer.WriteLine("while (brick.sensor({0}).read() < 0) {{", port);
                    writer.PushIndent("    ");
                    writer.WriteLine("script.wait(10)");
                    writer.PopIndent();
                    writer.WriteLine("}");
                    f = AbstractNodeReferencesTargetAbstractNode.GetLinksToTargetAbstractNode(f).First(obj => obj.Condition != "out").TargetAbstractNode;

                }
                else if (f is MotorsOffNode)
                {
                    String[] ports = ((MotorsOffNode)f).Ports.Split(',');
                    foreach (String s in ports)
                    {
                        writer.WriteLine("brick.motor({0}).powerOff();", s);
                    }
                    f = AbstractNodeReferencesTargetAbstractNode.GetLinksToTargetAbstractNode(f).First(obj => obj.Condition != "out").TargetAbstractNode;

                }
                isCycle = false;

            }
            if (f is FinishNode && end.StartsWith("FinishNode"))
            {
                writer.WriteLine("return;");
            }
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
