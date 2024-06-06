import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule} from '@ionic/angular';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { EncomendasService } from './encomendas.service';
import { EncomendaList } from '../modules/encomendaList.model';

@Component({
  selector: 'app-listagem',
  templateUrl: './listagem.page.html',
  styleUrls: ['./listagem.page.scss'],
  standalone: true,
  imports: [IonicModule, CommonModule, FormsModule, RouterModule]
})
export class ListagemPage implements OnInit {

  encomendas:EncomendaList[] = [];
  constructor(private activateRoute: ActivatedRoute,
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
