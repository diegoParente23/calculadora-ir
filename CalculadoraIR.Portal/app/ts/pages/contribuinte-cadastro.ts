class ContribuinteCadastroView extends ViewBase<string> {
    onLoad() {
        var header = new HeaderView("#header-component");
        var footer = new FooterView("#footer-component");

        header.update("");
        footer.update("");
    }

    btnCadastrar(event: Event) {
        var validou: boolean = true;
        var contribuinte: CadastrarContribuinteInput = new CadastrarContribuinteInput();
        var txtNome = <HTMLInputElement>document.querySelector("#txtNome");
        var txtCpf = <HTMLInputElement>document.querySelector("#txtCpf");
        var txtNumDeps = <HTMLInputElement>document.querySelector("#txtNumDeps");
        var txtRendaBruta = <HTMLInputElement>document.querySelector("#txtRendaBruta");

        if(txtNome.value == "") {
            validou = false;
            alert("O campo nome é obrigatório");
        }
        else if(txtCpf.value == "") {
            validou = false;
            alert("O campo cpf é obrigatório");
        }
        else if(txtNumDeps.value == "") {
            validou = false;
            alert("O campo número de dependentes é obrigatório");
        }
        else if(txtRendaBruta.value == "") {
            validou = false;
            alert("O campo renda bruta é obrigatório");
        }

        try {
            if (validou) {
                contribuinte.Nome = txtNome.value;
                contribuinte.Cpf = txtCpf.value;
                contribuinte.RendaBrutaMensal = parseFloat(txtRendaBruta.value);
                contribuinte.NumeroDeDependentes = parseInt(txtNumDeps.value);

                $.ajax({
                    type: "POST",
                    dataType: "json",
                    crossDomain: true,
                    url: Environment.UrlBaseApi + "add-contribuinte",
                    data: contribuinte,
                    success: function (data) {
                        alert("Contribuinte cadastrado com sucesso!");
                    },
                    error: function(error) {
                        alert("Houve uma falha no cadastro do contribuinte");
                    }
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
                <label class="label">Nome:</label>
                <div class="control">
                    <input id="txtNome" class="input" type="text" placeholder="Nome">
                </div>
            </div>
            <div class="field">
                <label class="label">CPF:</label>
                <div class="control">
                    <input id="txtCpf" class="input" type="text" placeholder="CPF">
                </div>
            </div>
            <div class="field">
                <label class="label">Núm dependentes:</label>
                <div class="control">
                    <input id="txtNumDeps" class="input" type="text" placeholder="Número de dependentes">
                </div>
            </div>
            <div class="field">
                <label class="label">Renda bruta mensal:</label>
                <div class="control">
                    <input id="txtRendaBruta" class="input" type="text" placeholder="Renda bruta mensal">
                </div>
            </div>
            <div class="field is-grouped">
                <div class="control">
                    <button id="btnCadastrar" class="button is-link">Cadastrar</button>
                </div>
            </div>
        </div>
        `;
    }
}

var content = new ContribuinteCadastroView("#content-component");
content.update("");

document.querySelector("#btnCadastrar").addEventListener('click', content.btnCadastrar.bind(content));