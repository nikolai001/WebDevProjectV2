
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

/*ÅBNER OG LUKKER INFORMATIONER OM TUREN*/
var n = document.getElementsByClassName('TripsHolder');
for (let e = 0; e < n.length; e++) {
    n[e].addEventListener('click', function () {

        var Info = document.getElementsByClassName("MoreInfo")[e];
        var Date = document.getElementsByClassName("Date")[e];
        var Country = document.getElementsByClassName("Country")[e];

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

    });
}

/*SÅ FILTERET TIL AT VIRKE*/
function CheckboxValues(name) {
    const checkboxes = document.querySelectorAll(`input[name="${name}"]:checked`);
    const CountryCheckboxes = document.querySelectorAll(`input[name="${name}"]:checked`);
    let values = [];
    let CountryValues = [];

    checkboxes.forEach((checkbox) => {
        values.push(checkbox.value);
    });

    CountryCheckboxes.forEach((CountryCheckbox) => {
        CountryValues.push(CountryCheckbox.value);
    });

    return [values, CountryValues];
}

var Start = document.getElementsByClassName('StartPoint');
var Box = document.getElementsByClassName('TripsHolder');
var Ctype = document.getElementsByClassName('CType');

document.querySelectorAll(".btn").forEach(btn => {  
    btn.addEventListener('click', event => {
        console.log(CheckboxValues('check')[0]);
        console.log(CheckboxValues('CountryTypeCheck')[1]);

        for (let i = 0; i < Box.length; i++) {

            if ( //Du har valgt en by ogd u har ikke valgt national eller international
                (CheckboxValues('check')[0].includes(Start[i].innerHTML.split(":").pop()) && 
                (CheckboxValues('CountryTypeCheck')[1].length == 0)) ||                       
                //Du har valgt en by og du har valgt national
                (CheckboxValues('check')[0].includes(Start[i].innerHTML.split(":").pop()) &&       
                (CheckboxValues('CountryTypeCheck')[1].includes("National") && Ctype[i].innerHTML == "1 - 1")) || 
                //Du har valgt en by og du har valgt international
                (CheckboxValues('check')[0].includes(Start[i].innerHTML.split(":").pop()) && 
                (CheckboxValues('CountryTypeCheck')[1].includes("International") && Ctype[i].innerHTML != "1 - 1")) ||
                //Du har ikke valgt en by og du har valgt national
                (CheckboxValues('check')[0].length == 0 &&                                         
                (CheckboxValues('CountryTypeCheck')[1].includes("National") && Ctype[i].innerHTML == "1 - 1")) || 
                //Du har ikke valgt en by og du har valgt international
                (CheckboxValues('check')[0].length == 0 && 
                (CheckboxValues('CountryTypeCheck')[1].includes("International") && Ctype[i].innerHTML != "1 - 1")) ||
                //Du har ikke valgt noget
                (CheckboxValues('check')[0].length == 0 && (CheckboxValues('CountryTypeCheck')[1].length == 0)) 
            ) {
                Box[i].style.display = "grid";
            }
            else {
                Box[i].style.display = "none";
            }
            
         }
    })
});



