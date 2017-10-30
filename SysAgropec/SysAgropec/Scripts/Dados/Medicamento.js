var ConfirmaExclusao = function (id, medicamento) {


    $("#idMedicamento").val(id);
    document.getElementById('msg').innerHTML = "Deseja realmente excluir o medicamento " + medicamento + " ? ";
    $("#myModal").modal('show');

}

var DeleteMedicamento = function () {

    var idMedicamento = $("#idMedicamento").val();

    $.ajax({

        type: "POST",
        url: "Delete",
        data: { idMedicamento: idMedicamento },
        success: function (result) {

            $("#myModal").modal('hide');
            $("#myModal2").modal('show');
            $("#row_" + idMedicamento).remove();

        }
    })

}

var Alterar = function (id) {

    var url = "Edit?ID=" + id;

    $("#myModalBodyMedicamento").load(url, function () {

        $("#myModalEditMedicamento").modal("show");


    })

}

function AddToEstoque(id, medicamento) {

    document.getElementById('medicamentoDescri').innerHTML = medicamento + " ...";
    document.getElementById('Medicamento_ID').value = id;
    $("#modalAddEstoque").modal('show');

    
}