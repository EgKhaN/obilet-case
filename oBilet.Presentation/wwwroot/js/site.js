
let today = moment().format("YYYY-MM-DDTHH:mm");
let tomorrow = moment().add(1, 'days').format("YYYY-MM-DDTHH:mm");

$(document).ready(function () {
    setDefaultPageValuesAndSetting();

    preventDuplicateSelectionsForLocations();

    bindPageChangesToCookie();
});

function setDefaultPageValuesAndSetting() {
    $("#departureDate").attr("min", today);

    $("#departureDate").val(tomorrow);

    if (localStorage.getItem("origin"))
        $('#origin').val(localStorage.getItem("origin")).trigger('change')

    if (localStorage.getItem("destination"))
        $('#destination').val(localStorage.getItem("destination")).trigger('change')

    if (localStorage.getItem("departureDate"))
        $('#departureDate').val(localStorage.getItem("departureDate"));
}

function preventDuplicateSelectionsForLocations() {
    //to not able select same values for Origin and location disabling same option in the other dropdown
    $('select').on('change', function () {
        /* enable any previously disabled options */
        $('option[disabled]').prop('disabled', false);

        /* loop over each select */
        $('select').each(function () {

            /* for every other select, disable option which matches this this.value */
            let otherDropdown = $('select').not(this);
            otherDropdown.find('option[value="' + this.value + '"]').prop('disabled', true);

            //if selected valu
            if (otherDropdown.find(":selected").val() === this.value) {
                console.log("değerler eşit")
                otherDropdown.find(':selected').next().attr('selected', 'selected');
            }
        });

    });
    $("#origin").trigger('change');
}

function bindPageChangesToCookie() {
    $('#departureDate').on("change", function () {
        localStorage.setItem("departureDate", this.value);
    });

    $('#origin').on("change", function () {
        localStorage.setItem("origin", this.value);
    });
    $('#destination').on("change", function () {
        localStorage.setItem("destination", this.value);
    });
}

function setToToday() {
    $("#departureDate").val(today);
    localStorage.setItem("departureDate", today);
}
function setToTomorrow() {
    $("#departureDate").val(tomorrow);
    localStorage.setItem("departureDate", tomorrow);
}
function swapLocation() {

    selectedOrigin = $("#origin").val();
    selectedDestination = $("#destination").val();
    $('#destination').val(selectedOrigin).trigger('change')
    $('#origin').val(selectedDestination).trigger('change')
}

