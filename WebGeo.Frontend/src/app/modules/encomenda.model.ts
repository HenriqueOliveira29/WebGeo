export class Encomenda{
    Id: number;
    shopId: number;
    date: Date;
    produtos: string[];

    constructor(id: number, idLoja: number, dataCriacao: Date)
    {
        this.Id = id;
        this.shopId = idLoja,
        this.date = dataCriacao;
        this.produtos = [];
    }
}