export class ProductList{
    id: number;
    name: string;
    description: string;
    quantity: number;

    /**
     *
     */
    constructor(id: number, name: string, desc: string, quant: number) {
        this.id = id;
        this.description = desc;
        this.name = name;
        this.quantity = quant
        
    }
}