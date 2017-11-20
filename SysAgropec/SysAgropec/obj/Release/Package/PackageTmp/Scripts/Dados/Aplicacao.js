function carregaAnimais() {

    $("#myModalAnimal").modal("show");

}
function fechaJanelaAnimal() {

    var radios = document.getElementsByName("optionsRadiosA");

    for (i = 0; i < radios.length; i++) {
        if (radios[i].checked) {

            var id = radios[i].value;
            var animal = document.getElementById(id).innerText;

            document.getElementById("Animal_ID").value = id;
            document.getElementById("nomeAnimal").value = animal;

            $("#myModalAnimal").modal("hide");
        }
    }

}

function carregaMedicamentos() {

    $("#myModalMedicamento").modal("show");

}
function fechaJanelaMedicamentos() {

    var radios = document.getElementsByName("optionsRadiosM");

    for (i = 0; i < radios.length; i++) {
        if (radios[i].checked) {

            var id = radios[i].value;
            var medicamento = document.getElementById(id).innerText;

            document.getElementById("Medicamento_ID").value = id;
            document.getElementById("nomeMedicamento").value = medicamento;

            $("#myModalMedicamento").modal("hide");
        }
    }

}

