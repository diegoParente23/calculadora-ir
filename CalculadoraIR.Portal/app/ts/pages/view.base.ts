abstract class ViewBase<T> {
    protected _element: Element;

    constructor(selector: string) {
        this._element = document.querySelector(selector);
    }

    onLoadCore(): any {
        window.onload = this.onLoad();
    }

    abstract onLoad(): any;

    update(modelo: T) {
        this._element.innerHTML = this.template(modelo);
        this.onLoadCore();
    }

    abstract template(modelo: T) : string;
}