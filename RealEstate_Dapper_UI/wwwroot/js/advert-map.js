$(document).ready(function () {
    var map = L.map('map').setView([39.9334, 32.8597], 6);
    var marker;
    var currentPolygon;

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; OpenStreetMap contributors'
    }).addTo(map);

    function updateMarker(lat, lng) {
        if (marker) {
            marker.setLatLng([lat, lng]);
        } else {
            marker = L.marker([lat, lng], { draggable: true }).addTo(map);

            marker.on('dragend', function (e) {
                var coord = e.target.getLatLng();
                // Noktayı virgüle çeviriyoruz
                $('#lat').val(coord.lat.toString().replace(".", ","));
                $('#lng').val(coord.lng.toString().replace(".", ","));
            });
        }

        $('#lat').val(lat.toString().replace(".", ","));
        $('#lng').val(lng.toString().replace(".", ","));
    }

    map.on('click', function (e) {
        updateMarker(e.latlng.lat, e.latlng.lng);
    });

    function searchLocation() {
        var city = $('#CityId option:selected').val() ? $('#CityId option:selected').text() : '';
        var district = $('#DistrictId option:selected').val() ? $('#DistrictId option:selected').text() : '';
        var neighborhood = $('#NeighborhoodId option:selected').val() ? $('#NeighborhoodId option:selected').text() : '';

        var addressParts = [];

        if (neighborhood) {
            neighborhood = neighborhood.trim();

            neighborhood = neighborhood.replace(/(\s)MAH\.?$/i, '');

            if (neighborhood.toLowerCase().indexOf("mahallesi") === -1) {
                neighborhood += " Mahallesi";
            }


            addressParts.push(neighborhood);
        }

        if (district) addressParts.push(district);
        if (city) addressParts.push(city);

        if (addressParts.length === 0) return;

        var query = addressParts.join(', ') + ', Turkey';

        console.log("Aranan Konum (Düzeltilmiş):", query);

        var url = 'https://nominatim.openstreetmap.org/search?format=json&polygon_geojson=1&q=' + encodeURIComponent(query);

        fetch(url)
            .then(res => res.json())
            .then(data => {
                if (data && data.length > 0) {
                    var result = data.find(x => x.class === "boundary") || data[0];
                    var lat = result.lat;
                    var lon = result.lon;

                    updateMarker(lat, lon);

                    if (currentPolygon) map.removeLayer(currentPolygon);

                    if (result.geojson && (result.geojson.type === "Polygon" || result.geojson.type === "MultiPolygon")) {
                        currentPolygon = L.geoJSON(result.geojson, {
                            style: { color: "red", weight: 2, fillColor: "red", fillOpacity: 0.1 }
                        }).addTo(map);

                        if (neighborhood || district) {
                            map.fitBounds(currentPolygon.getBounds());
                        } else {
                            map.setView([lat, lon], 8);
                        }
                    } else {
                        var zoomLevel = neighborhood ? 16 : (district ? 12 : 8);
                        map.setView([lat, lon], zoomLevel);
                    }
                } else {
                    console.log("Konum bulunamadı. Sorgu:", query);
                }
            })
            .catch(err => console.error("Hata:", err));
    }

    $.getJSON("/Location/GetCities", function (data) {
        $.each(data, function (index, item) {
            $("#CityId").append($('<option>', { value: item.cityID, text: item.cityName }));
        });
    });

    $('#CityId').change(function () {
        var selectedId = $(this).val();
        $('#DistrictId').empty().append('<option value="">İlçe Seçiniz</option>');
        $('#SemtId').empty().append('<option value="">Semt Seçiniz</option>');
        $('#NeighborhoodId').empty().append('<option value="">Mahalle Seçiniz</option>');

        if (selectedId) {
            $.getJSON("/Location/GetDistricts", { id: selectedId }, function (data) {
                $.each(data, function (index, item) {
                    $("#DistrictId").append($('<option>', { value: item.districtID, text: item.districtName }));
                });
            });
            searchLocation();
        }
    });

    $('#DistrictId').change(function () {
        var selectedId = $(this).val();
        $('#SemtId').empty().append('<option value="">Semt Seçiniz</option>');
        $('#NeighborhoodId').empty().append('<option value="">Mahalle Seçiniz</option>');

        if (selectedId) {
            $.getJSON("/Location/GetSemts", { id: selectedId }, function (data) {
                $.each(data, function (index, item) {
                    $("#SemtId").append($('<option>', { value: item.semtID, text: item.semtName }));
                });
            });
            searchLocation();
        }
    });

    $('#SemtId').change(function () {
        var selectedId = $(this).val();
        $('#NeighborhoodId').empty().append('<option value="">Mahalle Seçiniz</option>');
        if (selectedId) {
            $.getJSON("/Location/GetNeighborhoods", { id: selectedId }, function (data) {
                $.each(data, function (index, item) {
                    $("#NeighborhoodId").append($('<option>', { value: item.neighborhoodID, text: item.neighborhoodName }));
                });
            });
        }
    });

    $('#NeighborhoodId').change(function () {
        searchLocation();
    });
});
