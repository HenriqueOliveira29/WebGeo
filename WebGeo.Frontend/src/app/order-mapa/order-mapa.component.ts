import { AfterViewInit, Component } from '@angular/core';
import * as L from 'leaflet';
import 'leaflet-routing-machine';
import { RoutesList } from '../modules/routesList.module';
import { Geolocation } from '@capacitor/geolocation';

@Component({
  selector: 'app-order-mapa',
  templateUrl: './order-mapa.component.html',
  styleUrls: ['./order-mapa.component.scss'],
})
export class OrderMapaComponent implements AfterViewInit {
  private static map: L.Map;
  private routingControl: L.Routing.Control | null = null;
  routes: RoutesList[] = [];

  constructor() {}

  ngAfterViewInit() {
    this.initMapDefaultLeaflet();
    OrderMapaComponent.invalidateSize();
  }

  public static async getUserLocation(): Promise<L.LatLng> {
    const position = await Geolocation.getCurrentPosition();
    const { latitude, longitude } = position.coords;
    return L.latLng(latitude, longitude);
  }

  public async initMapDefaultLeaflet(): Promise<void> {
    const userLocation = await OrderMapaComponent.getUserLocation();

    OrderMapaComponent.map = L.map('map').setView(userLocation, 13);

    const tiles = L.tileLayer(
      'https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png',
      {
        maxZoom: 19,
        minZoom: 3,
        attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>',
      }
    );
    tiles.addTo(OrderMapaComponent.map);

    // Initial routing control if routes are already set
    if (this.routes.length > 0) {
      this.addRoutingControl();
    }
  }

  public addRoutes(routes: RoutesList[]): void {
    this.routes = routes;
    console.log(this.routes)
    this.reloadMap();
  }

  private reloadMap(): void {
    // Remove existing routing control if it exists
    if (this.routingControl) {
      OrderMapaComponent.map.removeControl(this.routingControl);
    }

    // Add new routes if there are any
    if (this.routes.length > 0) {
      this.addRoutingControl();
    }

    // Ensure the map's size is invalidated to correctly display the new route
    OrderMapaComponent.invalidateSize();
  }

  private addRoutingControl(): void {
    this.routingControl = L.Routing.control({
      waypoints: this.routes.map((element) => L.latLng(element.cordY, element.cordX)),
      fitSelectedRoutes: true,
      routeWhileDragging: true,
    }).addTo(OrderMapaComponent.map);
  }

  static invalidateSize(): void {
    setTimeout(() => {
      if (OrderMapaComponent.map) {
        OrderMapaComponent.map.invalidateSize();
      }
    }, 500);
  }
}
