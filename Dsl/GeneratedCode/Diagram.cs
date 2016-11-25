﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;
using DslDiagrams = global::Microsoft.VisualStudio.Modeling.Diagrams;

[module: global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Scope = "type", Target = "SPbSU.RobotsLanguage.RobotsLanguageDiagram")]

namespace SPbSU.RobotsLanguage
{
	/// <summary>
	/// DomainClass RobotsLanguageDiagram
	/// Description for SPbSU.RobotsLanguage.RobotsLanguageDiagram
	/// </summary>
	[DslDesign::DisplayNameResource("SPbSU.RobotsLanguage.RobotsLanguageDiagram.DisplayName", typeof(global::SPbSU.RobotsLanguage.RobotsLanguageDomainModel), "SPbSU.RobotsLanguage.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("SPbSU.RobotsLanguage.RobotsLanguageDiagram.Description", typeof(global::SPbSU.RobotsLanguage.RobotsLanguageDomainModel), "SPbSU.RobotsLanguage.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::SPbSU.RobotsLanguage.RobotsLanguageDomainModel))]
	[global::System.CLSCompliant(true)]
	[DslModeling::DomainObjectId("1f168244-784b-4191-b7de-470650dceb15")]
	public partial class RobotsLanguageDiagram : DslDiagrams::Diagram
	{
		#region Diagram boilerplate
		private static DslDiagrams::StyleSet classStyleSet;
		private static global::System.Collections.Generic.IList<DslDiagrams::ShapeField> shapeFields;
		/// <summary>
		/// Per-class style set for this shape.
		/// </summary>
		protected override DslDiagrams::StyleSet ClassStyleSet
		{
			get
			{
				if (classStyleSet == null)
				{
					classStyleSet = CreateClassStyleSet();
				}
				return classStyleSet;
			}
		}
		
		/// <summary>
		/// Per-class ShapeFields for this shape
		/// </summary>
		public override global::System.Collections.Generic.IList<DslDiagrams::ShapeField> ShapeFields
		{
			get
			{
				if (shapeFields == null)
				{
					shapeFields = CreateShapeFields();
				}
				return shapeFields;
			}
		}
		#endregion
		#region Toolbox filters
		private static global::System.ComponentModel.ToolboxItemFilterAttribute[] toolboxFilters = new global::System.ComponentModel.ToolboxItemFilterAttribute[] {
					new global::System.ComponentModel.ToolboxItemFilterAttribute(global::SPbSU.RobotsLanguage.RobotsLanguageToolboxHelperBase.ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) };
		
		/// <summary>
		/// Toolbox item filter attributes for this diagram.
		/// </summary>
		public override global::System.Collections.ICollection TargetToolboxItemFilterAttributes
		{
			get
			{
				return toolboxFilters;
			}
		}
		#endregion
		#region Auto-placement
		/// <summary>
		/// Indicate that child shapes should added through view fixup should be placed automatically.
		/// </summary>
		public override bool ShouldAutoPlaceChildShapes
		{
			get
			{
				return true;
			}
		}
		#endregion
		#region Shape mapping
		/// <summary>
		/// Called during view fixup to ask the parent whether a shape should be created for the given child element.
		/// </summary>
		/// <remarks>
		/// Always return true, since we assume there is only one diagram per model file for DSL scenarios.
		/// </remarks>
		protected override bool ShouldAddShapeForElement(DslModeling::ModelElement element)
		{
			return true;
		}
		
		/// <summary>
		/// Called during view fixup to configure the given child element, after it has been created.
		/// </summary>
		/// <remarks>
		/// Custom code for choosing the shapes attached to either end of a connector is called from here.
		/// </remarks>
		protected override void OnChildConfiguring(DslDiagrams::ShapeElement child, bool createdDuringViewFixup)
		{
			DslDiagrams::NodeShape sourceShape;
			DslDiagrams::NodeShape targetShape;
			DslDiagrams::BinaryLinkShape connector = child as DslDiagrams::BinaryLinkShape;
			if(connector == null)
			{
				base.OnChildConfiguring(child, createdDuringViewFixup);
				return;
			}
			this.GetSourceAndTargetForConnector(connector, out sourceShape, out targetShape);
			
			global::System.Diagnostics.Debug.Assert(sourceShape != null && targetShape != null, "Unable to find source and target shapes for connector.");
			connector.Connect(sourceShape, targetShape);
		}
		
		/// <summary>
		/// helper method to find the shapes for either end of a connector, including calling the user's custom code
		/// </summary>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		internal void GetSourceAndTargetForConnector(DslDiagrams::BinaryLinkShape connector, out DslDiagrams::NodeShape sourceShape, out DslDiagrams::NodeShape targetShape)
		{
			sourceShape = null;
			targetShape = null;
			
			if (sourceShape == null || targetShape == null)
			{
				DslDiagrams::NodeShape[] endShapes = GetEndShapesForConnector(connector);
				if(sourceShape == null)
				{
					sourceShape = endShapes[0];
				}
				if(targetShape == null)
				{
					targetShape = endShapes[1];
				}
			}
		}
		
		/// <summary>
		/// Helper method to find shapes for either end of a connector by looking for shapes associated with either end of the relationship mapped to the connector.
		/// </summary>
		private DslDiagrams::NodeShape[] GetEndShapesForConnector(DslDiagrams::BinaryLinkShape connector)
		{
			DslModeling::ElementLink link = connector.ModelElement as DslModeling::ElementLink;
			DslDiagrams::NodeShape sourceShape = null, targetShape = null;
			if (link != null)
			{
				global::System.Collections.ObjectModel.ReadOnlyCollection<DslModeling::ModelElement> linkedElements = link.LinkedElements;
				if (linkedElements.Count == 2)
				{
					DslDiagrams::Diagram currentDiagram = this.Diagram;
					DslModeling::LinkedElementCollection<DslDiagrams::PresentationElement> presentationElements = DslDiagrams::PresentationViewsSubject.GetPresentation(linkedElements[0]);
					foreach (DslDiagrams::PresentationElement presentationElement in presentationElements)
					{
						DslDiagrams::NodeShape shape = presentationElement as DslDiagrams::NodeShape;
						if (shape != null && shape.Diagram == currentDiagram)
						{
							sourceShape = shape;
							break;
						}
					}
					
					presentationElements = DslDiagrams::PresentationViewsSubject.GetPresentation(linkedElements[1]);
					foreach (DslDiagrams::PresentationElement presentationElement in presentationElements)
					{
						DslDiagrams::NodeShape shape = presentationElement as DslDiagrams::NodeShape;
						if (shape != null && shape.Diagram == currentDiagram)
						{
							targetShape = shape;
							break;
						}
					}
		
				}
			}
			
			return new DslDiagrams::NodeShape[] { sourceShape, targetShape };
		}
		
		/// <summary>
		/// Creates a new shape for the given model element as part of view fixup
		/// </summary>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily", Justification = "Generated code.")]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]
		protected override DslDiagrams::ShapeElement CreateChildShape(DslModeling::ModelElement element)
		{
			if(element is global::SPbSU.RobotsLanguage.StartNode)
			{
				global::SPbSU.RobotsLanguage.Start newShape = new global::SPbSU.RobotsLanguage.Start(this.Partition);
				if(newShape != null) newShape.Size = newShape.DefaultSize; // set default shape size
				return newShape;
			}
			if(element is global::SPbSU.RobotsLanguage.FinishNode)
			{
				global::SPbSU.RobotsLanguage.Finish newShape = new global::SPbSU.RobotsLanguage.Finish(this.Partition);
				if(newShape != null) newShape.Size = newShape.DefaultSize; // set default shape size
				return newShape;
			}
			if(element is global::SPbSU.RobotsLanguage.SubprogramNode)
			{
				global::SPbSU.RobotsLanguage.Subprogram newShape = new global::SPbSU.RobotsLanguage.Subprogram(this.Partition);
				if(newShape != null) newShape.Size = newShape.DefaultSize; // set default shape size
				return newShape;
			}
			if(element is global::SPbSU.RobotsLanguage.IfNode)
			{
				global::SPbSU.RobotsLanguage.If newShape = new global::SPbSU.RobotsLanguage.If(this.Partition);
				if(newShape != null) newShape.Size = newShape.DefaultSize; // set default shape size
				return newShape;
			}
			if(element is global::SPbSU.RobotsLanguage.EndIfNode)
			{
				global::SPbSU.RobotsLanguage.EndIf newShape = new global::SPbSU.RobotsLanguage.EndIf(this.Partition);
				if(newShape != null) newShape.Size = newShape.DefaultSize; // set default shape size
				return newShape;
			}
			if(element is global::SPbSU.RobotsLanguage.AbstractNodeReferencesTargetAbstractNode)
			{
				global::SPbSU.RobotsLanguage.ExampleConnector newShape = new global::SPbSU.RobotsLanguage.ExampleConnector(this.Partition);
				return newShape;
			}
			return base.CreateChildShape(element);
		}
		#endregion
		#region Decorator mapping
		/// <summary>
		/// Initialize shape decorator mappings.  This is done here rather than in individual shapes because decorator maps
		/// are defined per diagram type rather than per shape type.
		/// </summary>
		protected override void InitializeShapeFields(global::System.Collections.Generic.IList<DslDiagrams::ShapeField> shapeFields)
		{
			base.InitializeShapeFields(shapeFields);
			global::SPbSU.RobotsLanguage.Finish.DecoratorsInitialized += FinishDecoratorMap.OnDecoratorsInitialized;
			global::SPbSU.RobotsLanguage.Start.DecoratorsInitialized += StartDecoratorMap.OnDecoratorsInitialized;
		}
		
		/// <summary>
		/// Class containing decorator path traversal methods for Finish.
		/// </summary>
		internal static partial class FinishDecoratorMap
		{
			/// <summary>
			/// Event handler called when decorator initialization is complete for Finish.  Adds decorator mappings for this shape or connector.
			/// </summary>
			public static void OnDecoratorsInitialized(object sender, global::System.EventArgs e)
			{
				DslDiagrams::ShapeElement shape = (DslDiagrams::ShapeElement)sender;
				DslDiagrams::AssociatedPropertyInfo propertyInfo;
				
				propertyInfo = new DslDiagrams::AssociatedPropertyInfo(global::SPbSU.RobotsLanguage.AbstractNode.ElemNameDomainPropertyId);
				DslDiagrams::ShapeElement.FindDecorator(shape.Decorators, "NameDecorator").AssociateValueWith(shape.Store, propertyInfo);
				
				propertyInfo = new DslDiagrams::AssociatedPropertyInfo(global::SPbSU.RobotsLanguage.AbstractNode.ElemNameDomainPropertyId);
				DslDiagrams::ShapeElement.FindDecorator(shape.Decorators, "NameDecorator").AssociateValueWith(shape.Store, propertyInfo);
			}
		}
		
		/// <summary>
		/// Class containing decorator path traversal methods for Start.
		/// </summary>
		internal static partial class StartDecoratorMap
		{
			/// <summary>
			/// Event handler called when decorator initialization is complete for Start.  Adds decorator mappings for this shape or connector.
			/// </summary>
			public static void OnDecoratorsInitialized(object sender, global::System.EventArgs e)
			{
				DslDiagrams::ShapeElement shape = (DslDiagrams::ShapeElement)sender;
				DslDiagrams::AssociatedPropertyInfo propertyInfo;
				
				propertyInfo = new DslDiagrams::AssociatedPropertyInfo(global::SPbSU.RobotsLanguage.AbstractNode.ElemNameDomainPropertyId);
				DslDiagrams::ShapeElement.FindDecorator(shape.Decorators, "NameDecorator").AssociateValueWith(shape.Store, propertyInfo);
				
				propertyInfo = new DslDiagrams::AssociatedPropertyInfo(global::SPbSU.RobotsLanguage.AbstractNode.ElemNameDomainPropertyId);
				DslDiagrams::ShapeElement.FindDecorator(shape.Decorators, "NameDecorator").AssociateValueWith(shape.Store, propertyInfo);
			}
		}
		
		#endregion
		
		#region Connect actions
		private bool changingMouseAction;
		private global::SPbSU.RobotsLanguage.ConnectionTool1ConnectAction connectionTool1ConnectAction;
		/// <summary>
		/// Virtual method to provide a filter when to select the mouse action
		/// </summary>
		/// <param name="activeView">Currently active view</param>
		/// <param name="filter">filter string used to filter the toolbox items</param>
		protected virtual bool SelectedToolboxItemSupportsFilterString(DslDiagrams::DiagramView activeView, string filter)
		{
			return activeView.SelectedToolboxItemSupportsFilterString(filter);
		}
		/// <summary>
		/// Override to provide the right mouse action when trying
		/// to create links on the diagram
		/// </summary>
		/// <param name="pointArgs"></param>
		public override void OnViewMouseEnter(DslDiagrams::DiagramPointEventArgs pointArgs)
		{
			if (pointArgs  == null) throw new global::System.ArgumentNullException("pointArgs");
		
			DslDiagrams::DiagramView activeView = this.ActiveDiagramView;
			if(activeView != null)
			{
				DslDiagrams::MouseAction action = null;
				if (SelectedToolboxItemSupportsFilterString(activeView, global::SPbSU.RobotsLanguage.RobotsLanguageToolboxHelper.ConnectionTool1FilterString))
				{
					if (this.connectionTool1ConnectAction == null)
					{
						this.connectionTool1ConnectAction = new global::SPbSU.RobotsLanguage.ConnectionTool1ConnectAction(this);
						this.connectionTool1ConnectAction.MouseActionDeactivated += new DslDiagrams::MouseAction.MouseActionDeactivatedEventHandler(OnConnectActionDeactivated);
					}
					action = this.connectionTool1ConnectAction;
				} 
				else
				{
					action = null;
				}
				
				if (pointArgs.DiagramClientView.ActiveMouseAction != action)
				{
					try
					{
						this.changingMouseAction = true;
						pointArgs.DiagramClientView.ActiveMouseAction = action;
					}
					finally
					{
						this.changingMouseAction = false;
					}
				}
			}
		}
		
		/// <summary>
		/// Snap toolbox selection back to regular pointer after using a custom connect action.
		/// </summary>
		private void OnConnectActionDeactivated(object sender, DslDiagrams::DiagramEventArgs e)
		{
			OnMouseActionDeactivated();
		}
		
		/// <summary>
		/// Overridable method to manage the mouse deactivation. The default implementation snap stoolbox selection back to regular pointer 
		/// after using a custom connect action.
		/// </summary>
		protected virtual void OnMouseActionDeactivated()
		{
			DslDiagrams::DiagramView activeView = this.ActiveDiagramView;
		
			if (activeView != null && activeView.Toolbox != null)
			{
				// If we're not changing mouse action due to changing toolbox selection change,
				// reset toolbox selection.
				if (!this.changingMouseAction)
				{
					activeView.Toolbox.SelectedToolboxItemUsed();
				}
			}
		}
		#endregion
		
		/// <summary>
		/// Dispose of connect actions.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			try
			{
				if(disposing)
				{
					if(this.connectionTool1ConnectAction != null)
					{
						this.connectionTool1ConnectAction.Dispose();
						this.connectionTool1ConnectAction = null;
					}
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}
		#region Constructors, domain class Id
	
		/// <summary>
		/// RobotsLanguageDiagram domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new global::System.Guid(0x1f168244, 0x784b, 0x4191, 0xb7, 0xde, 0x47, 0x06, 0x50, 0xdc, 0xeb, 0x15);
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public RobotsLanguageDiagram(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public RobotsLanguageDiagram(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
	}
}
namespace SPbSU.RobotsLanguage
{
	
		/// <summary>
		/// Double derived implementation for the rule that initiates view fixup when an element that has an associated shape is added to the model.
		/// This now enables the DSL author to everride the SkipFixUp() method 
		/// </summary>
		internal partial class FixUpDiagramBase : DslModeling::AddRule
		{
			protected virtual bool SkipFixup(DslModeling::ModelElement childElement)
			{
				return childElement.IsDeleted;
			}
		}
	
		/// <summary>
		/// Rule that initiates view fixup when an element that has an associated shape is added to the model. 
		/// </summary>
		[DslModeling::RuleOn(typeof(global::SPbSU.RobotsLanguage.StartNode), FireTime = DslModeling::TimeToFire.TopLevelCommit, Priority = DslDiagrams::DiagramFixupConstants.AddShapeParentExistRulePriority, InitiallyDisabled=true)]
		[DslModeling::RuleOn(typeof(global::SPbSU.RobotsLanguage.FinishNode), FireTime = DslModeling::TimeToFire.TopLevelCommit, Priority = DslDiagrams::DiagramFixupConstants.AddShapeParentExistRulePriority, InitiallyDisabled=true)]
		[DslModeling::RuleOn(typeof(global::SPbSU.RobotsLanguage.SubprogramNode), FireTime = DslModeling::TimeToFire.TopLevelCommit, Priority = DslDiagrams::DiagramFixupConstants.AddShapeParentExistRulePriority, InitiallyDisabled=true)]
		[DslModeling::RuleOn(typeof(global::SPbSU.RobotsLanguage.IfNode), FireTime = DslModeling::TimeToFire.TopLevelCommit, Priority = DslDiagrams::DiagramFixupConstants.AddShapeParentExistRulePriority, InitiallyDisabled=true)]
		[DslModeling::RuleOn(typeof(global::SPbSU.RobotsLanguage.EndIfNode), FireTime = DslModeling::TimeToFire.TopLevelCommit, Priority = DslDiagrams::DiagramFixupConstants.AddShapeParentExistRulePriority, InitiallyDisabled=true)]
		[DslModeling::RuleOn(typeof(global::SPbSU.RobotsLanguage.AbstractNodeReferencesTargetAbstractNode), FireTime = DslModeling::TimeToFire.TopLevelCommit, Priority = DslDiagrams::DiagramFixupConstants.AddConnectionRulePriority, InitiallyDisabled=true)]
		internal sealed partial class FixUpDiagram : FixUpDiagramBase
		{
			[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
			public override void ElementAdded(DslModeling::ElementAddedEventArgs e)
			{
				if(e == null) throw new global::System.ArgumentNullException("e");
			
				DslModeling::ModelElement childElement = e.ModelElement;
				if (this.SkipFixup(childElement))
					return;
				DslModeling::ModelElement parentElement;
				if(childElement is DslModeling::ElementLink)
				{
					parentElement = GetParentForRelationship((DslModeling::ElementLink)childElement);
				} else
				if(childElement is global::SPbSU.RobotsLanguage.StartNode)
				{
					parentElement = GetParentForStartNode((global::SPbSU.RobotsLanguage.StartNode)childElement);
				} else
				if(childElement is global::SPbSU.RobotsLanguage.FinishNode)
				{
					parentElement = GetParentForFinishNode((global::SPbSU.RobotsLanguage.FinishNode)childElement);
				} else
				if(childElement is global::SPbSU.RobotsLanguage.SubprogramNode)
				{
					// Method:
					// private Microsoft.VisualStudio.Modeling.ModelElement GetParentForSubprogramNode(SubprogramNode childElement)
					// {
					// }
					// must be implemented in a partial class of SPbSU.RobotsLanguage.FixUpDiagram.  Given a child element,
					// this method should return the parent model element that is associated with the shape or diagram that will be the parent 
					// of the shape created for this child.  If no shape should be created, the method should return null.
					parentElement = GetParentForSubprogramNode((global::SPbSU.RobotsLanguage.SubprogramNode)childElement);
				} else
				if(childElement is global::SPbSU.RobotsLanguage.IfNode)
				{
					parentElement = GetParentForIfNode((global::SPbSU.RobotsLanguage.IfNode)childElement);
				} else
				if(childElement is global::SPbSU.RobotsLanguage.EndIfNode)
				{
					parentElement = GetParentForEndIfNode((global::SPbSU.RobotsLanguage.EndIfNode)childElement);
				} else
				{
					parentElement = null;
				}
				
				if(parentElement != null)
				{
					DslDiagrams::Diagram.FixUpDiagram(parentElement, childElement);
				}
			}
			public static global::SPbSU.RobotsLanguage.Compound GetParentForStartNode( global::SPbSU.RobotsLanguage.AbstractNode root )
			{
				// Segments 0 and 1
				global::SPbSU.RobotsLanguage.Compound result = root.Compound;
				if ( result == null ) return null;
				return result;
			}
			public static global::SPbSU.RobotsLanguage.Compound GetParentForFinishNode( global::SPbSU.RobotsLanguage.AbstractNode root )
			{
				// Segments 0 and 1
				global::SPbSU.RobotsLanguage.Compound result = root.Compound;
				if ( result == null ) return null;
				return result;
			}
			public static global::SPbSU.RobotsLanguage.Compound GetParentForIfNode( global::SPbSU.RobotsLanguage.AbstractNode root )
			{
				// Segments 0 and 1
				global::SPbSU.RobotsLanguage.Compound result = root.Compound;
				if ( result == null ) return null;
				return result;
			}
			public static global::SPbSU.RobotsLanguage.Compound GetParentForEndIfNode( global::SPbSU.RobotsLanguage.AbstractNode root )
			{
				// Segments 0 and 1
				global::SPbSU.RobotsLanguage.Compound result = root.Compound;
				if ( result == null ) return null;
				return result;
			}
			private static DslModeling::ModelElement GetParentForRelationship(DslModeling::ElementLink elementLink)
			{
				global::System.Collections.ObjectModel.ReadOnlyCollection<DslModeling::ModelElement> linkedElements = elementLink.LinkedElements;
	
				if (linkedElements.Count == 2)
				{
					DslDiagrams::ShapeElement sourceShape = linkedElements[0] as DslDiagrams::ShapeElement;
					DslDiagrams::ShapeElement targetShape = linkedElements[1] as DslDiagrams::ShapeElement;
	
					if(sourceShape == null)
					{
						DslModeling::LinkedElementCollection<DslDiagrams::PresentationElement> presentationElements = DslDiagrams::PresentationViewsSubject.GetPresentation(linkedElements[0]);
						foreach (DslDiagrams::PresentationElement presentationElement in presentationElements)
						{
							DslDiagrams::ShapeElement shape = presentationElement as DslDiagrams::ShapeElement;
							if (shape != null)
							{
								sourceShape = shape;
								break;
							}
						}
					}
					
					if(targetShape == null)
					{
						DslModeling::LinkedElementCollection<DslDiagrams::PresentationElement> presentationElements = DslDiagrams::PresentationViewsSubject.GetPresentation(linkedElements[1]);
						foreach (DslDiagrams::PresentationElement presentationElement in presentationElements)
						{
							DslDiagrams::ShapeElement shape = presentationElement as DslDiagrams::ShapeElement;
							if (shape != null)
							{
								targetShape = shape;
								break;
							}
						}
					}
					
					if(sourceShape == null || targetShape == null)
					{
						global::System.Diagnostics.Debug.Fail("Unable to find source and/or target shape for view fixup.");
						return null;
					}
	
					DslDiagrams::ShapeElement sourceParent = sourceShape.ParentShape;
					DslDiagrams::ShapeElement targetParent = targetShape.ParentShape;
	
					while (sourceParent != targetParent && sourceParent != null)
					{
						DslDiagrams::ShapeElement curParent = targetParent;
						while (sourceParent != curParent && curParent != null)
						{
							curParent = curParent.ParentShape;
						}
	
						if(sourceParent == curParent)
						{
							break;
						}
						else
						{
							sourceParent = sourceParent.ParentShape;
						}
					}
	
					while (sourceParent != null)
					{
						// ensure that the parent can parent connectors (i.e., a diagram or a swimlane).
						if(sourceParent is DslDiagrams::Diagram || sourceParent is DslDiagrams::SwimlaneShape)
						{
							break;
						}
						else
						{
							sourceParent = sourceParent.ParentShape;
						}
					}
	
					global::System.Diagnostics.Debug.Assert(sourceParent != null && sourceParent.ModelElement != null, "Unable to find common parent for view fixup.");
					return sourceParent.ModelElement;
				}
	
				return null;
			}
		}
		
	
		/// <summary>
		/// Reroute a connector when the role players of its underlying relationship change
		/// </summary>
		[DslModeling::RuleOn(typeof(global::SPbSU.RobotsLanguage.AbstractNodeReferencesTargetAbstractNode), FireTime = DslModeling::TimeToFire.TopLevelCommit, Priority = DslDiagrams::DiagramFixupConstants.AddConnectionRulePriority, InitiallyDisabled=true)]
		internal sealed class ConnectorRolePlayerChanged : DslModeling::RolePlayerChangeRule
		{
			/// <summary>
			/// Reroute a connector when the role players of its underlying relationship change
			/// </summary>
			public override void RolePlayerChanged(DslModeling::RolePlayerChangedEventArgs e)
			{
				if (e == null) throw new global::System.ArgumentNullException("e");
	
				global::System.Collections.ObjectModel.ReadOnlyCollection<DslDiagrams::PresentationViewsSubject> connectorLinks = DslDiagrams::PresentationViewsSubject.GetLinksToPresentation(e.ElementLink);
				foreach (DslDiagrams::PresentationViewsSubject connectorLink in connectorLinks)
				{
					// Fix up any binary link shapes attached to the element link.
					DslDiagrams::BinaryLinkShape linkShape = connectorLink.Presentation as DslDiagrams::BinaryLinkShape;
					if (linkShape != null)
					{
						global::SPbSU.RobotsLanguage.RobotsLanguageDiagram diagram = linkShape.Diagram as global::SPbSU.RobotsLanguage.RobotsLanguageDiagram;
						if (diagram != null)
						{
							if (e.NewRolePlayer != null)
							{
								DslDiagrams::NodeShape fromShape;
								DslDiagrams::NodeShape toShape;
								diagram.GetSourceAndTargetForConnector(linkShape, out fromShape, out toShape);
								if (fromShape != null && toShape != null)
								{
									if (!object.Equals(fromShape, linkShape.FromShape))
									{
										linkShape.FromShape = fromShape;
									}
									if (!object.Equals(linkShape.ToShape, toShape))
									{
										linkShape.ToShape = toShape;
									}
								}
								else
								{
									// delete the connector if we cannot find an appropriate target shape.
									linkShape.Delete();
								}
							}
							else
							{
								// delete the connector if the new role player is null.
								linkShape.Delete();
							}
						}
					}
				}
			}
		}
	}
