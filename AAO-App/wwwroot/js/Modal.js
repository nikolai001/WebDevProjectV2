let Buttons = document.querySelectorAll(".ModalTrigger");

const Scenarios = [
    { Name: "Help", Title: "Få hjælp til login", Content: "Ring til telefon nr. <br> +45 12 13 14 15" },
    { Name: "Location", Title: "Lokation", Content: "Præference for Alex Andersen afdeling" },
    { Name: "Address", Title: "Adresse", Content: "Byen du bor i" },
];

function AddListeners(x) {
    x.addEventListener("click", function (e) {
        var targetId = e.target.getAttribute('id');
        var Modal = document.querySelector("#Modal");

        let index = Scenarios.findIndex(x => x.Name === targetId);

        Modal.querySelector("#ModalTitle").innerHTML = Scenarios[index].Title
        Modal.querySelector("#ModalContent").innerHTML = Scenarios[index].Content
        Modal.classList.add('Display');
    });
};

Buttons.forEach(AddListeners);

function closeHelp() {
    var Modal = document.querySelector("#Modal");

    Modal.classList.remove('Display');
}








