export class EncomendaList{
    id: number;
    date: Date;
    dateString: string;
    localityName : string;
    numberOfProducts : number;
    shopId : number;

    constructor(id: number, idLoja: number, dataCriacao: Date, localityName: string, numberProducts: number, shopId: number, dateString: string)
    {
        this.id = id;
        this.shopId = idLoja,
        this.date = dataCriacao;
        this.localityName = localityName;
        this.numberOfProducts = numberProducts;
        this.shopId = shopId;
        this.dateString = dateString;
    }
}