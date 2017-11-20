$(document).ready(function () {
    $('#Quantidade').mask('000.000.000.000.000,00');
});

function carregaAnimais() {
    
    $("#myModalEditLivro").modal("show");
    
}
function fechaJanela() {

    var radios = document.getElementsByName("optionsRadios");
    
    for (i = 0; i < radios.length; i++) {
        if (radios[i].checked) {

            var id = radios[i].value;
            var animal = document.getElementById(id).innerText;

            document.getElementById("Animail_ID").value = id;
            document.getElementById("nomeAnimal").value = animal;

            $("#myModalEditLivro").modal("hide");
        }
    }

}

