
function appointmentChartDataShow (data) {
    // -----------------------
    // - MONTHLY SALES CHART -
    // -----------------------


    // -----------Get Appointment Data Data

    var pendingData = data.filter(x => x.AppointmentStatus === 'Requested')[0];
    var approvedData = data.filter(x => x.AppointmentStatus === 'Approved')[0];
    var rejectedData = data.filter(x => x.AppointmentStatus === 'Rejected')[0];
    var completedData = data.filter(x => x.AppointmentStatus === 'Completed')[0];

    // Get context with jQuery - using jQuery's .get() method.
    var appointmentChartCanvas = $('#appointmentChart').get(0).getContext('2d');
    // This will get the first returned node in the jQuery collection.
    var appointmentChart = new Chart(appointmentChartCanvas);

    var appointmentChartData = {
        labels: ['January', 'February', 'March', 'April', 'May', 'June',
            'July', 'August', 'September', 'Octobor', 'November', 'December'],
        datasets: [
            {
                label: 'Pending',
                fillColor: 'rgba(0,192,239,0.1)',
                strokeColor: '#00C0EF',
                pointColor: '#00C0EF',
                pointStrokeColor: '#00C0EF',
                pointHighlightFill: '#00C0EF',
                pointHighlightStroke: '#00C0EF',
                data: [pendingData.Jan, pendingData.Feb, pendingData.Mar, pendingData.Apr, pendingData.May, pendingData.Jun,
                    pendingData.Jul, pendingData.Aug, pendingData.Sep, pendingData.Oct, pendingData.Nov, pendingData.Dec]
            },
            {
                label: 'Approved',
                fillColor: 'rgba(0,166,90,0.2)',
                strokeColor: '#00A65A',
                pointColor: '#00A65A',
                pointStrokeColor: '#00A65A',
                pointHighlightFill: '#00A65A',
                pointHighlightStroke: '#00A65A',
                data: [approvedData.Jan, approvedData.Feb, approvedData.Mar, approvedData.Apr, approvedData.May, approvedData.Jun,
                    approvedData.Jul, approvedData.Aug, approvedData.Sep, approvedData.Oct, approvedData.Nov, approvedData.Dec]
            },
            {
                label: 'Rejected',
                fillColor: 'rgba(221,75,57,0.2)',
                strokeColor: '#DD4B39',
                pointColor: '#DD4B39',
                pointStrokeColor: '#DD4B39',
                pointHighlightFill: '#DD4B39',
                pointHighlightStroke: '#DD4B39',
                data: [rejectedData.Jan, rejectedData.Feb, rejectedData.Mar, rejectedData.Apr, rejectedData.May, rejectedData.Jun,
                    rejectedData.Jul, rejectedData.Aug, rejectedData.Sep, rejectedData.Oct, rejectedData.Nov, rejectedData.Dec]
            },
            {
                label: 'Completed',
                fillColor: 'rgba(243,156,18,0.1)',
                strokeColor: '#F39C12',
                pointColor: '#F39C12',
                pointStrokeColor: '#F39C12',
                pointHighlightFill: '#F39C12',
                pointHighlightStroke: '#F39C12',
                data: [completedData.Jan, completedData.Feb, completedData.Mar, completedData.Apr, completedData.May, completedData.Jun,
                    completedData.Jul, completedData.Aug, completedData.Sep, completedData.Oct, completedData.Nov, completedData.Dec]
            }
        ]
    };

    var appointmentChartOptions = {
        // Boolean - If we should show the scale at all
        showScale: true,
        // Boolean - Whether grid lines are shown across the chart
        scaleShowGridLines: false,
        // String - Colour of the grid lines
        scaleGridLineColor: 'rgba(0,0,0,.05)',
        // Number - Width of the grid lines
        scaleGridLineWidth: 1,
        // Boolean - Whether to show horizontal lines (except X axis)
        scaleShowHorizontalLines: true,
        // Boolean - Whether to show vertical lines (except Y axis)
        scaleShowVerticalLines: true,
        // Boolean - Whether the line is curved between points
        bezierCurve: true,
        // Number - Tension of the bezier curve between points
        bezierCurveTension: 0.3,
        // Boolean - Whether to show a dot for each point
        pointDot: false,
        // Number - Radius of each point dot in pixels
        pointDotRadius: 4,
        // Number - Pixel width of point dot stroke
        pointDotStrokeWidth: 1,
        // Number - amount extra to add to the radius to cater for hit detection outside the drawn point
        pointHitDetectionRadius: 20,
        // Boolean - Whether to show a stroke for datasets
        datasetStroke: true,
        // Number - Pixel width of dataset stroke
        datasetStrokeWidth: 2,
        // Boolean - Whether to fill the dataset with a color
        datasetFill: true,
        // String - A legend template
        legendTemplate: '<ul class=\'<%=name.toLowerCase()%>-legend\'><% for (var i=0; i<datasets.length; i++){%><li><span style=\'background-color:<%=datasets[i].lineColor%>\'></span><%=datasets[i].label%></li><%}%></ul>',
        // Boolean - whether to maintain the starting aspect ratio or not when responsive, if set to false, will take up entire container
        maintainAspectRatio: true,
        // Boolean - whether to make the chart responsive to window resizing
        responsive: true,

        // Custom-----------
        scaleOverride: true,
        scaleSteps: 5,
        scaleStepWidth: 2,
        scaleStartValue: 0
    };

    // Create the line chart
    appointmentChart.Line(appointmentChartData, appointmentChartOptions);

    // ---------------------------
    // - END MONTHLY SALES CHART -
    // ---------------------------
}



function appointmentChartData(url, method, paramData) {
    method = method === null ? "GET" : method;

    $.ajax({
        url: url,
        type: method,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: paramData,
        success: function (data) {
            appointmentChartDataShow(data);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.alert(textStatus + "! please try again", '<i class="fa fa-exclamation-circle" aria-hidden="true"> Alert</i>');
        }
    });

}