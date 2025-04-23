if (localStorage.getItem("color"))
    $("#color").attr("href", "assets/css/" + localStorage.getItem("color") + ".css");
if (localStorage.getItem("dark"))
    $("body").attr("class", "dark-only");
$('<div class="customizer-links"><button class="rtl-btn" hidden>RTL</button></div>').appendTo($('body'));
(function () {})();
//live customizer js
$(document).ready(function () {
    var storedMode = localStorage.getItem("rtlMode");
    if (storedMode) {
        applyMode(storedMode);
    }
    function applyMode(mode) {

        if (mode === "rtl") {
            $('.rtl-btn').addClass('rtl').text('LTR');
            $('body').addClass('rtl');
            $("html").attr("dir", "rtl");
        } else {
            $('.rtl-btn').removeClass('rtl').text('RTL');
            $('body').removeClass('rtl');
            $("html").attr("dir", "");
        }
    }

    // Check if RTL mode was previously selected and apply it
  
    $('.rtl-btn').on('click', function () {
        $("html").attr("dir", "");
        $(this).toggleClass('rtl');
        if ($('.rtl-btn').hasClass('rtl')) {
            localStorage.removeItem("rtlMode");
            localStorage.setItem("rtlMode", "rtl");
            $('.rtl-btn').text('LTR');
            $('body').addClass('rtl');
            $("html").attr("dir", "rtl");
        } else {
            $('.rtl-btn').text('RTL');
            localStorage.removeItem("rtlMode");
            localStorage.setItem("rtlMode", "ltr");
            $('body').removeClass('rtl');
            $("html").attr("dir", "");
        }
    });

    return false;
});