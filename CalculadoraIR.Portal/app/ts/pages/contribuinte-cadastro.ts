class ContribuinteCadastroView extends ViewBase<string> {
    onLoad() {
        var header = new HeaderView("#header-component");
        var footer = new FooterView("#footer-component");

        header.update("");
        footer.update("");
    }

    btnCadastrar(event: Event) {
        var validou: boolean = true;
        var contribuinte: Contribuinte = new Contribuinte();
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
                $.ajax({
                    type: "POST",
                    dataType: "json",
                    url: Environment.UrlBaseApi + "/add-contribuinte",
                    data: contribuinte,
                    success: function (data) {
                        alert("Contribuinte cadastrado com sucesso!");
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
        <form class="form">
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
        </form>
        `;
    }
}

var content = new ContribuinteCadastroView("#content-component");
content.update("");

document.querySelector(".form").addEventListener('submit', content.btnCadastrar.bind(content));