class CalculoIRView extends ViewBase {
    onLoad() {
        var header = new HeaderView("#header-component");
        var footer = new FooterView("#footer-component");
        header.update("");
        footer.update("");
    }
    btnPesquisar() {
        var linhas = "";
        var validou = true;
        var inputElement = document.querySelector("#txtSalarioMinimo");
        if (inputElement.value == "") {
            validou = false;
            alert("O campo salário minimo deve ser preenchido");
        }
        try {
            if (validou) {
                $.ajax({
                    type: "GET",
                    dataType: "json",
                    crossDomain: true,
                    url: Environment.UrlBaseApi + "calcular-imposto/" + inputElement.value,
                    success: function (data) {
                        var resultado = JSON.parse(data);
                        resultado.ContribuintesImpostoDeRenda.forEach((imposto) => {
                            linhas += `<tr><td>${imposto.Contribuinte.Nome}</td>`;
                            linhas += `<td>${imposto.Contribuinte.Cpf.Number}</td>`;
                            linhas += `<td>${imposto.Contribuinte.RendaBrutaMensal}</td>`;
                            linhas += `<td>${imposto.Contribuinte.NumeroDeDependentes}</td>`;
                            linhas += `<td>${imposto.Imposto}</td></tr>`;
                        });
                        var html = `
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>Nome</th>
                                    <th>CPF</th>
                                    <th>Renda Bruta</th>
                                    <th>Qtde de Dependentes</th>
                                    <th>Imposto de Renda</th>
                                </tr>
                            </thead>
                            <tbody>
                                ${linhas}
                            </tbody>
                        </table>`;
                        $("#resultado-component").replaceWith(html);
                    },
                    error: function (error) {
                        alert("Houve uma falha no cadastro do contribuinte");
                    }
                });
            }
        }
        catch (e) {
            alert(e);
        }
    }
    template(modelo) {
        return `
        <div class="container">
            <div class="field">
                <label class="label">Salário Minímo:</label>
                <div class="control">
                    <input id="txtSalarioMinimo" class="input" type="text" placeholder="Salário Minímo">
                </div>
            </div>
            <div class="field is-grouped">
                <div class="control">
                    <button id="btnPesquisar" class="button is-link">Pesquisar</button>
                </div>
            </div>
            <div id="resultado-component"></div>
        </div>
        `;
    }
}
var calculo = new CalculoIRView("#content-component");
calculo.update("");
document.querySelector("#btnPesquisar").addEventListener('click', calculo.btnPesquisar.bind(calculo));
