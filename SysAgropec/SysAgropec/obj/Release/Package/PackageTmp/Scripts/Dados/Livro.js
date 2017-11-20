var ConfirmaExclusao = function (id,livro) {


    $("#idLivro").val(id);
    document.getElementById('msg').innerHTML = "Deseja realmente excluir o livro " + livro + " ? ";
    $("#myModal").modal('show');

}

var DeleteLivro = function () {

    var idLivro = $("#idLivro").val();

    $.ajax({

        type: "POST",
        url: "Delete",
        data: { idLivro: idLivro },
        success: function (result) {

            $("#myModal").modal('hide');
            $("#myModal2").modal('show');
            $("#row_" + idLivro).remove();
            
        }
    })

}

var Alterar = function (id) {

    var url = "Edit?ID=" + id;

    $("#myModalBodyLivro").load(url, function () {

        $("#myModalEditLivro").modal("show");


    })

}