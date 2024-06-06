import { ProductList } from "./productList.module";
import { RoutesList } from "./routesList.module";

export class encomendaDetail{
    id: number = 0;
    products : ProductList[] = [];
    date: Date = new Date;
    dateString: string = "";
    routes: RoutesList[] = [];
    shopId: number = 0;
    shopName: string = "";
    storageId: number = 0;
    storageName: string = "";

}