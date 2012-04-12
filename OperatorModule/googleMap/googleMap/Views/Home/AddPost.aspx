<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	AddPost
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<head>
    <title>Google Map</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no">
    <meta charset="UTF-8">
    <style type="text/css">
        html, body, #map_canvas {
        margin: 0;
        padding: 0;
        }
    </style>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.6.min.js"></script>
    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>
</head>
<body>
<div id="map_canvas" style="width: 100%; height: 499px;">
</div>
<form>
    <div id="details" class="textBoxClass">
        <table border="1">
            <tr>
            <td><label for="LatTxt">Latitude</label></td>
            <td><input type="text" placeholder="Latitude" id="Lat" name="LatTxt" value="" /></td>
            </tr>
            <tr>
            <td><label for="LngTxt">Longitude</label></td>
            <td><input type="text" placeholder="Longitude" id="Lng" name="LngTxt" value="" /></td>
            </tr>
            <tr>
            <td><label for="PostName">Post Name</label></td>
            <td><input type="text" placeholder="Post Name" id="PostName" name="PostName" value="" /></td>
            </tr>
            <tr>
            <td><label for="SerialNo">Serial Number</label></td>
            <td><input type="text" placeholder="Serial Number" id="SerialNo" name="SerialNo" value="" /></td>
            </tr>
            <tr>
            <td><label for="ClusterNo">Cluster Number</label></td>
            <td><input type="text" placeholder="Cluster Number" id="ClusterNo" name="ClusterNo" value="<%=ViewData["Cluster"]%>" /></td>
            </tr>
            <tr><td><input type="submit" id="SubmitBtn" name="SubmitBtn" value="Submit" /></td></tr>
            
        </table>
    </div>
</form>
    
    
</body>
<script type="text/javascript">
    var markers = [];
    var frame_marker = new google.maps.MarkerImage(
    					'<%=ResolveUrl("~/Content/Images/green_pin2.png")%>',
    					new google.maps.Size(70, 70),
    					new google.maps.Point(0, 0),
    					new google.maps.Point(35, 40)
    );
    var imageUrl = '<%=ResolveUrl("~/Content/Images/infoContainer.png")%>';
    var ServerHost = 'http://' + top.location.host + '/home/';

    function initialize() {
        var myOptions = {
            zoom: 18,
            center: new google.maps.LatLng(10.29700, 123.89693), //Latlng(10.296714986745238, 123.89705338161468)
            mapTypeId: google.maps.MapTypeId.ROADMAP    
        };
        var map = new google.maps.Map(document.getElementById('map_canvas'), myOptions);

        google.maps.event.addListener(map, 'click', function (e) {
            var lIndex = e.latLng.toString().indexOf(',');
            var LatTxt = document.getElementById('Lat');
            var LngTxt = document.getElementById('Lng');
            var PostName = document.getElementById('PostName');
            var SerialNo = document.getElementById('SerialNo');
            var infowindow = new google.maps.InfoWindow({
                content: '<div style="background: "><p>Post:</br>' + e.latLng + '</p></div>'
            });

            LatTxt.value = e.latLng.toString().substring(1, lIndex);
            LngTxt.value = e.latLng.toString().substring(lIndex + 2, e.latLng.toString().length - 1);

            //Get Location
            $.ajax({
                type: 'GET',
                url: ServerHost + 'GetLocationByLatLong?Lat=' + LatTxt.value + '&Long=' + LngTxt.value,
                success: function (data) {
                    if (data.Result == true) {
                        PostName.value = data.Location;
                    }
                },
                error: {}
            });

            $.ajax({
                type: 'GET',
                url: ServerHost + 'GetSerialNumber',
                success: function (data) {
                    if (data.Result == true) {
                        SerialNo.value = data.Serial;
                    }
                },
                error: {}
            });


            if (markers) {
                for (i in markers)
                    markers[i].setMap(null);
            }

            var newMarker = new google.maps.Marker({
                position: e.latLng,
                icon: frame_marker,
                map: map,
                title: "Sample Test"
            });

            markers.push(newMarker);

            google.maps.event.addListener(newMarker, 'click', function () {
                infowindow.open(map, newMarker);
            });
        });
    }

    google.maps.event.addDomListener(window, 'load', initialize);
</script>
</asp:Content>

