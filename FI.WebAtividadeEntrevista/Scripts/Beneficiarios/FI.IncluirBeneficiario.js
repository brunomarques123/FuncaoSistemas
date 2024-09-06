$(document).ready(function () {
    $('#addBeneficiarioBtn').click(function () {
        var cpf = $('#BeneficiarioCPF').val();
        var nome = $('#BeneficiarioNome').val();
        var clienteId = $('clienteIdHidden').val();

        console.log('clienteIdHidden: ' + clienteId);

        // Verifica se os campos não estão vazios
        if (cpf && nome) {
            $.ajax({
                url: '/Cliente/Incluir', // Ajuste para o seu endpoint
                type: 'POST',
                data: {
                    CPF: cpf,
                    Nome: nome
                },
                success: function (response) {
                    if (response.Result === 'OK') {
                        alert('Beneficiário incluído com sucesso');
                        // Adicione o beneficiário à lista se necessário
                        $('#beneficiariosList').append('<div>' + nome + ' (' + cpf + ')</div>');
                        // Limpe os campos do modal
                        $('#BeneficiarioCPF').val('');
                        $('#BeneficiarioNome').val('');
                    } else {
                        alert('Erro: ' + response.Message);
                    }
                },
                error: function () {
                    alert('Ocorreu um erro ao incluir o beneficiário.');
                }
            });
        } else {
            alert('Por favor, preencha todos os campos.');
        }
    });
});
