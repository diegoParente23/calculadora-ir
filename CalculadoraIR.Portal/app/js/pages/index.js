class IndexView extends ViewBase {
    onLoad() {
        var header = new HeaderView("#header-component");
        var footer = new FooterView("#footer-component");
        header.update("");
        footer.update("");
    }
    template(modelo) {
        return `
        <div class="container">
            <h1 class="title">Calculadora</h1>
            <h1 class="subtitle">Imposto de Renda</h1>
        </div>`;
    }
}
var c = new IndexView("#content-component");
c.update("");
