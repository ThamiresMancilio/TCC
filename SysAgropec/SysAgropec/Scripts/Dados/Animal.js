var ConfirmaExclusao = function (id, animal) {


    $("#idAnimal").val(id);
    document.getElementById('msg').innerHTML = "Deseja realmente excluir o animal " + animal + " ? O animal não poderá ser utilizado no sistema, porém não exclui dados vinculados ao mesmo";
    $("#myModal").modal('show');

}

var DeleteAnimal = function () {

    var idAnimal = $("#idAnimal").val();

    $.ajax({

        type: "POST",
        url: "Delete",
        data: { idAnimal: idAnimal },
        success: function (result) {

            $("#myModal").modal('hide');
            $("#myModal2").modal('show');
            $("#row_" + idAnimal).remove();

        }
    })

}

var Alterar = function (id) {

    var url = "Edit?ID=" + id;

    $("#myModalBodyAnimal").load(url, function () {

        $("#myModalEditAnimal").modal("show");


    })

}

