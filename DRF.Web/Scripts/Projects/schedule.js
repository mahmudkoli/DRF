

$(document).ready(function () {

    $('#addScheduleRow').on('click', function() {
        var row = $(this).closest('tr').clone();
        row.find('td:last').html('<a href="#" class="text-danger removeScheduleRow"><i class="fa fa-lg fa-remove"></i></a>');
        $('#scheduleTable').append(row);

        $('.timepicker').timepicker();
        nameSerialization('#scheduleTable');
    });

    $(document).on('click', '.removeScheduleRow', function () {
        $(this).closest('tr').remove();

        nameSerialization('#scheduleTable');
    });

    function nameSerialization(identifier) {
        var count = 0;
        $(identifier + ' tbody tr').each(function () {
            var suffix = $(this).find('input:first').attr('name').match(/\d+/);
            $(this).find('input,select').each(function () {
                // Replaced Name
                var oldName = $(this).attr('name');
                var newName = oldName.replace('[' + suffix + ']', '[' + count + ']');
                $(this).attr('name', newName);
            });
            count++;
        });
    }

});