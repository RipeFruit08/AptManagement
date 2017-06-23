$(document).ready(function () {
    console.log("ready sir!");
    $('#delAptBtn').click(foo)
});

function foo(e) {
    e.preventDefault()
    var url = $(this).attr("href")
    var AptID = $(this).attr("data-aptid")
    console.log(url)
    console.log(AptID)
}