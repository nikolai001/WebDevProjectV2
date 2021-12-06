const Scenarios = {

}

let Button = document.querySelector(".ModalTrigger");
Button.addEventListener('click', function (e) {
    var targetId = e.target.getAttribute('id');
    if (targetId == "Help") {
        var Modal = document.querySelector("#Modal");
        Modal.querySelector("#ModalTitle").innerHTML = Scenarios[0]
        Modal.querySelector("#ModalContent").innerHTML = Scenarios[0]
        Modal.style.Display = "grid"
        //Modal.classList.add('Display');
    }
});