class ViewBase {
    constructor(selector) {
        this._element = document.querySelector(selector);
    }
    onLoadCore() {
        window.onload = this.onLoad();
    }
    update(modelo) {
        this._element.innerHTML = this.template(modelo);
        this.onLoadCore();
    }
}
