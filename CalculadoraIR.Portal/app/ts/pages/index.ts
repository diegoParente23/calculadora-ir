class IndexView extends ViewBase<string> {
    
    onLoad() {
        var header = new HeaderView("#header-component");
        var footer = new FooterView("#footer-component");

        header.update("");
        footer.update("");
    }
   
    template(modelo: string): string {
        return `
        <div class="container">
            <h1 class="title">Calculadora</h1>
            <h1 class="subtitle">Imposto de Renda</h1>
        </div>`;
    }
}

var c: IndexView = new IndexView("#content-component");
c.update("");