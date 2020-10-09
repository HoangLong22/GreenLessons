var common = {
    init: function () {
        common.registerEvent();
    },
    registerEvent: function () {
        $("#txtquery").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/Lesson/ListName",
                    dataType: "json",
                    data: {
                        q: request.term
                    },
                    success: function (res) {
                        response(res.data);
                    }
                });
            },
            focus: function (event, ui) {
                $("#txtquery").val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                $("#txtquery").val(ui.item.label);
                return false;
            }
        })
            .autocomplete("instance")._renderItem = function (ul, item) {
                return $("<li>")
                    .append("<a>" + item.label + "</a>")
                    .appendTo(ul);
            };
    }
}
common.init();