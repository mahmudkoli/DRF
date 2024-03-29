﻿

$(document).ready(function () {

    var startDate = new Date();
    var endDate = new Date(new Date().setMonth(startDate.getMonth() + 1));

    $('#calendar').datepicker({
        todayHighlight: true,
        daysOfWeekDisabled: [5],
        weekStart: 6,
        startDate: startDate,
        endDate: endDate,
        format: "mm-dd-yyyy",
        datesDisabled: ["02/21/2019"]
    });

    var doctorId = $('#doctorId').val();
    var chamberId = $('#chamberId').val();
    getDoctorAvailableDay(doctorId, chamberId);

    $('#chamberId').on('change', function () {
        $('#doctorAvailableTime').empty();
        doctorId = $('#doctorId').val();
        chamberId = $('#chamberId').val();
        getDoctorAvailableDay(doctorId, chamberId);
    });

    $("#calendar").datepicker().on("changeDate", function () {
        
        //$('#calendar').datepicker('setDatesDisabled', ['2019/02/27', '2019/02/28']);
        //$('#calendar').datepicker('setDaysOfWeekDisabled', [1, 2]);
        
        doctorId = $('#doctorId').val();
        chamberId = $('#chamberId').val();
        var selectedDate = $("#calendar").datepicker('getDate');
        //var newDate = (selectedDate.getMonth() + 1) + '/' + selectedDate.getDate() + '/' + selectedDate.getFullYear();
        $('#newAppointmentDate').val(selectedDate.toUTCString());
        getDoctorAvailableTime(doctorId, chamberId, selectedDate.toUTCString());

    });

    function getDoctorAvailableDay(doctorId, chamberId) {
        var url = '/JsonData/GetDoctorAvailableDay';
        var method = 'GET';
        var data = { doctorId: doctorId, chamberId: chamberId };

        $.ajax({
            url: url,
            type: method,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: data,
            success: function (data) {
                var totalDays = [0, 1, 2, 3, 4, 5, 6];
                var avlDays = data.days.map((val) => { return convertToDatePickerDay(val); });
                avlDays = $.unique(avlDays);
                var offDays = $(totalDays).not(avlDays).get();
                $('#calendar').datepicker('setDaysOfWeekDisabled', offDays);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(textStatus + "! please try again", '<i class="fa fa-exclamation-circle" aria-hidden="true"> Alert</i>');
            }
        });
    }


    function getDoctorAvailableTime(doctorId, chamberId, date) {
        var url = '/JsonData/GetDoctorAvailableTime';
        var method = 'GET';
        var data = { doctorId: doctorId, chamberId: chamberId, date: date };

        $.ajax({
            url: url,
            type: method,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: data,
            success: function (data) {
                
                $('#doctorAvailableTime').empty();

                $.each(data.times, function (i, val) {

                    var newDate = new Date(parseInt(val.substr(6)));
                    var timeOptions = { hour: 'numeric', minute: 'numeric', hour12: true };
                    var timeString = newDate.toLocaleString('en-US', timeOptions);
                    
                    var labelOption = '<li>' +
                        '<input type="radio" id="radio_' + i + '" name="NewAppointmentTime" value="' + newDate.toUTCString() + '" >' +
                            '<label for="radio_' + i + '">' + timeString + '</label>' +
                            '</li >';

                    $('#doctorAvailableTime').append(labelOption);
                });
                
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(textStatus + "! please try again", '<i class="fa fa-exclamation-circle" aria-hidden="true"> Alert</i>');
            }
        });
    }
    
    function convertToDatePickerDay(val) {
        //---------Saturday = 1--------------
        //var day = 0;
        //if (val == 1) {
        //    day = val + 5;
        //}else if (val >= 2 && val <= 7) {
        //    day = val - 2;
        //}
        return (val + 5) % 7;
    }

});