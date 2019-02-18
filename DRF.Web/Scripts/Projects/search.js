


$('#areaSearch').on('keyup', function () {
    var selector = '#areaSearch';
    var url = '/AutoComplete/GetAllAreaName';
    var method = 'GET';
    AutoCompleteName(selector, url, method);
});

$('#specialtySearch').on('keyup', function () {
    var selector = '#specialtySearch';
    var url = '/AutoComplete/GetAllSpecialtyName';
    var method = 'GET';
    AutoCompleteName(selector, url, method);
});

$('#doctorNameSearch').on('keyup', function () {
    var selector = '#doctorNameSearch';
    var url = '/AutoComplete/GetAllDoctorName';
    var method = 'GET';
    AutoCompleteName(selector, url, method);
});