var ConfirmaExclusao = function (id, lote) {


    $("#idLote").val(id);
    document.getElementById('msg').innerHTML = "Deseja realmente excluir o lote nº " + lote + " ? ";
    $("#myModal").modal('show');

}

var DeleteLote = function () {

    var idLote = $("#idLote").val();

    $.ajax({

        type: "POST",
        url: "Delete",
        data: { idLote: idLote },
        success: function (result) {

            $("#myModal").modal('hide');
            $("#myModal2").modal('show');
            $("#row_" + idLote).remove();

        }
    })

}

var Alterar = function (id) {

    var url = "Edit?ID=" + id;

    $("#myModalBodyLote").load(url, function () {

        $("#myModalEditLote").modal("show");


    })

}