# RoutingSample-ForAndroid

### Description


The Map Suite Routing “How Do I?” solution offers a series of useful how-to examples for using the Map Suite Routing extension. The bundled solution comes with a small set of routable street data from Newfoundland Island Realty, Canada and demonstrates simple routing, avoiding specific areas, getting turn-by-turn directions, optimizing for the Traveling Salesman Problem, and much more. Full source code is included in both C# and VB.NET languages; simply select your preferred language to download the associated solution.

Please refer to [Wiki](http://wiki.thinkgeo.com/wiki/map_suite_mobile_for_android) for the details.

![Screenshot](https://github.com/ThinkGeo/RoutingSample-ForAndroid/blob/master/ScreenShot.png)

### Requirements
This sample makes use of the following NuGet Packages

[MapSuite 10.0.0](https://www.nuget.org/packages?q=ThinkGeo)

### About the Code
```csharp
var routingSource = new RtgRoutingSource(DataManager.GetDataPath("land_lnd_street_segment_route.rtg"));
var featureSource = new ShapeFileFeatureSource(DataManager.GetDataPath("land_lnd_street_segment_route.routable.shp"));
featureSource.Open();
var boundry = featureSource.GetBoundingBox();
routingEngine = new RoutingEngine(routingSource, featureSource);
routingEngine.GeographyUnit = GeographyUnit.Meter;
routingEngine.SearchRadiusInMeters = 2000000;
```
### Getting Help

[Map Suite Web for Android Wiki Resources](http://wiki.thinkgeo.com/wiki/map_suite_mobile_for_android)

[Map Suite Web for Android Product Description](https://thinkgeo.com/mobile)

[ThinkGeo Community Site](http://community.thinkgeo.com/)

[ThinkGeo Web Site](http://www.thinkgeo.com)

### Key APIs
This example makes use of the following APIs:

- [ThinkGeo.MapSuite.Routing.RtgRoutingSource](http://wiki.thinkgeo.com/wiki/api/thinkgeo.mapsuite.routing.rtgroutingsource)
- [ThinkGeo.MapSuite.Layers.ShapeFileFeatureSource](http://wiki.thinkgeo.com/wiki/api/thinkgeo.mapsuite.layers.shapefilefeaturesource)
- [ThinkGeo.MapSuite.Routing.RoutingEngine](http://wiki.thinkgeo.com/wiki/api/thinkgeo.mapsuite.routing.routingengine)
- [ThinkGeo.MapSuite.Shapes.RectangleShape](http://wiki.thinkgeo.com/wiki/api/thinkgeo.mapsuite.shapes.rectangleshape)

### About Map Suite
Map Suite is a set of powerful development components and services for the .Net Framework.

### About ThinkGeo
ThinkGeo is a GIS (Geographic Information Systems) company founded in 2004 and located in Frisco, TX. Our clients are in more than 40 industries including agriculture, energy, transportation, government, engineering, software development, and defense.
