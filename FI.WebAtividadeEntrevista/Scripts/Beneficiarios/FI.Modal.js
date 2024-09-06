let beneficiarios = null;

let beneficiarioAtual = null;

document.addEventListener('DOMContentLoaded', function () {
    //loadBeneficiarios();

    document.getElementById('addBeneficiarioBtn').addEventListener('click', function () {
        const cpf = document.getElementById('BeneficiarioCPF').value;
        const nome = document.getElementById('BeneficiarioNome').value;

        if (cpf && nome) {
            if (beneficiarioAtual) {
                // Alterar beneficiário existente
                beneficiarioAtual.cpf = cpf;
                beneficiarioAtual.nome = nome;
                beneficiarioAtual = null;
            } else {
                // Adicionar novo beneficiário
                const novoBeneficiario = {
                    id: beneficiarios.length + 1, // Gerar ID simples para o exemplo
                    cpf: cpf,
                    nome: nome
                };
                beneficiarios.push(novoBeneficiario);
            }

            document.getElementById('BeneficiarioCPF').value = '';
            document.getElementById('BeneficiarioNome').value = '';

            loadBeneficiarios();
        } else {
            alert('Preencha todos os campos.');
        }
    });
});

function loadBeneficiarios() {
    const beneficiariosList = document.getElementById('beneficiariosList');
    beneficiariosList.innerHTML = '';

    // fazer depois esse load
    //fetch('/Beneficiario/ObterBeneficiarios')


    beneficiarios.forEach(beneficiario => {
        const row = document.createElement('div');
        row.className = 'row mb-3';
        row.innerHTML = `
            <div class="col-md-4">
                <div class="form-group">
                    <label>${beneficiario.cpf}</label>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label>${beneficiario.nome}</label>
                </div>
            </div>
            <div class="col-md-4 d-flex align-items-center">
                <button type="button" class="btn btn-sm btn-primary mr-1" onclick="prepararAlteracao(${beneficiario.id})">Alterar</button>
                <button type="button" class="btn btn-sm btn-danger" onclick="excluirBeneficiario(${beneficiario.id})">Excluir</button>
            </div>
        `;
        beneficiariosList.appendChild(row);
    });
}

function prepararAlteracao(id) {
    beneficiarioAtual = beneficiarios.find(b => b.id === id);

    if (beneficiarioAtual) {
        document.getElementById('BeneficiarioCPF').value = beneficiarioAtual.cpf;
        document.getElementById('BeneficiarioNome').value = beneficiarioAtual.nome;
    }
}

function excluirBeneficiario(id) {
    beneficiarios = beneficiarios.filter(b => b.id !== id);
    loadBeneficiarios();
}
