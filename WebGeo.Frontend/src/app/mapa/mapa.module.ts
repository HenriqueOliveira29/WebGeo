import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderMapaComponent } from '../order-mapa/order-mapa.component';



@NgModule({
  declarations: [MapaModule.mapa],
  imports: [
    CommonModule
  ],
  exports: [MapaModule.mapa]
})
export class MapaModule {
  static mapa = OrderMapaComponent;
 }
