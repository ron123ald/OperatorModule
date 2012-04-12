<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ShowAllPost
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<head> 
  <meta http-equiv="content-type" content="text/html; charset=UTF-8" /> 
  <title>Google Maps Multiple Markers</title> 
  <script src="http://maps.google.com/maps/api/js?sensor=false" 
          type="text/javascript"></script>
</head> 
<body>
  <div id="map" style="width: 100%; height: 499px;"></div>

  <script type="text/javascript">

        var frame_marker = new google.maps.MarkerImage(
    					'<%=ResolveUrl("~/Content/Images/green_pin2.png")%>',
    					new google.maps.Size(70, 70),
    					new google.maps.Point(0, 0),
    					new google.maps.Point(35, 40));

        var Post_marker = new google.maps.MarkerImage(
    					'<%=ResolveUrl("~/Content/Images/red_pin2.png")%>',
    					new google.maps.Size(70, 70),
    					new google.maps.Point(0, 0),
    					new google.maps.Point(35, 40));

        var stringLocation = '<%=ViewData["locations"]%>';
        var ErrorIndex = new Array();
        if (stringLocation != "") {
        var stringSplit = stringLocation.split(';');
        var size = stringSplit.length;
        var counterErrorIndex;
        var locations = new Array(size);

        
            var counter, innercount, tempSplit;
            for (counter = 0, counterErrorIndex = 0; counter < size; counter++) {
                locations[counter] = new Array(4);

                tempSplit = stringSplit[counter].split(',');
                if (tempSplit.length == 5) {
                    //Show Error Post
                    locations[counter][0] = tempSplit[1];
                    locations[counter][1] = tempSplit[2];
                    locations[counter][2] = tempSplit[3];
                    locations[counter][3] = tempSplit[4];
                    ErrorIndex[counterErrorIndex] = counter;
                    counterErrorIndex++;
                }
                else {
                    locations[counter][0] = tempSplit[0];
                    locations[counter][1] = tempSplit[1];
                    locations[counter][2] = tempSplit[2];
                    locations[counter][3] = tempSplit[3];
                }
            }

            var map = new google.maps.Map(document.getElementById('map'), {
                zoom: 18,
                center: new google.maps.LatLng(10.29700, 123.89693),
                mapTypeId: google.maps.MapTypeId.ROADMAP
            });

            var infowindow = new google.maps.InfoWindow();

            var marker, i, flag, x;
            flag = false;
            for (i = 0; i < locations.length; i++) {
                for (x = 0; x < ErrorIndex.length; x++) {
                    if (ErrorIndex[x] == i) {
                        flag = true;
                        break;
                    }
                }
                if (flag) {
                    marker = new google.maps.Marker({
                        position: new google.maps.LatLng(locations[i][1], locations[i][2]),
                        icon: Post_marker,
                        map: map,
                        title: "Sample Test"
                    });
                    flag = false;
                }
                else if (!flag) {
                    marker = new google.maps.Marker({
                        position: new google.maps.LatLng(locations[i][1], locations[i][2]),
                        icon: frame_marker,
                        map: map,
                        title: "Sample Test"
                    });
                }

                google.maps.event.addListener(marker, 'click', (function (marker, i) {
                    return function () {
                        infowindow.setContent(locations[i][0]);
                        infowindow.open(map, marker);
                    }
                })(marker, i));
            }
        }
      
  </script>
</body>

</asp:Content>
