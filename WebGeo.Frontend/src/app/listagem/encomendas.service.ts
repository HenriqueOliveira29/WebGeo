import { Injectable } from '@angular/core';
import { Encomenda } from '../modules/encomenda.model';
import { HttpClient } from '@angular/common/http';
import { MessagingHelper } from '../modules/messagingHelper.model';
import { Observable, catchError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EncomendasService {

  private endPoint = 'http://localhost:80';

  constructor(private httpClient: HttpClient) {}

  getEncomendas() : Observable<Encomenda[]> {
    return this.httpClient.get<Encomenda[]>(`${this.endPoint}/Order`)
  
  }


}
