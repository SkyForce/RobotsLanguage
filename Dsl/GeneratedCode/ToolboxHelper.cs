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
using System;
using System.Diagnostics;
using System.Drawing.Design;
using System.Windows.Forms;
using DslDiagrams = global::Microsoft.VisualStudio.Modeling.Diagrams;

namespace SPbSU.RobotsLanguage
{
	/// <summary>
	/// Helper class used to create and initialize toolbox items for this DSL.
	/// </summary>
	/// <remarks>
	/// Double-derived class to allow easier code customization.
	/// </remarks>
	public partial class RobotsLanguageToolboxHelper : RobotsLanguageToolboxHelperBase 
	{
		/// <summary>
		/// Constructs a new RobotsLanguageToolboxHelper.
		/// </summary>
		public RobotsLanguageToolboxHelper(global::System.IServiceProvider serviceProvider)
			: base(serviceProvider) { }
	}
	
	/// <summary>
	/// Helper class used to create and initialize toolbox items for this DSL.
	/// </summary>
	
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Justification = "The store is disposed on domain shut down")]
	public abstract class RobotsLanguageToolboxHelperBase
	{
		/// <summary>
		/// Toolbox item filter string used to identify RobotsLanguage toolbox items.  
		/// </summary>
		/// <remarks>
		/// See the MSDN documentation for the ToolboxItemFilterAttribute class for more information on toolbox
		/// item filters.
		/// </remarks>
		public const string ToolboxFilterString = "RobotsLanguage.1.0";
		/// <summary>
		/// Toolbox item filter string used to identify ConnectionTool1 connector tool.
		/// </summary>
		public const string ConnectionTool1FilterString = "ConnectionTool1.1.0";

	
		private global::System.Collections.Generic.Dictionary<string, DslDesign::ModelingToolboxItem> toolboxItemCache = new global::System.Collections.Generic.Dictionary<string, DslDesign::ModelingToolboxItem>();
		private DslModeling::Store toolboxStore;
		
		private global::System.IServiceProvider sp;
		
		/// <summary>
		/// Constructs a new RobotsLanguageToolboxHelperBase.
		/// </summary>
		protected RobotsLanguageToolboxHelperBase(global::System.IServiceProvider serviceProvider)
		{
			if(serviceProvider == null) throw new global::System.ArgumentNullException("serviceProvider");
			
			this.sp = serviceProvider;
		}
		
		/// <summary>
		/// Serivce provider used to access services from the hosting environment.
		/// </summary>
		protected global::System.IServiceProvider ServiceProvider
		{
			get
			{
				return this.sp;
			}
		}

		/// <summary>
		/// Returns the display name of the tab that should be opened by default when the editor is opened.
		/// </summary>
		public static string DefaultToolboxTabName
		{
			get
			{
				return global::SPbSU.RobotsLanguage.RobotsLanguageDomainModel.SingletonResourceManager.GetString("RobotsLanguageToolboxTab", global::System.Globalization.CultureInfo.CurrentUICulture);
			}
		}
		
		
		/// <summary>
		/// Returns the toolbox items count in the default tool box tab.
		/// </summary>
		public static int DefaultToolboxTabToolboxItemsCount
		{
			get
			{
				return 9;
			}
		}
		

		/// <summary>
		/// Returns a list of custom toolbox items to be added dynamically
		/// </summary>
		public virtual global::System.Collections.Generic.IList<DslDesign::ModelingToolboxItem> CreateToolboxItems()
		{
			global::System.Collections.Generic.List<DslDesign::ModelingToolboxItem> toolboxItems = new global::System.Collections.Generic.List<DslDesign::ModelingToolboxItem>();
			return toolboxItems;
		}
		
		/// <summary>
		/// Creates an ElementGroupPrototype for the element tool corresponding to the given domain class id.
		/// Default behavior is to create a prototype containing an instance of the domain class.
		/// Derived classes may override this to add additional information to the prototype.
		/// </summary>
		protected virtual DslModeling::ElementGroupPrototype CreateElementToolPrototype(DslModeling::Store store, global::System.Guid domainClassId)
		{
			DslModeling::ModelElement element = store.ElementFactory.CreateElement(domainClassId);
			DslModeling::ElementGroup elementGroup = new DslModeling::ElementGroup(store.DefaultPartition);
			elementGroup.AddGraph(element, true);
			return elementGroup.CreatePrototype();
		}

		/// <summary>
		/// Returns instance of ModelingToolboxItem based on specified name.
		/// This method must be called from within a Transaction. Failure to do so will result in an exception
		/// </summary>
		/// <param name="itemId">unique name of desired ToolboxItem</param>
		/// <param name="store">Store to perform the operation against</param>
		/// <returns>An instance of ModelingToolboxItem if the itemId can be resolved, null otherwise</returns>
		public virtual DslDesign::ModelingToolboxItem GetToolboxItem(string itemId, DslModeling::Store store)
		{
			DslDesign::ModelingToolboxItem result = null;
			if (string.IsNullOrEmpty(itemId))
			{
				return null;
			}
			if (store == null)
			{
				return null;
			}
			global::System.Resources.ResourceManager resourceManager = global::SPbSU.RobotsLanguage.RobotsLanguageDomainModel.SingletonResourceManager;
			global::System.Globalization.CultureInfo resourceCulture = global::System.Globalization.CultureInfo.CurrentUICulture;
			switch(itemId)
			{
				case "SPbSU.RobotsLanguage.StartToolboxItem":
					// Add Start shape tool.
					result = new DslDesign::ModelingToolboxItem(
						"SPbSU.RobotsLanguage.StartToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						1, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("StartToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("StartToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.
						"SPbSU.RobotsLanguage.RobotsLanguageToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("RobotsLanguageToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"CreateExampleClassF1Keyword", // F1 help keyword for the toolbox item.
						resourceManager.GetString("StartToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						CreateElementToolPrototype(store, global::SPbSU.RobotsLanguage.StartNode.DomainClassId), // ElementGroupPrototype (data object) representing model element on the toolbox.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
						new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) 
						});
					break;
				case "SPbSU.RobotsLanguage.FinishToolboxItem":
					// Add Finish shape tool.
					result = new DslDesign::ModelingToolboxItem(
						"SPbSU.RobotsLanguage.FinishToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						2, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("FinishToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("FinishToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.
						"SPbSU.RobotsLanguage.RobotsLanguageToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("RobotsLanguageToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"Finish", // F1 help keyword for the toolbox item.
						resourceManager.GetString("FinishToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						CreateElementToolPrototype(store, global::SPbSU.RobotsLanguage.FinishNode.DomainClassId), // ElementGroupPrototype (data object) representing model element on the toolbox.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
						new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) 
						});
					break;
				case "SPbSU.RobotsLanguage.ConnectionTool1ToolboxItem":

					// Add ConnectionTool1 connector tool.
					result = new DslDesign::ModelingToolboxItem(
						"SPbSU.RobotsLanguage.ConnectionTool1ToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						3, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("ConnectionTool1ToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("ConnectionTool1ToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.				
						"SPbSU.RobotsLanguage.RobotsLanguageToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("RobotsLanguageToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"ConnectionTool1", // F1 help keyword for the toolbox item.
						resourceManager.GetString("ConnectionTool1ToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						null, // Connector toolbox items do not have an underlying data object.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
							new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require), 
							new global::System.ComponentModel.ToolboxItemFilterAttribute(ConnectionTool1FilterString)
						});
					break;
				case "SPbSU.RobotsLanguage.SubprogramToolboxItem":
					// Add Subprogram shape tool.
					result = new DslDesign::ModelingToolboxItem(
						"SPbSU.RobotsLanguage.SubprogramToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						4, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("SubprogramToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("SubprogramToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.
						"SPbSU.RobotsLanguage.RobotsLanguageToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("RobotsLanguageToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"Subprogram", // F1 help keyword for the toolbox item.
						resourceManager.GetString("SubprogramToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						CreateElementToolPrototype(store, global::SPbSU.RobotsLanguage.SubprogramNode.DomainClassId), // ElementGroupPrototype (data object) representing model element on the toolbox.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
						new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) 
						});
					break;
				case "SPbSU.RobotsLanguage.IfToolboxItem":
					// Add If shape tool.
					result = new DslDesign::ModelingToolboxItem(
						"SPbSU.RobotsLanguage.IfToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						5, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("IfToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("IfToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.
						"SPbSU.RobotsLanguage.RobotsLanguageToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("RobotsLanguageToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"If", // F1 help keyword for the toolbox item.
						resourceManager.GetString("IfToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						CreateElementToolPrototype(store, global::SPbSU.RobotsLanguage.IfNode.DomainClassId), // ElementGroupPrototype (data object) representing model element on the toolbox.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
						new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) 
						});
					break;
				case "SPbSU.RobotsLanguage.EndIfToolboxItem":
					// Add EndIf shape tool.
					result = new DslDesign::ModelingToolboxItem(
						"SPbSU.RobotsLanguage.EndIfToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						6, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("EndIfToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("EndIfToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.
						"SPbSU.RobotsLanguage.RobotsLanguageToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("RobotsLanguageToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"EndIf", // F1 help keyword for the toolbox item.
						resourceManager.GetString("EndIfToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						CreateElementToolPrototype(store, global::SPbSU.RobotsLanguage.EndIfNode.DomainClassId), // ElementGroupPrototype (data object) representing model element on the toolbox.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
						new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) 
						});
					break;
				case "SPbSU.RobotsLanguage.IterationsToolboxItem":
					// Add Iterations shape tool.
					result = new DslDesign::ModelingToolboxItem(
						"SPbSU.RobotsLanguage.IterationsToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						7, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("IterationsToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("IterationsToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.
						"SPbSU.RobotsLanguage.RobotsLanguageToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("RobotsLanguageToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"Iterations", // F1 help keyword for the toolbox item.
						resourceManager.GetString("IterationsToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						CreateElementToolPrototype(store, global::SPbSU.RobotsLanguage.IterationsNode.DomainClassId), // ElementGroupPrototype (data object) representing model element on the toolbox.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
						new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) 
						});
					break;
				case "SPbSU.RobotsLanguage.EndIterationsToolboxItem":
					// Add EndIterations shape tool.
					result = new DslDesign::ModelingToolboxItem(
						"SPbSU.RobotsLanguage.EndIterationsToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						8, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("EndIterationsToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("EndIterationsToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.
						"SPbSU.RobotsLanguage.RobotsLanguageToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("RobotsLanguageToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"EndIterations", // F1 help keyword for the toolbox item.
						resourceManager.GetString("EndIterationsToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						CreateElementToolPrototype(store, global::SPbSU.RobotsLanguage.EndIterationsNode.DomainClassId), // ElementGroupPrototype (data object) representing model element on the toolbox.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
						new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) 
						});
					break;
				case "SPbSU.RobotsLanguage.SubprogramCallToolboxItem":
					// Add SubprogramCall shape tool.
					result = new DslDesign::ModelingToolboxItem(
						"SPbSU.RobotsLanguage.SubprogramCallToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						9, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("SubprogramCallToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("SubprogramCallToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.
						"SPbSU.RobotsLanguage.RobotsLanguageToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("RobotsLanguageToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"SubprogramCall", // F1 help keyword for the toolbox item.
						resourceManager.GetString("SubprogramCallToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						CreateElementToolPrototype(store, global::SPbSU.RobotsLanguage.SubprogramCallNode.DomainClassId), // ElementGroupPrototype (data object) representing model element on the toolbox.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
						new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) 
						});
					break;
				default:
					break;
			} // end switch
			
			return result;
		}
		

		/// <summary>
		/// The store toe be used for all the toolbox item creation
		/// </summary>
		protected DslModeling::Store ToolboxStore
		{
			get
			{ 
				if (toolboxStore==null)
				{
					toolboxStore = new DslModeling::Store(this.ServiceProvider);
					EventHandler StoreCleanUp = (o, e) =>
					{
						//Since Store implements IDisposable, we need to dispose it when we're finished
						if (this.toolboxStore != null)
						{
							this.toolboxStore.Dispose();
						}
						this.toolboxStore = null;
					};
					//There is no DomainUnload event for the default AppDomain, so we listen for both ProcessExit and DomainUnload
					AppDomain.CurrentDomain.ProcessExit += new EventHandler(StoreCleanUp);
					AppDomain.CurrentDomain.DomainUnload += new EventHandler(StoreCleanUp);
					
					//load the domain model
					toolboxStore.LoadDomainModels(typeof(global::SPbSU.RobotsLanguage.RobotsLanguageDomainModel));
					
				}
				return toolboxStore;
			}
		}
		
		/// <summary>
		/// Given a toolbox item "unique ID" returns the the toolbox item using cached dictionary
		/// </summary>
		/// <param name="itemId">The unique ToolboxItem to retrieve</param>
		private DslDesign::ModelingToolboxItem GetToolboxItem(string itemId)
		{
			DslDesign::ModelingToolboxItem item = null;

			if (!this.toolboxItemCache.TryGetValue(itemId, out item))
			{
				DslModeling::Store store = this.ToolboxStore;
				
				// Open transaction so we can create model elements corresponding to toolbox items.
				using (DslModeling::Transaction t = store.TransactionManager.BeginTransaction("CreateToolboxItems"))
				{
					// Retrieve the specified ToolboxItem from the DSL
					this.toolboxItemCache[itemId] = item = this.GetToolboxItem(itemId, store);
				}
			}

			return item;
		}
		
		/// <summary>
		/// Given a toolbox item "unique ID" and a data format identifier, returns the content of
		/// the data format. 
		/// </summary>
		/// <param name="itemId">The unique ToolboxItem to retrieve data for</param>
		/// <param name="format">The desired format of the resulting data</param>
		public virtual object GetToolboxItemData(string itemId, DataFormats.Format format)
		{
			DslDesign::ModelingToolboxItem item = null;

			global::System.Resources.ResourceManager resourceManager = global::SPbSU.RobotsLanguage.RobotsLanguageDomainModel.SingletonResourceManager;
			global::System.Globalization.CultureInfo resourceCulture = global::System.Globalization.CultureInfo.CurrentUICulture;

			System.Windows.Forms.IDataObject tbxDataObj;

			//get the toolbox item
			item = GetToolboxItem(itemId);

			if (item != null)
			{
				ToolboxItemContainer container = new ToolboxItemContainer(item);
				tbxDataObj = container.ToolboxData;

				if (tbxDataObj.GetDataPresent(format.Name))
				{
					return tbxDataObj.GetData(format.Name);
				}
				else 
				{
					string invalidFormatString = resourceManager.GetString("UnsupportedToolboxFormat", resourceCulture);
					throw new InvalidOperationException(string.Format(resourceCulture, invalidFormatString, format.Name));
				}
			}

			string errorFormatString = resourceManager.GetString("UnresolvedToolboxItem", resourceCulture);
			throw new InvalidOperationException(string.Format(resourceCulture, errorFormatString, itemId));
		}		
	}
}
