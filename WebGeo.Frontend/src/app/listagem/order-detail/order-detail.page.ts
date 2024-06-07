import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule} from '@ionic/angular';
import { IonContent, IonHeader, IonTitle, IonToolbar } from '@ionic/angular/standalone';
import { ActivatedRoute, Route, Router, RouterModule } from '@angular/router';
import { EncomendasService } from '../encomendas.service';
import { MapaModule } from 'src/app/mapa/mapa.module';
import { RoutesList } from 'src/app/modules/routesList.module';
import { OrderMapaComponent } from 'src/app/order-mapa/order-mapa.component';
import { encomendaDetail } from 'src/app/modules/encomendaDetail.model';
import { MessagingHelper } from 'src/app/modules/messagingHelper.model';
import { setAlternateWeakRefImpl } from '@angular/core/primitives/signals';

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.page.html',
  styleUrls: ['./order-detail.page.scss'],
  standalone: true,
  providers: [OrderMapaComponent],
  imports: [IonicModule, CommonModule, FormsModule, RouterModule, MapaModule]
})
export class OrderDetailPage implements OnInit {
 
  public encomenda: encomendaDetail | null = null;
  public cordX: number = 0;
  public cordY: number = 0;
  public orderId: string | null = "";

  constructor(
    private activeRoutes: ActivatedRoute,
    private orderService : EncomendasService,
    private orderMapaComponent: OrderMapaComponent,
    private router: Router
  ) { }

  ngOnInit() {
    this.activeRoutes.paramMap.subscribe(
      async paramMap => {
        if(paramMap.has("orderId"))
        {
          this.orderId = paramMap.get("orderId");
          var response = await this.orderService.getEncomenda(this.orderId, this.cordX, this.cordY);
          response.subscribe(result => {
            console.log(result)
            if(result.success == false)
            {
              alert(result.message);
            }
            else{
              this.encomenda = result.obj;
              this.orderMapaComponent.addRoutes(this.encomenda.routes);
            }
          });
        }
      }
    )
  }

  public async calcularRotaComNovasCords() : Promise<void>{
    var response = await this.orderService.getEncomenda(this.orderId, this.cordX, this.cordY);
          response.subscribe(result => {
            console.log(result)
            if(result.success == false)
            {
              alert(result.message);
            }
            else{
              this.encomenda = result.obj;
              this.orderMapaComponent.addRoutes(this.encomenda.routes);
            }
          });
  }

  public async entregarEncomenda() : Promise<void> {
    console.log("ola tudo bem")
    var response = await this.orderService.entregarEncomendaToShop(this.encomenda != null ? this.encomenda.id : 0);
          response.subscribe(result => {
            console.log(result)
            if(result.success == false)
            {
              alert(result.message);
            }
            else{
              this.router.navigate(['/listagem']);
            }
          });
  }
}
