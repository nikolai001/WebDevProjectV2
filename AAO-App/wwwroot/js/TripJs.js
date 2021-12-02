
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

/*document.getElementById("TripContainer").addEventListener('click', (e) => {
    console.log(e.target.id);
});
*/


var Info = document.getElementsByClassName("MoreInfo")[0];
for (var i = 0; i < Info.length; i++) {
    Info[i].id = "Info" + (i + 1);
}

var Date = document.getElementsByClassName("Date")[0];
for (var i = 0; i < Date.length; i++) {
    Date[i].id = "Date" + (i + 1);
}

var Country = document.getElementsByClassName("Country")[0];
for (var i = 0; i < Country.length; i++) {
    Country[i].id = "Country" + (i + 1);
}

var Holder = document.getElementsByClassName("TripsHolder")[0];
for (var i = 0; i < Holder.length; i++) {
    Holder[i].id = "TripHolder" + (i + 1);
}


Holder.addEventListener('click', ShowInfo);
function ShowInfo() {
    /*var Info = document.getElementById("Info")[1];
    var Date = document.getElementById("Date")[1];
    var Country = document.getElementById("Country")[1];*/
    //for (var i = 0; i < Info.length; i++) {


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