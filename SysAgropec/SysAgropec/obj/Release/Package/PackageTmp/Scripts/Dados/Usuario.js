var ConfirmaExclusao = function (id, usuario) {


    $("#idUsuario").val(id);
    document.getElementById('msg').innerHTML = "Deseja realmente excluir o usuário " + usuario + " ? ";
    $("#myModal").modal('show');

}

var DeleteUsuario = function () {

    var idUsuario = $("#idUsuario").val();

    $.ajax({

        type: "POST",
        url: "Delete",
        data: { idUsuario: idUsuario },
        success: function (result) {

            $("#myModal").modal('hide');
            $("#myModal2").modal('show');
            $("#row_" + idUsuario).remove();

        }
    })

}

var AlterarFazendasParticipantes = function (id) {

    var url = "Edit?ID=" + id;

    $("#myModalBodyUsuario").load(url, function () {

        $("#myModalEditUsuario").modal("show");


    })

}