
var Alterar = function (id) {

    var url = "Edit?ID=" + id;

    $("#myModalBodyFazenda").load(url, function () {

        $("#myModalEditFazenda").modal("show");


    })

}


$(document).ready(function () {

    function limpa_formulário_cep() {
        // Limpa valores do formulário de cep.
        $("#Logradouro").val("");
        $("#Bairro").val("");
        $("#Cidade").val("");
        $("#Estado").val("");
        
    }

    //Quando o campo cep perde o foco.
    $("#Cep").blur(function () {

        //Nova variável "cep" somente com dígitos.
        var cep = $(this).val().replace(/\D/g, '');

        //Verifica se campo cep possui valor informado.
        if (cep != "") {

            //Expressão regular para validar o CEP.
            var validacep = /^[0-9]{8}$/;

            //Valida o formato do CEP.
            if (validacep.test(cep)) {

                //Preenche os campos com "..." enquanto consulta webservice.
                $("#Logradouro").val("...");
                $("#Bairro").val("...");
                $("#Cidade").val("...");
                $("#Estado").val("...");

                //Consulta o webservice viacep.com.br/
                $.getJSON("//viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                    if (!("erro" in dados)) {
                        //Atualiza os campos com os valores da consulta.
                        $("#Logradouro").val(dados.logradouro);
                        $("#Bairro").val(dados.bairro);
                        $("#Cidade").val(dados.localidade);
                        $("#Estado").val(dados.uf);
                        
                    } //end if.
                    else {
                        //CEP pesquisado não foi encontrado.
                        limpa_formulário_cep();
                        alert("CEP não encontrado.");
                    }
                });
            } //end if.
            else {
                //cep é inválido.
                limpa_formulário_cep();
                alert("Formato de CEP inválido.");
            }
        } //end if.
        else {
            //cep sem valor, limpa formulário.
            limpa_formulário_cep();
        }
    });
});

//$(".file").fileinput({
//    uploadUrl:"UploadImage",
//    showUpload: false,
//    showCaption: false,
//    fileType: "any",
//    previewFileIcon: "<i class='glyphicon glyphicon-king'></i>",
//    overwriteInitial: false


//}).on("filebatchselected", function (event, files) {

//    $(".file").fileinput("upload");

//});



//$(".file").fileinput({
//    showUpload: false,
//    showCaption: false,
//    browseClass: "btn btn-primary btn-lg",
//    previewFileIcon: "<i class='glyphicon glyphicon-king'></i>",
//    maxFilesNum: 1,
//    "fileActionSettings": { "showDrag": false },
//    overwriteInitial: false,
//    allowedFileExtensions: ['jpg', 'png', 'gif']
//    /*initialPreviewAsData: true,
//    initialPreview: [
//        "http://lorempixel.com/1920/1080/transport/1",
//    ],
//    initialPreviewConfig: [
//        {caption: "transport-1.jpg", size: 329892, width: "120px", url: "{$url}", key: 1},
//    ],*/
//});