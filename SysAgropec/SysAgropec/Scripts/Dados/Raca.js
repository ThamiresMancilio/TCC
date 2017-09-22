var ConfirmaExclusao = function (id, raca) {


    $("#idRaca").val(id);
    document.getElementById('msg').innerHTML = "Deseja realmente excluir a raça " + raca + " ? ";
    $("#myModal").modal('show');

}

var DeleteRaca = function () {

    var idRaca = $("#idRaca").val();

    $.ajax({

        type: "POST",
        url: "Delete",
        data: { idRaca: idRaca },
        success: function (result) {

            $("#myModal").modal('hide');
            $("#myModal2").modal('show');
            $("#row_" + idRaca).remove();

        }
    })

}

var Alterar = function (id) {

    var url = "Edit?ID=" + id;

    $("#myModalBodyRaca").load(url, function () {

        $("#myModalEditRaca").modal("show");


    })

}