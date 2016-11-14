<?xml version="1.0" encoding="utf-8"?>
<Dsl xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="f5d71ec9-ccb6-496e-810b-185c031a52a4" Description="Description for SPbSU.RobotsLanguage.RobotsLanguage" Name="RobotsLanguage" DisplayName="RobotsLanguage" Namespace="SPbSU.RobotsLanguage" ProductName="RobotsLanguage" CompanyName="SPbSU" PackageGuid="9034a183-e637-44b2-b39d-06082cb16378" PackageNamespace="SPbSU.RobotsLanguage" xmlns="http://schemas.microsoft.com/VisualStudio/2005/DslTools/DslDefinitionModel">
  <Classes>
    <DomainClass Id="55fa0139-cb00-4fa4-863f-f478a6c79aff" Description="The root in which all other elements are embedded. Appears as a diagram." Name="RobotModel" DisplayName="Robot Model" Namespace="SPbSU.RobotsLanguage">
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Notes>Creates an embedding link when an element is dropped onto a model. </Notes>
          <Index>
            <DomainClassMoniker Name="AbstractNode" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>RobotModelHasElements.Elements</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="55b183c1-cce3-4840-b116-fd5ffad02289" Description="Elements embedded in the model. Appear as boxes on the diagram." Name="AbstractNode" DisplayName="Abstract Node" InheritanceModifier="Abstract" Namespace="SPbSU.RobotsLanguage">
      <Properties>
        <DomainProperty Id="18a7f25c-95fa-4431-99f4-2c20d6b1ca3b" Description="Description for SPbSU.RobotsLanguage.AbstractNode.Elem Name" Name="ElemName" DisplayName="Elem Name" DefaultValue="" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="027205a2-e68c-4d40-ba39-ece4a495a665" Description="Description for SPbSU.RobotsLanguage.StartNode" Name="StartNode" DisplayName="Start Node" Namespace="SPbSU.RobotsLanguage">
      <BaseClass>
        <DomainClassMoniker Name="AbstractNode" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="dace7fcb-5886-4442-9f1d-26c791759043" Description="Description for SPbSU.RobotsLanguage.FinishNode" Name="FinishNode" DisplayName="Finish Node" Namespace="SPbSU.RobotsLanguage">
      <BaseClass>
        <DomainClassMoniker Name="AbstractNode" />
      </BaseClass>
    </DomainClass>
  </Classes>
  <Relationships>
    <DomainRelationship Id="1f1db859-6770-4fc3-8862-c3a1bb1d035e" Description="Embedding relationship between the Model and Elements" Name="RobotModelHasElements" DisplayName="Robot Model Has Elements" Namespace="SPbSU.RobotsLanguage" IsEmbedding="true">
      <Source>
        <DomainRole Id="a2d74ab9-0039-439c-a6ff-e2bd9fdf294f" Description="" Name="RobotModel" DisplayName="Robot Model" PropertyName="Elements" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Elements">
          <RolePlayer>
            <DomainClassMoniker Name="RobotModel" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="276cd009-dcf9-4166-b412-f22a7cfc96bd" Description="" Name="Element" DisplayName="Element" PropertyName="RobotModel" Multiplicity="ZeroOne" PropagatesDelete="true" PropertyDisplayName="Robot Model">
          <RolePlayer>
            <DomainClassMoniker Name="AbstractNode" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="1d688510-5d91-4320-afb3-7875c62fd843" Description="Description for SPbSU.RobotsLanguage.AbstractNodeReferencesTargetAbstractNode" Name="AbstractNodeReferencesTargetAbstractNode" DisplayName="Abstract Node References Target Abstract Node" Namespace="SPbSU.RobotsLanguage">
      <Source>
        <DomainRole Id="caa5b174-6574-469c-aa81-13f57fa8224b" Description="Description for SPbSU.RobotsLanguage.AbstractNodeReferencesTargetAbstractNode.SourceAbstractNode" Name="SourceAbstractNode" DisplayName="Source Abstract Node" PropertyName="TargetAbstractNode" PropertyDisplayName="Target Abstract Node">
          <RolePlayer>
            <DomainClassMoniker Name="AbstractNode" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="db2198f6-d7f0-4ac1-8f3d-4ae104a05963" Description="Description for SPbSU.RobotsLanguage.AbstractNodeReferencesTargetAbstractNode.TargetAbstractNode" Name="TargetAbstractNode" DisplayName="Target Abstract Node" PropertyName="SourceAbstractNode" PropertyDisplayName="Source Abstract Node">
          <RolePlayer>
            <DomainClassMoniker Name="AbstractNode" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
  </Relationships>
  <Types>
    <ExternalType Name="DateTime" Namespace="System" />
    <ExternalType Name="String" Namespace="System" />
    <ExternalType Name="Int16" Namespace="System" />
    <ExternalType Name="Int32" Namespace="System" />
    <ExternalType Name="Int64" Namespace="System" />
    <ExternalType Name="UInt16" Namespace="System" />
    <ExternalType Name="UInt32" Namespace="System" />
    <ExternalType Name="UInt64" Namespace="System" />
    <ExternalType Name="SByte" Namespace="System" />
    <ExternalType Name="Byte" Namespace="System" />
    <ExternalType Name="Double" Namespace="System" />
    <ExternalType Name="Single" Namespace="System" />
    <ExternalType Name="Guid" Namespace="System" />
    <ExternalType Name="Boolean" Namespace="System" />
    <ExternalType Name="Char" Namespace="System" />
  </Types>
  <Shapes>
    <GeometryShape Id="f101e528-6652-4c1f-8e56-37a5d87390eb" Description="Shape used to represent ExampleElements on a Diagram." Name="Start" DisplayName="Start" Namespace="SPbSU.RobotsLanguage" TooltipType="Fixed" FixedTooltipText="Start" FillColor="242, 239, 229" OutlineColor="113, 111, 110" InitialWidth="2" InitialHeight="0.75" OutlineThickness="0.01" Geometry="Rectangle">
      <Notes>The shape has a text decorator used to display the Name property of the mapped ExampleElement.</Notes>
      <ShapeHasDecorators Position="Center" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="NameDecorator" DisplayName="Name Decorator" DefaultText="NameDecorator" />
      </ShapeHasDecorators>
    </GeometryShape>
    <GeometryShape Id="a5077011-14e7-453c-9425-8306b4c697a9" Description="Description for SPbSU.RobotsLanguage.Finish" Name="Finish" DisplayName="Finish" Namespace="SPbSU.RobotsLanguage" FixedTooltipText="Finish" InitialHeight="1" Geometry="Rectangle">
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="NameDecorator" DisplayName="Name Decorator" DefaultText="NameDecorator" />
      </ShapeHasDecorators>
    </GeometryShape>
  </Shapes>
  <Connectors>
    <Connector Id="994625fb-e6ca-4fe5-8c78-af42cd4028a1" Description="Connector between the ExampleShapes. Represents ExampleRelationships on the Diagram." Name="ExampleConnector" DisplayName="Example Connector" Namespace="SPbSU.RobotsLanguage" FixedTooltipText="Example Connector" Color="113, 111, 110" TargetEndStyle="EmptyArrow" Thickness="0.01" />
  </Connectors>
  <XmlSerializationBehavior Name="RobotsLanguageSerializationBehavior" Namespace="SPbSU.RobotsLanguage">
    <ClassData>
      <XmlClassData TypeName="RobotModel" MonikerAttributeName="" SerializeId="true" MonikerElementName="robotModelMoniker" ElementName="robotModel" MonikerTypeName="RobotModelMoniker">
        <DomainClassMoniker Name="RobotModel" />
        <ElementData>
          <XmlRelationshipData RoleElementName="elements">
            <DomainRelationshipMoniker Name="RobotModelHasElements" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="AbstractNode" MonikerAttributeName="elemName" SerializeId="true" MonikerElementName="abstractNodeMoniker" ElementName="abstractNode" MonikerTypeName="AbstractNodeMoniker">
        <DomainClassMoniker Name="AbstractNode" />
        <ElementData>
          <XmlPropertyData XmlName="elemName" IsMonikerKey="true">
            <DomainPropertyMoniker Name="AbstractNode/ElemName" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="targetAbstractNode">
            <DomainRelationshipMoniker Name="AbstractNodeReferencesTargetAbstractNode" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="RobotModelHasElements" MonikerAttributeName="" SerializeId="true" MonikerElementName="robotModelHasElementsMoniker" ElementName="robotModelHasElements" MonikerTypeName="RobotModelHasElementsMoniker">
        <DomainRelationshipMoniker Name="RobotModelHasElements" />
      </XmlClassData>
      <XmlClassData TypeName="Start" MonikerAttributeName="" SerializeId="true" MonikerElementName="startMoniker" ElementName="start" MonikerTypeName="StartMoniker">
        <GeometryShapeMoniker Name="Start" />
      </XmlClassData>
      <XmlClassData TypeName="ExampleConnector" MonikerAttributeName="" SerializeId="true" MonikerElementName="exampleConnectorMoniker" ElementName="exampleConnector" MonikerTypeName="ExampleConnectorMoniker">
        <ConnectorMoniker Name="ExampleConnector" />
      </XmlClassData>
      <XmlClassData TypeName="RobotsLanguageDiagram" MonikerAttributeName="" SerializeId="true" MonikerElementName="robotsLanguageDiagramMoniker" ElementName="robotsLanguageDiagram" MonikerTypeName="RobotsLanguageDiagramMoniker">
        <DiagramMoniker Name="RobotsLanguageDiagram" />
      </XmlClassData>
      <XmlClassData TypeName="Finish" MonikerAttributeName="" SerializeId="true" MonikerElementName="finishMoniker" ElementName="finish" MonikerTypeName="FinishMoniker">
        <GeometryShapeMoniker Name="Finish" />
      </XmlClassData>
      <XmlClassData TypeName="StartNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="startNodeMoniker" ElementName="startNode" MonikerTypeName="StartNodeMoniker">
        <DomainClassMoniker Name="StartNode" />
      </XmlClassData>
      <XmlClassData TypeName="FinishNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="finishNodeMoniker" ElementName="finishNode" MonikerTypeName="FinishNodeMoniker">
        <DomainClassMoniker Name="FinishNode" />
      </XmlClassData>
      <XmlClassData TypeName="AbstractNodeReferencesTargetAbstractNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="abstractNodeReferencesTargetAbstractNodeMoniker" ElementName="abstractNodeReferencesTargetAbstractNode" MonikerTypeName="AbstractNodeReferencesTargetAbstractNodeMoniker">
        <DomainRelationshipMoniker Name="AbstractNodeReferencesTargetAbstractNode" />
      </XmlClassData>
    </ClassData>
  </XmlSerializationBehavior>
  <ExplorerBehavior Name="RobotsLanguageExplorer" />
  <ConnectionBuilders>
    <ConnectionBuilder Name="AbstractNodeReferencesTargetAbstractNodeBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="AbstractNodeReferencesTargetAbstractNode" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="AbstractNode" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="AbstractNode" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
  </ConnectionBuilders>
  <Diagram Id="1f168244-784b-4191-b7de-470650dceb15" Description="Description for SPbSU.RobotsLanguage.RobotsLanguageDiagram" Name="RobotsLanguageDiagram" DisplayName="Minimal Language Diagram" Namespace="SPbSU.RobotsLanguage">
    <Class>
      <DomainClassMoniker Name="RobotModel" />
    </Class>
    <ShapeMaps>
      <ShapeMap>
        <DomainClassMoniker Name="StartNode" />
        <ParentElementPath>
          <DomainPath>RobotModelHasElements.RobotModel/!RobotModel</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="Finish/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="AbstractNode/ElemName" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="Start/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="AbstractNode/ElemName" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <GeometryShapeMoniker Name="Start" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="FinishNode" />
        <ParentElementPath>
          <DomainPath>RobotModelHasElements.RobotModel/!RobotModel</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="Finish/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="AbstractNode/ElemName" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="Start/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="AbstractNode/ElemName" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <GeometryShapeMoniker Name="Finish" />
      </ShapeMap>
    </ShapeMaps>
    <ConnectorMaps>
      <ConnectorMap>
        <ConnectorMoniker Name="ExampleConnector" />
        <DomainRelationshipMoniker Name="AbstractNodeReferencesTargetAbstractNode" />
      </ConnectorMap>
    </ConnectorMaps>
  </Diagram>
  <Designer CopyPasteGeneration="CopyPasteOnly" FileExtension="rob" EditorGuid="17de3b6d-2977-4872-8c4c-43af35df5d04">
    <RootClass>
      <DomainClassMoniker Name="RobotModel" />
    </RootClass>
    <XmlSerializationDefinition CustomPostLoad="false">
      <XmlSerializationBehaviorMoniker Name="RobotsLanguageSerializationBehavior" />
    </XmlSerializationDefinition>
    <ToolboxTab TabText="RobotsLanguage">
      <ElementTool Name="Start" ToolboxIcon="resources\exampleshapetoolbitmap.bmp" Caption="Start" Tooltip="Create an ExampleElement" HelpKeyword="CreateExampleClassF1Keyword">
        <DomainClassMoniker Name="StartNode" />
      </ElementTool>
      <ElementTool Name="Finish" ToolboxIcon="Resources\ExampleShapeToolBitmap.bmp" Caption="Finish" Tooltip="Finish" HelpKeyword="Finish">
        <DomainClassMoniker Name="FinishNode" />
      </ElementTool>
      <ConnectionTool Name="ConnectionTool1" ToolboxIcon="Resources\ExampleConnectorToolBitmap.bmp" Caption="ConnectionTool1" Tooltip="Connection Tool1" HelpKeyword="ConnectionTool1">
        <ConnectionBuilderMoniker Name="RobotsLanguage/AbstractNodeReferencesTargetAbstractNodeBuilder" />
      </ConnectionTool>
    </ToolboxTab>
    <Validation UsesMenu="false" UsesOpen="false" UsesSave="false" UsesLoad="false" />
    <DiagramMoniker Name="RobotsLanguageDiagram" />
  </Designer>
  <Explorer ExplorerGuid="b86010e1-862e-4092-a2da-9ff6486ba203" Title="RobotsLanguage Explorer">
    <ExplorerBehaviorMoniker Name="RobotsLanguage/RobotsLanguageExplorer" />
  </Explorer>
</Dsl>