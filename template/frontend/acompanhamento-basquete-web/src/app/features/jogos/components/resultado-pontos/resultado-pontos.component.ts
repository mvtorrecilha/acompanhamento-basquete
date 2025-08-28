import { Component, inject, OnInit, signal } from '@angular/core';
import { JogoService } from '../../services/jogo.service';
import { toSignal } from '@angular/core/rxjs-interop';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-resultado-pontos',
  imports: [CommonModule],
  templateUrl: './resultado-pontos.component.html',
  styleUrls: ['./resultado-pontos.component.scss'],
  providers: [JogoService]
})
export class ResultadoPontosComponent implements OnInit {

  private _jogoService = inject(JogoService);

  resultados = toSignal(this._jogoService.obterResultados(), { initialValue: null });

  ngOnInit() {}

}
