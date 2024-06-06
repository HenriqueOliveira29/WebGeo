import { Injectable } from '@angular/core';
import { EncomendaList } from '../modules/encomendaList.model';
import { HttpClient, HttpHeaders, HttpParams, HttpParamsOptions  } from '@angular/common/http';
import { MessagingHelper } from '../modules/messagingHelper.model';
import { Observable, catchError } from 'rxjs';
import { RoutesList } from '../modules/routesList.module';
import { encomendaDetail } from '../modules/encomendaDetail.model';
import { OrderMapaComponent } from '../order-mapa/order-mapa.component';

@Injectable({
  providedIn: 'root'
})
export class EncomendasService {

  async getEncomenda(orderId: string | null) : Promise<Observable<MessagingHelper<encomendaDetail>>> {
    var headerssend = new HttpHeaders();
    headerssend.append("Accept", 'application/json');
    headerssend.append('Content-Type', 'application/json' );

    var cords = await OrderMapaComponent.getUserLocation();
    let postdata = {
      "estafetaX" : cords.lat,
      "estafetaY" : cords.lng,
      "orderId" : orderId
    }

    return await this.httpClient.post<MessagingHelper<encomendaDetail>>(`${this.endPoint}/Order/GetOrderByIdAndCords`, postdata, { headers: headerssend })
  }

  async entregarEncomendaToShop(orderId: number) : Promise<Observable<MessagingHelper<null>>>{

    var headerssend = new HttpHeaders();
    headerssend.append("Accept", 'application/json');
    headerssend.append('Content-Type', 'application/json' );
    return await this.httpClient.put<MessagingHelper<null>>(`${this.endPoint}/Order/DeliverRestockToShop/${orderId}`, {}, { headers: headerssend });
  }

  private endPoint = 'https://localhost:7169';

  constructor(private httpClient: HttpClient) {}

  getEncomendas() : Observable<EncomendaList[]> {
    return this.httpClient.get<EncomendaList[]>(`${this.endPoint}/Order`)
  }


}
