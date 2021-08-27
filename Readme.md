<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128576108/13.2.8%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4744)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Manual Colorization/Form1.cs) (VB: [Form1.vb](./VB/Manual Colorization/Form1.vb))
<!-- default file list end -->
# How to color manually added shapes using the choropleth colorizer


<p>This example demonstrates how to paint  two triangles on a map using the choropleth colorizer. </p><br />



<h3>Description</h3>

<p>To accomplish this task for map shapes, do the following:</p><p><br />
1) Create a choropleth colorizer using the<strong> VectorItemsLayer.Colorizer</strong> property; </p><p><br />
2) Specify range stops (data splits in ranges) for the colorizer using the <a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraMapChoroplethColorizer_RangeStopstopic"><u>ChoroplethColorizer.RangeStops</u></a> property;</p><p><br />
3) Specify a set of colors in the <strong>ColorCollection</strong> object, which is accessed via the <a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraMapMapColorizer_Colorstopic"><u>MapColorizer.Colors</u></a> property; </p><p><br />
4)  Create a <a href="https://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraMapMapItemAttributetopic"><u>MapItemAttribute</u></a> object  using the <a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraMapMapItem_Attributestopic"><u>MapItem.Attributes</u></a>  property;</p><p><br />
5)  Specify the attribute name, type, and value using the corresponding properties (<a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraMapMapItemAttribute_Nametopic"><u>MapItemAttribute.Name</u></a>, <a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraMapMapItemAttribute_Typetopic"><u>MapItemAttribute.Type</u></a>, and <a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraMapMapItemAttribute_Valuetopic"><u>MapItemAttribute.Value</u></a>);</p><p><br />
6) Assign the <a href="https://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraMapShapeAttributeValueProvidertopic"><u>ShapeAttributeValueProvider</u></a>r object with the specified attribute name (<a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraMapShapeAttributeValueProvider_AttributeNametopic"><u>ShapeAttributeValueProvider.AttributeName</u></a>) to the <a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraMapChoroplethColorizer_ValueProvidertopic"><u>ChoroplethColorizer.ValueProvider</u></a> property.</p><p><br />
</p>

<br/>


