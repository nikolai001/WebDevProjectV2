
/*ÅBNER OG LUKKER FILTER*/
function OpenCloseFilter() {
    var filter = document.getElementById("Filter");

    if (filter.style.display == "none") {
        filter.style.display = "flex";
    }

    else {
        filter.style.display = "none";
    }
}

/*TOGGLE IMELLEM LEDIGE TURE OG MINE TURE*/
function MyTrip() {
    document.getElementById("TripItem1").style.height = "46px";
    document.getElementById("TripItem1").style.lineHeight = "46px";
    document.getElementById("line").style.backgroundColor = "#005140";
    document.getElementById("TripItem2").style.height = "42px";
    document.getElementById("TripItem2").style.lineHeight = "42px";
}

function AvaTrip() {
    document.getElementById("TripItem2").style.height = "46px"
    document.getElementById("TripItem2").style.lineHeight = "46px";
    document.getElementById("line").style.backgroundColor = "#00904A";
    document.getElementById("TripItem1").style.height = "42px";
    document.getElementById("TripItem1").style.lineHeight = "42px";
}

/*VISER INFORMATIONER OM TUREN*/
function ShowInfo() {
    var Info = document.getElementById("Info");
    var Date = document.getElementById("Date");
    var Country = document.getElementById("Country");

    if (Info.style.display == "none" || Date.style.borderRadius == "0.25em 0 0 0.25em" || Country.style.borderRadius == "0 0 0.25em 0") {
        Info.style.display = "grid";
        Date.style.borderRadius = "0.25em 0 0 0";
        Country.style.borderRadius = "0";
    }

    else {
        Info.style.display = "none";
        Date.style.borderRadius = "0.25em 0 0 0.25em";
        Country.style.borderRadius = "0 0 0.25em 0";
    }

}