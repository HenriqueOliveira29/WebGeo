import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'listagem',
    pathMatch: 'full',
  },
  {
    path: 'listagem',
    loadComponent: () => import('./listagem/listagem.page').then( m => m.ListagemPage)
  },
  {
    path: 'listagem/:orderId',
    loadComponent: () => import('./listagem/order-detail/order-detail.page').then( m => m.OrderDetailPage)
  },
];
