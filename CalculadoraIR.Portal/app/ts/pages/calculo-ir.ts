class CalculoIRView extends ViewBase<string> {
    private urlBase: string = "http://localhost:5135/contribuinte/api/v1/";

    onLoad() {
        var header = new HeaderView("#header-component");
        var footer = new FooterView("#footer-component");

        header.update("");
        footer.update("");
    }

    btnPesquisar() {
        var contribuinteService = new ContribuinteService();
        var linhas: string = "";
        var validou: boolean = true;
        var inputElement = <HTMLInputElement>document.querySelector("#txtSalarioMinimo");

        if (inputElement.value == "") {
            validou = false;
            alert("O campo salário minimo deve ser preenchido");
        }

        try {
            if (validou) {
                $.ajax({
                    type: "GET",
                    dataType: "json",
                    url: this.urlBase + "calcular-imposto/" + inputElement.value,
                    success: function (data) {
                        var contribuintes = (data as ImpostoDeRenda[]);

                        contribuintes.forEach((imposto: ImpostoDeRenda) => {
                            linhas += `<td>${imposto.contribuinte.nome}</td>`;
                            linhas += `<td>${imposto.contribuinte.cpf}</td>`;
                            linhas += `<td>${imposto.contribuinte.nome}</td>`;
                            linhas += `<td>${imposto.contribuinte.nome}</td>`;
                            linhas += `<td>${imposto.contribuinte.nome}</td>`;
                        });

                        var html: string = `
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
                });
            }
        }
        catch (e) {
            alert(e);
        }
    }

    template(modelo: string): string {
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