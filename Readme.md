<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Manual Colorization/Form1.cs) (VB: [Form1.vb](./VB/Manual Colorization/Form1.vb))
<!-- default file list end -->
# How to color manually added shapes using the choropleth colorizer


<p>This example demonstrates how to paint  two triangles on a map using the choropleth colorizer. </p><br />



<h3>Description</h3>

<p>To accomplish this task for map shapes, do the following:</p><p>1) Create a choropleth colorizer using the <a href="http://help.devexpress.com/#WindowsForms/DevExpressXtraMapMapControl_Colorizertopic"><u>MapControl.Colorizer</u></a> property; </p><p>2) Specify range stops (data splits in ranges) for the colorizer using the <a href="http://help.devexpress.com/#WindowsForms/DevExpressXtraMapChoroplethColorizer_RangeStopstopic"><u>ChoroplethColorizer.RangeStops</u></a> property;</p><p>3) Specify a set of colors in the <a href="http://help.devexpress.com/#WindowsForms/clsDevExpressXtraMapColorCollectiontopic"><u>ColorCollection</u></a> object, which is accessed via the <a href="http://help.devexpress.com/#WindowsForms/DevExpressXtraMapMapColorizer_Colorstopic"><u>MapColorizer.Colors</u></a> property; </p><p>4)  Create a <a href="http://help.devexpress.com/#WindowsForms/clsDevExpressXtraMapMapItemAttributetopic"><u>MapItemAttribute</u></a> object  using the <a href="http://help.devexpress.com/#WindowsForms/DevExpressXtraMapMapItem_Attributestopic"><u>MapItem.Attributes</u></a>  property;</p><p>5)  Specify the attribute name, type, and value using the corresponding properties (<a href="http://help.devexpress.com/#WindowsForms/DevExpressXtraMapMapItemAttribute_Nametopic"><u>MapItemAttribute.Name</u></a>, <a href="http://help.devexpress.com/#WindowsForms/DevExpressXtraMapMapItemAttribute_Typetopic"><u>MapItemAttribute.Type</u></a>, and <a href="http://help.devexpress.com/#WindowsForms/DevExpressXtraMapMapItemAttribute_Valuetopic"><u>MapItemAttribute.Value</u></a>);</p><p>6) Assign the <a href="http://help.devexpress.com/#WindowsForms/clsDevExpressXtraMapShapeAttributeValueProvidertopic"><u>ShapeAttributeValueProvider</u></a> object with the specified attribute name (<a href="http://help.devexpress.com/#WindowsForms/DevExpressXtraMapShapeAttributeValueProvider_AttributeNametopic"><u>ShapeAttributeValueProvider.AttributeName</u></a>) to the <a href="http://help.devexpress.com/#WindowsForms/DevExpressXtraMapChoroplethColorizer_ValueProvidertopic"><u>ChoroplethColorizer.ValueProvider</u></a> property.</p>

<br/>


