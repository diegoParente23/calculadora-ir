class HeaderView extends ViewBase {
    onLoad() {
    }
    template(modelo) {
        return `
        <nav class="navbar" role="navigation" aria-label="main navigation">
            <div class="container">
                <div class="navbar-brand">
                    <a class="navbar-item bd-navbar-item-videos " href="./contribuinte-cadastro.html">
                        <span>Cadastrar Contribuinte</span>
                    </a>

                    <a class="navbar-item bd-navbar-item-blog " href="./calculo-ir.html">
                        <span>Calcular IR</span>
                    </a>
                </div>
            </div>
        </nav>`;
    }
}
