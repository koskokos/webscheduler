function addUserProperty() {
    var counter = 0;
    while ($("#additionalUserData #additionalUserData" + counter).length != 0) counter++;
    $("#additionalUserData").append("<div id=\"additionalUserData" + counter + "\">" +
                                    "<div id=\"userdata-name" + counter + "\" class=\"userdata-name\">" +
                                        "<input class=\"text-box single-line\" id=\"UserProperties_" + counter + "__Name\" name=\"UserProperties[" + counter + "].Name\" type=\"text\" value=\"\">" +
                                        "<span class=\"field-validation-valid\" data-valmsg-for=\"UserProperties[" + counter + "].Name\" data-valmsg-replace=\"true\"></span>" +
                                    "</div>" +
                                    "<div id=\"userdata-value" + counter + "\" class=\"userdata-value\">" +
                                        "<input class=\"text-box single-line\" id=\"UserProperties_" + counter + "__Value\" name=\"UserProperties[" + counter + "].Value\" type=\"text\" value=\"\">" +
                                        "<span class=\"field-validation-valid\" data-valmsg-for=\"UserProperties[" + counter + "].Value\" data-valmsg-replace=\"true\"></span>" +
                                    "</div>" +
                                    "<div id=\"delete-userdata" + counter + "\" class=\"delete-userdata\">" +
                                        "<a href=\"javascript:deleteUserProperty(" + counter + ")\">DeleteUserProperty</a>" +
                                    "</div>" +
                                    "</div>");
    normalizeProperties();
}
function deleteUserProperty(target) {
    $("#additionalUserData" + target).remove();
    normalizeProperties();
}
function normalizeProperties() {
    var images = $("#additionalUserData ").children();
    var counter = images.length;
    for (var i = 0; i < images.length; i++) {
        $(images[i]).attr("id", "additionalUserData" + i);
        $(images[i]).children("[id^=UserProperties][id$=UserId]").attr("name", "UserProperties[" + i + "].UserId");
        $(images[i]).children("[id^=UserProperties][id$=UserId]").attr("id", "UserProperties_" + i + "__UserId");
        $(images[i]).children("[id^=UserProperties][id$=_Id]").attr("name", "UserProperties[" + i + "].Id");
        $(images[i]).children("[id^=UserProperties][id$=_Id]").attr("id", "UserProperties_" + i + "__Id");
        var obj = $(images[i]).children("[id^=userdata-name]");
        obj.attr("id", "userdata-name" + i);
        obj.children(".field-validation-valid").attr("data-valmsg-for", "UserProperties[" + i + "].Name");
        var obj1 = obj.children("[id^=UserProperties_]");
        obj1.attr("id", "UserProperties_" + i + "__Name");
        obj1.attr("name", "UserProperties[" + i + "].Name");
        obj = $(images[i]).children("[id^=userdata-value]");
        obj.attr("id", "userdata-value" + i);
        obj.children(".field-validation-valid").attr("data-valmsg-for", "UserProperties[" + i + "].Value");
        obj1 = obj.children("[id^=UserProperties_]");
        obj1.attr("id", "UserProperties_" + i + "__Value");
        obj1.attr("name", "UserProperties[" + i + "].Value");
        $(images[i]).children(".delete-userdata").children("a").attr("href", "javascript:deleteUserProperty(" + i + ")");
        $(images[i]).children(".delete-userdata").attr("id", "delete-userdata" + i);
    }
}