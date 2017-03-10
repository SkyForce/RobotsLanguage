<?xml version="1.0" encoding="utf-8"?>
<Dsl xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="f5d71ec9-ccb6-496e-810b-185c031a52a4" Description="Description for SPbSU.RobotsLanguage.RobotsLanguage" Name="RobotsLanguage" DisplayName="RobotsLanguage" Namespace="SPbSU.RobotsLanguage" ProductName="RobotsLanguage" CompanyName="SPbSU" PackageGuid="9034a183-e637-44b2-b39d-06082cb16378" PackageNamespace="SPbSU.RobotsLanguage" xmlns="http://schemas.microsoft.com/VisualStudio/2005/DslTools/DslDefinitionModel">
  <Classes>
    <DomainClass Id="55fa0139-cb00-4fa4-863f-f478a6c79aff" Description="The root in which all other elements are embedded. Appears as a diagram." Name="RobotModel" DisplayName="Robot Model" Namespace="SPbSU.RobotsLanguage">
      <BaseClass>
        <DomainClassMoniker Name="Compound" />
      </BaseClass>
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
    <DomainClass Id="46b80a85-0307-40a7-9260-5fb54debfe60" Description="Description for SPbSU.RobotsLanguage.Compound" Name="Compound" DisplayName="Compound" InheritanceModifier="Abstract" Namespace="SPbSU.RobotsLanguage">
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="AbstractNode" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>CompoundHasAbstractNode.AbstractNode</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="SubprogramNode" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>CompoundHasSubprogramNode.SubprogramNode</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="1d4b884e-32b1-4612-92c1-b160b2c70f7a" Description="Description for SPbSU.RobotsLanguage.SubprogramNode" Name="SubprogramNode" DisplayName="Subprogram Node" Namespace="SPbSU.RobotsLanguage">
      <BaseClass>
        <DomainClassMoniker Name="Compound" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="02655334-74c7-4a29-b638-f2bfeff27c34" Description="Description for SPbSU.RobotsLanguage.SubprogramNode.Elem Name" Name="ElemName" DisplayName="Elem Name" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="616b1380-5ce9-4492-90f2-67434d4a6910" Description="Description for SPbSU.RobotsLanguage.IfNode" Name="IfNode" DisplayName="If Node" Namespace="SPbSU.RobotsLanguage">
      <BaseClass>
        <DomainClassMoniker Name="AbstractNode" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="18da06d3-9e00-4b3e-9595-1196a2101737" Description="Description for SPbSU.RobotsLanguage.IfNode.Condition" Name="condition" DisplayName="Condition" DefaultValue="condition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="5e430085-4c92-4e41-a4b9-1e9790d84b7a" Description="Description for SPbSU.RobotsLanguage.EndIfNode" Name="EndIfNode" DisplayName="End If Node" Namespace="SPbSU.RobotsLanguage">
      <BaseClass>
        <DomainClassMoniker Name="AbstractNode" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="995b91df-a86f-42ba-9348-bd97a4a50306" Description="Description for SPbSU.RobotsLanguage.IterationsNode" Name="IterationsNode" DisplayName="Iterations Node" Namespace="SPbSU.RobotsLanguage">
      <BaseClass>
        <DomainClassMoniker Name="AbstractNode" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="d0f2e232-ee5e-4bb5-8b18-a800c4dbdfc7" Description="Description for SPbSU.RobotsLanguage.IterationsNode.Number" Name="number" DisplayName="Number" DefaultValue="10">
          <Type>
            <ExternalTypeMoniker Name="/System/Int32" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="15eb50e9-dd1f-4e16-b11b-a0d01aef3718" Description="Description for SPbSU.RobotsLanguage.SubprogramCallNode" Name="SubprogramCallNode" DisplayName="Subprogram Call Node" Namespace="SPbSU.RobotsLanguage">
      <BaseClass>
        <DomainClassMoniker Name="AbstractNode" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="931d49bd-0dfd-43c9-a36f-768f7aa24643" Description="Description for SPbSU.RobotsLanguage.SubprogramCallNode.Subprogram" Name="Subprogram" DisplayName="Subprogram" DefaultValue="Subprogram">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="1f952800-6025-4a3b-a498-407eccae749e" Description="Description for SPbSU.RobotsLanguage.ParallelNode" Name="ParallelNode" DisplayName="Parallel Node" Namespace="SPbSU.RobotsLanguage">
      <BaseClass>
        <DomainClassMoniker Name="AbstractNode" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="baf348e3-6cdf-4703-88e5-ce14a8111cc0" Description="Description for SPbSU.RobotsLanguage.EndParallelNode" Name="EndParallelNode" DisplayName="End Parallel Node" Namespace="SPbSU.RobotsLanguage">
      <BaseClass>
        <DomainClassMoniker Name="AbstractNode" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="1003be0e-277a-41a3-b4c0-8db1f065aa2a" Description="Description for SPbSU.RobotsLanguage.BreakNode" Name="BreakNode" DisplayName="Break Node" Namespace="SPbSU.RobotsLanguage">
      <BaseClass>
        <DomainClassMoniker Name="AbstractNode" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="4a312676-0f5c-4021-9ac5-e94e81834baa" Description="Description for SPbSU.RobotsLanguage.SwitchNode" Name="SwitchNode" DisplayName="Switch Node" Namespace="SPbSU.RobotsLanguage">
      <BaseClass>
        <DomainClassMoniker Name="AbstractNode" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="142607b8-3b41-4f7b-bf67-62fe2b48a797" Description="Description for SPbSU.RobotsLanguage.SwitchNode.Condition" Name="Condition" DisplayName="Condition" DefaultValue="condition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="37f16d00-0ec3-4b67-889f-d83d9fc1f99d" Description="Description for SPbSU.RobotsLanguage.EndSwitchNode" Name="EndSwitchNode" DisplayName="End Switch Node" Namespace="SPbSU.RobotsLanguage">
      <BaseClass>
        <DomainClassMoniker Name="AbstractNode" />
      </BaseClass>
    </DomainClass>
  </Classes>
  <Relationships>
    <DomainRelationship Id="1d688510-5d91-4320-afb3-7875c62fd843" Description="Description for SPbSU.RobotsLanguage.AbstractNodeReferencesTargetAbstractNode" Name="AbstractNodeReferencesTargetAbstractNode" DisplayName="Abstract Node References Target Abstract Node" Namespace="SPbSU.RobotsLanguage">
      <Properties>
        <DomainProperty Id="ffb31d05-6390-4122-829b-0953ca1a990a" Description="Description for SPbSU.RobotsLanguage.AbstractNodeReferencesTargetAbstractNode.Condition" Name="Condition" DisplayName="Condition" DefaultValue="">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
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
    <DomainRelationship Id="7f7180b7-a5ef-4827-bca5-ee56c27fc928" Description="Description for SPbSU.RobotsLanguage.CompoundHasAbstractNode" Name="CompoundHasAbstractNode" DisplayName="Compound Has Abstract Node" Namespace="SPbSU.RobotsLanguage" IsEmbedding="true">
      <Source>
        <DomainRole Id="4fdb783e-3c01-4abc-9485-4e347c4b9ec2" Description="Description for SPbSU.RobotsLanguage.CompoundHasAbstractNode.Compound" Name="Compound" DisplayName="Compound" PropertyName="AbstractNode" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Abstract Node">
          <RolePlayer>
            <DomainClassMoniker Name="Compound" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="587d308c-9a63-4476-8824-c54ace59fd3e" Description="Description for SPbSU.RobotsLanguage.CompoundHasAbstractNode.AbstractNode" Name="AbstractNode" DisplayName="Abstract Node" PropertyName="Compound" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Compound">
          <RolePlayer>
            <DomainClassMoniker Name="AbstractNode" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="5807bbd7-2455-45df-accc-3841e93f902f" Description="Description for SPbSU.RobotsLanguage.CompoundHasSubprogramNode" Name="CompoundHasSubprogramNode" DisplayName="Compound Has Subprogram Node" Namespace="SPbSU.RobotsLanguage" IsEmbedding="true">
      <Source>
        <DomainRole Id="6968a40d-7270-4252-8c6c-5544b6f0a25b" Description="Description for SPbSU.RobotsLanguage.CompoundHasSubprogramNode.Compound" Name="Compound" DisplayName="Compound" PropertyName="SubprogramNode" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Subprogram Node">
          <RolePlayer>
            <DomainClassMoniker Name="Compound" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="59e11ac3-5bc2-4f9b-b471-aa18db68c571" Description="Description for SPbSU.RobotsLanguage.CompoundHasSubprogramNode.SubprogramNode" Name="SubprogramNode" DisplayName="Subprogram Node" PropertyName="Compound" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Compound">
          <RolePlayer>
            <DomainClassMoniker Name="SubprogramNode" />
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
    <GeometryShape Id="cec34f27-e84d-40fa-8494-e3c714daef30" Description="Description for SPbSU.RobotsLanguage.Subprogram" Name="Subprogram" DisplayName="Subprogram" Namespace="SPbSU.RobotsLanguage" FixedTooltipText="Subprogram" InitialHeight="1" Geometry="Rectangle">
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0">
        <ExpandCollapseDecorator Name="ExpandCollapseDecorator1" DisplayName="Expand Collapse Decorator1" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="TextDecorator1" DisplayName="Text Decorator1" DefaultText="TextDecorator1" />
      </ShapeHasDecorators>
    </GeometryShape>
    <ImageShape Id="dfc65c6c-9289-454b-9ea3-7aca63214a1c" Description="Description for SPbSU.RobotsLanguage.Start" Name="Start" DisplayName="Start" Namespace="SPbSU.RobotsLanguage" FixedTooltipText="Start" InitialHeight="1" Image="Resources\initialBlock.png" />
    <ImageShape Id="afbd3bf8-e3c9-4009-b0ed-ad929971e6a5" Description="Description for SPbSU.RobotsLanguage.If" Name="If" DisplayName="If" Namespace="SPbSU.RobotsLanguage" FixedTooltipText="If" InitialHeight="1" Image="Resources\ifBlock.png">
      <ShapeHasDecorators Position="OuterBottomCenter" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="Condition" DisplayName="Condition" DefaultText="Condition" />
      </ShapeHasDecorators>
    </ImageShape>
    <ImageShape Id="52ece8ee-a694-44a6-a9ca-0710d57a909d" Description="Description for SPbSU.RobotsLanguage.Finish" Name="Finish" DisplayName="Finish" Namespace="SPbSU.RobotsLanguage" FixedTooltipText="Finish" InitialHeight="1" Image="Resources\finalBlock.png" />
    <ImageShape Id="63dcbc22-7dc0-48cb-aa4b-c917dda5bdf8" Description="Description for SPbSU.RobotsLanguage.EndIf" Name="EndIf" DisplayName="End If" Namespace="SPbSU.RobotsLanguage" FixedTooltipText="End If" InitialHeight="1" Image="Resources\endIfBlock.png" />
    <ImageShape Id="3ef594b0-ae58-450b-b83b-29da17522497" Description="Description for SPbSU.RobotsLanguage.Iterations" Name="Iterations" DisplayName="Iterations" Namespace="SPbSU.RobotsLanguage" FixedTooltipText="Iterations" InitialHeight="1" Image="Resources\loopBlock.png">
      <ShapeHasDecorators Position="OuterBottomCenter" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="number" DisplayName="Number" DefaultText="number" />
      </ShapeHasDecorators>
    </ImageShape>
    <ImageShape Id="98cf7454-b1ed-44cb-b43f-14fd35c0474b" Description="Description for SPbSU.RobotsLanguage.Parallel" Name="Parallel" DisplayName="Parallel" Namespace="SPbSU.RobotsLanguage" FixedTooltipText="Parallel" InitialHeight="1" Image="Resources\forkBlock.png" />
    <ImageShape Id="52798ce1-2adf-49da-bdcf-f5f72cad708f" Description="Description for SPbSU.RobotsLanguage.EndParallel" Name="EndParallel" DisplayName="End Parallel" Namespace="SPbSU.RobotsLanguage" FixedTooltipText="End Parallel" InitialHeight="1" Image="Resources\joinBlock.png" />
    <ImageShape Id="9b3c850a-4df9-4e00-ac8e-f0afa6afa933" Description="Description for SPbSU.RobotsLanguage.Switch" Name="Switch" DisplayName="Switch" Namespace="SPbSU.RobotsLanguage" FixedTooltipText="Switch" InitialHeight="1" Image="Resources\switchBlock.png">
      <ShapeHasDecorators Position="OuterBottomCenter" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="Condition" DisplayName="Condition" DefaultText="Condition" />
      </ShapeHasDecorators>
    </ImageShape>
    <ImageShape Id="10b17550-9e1b-47b9-9c6b-86c03f655d83" Description="Description for SPbSU.RobotsLanguage.EndSwitch" Name="EndSwitch" DisplayName="End Switch" Namespace="SPbSU.RobotsLanguage" FixedTooltipText="End Switch" InitialHeight="1" Image="Resources\joinBlock.png" />
    <ImageShape Id="68297388-26a3-4c72-8a60-788e095d9355" Description="Description for SPbSU.RobotsLanguage.SubprogramCall" Name="SubprogramCall" DisplayName="Subprogram Call" Namespace="SPbSU.RobotsLanguage" FixedTooltipText="Subprogram Call" InitialHeight="1" Image="Resources\subprogramRobotsBlock.png">
      <ShapeHasDecorators Position="OuterBottomCenter" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="Subprogram" DisplayName="Subprogram" DefaultText="Subprogram" />
      </ShapeHasDecorators>
    </ImageShape>
    <ImageShape Id="e3adc532-b963-469f-8fea-db63d3049201" Description="Description for SPbSU.RobotsLanguage.Break" Name="Break" DisplayName="Break" Namespace="SPbSU.RobotsLanguage" FixedTooltipText="Break" InitialHeight="1" Image="Resources\break.png" />
  </Shapes>
  <Connectors>
    <Connector Id="994625fb-e6ca-4fe5-8c78-af42cd4028a1" Description="Connector between the ExampleShapes. Represents ExampleRelationships on the Diagram." Name="ExampleConnector" DisplayName="Example Connector" Namespace="SPbSU.RobotsLanguage" FixedTooltipText="Example Connector" Color="113, 111, 110" TargetEndStyle="EmptyArrow" Thickness="0.01">
      <ConnectorHasDecorators Position="SourceTop" OffsetFromShape="0" OffsetFromLine="0">
        <TextDecorator Name="Condition" DisplayName="Condition" DefaultText="Condition" />
      </ConnectorHasDecorators>
    </Connector>
  </Connectors>
  <XmlSerializationBehavior Name="RobotsLanguageSerializationBehavior" Namespace="SPbSU.RobotsLanguage">
    <ClassData>
      <XmlClassData TypeName="RobotModel" MonikerAttributeName="" SerializeId="true" MonikerElementName="robotModelMoniker" ElementName="robotModel" MonikerTypeName="RobotModelMoniker">
        <DomainClassMoniker Name="RobotModel" />
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
      <XmlClassData TypeName="ExampleConnector" MonikerAttributeName="" SerializeId="true" MonikerElementName="exampleConnectorMoniker" ElementName="exampleConnector" MonikerTypeName="ExampleConnectorMoniker">
        <ConnectorMoniker Name="ExampleConnector" />
      </XmlClassData>
      <XmlClassData TypeName="RobotsLanguageDiagram" MonikerAttributeName="" SerializeId="true" MonikerElementName="robotsLanguageDiagramMoniker" ElementName="robotsLanguageDiagram" MonikerTypeName="RobotsLanguageDiagramMoniker">
        <DiagramMoniker Name="RobotsLanguageDiagram" />
      </XmlClassData>
      <XmlClassData TypeName="StartNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="startNodeMoniker" ElementName="startNode" MonikerTypeName="StartNodeMoniker">
        <DomainClassMoniker Name="StartNode" />
      </XmlClassData>
      <XmlClassData TypeName="FinishNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="finishNodeMoniker" ElementName="finishNode" MonikerTypeName="FinishNodeMoniker">
        <DomainClassMoniker Name="FinishNode" />
      </XmlClassData>
      <XmlClassData TypeName="AbstractNodeReferencesTargetAbstractNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="abstractNodeReferencesTargetAbstractNodeMoniker" ElementName="abstractNodeReferencesTargetAbstractNode" MonikerTypeName="AbstractNodeReferencesTargetAbstractNodeMoniker">
        <DomainRelationshipMoniker Name="AbstractNodeReferencesTargetAbstractNode" />
        <ElementData>
          <XmlPropertyData XmlName="condition">
            <DomainPropertyMoniker Name="AbstractNodeReferencesTargetAbstractNode/Condition" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="Compound" MonikerAttributeName="" SerializeId="true" MonikerElementName="compoundMoniker" ElementName="compound" MonikerTypeName="CompoundMoniker">
        <DomainClassMoniker Name="Compound" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="abstractNode">
            <DomainRelationshipMoniker Name="CompoundHasAbstractNode" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="subprogramNode">
            <DomainRelationshipMoniker Name="CompoundHasSubprogramNode" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="SubprogramNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="subprogramNodeMoniker" ElementName="subprogramNode" MonikerTypeName="SubprogramNodeMoniker">
        <DomainClassMoniker Name="SubprogramNode" />
        <ElementData>
          <XmlPropertyData XmlName="elemName">
            <DomainPropertyMoniker Name="SubprogramNode/ElemName" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="Subprogram" MonikerAttributeName="" SerializeId="true" MonikerElementName="subprogramMoniker" ElementName="subprogram" MonikerTypeName="SubprogramMoniker">
        <GeometryShapeMoniker Name="Subprogram" />
      </XmlClassData>
      <XmlClassData TypeName="CompoundHasAbstractNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="compoundHasAbstractNodeMoniker" ElementName="compoundHasAbstractNode" MonikerTypeName="CompoundHasAbstractNodeMoniker">
        <DomainRelationshipMoniker Name="CompoundHasAbstractNode" />
      </XmlClassData>
      <XmlClassData TypeName="CompoundHasSubprogramNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="compoundHasSubprogramNodeMoniker" ElementName="compoundHasSubprogramNode" MonikerTypeName="CompoundHasSubprogramNodeMoniker">
        <DomainRelationshipMoniker Name="CompoundHasSubprogramNode" />
      </XmlClassData>
      <XmlClassData TypeName="IfNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="ifNodeMoniker" ElementName="ifNode" MonikerTypeName="IfNodeMoniker">
        <DomainClassMoniker Name="IfNode" />
        <ElementData>
          <XmlPropertyData XmlName="condition">
            <DomainPropertyMoniker Name="IfNode/condition" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="EndIfNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="endIfNodeMoniker" ElementName="endIfNode" MonikerTypeName="EndIfNodeMoniker">
        <DomainClassMoniker Name="EndIfNode" />
      </XmlClassData>
      <XmlClassData TypeName="IterationsNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="iterationsNodeMoniker" ElementName="iterationsNode" MonikerTypeName="IterationsNodeMoniker">
        <DomainClassMoniker Name="IterationsNode" />
        <ElementData>
          <XmlPropertyData XmlName="number">
            <DomainPropertyMoniker Name="IterationsNode/number" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="SubprogramCallNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="subprogramCallNodeMoniker" ElementName="subprogramCallNode" MonikerTypeName="SubprogramCallNodeMoniker">
        <DomainClassMoniker Name="SubprogramCallNode" />
        <ElementData>
          <XmlPropertyData XmlName="subprogram">
            <DomainPropertyMoniker Name="SubprogramCallNode/Subprogram" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ParallelNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="parallelNodeMoniker" ElementName="parallelNode" MonikerTypeName="ParallelNodeMoniker">
        <DomainClassMoniker Name="ParallelNode" />
      </XmlClassData>
      <XmlClassData TypeName="EndParallelNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="endParallelNodeMoniker" ElementName="endParallelNode" MonikerTypeName="EndParallelNodeMoniker">
        <DomainClassMoniker Name="EndParallelNode" />
      </XmlClassData>
      <XmlClassData TypeName="BreakNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="breakNodeMoniker" ElementName="breakNode" MonikerTypeName="BreakNodeMoniker">
        <DomainClassMoniker Name="BreakNode" />
      </XmlClassData>
      <XmlClassData TypeName="SwitchNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="switchNodeMoniker" ElementName="switchNode" MonikerTypeName="SwitchNodeMoniker">
        <DomainClassMoniker Name="SwitchNode" />
        <ElementData>
          <XmlPropertyData XmlName="condition">
            <DomainPropertyMoniker Name="SwitchNode/Condition" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="EndSwitchNode" MonikerAttributeName="" SerializeId="true" MonikerElementName="endSwitchNodeMoniker" ElementName="endSwitchNode" MonikerTypeName="EndSwitchNodeMoniker">
        <DomainClassMoniker Name="EndSwitchNode" />
      </XmlClassData>
      <XmlClassData TypeName="Start" MonikerAttributeName="" SerializeId="true" MonikerElementName="startMoniker" ElementName="start" MonikerTypeName="StartMoniker">
        <ImageShapeMoniker Name="Start" />
      </XmlClassData>
      <XmlClassData TypeName="If" MonikerAttributeName="" SerializeId="true" MonikerElementName="ifMoniker" ElementName="if" MonikerTypeName="IfMoniker">
        <ImageShapeMoniker Name="If" />
      </XmlClassData>
      <XmlClassData TypeName="Finish" MonikerAttributeName="" SerializeId="true" MonikerElementName="finishMoniker" ElementName="finish" MonikerTypeName="FinishMoniker">
        <ImageShapeMoniker Name="Finish" />
      </XmlClassData>
      <XmlClassData TypeName="EndIf" MonikerAttributeName="" SerializeId="true" MonikerElementName="endIfMoniker" ElementName="endIf" MonikerTypeName="EndIfMoniker">
        <ImageShapeMoniker Name="EndIf" />
      </XmlClassData>
      <XmlClassData TypeName="Iterations" MonikerAttributeName="" SerializeId="true" MonikerElementName="iterationsMoniker" ElementName="iterations" MonikerTypeName="IterationsMoniker">
        <ImageShapeMoniker Name="Iterations" />
      </XmlClassData>
      <XmlClassData TypeName="Parallel" MonikerAttributeName="" SerializeId="true" MonikerElementName="parallelMoniker" ElementName="parallel" MonikerTypeName="ParallelMoniker">
        <ImageShapeMoniker Name="Parallel" />
      </XmlClassData>
      <XmlClassData TypeName="EndParallel" MonikerAttributeName="" SerializeId="true" MonikerElementName="endParallelMoniker" ElementName="endParallel" MonikerTypeName="EndParallelMoniker">
        <ImageShapeMoniker Name="EndParallel" />
      </XmlClassData>
      <XmlClassData TypeName="Switch" MonikerAttributeName="" SerializeId="true" MonikerElementName="switchMoniker" ElementName="switch" MonikerTypeName="SwitchMoniker">
        <ImageShapeMoniker Name="Switch" />
      </XmlClassData>
      <XmlClassData TypeName="EndSwitch" MonikerAttributeName="" SerializeId="true" MonikerElementName="endSwitchMoniker" ElementName="endSwitch" MonikerTypeName="EndSwitchMoniker">
        <ImageShapeMoniker Name="EndSwitch" />
      </XmlClassData>
      <XmlClassData TypeName="SubprogramCall" MonikerAttributeName="" SerializeId="true" MonikerElementName="subprogramCallMoniker" ElementName="subprogramCall" MonikerTypeName="SubprogramCallMoniker">
        <ImageShapeMoniker Name="SubprogramCall" />
      </XmlClassData>
      <XmlClassData TypeName="Break" MonikerAttributeName="" SerializeId="true" MonikerElementName="breakMoniker" ElementName="break" MonikerTypeName="BreakMoniker">
        <ImageShapeMoniker Name="Break" />
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
      <ShapeMap HasCustomParentElement="true">
        <DomainClassMoniker Name="SubprogramNode" />
        <ParentElementPath>
          <DomainPath />
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="Subprogram/TextDecorator1" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="SubprogramNode/ElemName" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <GeometryShapeMoniker Name="Subprogram" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="StartNode" />
        <ParentElementPath>
          <DomainPath>CompoundHasAbstractNode.Compound/!Compound</DomainPath>
        </ParentElementPath>
        <ImageShapeMoniker Name="Start" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="IfNode" />
        <ParentElementPath>
          <DomainPath>CompoundHasAbstractNode.Compound/!Compound</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="If/Condition" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="IfNode/condition" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <ImageShapeMoniker Name="If" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="FinishNode" />
        <ParentElementPath>
          <DomainPath>CompoundHasAbstractNode.Compound/!Compound</DomainPath>
        </ParentElementPath>
        <ImageShapeMoniker Name="Finish" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="EndIfNode" />
        <ParentElementPath>
          <DomainPath>CompoundHasAbstractNode.Compound/!Compound</DomainPath>
        </ParentElementPath>
        <ImageShapeMoniker Name="EndIf" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="IterationsNode" />
        <ParentElementPath>
          <DomainPath>CompoundHasAbstractNode.Compound/!Compound</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="Iterations/number" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="IterationsNode/number" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <ImageShapeMoniker Name="Iterations" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="ParallelNode" />
        <ParentElementPath>
          <DomainPath>CompoundHasAbstractNode.Compound/!Compound</DomainPath>
        </ParentElementPath>
        <ImageShapeMoniker Name="Parallel" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="EndParallelNode" />
        <ParentElementPath>
          <DomainPath>CompoundHasAbstractNode.Compound/!Compound</DomainPath>
        </ParentElementPath>
        <ImageShapeMoniker Name="EndParallel" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="SwitchNode" />
        <ParentElementPath>
          <DomainPath>CompoundHasAbstractNode.Compound/!Compound</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="Switch/Condition" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="SwitchNode/Condition" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <ImageShapeMoniker Name="Switch" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="EndSwitchNode" />
        <ParentElementPath>
          <DomainPath>CompoundHasAbstractNode.Compound/!Compound</DomainPath>
        </ParentElementPath>
        <ImageShapeMoniker Name="EndSwitch" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="SubprogramCallNode" />
        <ParentElementPath>
          <DomainPath>CompoundHasAbstractNode.Compound/!Compound</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="SubprogramCall/Subprogram" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="SubprogramCallNode/Subprogram" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <ImageShapeMoniker Name="SubprogramCall" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="BreakNode" />
        <ParentElementPath>
          <DomainPath>CompoundHasAbstractNode.Compound/!Compound</DomainPath>
        </ParentElementPath>
        <ImageShapeMoniker Name="Break" />
      </ShapeMap>
    </ShapeMaps>
    <ConnectorMaps>
      <ConnectorMap>
        <ConnectorMoniker Name="ExampleConnector" />
        <DomainRelationshipMoniker Name="AbstractNodeReferencesTargetAbstractNode" />
        <DecoratorMap>
          <TextDecoratorMoniker Name="ExampleConnector/Condition" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="AbstractNodeReferencesTargetAbstractNode/Condition" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
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
      <ElementTool Name="Subprogram" ToolboxIcon="Resources\ExampleShapeToolBitmap.bmp" Caption="Subprogram" Tooltip="Subprogram" HelpKeyword="Subprogram">
        <DomainClassMoniker Name="SubprogramNode" />
      </ElementTool>
      <ElementTool Name="If" ToolboxIcon="Resources\ExampleShapeToolBitmap.bmp" Caption="If" Tooltip="If" HelpKeyword="If">
        <DomainClassMoniker Name="IfNode" />
      </ElementTool>
      <ElementTool Name="EndIf" ToolboxIcon="Resources\ExampleShapeToolBitmap.bmp" Caption="EndIf" Tooltip="End If" HelpKeyword="EndIf">
        <DomainClassMoniker Name="EndIfNode" />
      </ElementTool>
      <ElementTool Name="Iterations" ToolboxIcon="Resources\ExampleShapeToolBitmap.bmp" Caption="Iterations" Tooltip="Iterations" HelpKeyword="Iterations">
        <DomainClassMoniker Name="IterationsNode" />
      </ElementTool>
      <ElementTool Name="SubprogramCall" ToolboxIcon="Resources\ExampleShapeToolBitmap.bmp" Caption="SubprogramCall" Tooltip="Subprogram Call" HelpKeyword="SubprogramCall">
        <DomainClassMoniker Name="SubprogramCallNode" />
      </ElementTool>
      <ElementTool Name="Parallel" ToolboxIcon="Resources\ExampleShapeToolBitmap.bmp" Caption="Parallel" Tooltip="Parallel" HelpKeyword="Parallel">
        <DomainClassMoniker Name="ParallelNode" />
      </ElementTool>
      <ElementTool Name="EndParallel" ToolboxIcon="Resources\ExampleShapeToolBitmap.bmp" Caption="EndParallel" Tooltip="End Parallel" HelpKeyword="EndParallel">
        <DomainClassMoniker Name="EndParallelNode" />
      </ElementTool>
      <ElementTool Name="Break" ToolboxIcon="Resources\ExampleShapeToolBitmap.bmp" Caption="Break" Tooltip="Break" HelpKeyword="Break">
        <DomainClassMoniker Name="BreakNode" />
      </ElementTool>
      <ElementTool Name="Switch" ToolboxIcon="Resources\ExampleShapeToolBitmap.bmp" Caption="Switch" Tooltip="Switch" HelpKeyword="Switch">
        <DomainClassMoniker Name="SwitchNode" />
      </ElementTool>
      <ElementTool Name="EndSwitch" ToolboxIcon="Resources\ExampleShapeToolBitmap.bmp" Caption="EndSwitch" Tooltip="End Switch" HelpKeyword="EndSwitch">
        <DomainClassMoniker Name="EndSwitchNode" />
      </ElementTool>
    </ToolboxTab>
    <Validation UsesMenu="true" UsesOpen="true" UsesSave="true" UsesCustom="true" UsesLoad="true" />
    <DiagramMoniker Name="RobotsLanguageDiagram" />
  </Designer>
  <Explorer ExplorerGuid="b86010e1-862e-4092-a2da-9ff6486ba203" Title="RobotsLanguage Explorer">
    <ExplorerBehaviorMoniker Name="RobotsLanguage/RobotsLanguageExplorer" />
  </Explorer>
</Dsl>