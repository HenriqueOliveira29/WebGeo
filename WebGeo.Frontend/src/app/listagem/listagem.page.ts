import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule} from '@ionic/angular';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { EncomendasService } from './encomendas.service';
import { Encomenda } from '../modules/encomenda.model';

@Component({
  selector: 'app-listagem',
  templateUrl: './listagem.page.html',
  styleUrls: ['./listagem.page.scss'],
  standalone: true,
  imports: [IonicModule, CommonModule, FormsModule]
})
export class ListagemPage implements OnInit {

  encomendas:Encomenda[] = [];
  constructor(private activateRoute: ActivatedRoute,
    private httpClient: HttpClient,
    private encomendasService: EncomendasService
  ) { }

  ngOnInit() {
    this.activateRoute.paramMap.subscribe(() => this.Refresh())
  }

  Refresh(){
    this.encomendasService.getEncomendas().subscribe(resultado => {
      this.encomendas = resultado;
      
    })
  }

}
