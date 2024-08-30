$(document).ready(function () {
    // Código para inicializar o modal e formulário de inclusão de beneficiários
    $('#addBeneficiarioBtn').click(function () {
        let cpf = $('#BeneficiarioCPF').val();
        let nome = $('#BeneficiarioNome').val();

        if (cpf && nome) {
            $.ajax({
                url: urlBeneficiarioPost,
                method: "POST",
                data: {
                    "CPF": cpf,
                    "Nome": nome,
                    "IdCliente": idCliente // Supondo que o ID do cliente está disponível em uma variável
                },
                error: function (r) {
                    if (r.status == 400)
                        ModalDialog("Ocorreu um erro", r.responseJSON);
                    else if (r.status == 500)
                        ModalDialog("Ocorreu um erro", "Ocorreu um erro interno no servidor.");
                },
                success: function (r) {
                    ModalDialog("Sucesso!", r);
                    $('#beneficiariosList').append(
                        '<div class="row mb-3">' +
                        '    <div class="col-md-4">' +
                        '        <div class="form-group">' +
                        '            <label>' + cpf + '</label>' +
                        '        </div>' +
                        '    </div>' +
                        '    <div class="col-md-4">' +
                        '        <div class="form-group">' +
                        '            <label>' + nome + '</label>' +
                        '        </div>' +
                        '    </div>' +
                        '    <div class="col-md-4 d-flex align-items-center">' +
                        '        <button type="button" class="btn btn-sm btn-primary mr-1">Alterar</button>' +
                        '        <button type="button" class="btn btn-sm btn-primary">Excluir</button>' +
                        '    </div>' +
                        '</div>'
                    );
                    $('#beneficiariosModal').modal('hide');
                }
            });
        } else {
            ModalDialog("Aviso", "Por favor, preencha todos os campos.");
        }
    });
});
