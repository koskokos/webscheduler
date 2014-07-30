function setLangCookie(lang) {
    $.cookie("lang", lang, {Path: "/*"});
    location.reload();
}
window.onload = function () {
    switch ($.cookie("lang")) {
        case "en":
            $('#en-lang').css("border", "solid 2px #f39d21")
            $('#en-lang').css("border-radius", "3px")
            break;
        case "uk":
            $('#ua-lang').css("border", "solid 2px #f39d21")
            $('#ua-lang').css("border-radius", "3px")
            break;
        case "ru":
            $('#ru-lang').css("border", "solid 2px #f39d21")
            $('#ru-lang').css("border-radius", "3px")
            break;

        default:
            break;
    }
}

//window.onload() = function () {
//    document.getElementById("do").onclick = function () {
//        for (var i = 0; i < length; i++) {
//            document.getElementById("images").appendChild("<img src=\"\" alt =\"\"  />");
//        }
//    }
//}

