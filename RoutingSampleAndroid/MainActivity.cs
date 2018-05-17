using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using ThinkGeo.MapSuite;
using ThinkGeo.MapSuite.Android;
using ThinkGeo.MapSuite.Layers;
using ThinkGeo.MapSuite.Routing;
using ThinkGeo.MapSuite.Shapes;
using ThinkGeo.MapSuite.Styles;

namespace RoutingSample
{
    [Activity(Label = "RoutingSample", Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private MapView mapView;
        private LayerOverlay layerOverlay;
        private RoutingLayer routingLayer;
        private RoutingEngine routingEngine;
        private bool firstClick = true;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            try
            {
                FrameLayout mapContainerView = FindViewById<FrameLayout>(Resource.Id.MapContainerView);
                mapContainerView.RemoveAllViews();
                mapView = new MapView(Application.Context);
                mapView.SetBackgroundColor(Color.Argb(255, 244, 242, 238));

                InitalizeMap();

                mapContainerView.AddView(mapView, new ViewGroup.LayoutParams(ViewGroup.LayoutParams.FillParent, ViewGroup.LayoutParams.FillParent));
            }
            catch (Exception ex)
            {
                Log.Debug("Sample Changed", ex.Message);
            }
        }

        private void InitalizeMap()
        {
            mapView.MapUnit = GeographyUnit.Meter;
            mapView.SingleTap += MapView_SingleTap;

            LayerOverlay backgroundOverlay = new LayerOverlay();
            ShapeFileFeatureLayer shapeFileFeatureLayer = new ShapeFileFeatureLayer(DataManager.GetDataPath("land_lnd_street_segment_route.routable.shp"));
            shapeFileFeatureLayer.ZoomLevelSet.ZoomLevel01.DefaultLineStyle = WorldStreetsLineStyles.MotorwayFill(2.0f);
            shapeFileFeatureLayer.ZoomLevelSet.ZoomLevel01.ApplyUntilZoomLevel = ApplyUntilZoomLevel.Level20;
            backgroundOverlay.Layers.Add(shapeFileFeatureLayer);
            mapView.Overlays.Add(backgroundOverlay);

            layerOverlay = new LayerOverlay();
            routingLayer = new RoutingLayer();
            layerOverlay.Layers.Add(routingLayer);
            mapView.Overlays.Add(layerOverlay);

            var routingSource = new RtgRoutingSource(DataManager.GetDataPath("land_lnd_street_segment_route.rtg"));
            var featureSource = new ShapeFileFeatureSource(DataManager.GetDataPath("land_lnd_street_segment_route.routable.shp"));
            featureSource.Open();
            var boundry = featureSource.GetBoundingBox();
            routingEngine = new RoutingEngine(routingSource, featureSource);
            routingEngine.GeographyUnit = GeographyUnit.Meter;
            routingEngine.SearchRadiusInMeters = 2000000;

            mapView.CurrentExtent = new RectangleShape(307619.124092, 900219997.607509, 121246866.13256, 800097784.115004);
        }

        private void MapView_SingleTap(object sender, SingleTapMapViewEventArgs e)
        {
            routingLayer.Routes.Clear();
            if (firstClick)
            {
                routingLayer.StartPoint = e.WorldPoint;
                firstClick = false;
            }
            else
            {
                routingLayer.EndPoint = e.WorldPoint;
                firstClick = true;
            }

            routingLayer.Routes.Clear();
            if (routingLayer.StartPoint != null && routingLayer.EndPoint != null)
            {
                RoutingResult routingResult = routingEngine.GetRoute(routingLayer.StartPoint, routingLayer.EndPoint);
                routingLayer.Routes.Add(routingResult.Route);
            }

            layerOverlay.Refresh();
        }
    }
}

