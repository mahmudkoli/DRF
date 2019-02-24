

function AutoCompleteName(selector, url, method) {
    method = method === null ? "GET" : method;
    $(selector).autocomplete({
        source: function (request, response) {
            $.ajax({
                url: url,
                type: method,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: { term: $(selector).val() },
                beforeSend: function () {
                    $(selector).css("background", "#FFF");
                },
                success: function (data) {
                    response($.map(data, function (value, index) {

                            return {
                                //for showing label and value
                                label: value,
                                value: value,

                                //for passing value to ui after select
                                Name: value,
                                Flag: 'All'

                            };
                        })
                    );
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $.alert(textStatus + "! please try again", '<i class="fa fa-exclamation-circle" aria-hidden="true"> Alert</i>');
                }
            });
        },
        minLength: 2,
        select: function (event, ui) {
            if (ui.item.Flag === 'All') {
                $(selector).val(ui.item.Name);
            }
        }
    });
}