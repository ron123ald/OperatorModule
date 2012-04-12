<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<head> 
  <meta http-equiv="content-type" content="text/html; charset=UTF-8" /> 
  <title>Google Map</title> 
  <script src="http://maps.google.com/maps/api/js?sensor=false" 
          type="text/javascript"></script>
</head> 
<body>

  <div id="map" style="width: 100%; height: 499px;"></div>

  <script type="text/javascript">
      var frame_marker = new google.maps.MarkerImage(
    					'<%=ResolveUrl("~/Content/Images/red_pin2.png")%>',
    					new google.maps.Size(70, 70),
    					new google.maps.Point(0, 0),
    					new google.maps.Point(35, 40));

      var locations = ['<%=ViewData["PostID"] %>', <%=ViewData["lat"] %>, <%=ViewData["long"] %>, 1];

      var map = new google.maps.Map(document.getElementById('map'), {
          zoom: 18,
          center: new google.maps.LatLng(locations[1], locations[2]),
          mapTypeId: google.maps.MapTypeId.ROADMAP
      });

      var infowindow = new google.maps.InfoWindow();

      var marker, i;
          marker = new google.maps.Marker({
                position: new google.maps.LatLng(locations[1], locations[2]),
                icon: frame_marker,
                map: map,
                title: "Sample Test"
          });


          google.maps.event.addListener(marker, 'click', (function (marker, i) {
              return function () {
                  infowindow.setContent(locations[0]);
                  infowindow.open(map, marker);
              }
          })(marker, i));
  </script>

</body>
</asp:Content>
