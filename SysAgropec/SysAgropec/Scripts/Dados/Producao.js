
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

var ConfirmaExclusao = function (id, animal) {


    $("#idProducao").val(id);
    document.getElementById('msg').innerHTML = "Deseja realmente excluir a produção para o animal " + animal + " ? ";
    $("#myModal").modal('show');

}

var DeleteProducao = function () {

    var idProducao = $("#idProducao").val();

    $.ajax({

        type: "POST",
        url: "Delete",
        data: { idProducao: idProducao },
        success: function (result) {

            $("#myModal").modal('hide');
            $("#myModal2").modal('show');
            $("#row_" + idProducao).remove();

        }
    })

}